$(document).ready(function () {


    $('#service-start').on('click', function () {

        var fulfillmentId = parseInt($('#fulfillmentId').val());

        $.ajax({
            url: "/api/services/setFulFillmentInProcess",
            data: { 'id': fulfillmentId },
            method: "GET",
            success: function () {
                window.location.reload(false);
            }
        });
    });


    $('#service-end').on('click', function () {

        var fulfillmentId = parseInt($('#fulfillmentId').val());

        $.ajax({
            url: "/api/services/setFulfillmentFinished",
            data: { 'id': fulfillmentId },
            method: "GET",
            success: function () {
                window.location.reload(false);
            }
        });
    });


    /* Parts of service */
    $('#serviceParts').DataTable({
        ajax: {
            url: "/api/services/getParts",
            data: { 'id': parseInt($('#service-id').val()) },
            dataSrc: ""
        },
        columns: [
            {
                data: "model"
            },
            {
                data: "price"
            },
            {
                data: "quantity"
            },
            {
                data: "price",
                render: function (data, type, part) {
                    return part.price * part.quantity;
                }
            }
        ]
    });

    var partsInServiceCenter = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('model'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/partsInServiceCenter/filter?id=2&query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    var partId = 0


    $('#part').typeahead({
        minLength: 2,
        highlight: true
    },
    {
        name: 'part',
        display: 'model',
        source: partsInServiceCenter
    }).on("typeahead:select", function (e, part) {
        partId = part.id;
    });


    $('#addPartToService').on("click", function () {

        var serviceId = parseInt($('#service-id').val());
        var quantityVal = $('#quantity').val();
        var serviceCenterId = parseInt($('#serviceCenter-id').val());

        $.ajax({
            type: "POST",
            url: "/api/orderServices",
            data: { "Quantity": quantityVal, "OrderServiceId": serviceId, "partId": partId, "serviceCenterId": serviceCenterId },
            success: function (response) {
                $("#serviceParts").DataTable().ajax.reload();
            },
            error: function (responce) {
                alert(responce.responseJSON.message);
            }
        });

        partId = 0;
        $('#part').typeahead("val", "");
    });

















    $('#master-services').DataTable({
        ajax: {
            url: "/api/services/getServices",
            data: { 'id': parseInt($('#emp-id').val()) },
            dataSrc: ""
        },
        columns: [
            {
                data: "orderNumber"
            },
            {
                data: "service"
            },
            {
                data: "dateStart",
                render: function (data) {
                    if(data != null)
                        return data.substr(0, 10)
                    return data;
                }
            },
            {
                data: "dateDone",
                render: function (data) {
                    if (data != null)
                        return data.substr(0, 10)
                    return data;
                }
            },
            {
                data: "dateDone",
                render: function (data, type, service) {
                    if (service.dateStart == null) {
                        return "Новий";
                    }
                    if (service.dateDone == null) {
                        return "В процесі";
                    }
                    return "Завершений";
                }
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/orderServices/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a></div>";

                    return btns;
                }
            }
        ]
    });


    $('#order-services').DataTable({
        ajax: {
            url: "/api/OrderServices",
            data: { 'id': $('#orderId').val() },
            dataSrc: ""
        },
        columns: [
            {
                data: "serviceType.name"
            },
            {
                data: "totalServicePrice"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/orderServices/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
                        "<a href='/orderServices/delete/" + data + "' class='btn-link js-delete' data-order-service-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });


    /* Parts in service center */
    $('#partsInServiceCenter').DataTable({
        ajax: {
            url: "/api/PartsInServiceCenter/GetPartsInServiceCenter",
            data: { 'id': $('#centerTargetId').val() },
            dataSrc: ""
        },
        columns: [
            {
                data: "part.partCode"
            },
            {
                data: "part.model",
            },
            {
                data: "part.price"
            },
            {
                data: "quantity"
            }
        ]
    });

    /* Brands in service center */
    $('#brandsInServiceCenter').DataTable({
        ajax: {
            url: "/api/ServiceCenterBrands",
            data: { 'id': $('#centerTargetId').val() },
            dataSrc: ""
        },
        columns: [
            {
                data: "brand.title"
            }
        ]
    });

    /* Service center device types */
    $('#deviceTypesInServiceCenter').DataTable({
        ajax: {
            url: "/api/ServiceCenterDeviceTypes",
            data: { 'id': $('#centerTargetId').val() },
            dataSrc: ""
        },
        columns: [
            {
                data: "deviceType.title"
            }
        ]
    });


    
    /* Table of Parts */
    $('#parts').DataTable({
        ajax: {
            url: "/api/parts",
            dataSrc: ""
        },
        columns: [
            {
                data: "model"
            },
            {
                data: "partCategory.title"
            },
            {
                data: "brand.title"
            },
            {
                data: "price"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/parts/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>";

                    return btns;
                }
            }
        ]
    });


    /* Table of Service Appliance */
    $('#service-appliance').DataTable({
        ajax: {
            url: "/api/serviceAppliances",
            dataSrc: ""
        },
        columns: [
            {
                data: "model"
            },
            {
                data: "brand.title"
            },
            {
                data: "deviceType.title"
            }
        ]
    });


    /* Table of Service Centers */
    $('#service-centers').DataTable({
        ajax: {
            url: "/api/serviceCenters",
            dataSrc: ""
        },
        columns: [
            {
                data: "centerNumber"
            },
            {
                data: "city.title",
            },
            {
                data: "address"
            },
            {
                data: "phone"
            },
            {
                data: "id",
                render: function (data) {
                    return "<div class='actions-btn'><a href='/serviceCenters/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>";
                }
            }
        ]
    });


    /* Table of Orders */
    var ordersTable = $('#orders').DataTable({
        ajax: {
            url: "/api/orders",
            dataSrc: ""
        },
        columns: [
            {
                data: "orderNumber"
            },
            {
                data: "orderDate",
                render: function (data) {
                    return data.substr(0, 10);
                }
            },
            {
                data: "customer.name"
            },
            {
                data: "serviceAppliance.model"
            },
            {
                data: "orderDone",
                render: function (data) {
                    if (data != null)
                        return "Так";
                    else
                        return "Ні";
                }
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/orders/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
                        "<a href='/orders/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/orders/delete/" + data + "' class='btn-link js-delete' data-order-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#orders").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити це замовлення?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/orders/" + button.attr("data-order-id"),
                    method: "DELETE",
                    success: function () {
                        ordersTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });


    /* Table of Service Types */
    $('#service-types').DataTable({
        ajax: {
            url: "/api/serviceTypes",
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "price"
            }
        ]
    });





    /* Table of Device Types */
    $('#device-types').DataTable({
        ajax: {
            url: "/api/deviceTypes",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            }
        ]
    });





    /* Table of Brands */
    $('#brands').DataTable({
        ajax: {
            url: "/api/brands",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            }
        ]
    });

});



(function ($) {
    "use strict";

    // Add active state to sidbar nav links
    var path = window.location.href; // because the 'href' property of the DOM element is the absolute path
    $("#layoutSidenav_nav .sb-sidenav a.nav-link").each(function () {
        if (this.href === path) {
            $(this).addClass("active");
        }
    });

    // Toggle the side navigation
    $("#sidebarToggle").on("click", function (e) {
        e.preventDefault();
        $("body").toggleClass("sb-sidenav-toggled");
    });
})(jQuery);