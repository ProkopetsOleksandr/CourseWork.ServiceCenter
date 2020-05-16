$(document).ready(function () {


    $('#new-services').DataTable({
        ajax: {
            url: "/api/newOrderServices",
            data: { 'id': parseInt($('#service-center-id').val()) },
            dataSrc: ""
        },
        columns: [
            {
                data: "orderNumber"
            },
            {
                data: "name"
            },
            {
                data: "orderFulfillmentId",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/ordersFulfillment/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a></div>";
                    return btns;
                }
            }
        ]
    });








    $('#current-load').DataTable({
        ajax: {
            url: "/api/JobsLoad",
            data: { 'id': parseInt($('#service-center-id').val()) },
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "jobsLoad"
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
    var deviceTypes = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/deviceTypes?query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    var deviceTypeId = 0
    $('#deviceType').typeahead({
        minLength: 2,
        highlight: true
    },
        {
            name: 'deviceTypes',
            display: 'title',
            source: deviceTypes
        }).on("typeahead:select", function (e, deviceType) {
            deviceTypeId = deviceType.id;
        });
    $('#addDeviceTypeToServiceCenter').on("click", function () {

        var centerId = $('#centerTargetId').val();

        $.ajax({
            type: "POST",
            url: "/api/serviceCenterDeviceTypes",
            data: { "serviceCenterId": centerId, "deviceTypeId": deviceTypeId },
            success: function (response) {
                $("#deviceTypesInServiceCenter").DataTable().ajax.reload();
            }
        });

        deviceTypeId = 0;
        $('#deviceType').typeahead("val", "");
    });


    /* Service center brands */
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
    var brands = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('title'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/brands?query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    var brandId = 0
    $('#brand').typeahead({
        minLength: 2,
        highlight: true
    },
        {
            name: 'brands',
            display: 'title',
            source: brands
        }).on("typeahead:select", function (e, brand) {
            brandId = brand.id;
        });
    $('#addBrandToServiceCenter').on("click", function () {

        var centerId = $('#centerTargetId').val();

        $.ajax({
            type: "POST",
            url: "/api/serviceCenterBrands",
            data: { "serviceCenterId": centerId, "brandId": brandId },
            success: function (response) {
                $("#brandsInServiceCenter").DataTable().ajax.reload();
            }
        });

        brandId = 0;
        $('#brand').typeahead("val", "");
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

    var parts = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('model'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/parts?query=%QUERY',
            wildcard: '%QUERY'
        }
    });
    var partId = 0
    $('#part').typeahead({
        minLength: 2,
        highlight: true
    },
        {
        name: 'parts',
        display: 'model',
        source: parts
    }).on("typeahead:select", function (e, part) {
        partId = part.id;
    });
    $('#addPartToServiceCenter').on("click", function () {

        var centerId = $('#centerTargetId').val();
        var quantityVal = $('#quantity').val();

        $.ajax({
            type: "POST",
            url: "/api/partsInServiceCenter",
            data: { "Quantity": quantityVal, "serviceCenterId": centerId, "partId": partId },
            success: function (response) {
                $("#partsInServiceCenter").DataTable().ajax.reload();
            }
        });

        partId = 0;
        $('#part').typeahead("val", "");
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

                        ordersTable.ajax.reload();
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

    
    /* Table of Customers */
    $('#customers').DataTable({
        ajax: {
            url: "/api/customers/getcustomers",
            dataSrc: ""
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "phone"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/customers/edit/" + data +"' class='btn-link'><i class='fas fa-edit text-warning'></i></a>";

                    return btns;
                }
            }
        ]
    });


    /* Table of Employees */
    $('#employees').DataTable({
        ajax: {
            url: "/api/employees",
            dataSrc: "",
            data: {id: $("#centerId").val() }
        },
        columns: [
            {
                data: "name"
            },
            {
                data: "phone"
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


    /* Table of Cities */
    $('#cities').DataTable({
        ajax: {
            url: "/api/cities",
            dataSrc: ""
        },
        columns: [
            {
                data: "title",
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/cities/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>";

                    return btns;
                }
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