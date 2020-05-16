$(document).ready(function () {

    var usersTable = $('#users').DataTable({
        ajax: {
            url: "/api/users",
            dataSrc: ""
        },
        columns: [
            {
                data: "username"
            },
            {
                data: "email"
            },
            {
                data: "role"
            },
            {
                data: "userId",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/account/view/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +

                        "<a href='/account/delete/" + data + "' class='btn-link js-delete' data-user-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#users").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цього користувача?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/users/" + button.attr("data-user-id"),
                    method: "DELETE",
                    success: function () {
                        usersTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
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
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/partInServiceCenter/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a></div>";

                    return btns;
                }
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




    var serviceCentersTable = $('#service-centers').DataTable({
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
                    var btns = "<div class='actions-btn'><a href='/serviceCenters/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
                        "<a href='/serviceCenters/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/serviceCenters/delete/" + data + "' class='btn-link js-delete' data-center-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#service-centers").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цей сервіс центр?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/serviceCenters/" + button.attr("data-center-id"),
                    method: "DELETE",
                    success: function () {
                        serviceCentersTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

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

    var appliancesTable = $('#service-appliance').DataTable({
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
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'>" +
                        "<a href='/serviceAppliances/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/serviceAppliances/delete/" + data + "' class='btn-link js-delete' data-appliance-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#service-appliance").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цю техніку?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/serviceAppliances/" + button.attr("data-appliance-id"),
                    method: "DELETE",
                    success: function () {
                        appliancesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var partsTable = $('#parts').DataTable({
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
                    var btns = "<div class='actions-btn'><a href='/parts/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
                        "<a href='/parts/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/parts/delete/" + data + "' class='btn-link js-delete' data-part-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#parts").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цю запчастину?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/parts/" + button.attr("data-part-id"),
                    method: "DELETE",
                    success: function () {
                        partsTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var partCategoriesTable = $('#part-categories').DataTable({
        ajax: {
            url: "/api/partCategories",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/partCategories/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/partCategories/delete/" + data + "' class='btn-link js-delete' data-category-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#part-categories").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цю категорію?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/partCategories/" + button.attr("data-category-id"),
                    method: "DELETE",
                    success: function () {
                        partCategoriesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var citiesTable = $('#cities').DataTable({
        ajax: {
            url: "/api/cities",
            dataSrc: ""
        },
        columns: [
            {
                data: "title",
                render: function (data, type, city) {
                    return "<a href='/cities/view/" + city.id + "'>" + city.title + "</a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/cities/view/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
                        "<a href='/cities/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/cities/delete/" + data + "' class='btn-link js-delete' data-city-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#cities").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити це місто?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/cities/" + button.attr("data-city-id"),
                    method: "DELETE",
                    success: function () {
                        citiesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var deviceTypesTable = $('#device-types').DataTable({
        ajax: {
            url: "/api/deviceTypes",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/deviceTypes/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/deviceTypes/delete/" + data + "' class='btn-link js-delete' data-deviceType-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#device-types").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цей тип пристроїв?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/deviceTypes/" + button.attr("data-DeviceType-id"),
                    method: "DELETE",
                    success: function () {
                        deviceTypesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var employeePositionsTable = $('#employee-positions').DataTable({
        ajax: {
            url: "/api/employeePositions",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/employeePositions/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/employeePositions/delete/" + data + "' class='btn-link js-delete' data-employeePosition-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#employee-positions").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цю посаду?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/employeePositions/" + button.attr("data-employeePosition-id"),
                    method: "DELETE",
                    success: function () {
                        employeePositionsTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var serviceTypesTable = $('#service-types').DataTable({
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
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/serviceTypes/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/serviceTypes/delete/" + data + "' class='btn-link js-delete' data-serviceType-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#service-types").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цей сервіс?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/serviceTypes/" + button.attr("data-serviceType-id"),
                    method: "DELETE",
                    success: function () {
                        serviceTypesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var brandsTable = $('#brands').DataTable({
        ajax: {
            url: "/api/brands",
            dataSrc: ""
        },
        columns: [
            {
                data: "title"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/brands/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/brands/delete/" + data + "' class='btn-link js-delete' data-brand-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#brands").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цей бренд?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/brands/" + button.attr("data-brand-id"),
                    method: "DELETE",
                    success: function () {
                        brandsTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var employeesTable = $('#employees').DataTable({
        ajax: {
            url: "/api/employees",
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
                data: "address"
            },
            {
                data: "birthday",
                render: function (data) {
                    return data.substr(0, 10);
                }
            },
            {
                data: "employeePosition.title"
            },
            {
                data: "serviceCenter",
                render: function (data) {
                    return "<a href='/service-center/" + data.id + "'>" + data.centerNumber + "</a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/employee/edit/" + data + "' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                        "<a href='/employee/delete/" + data + "' class='btn-link js-delete' data-employee-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#employees").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цього працівника?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/employees/" + button.attr("data-employee-id"),
                    method: "DELETE",
                    success: function () {
                        employeesTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
    });

    var customersTable = $('#customers').DataTable({
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
                    var btns = "<div class='actions-btn'><a href='/customers/edit/" + data +"' class='btn-link'><i class='fas fa-edit text-warning'></i></a>" +
                                                        "<a href='/customer/delete/" + data + "' class='btn-link js-delete' data-customer-id=" + data + "><i class='fas fa-trash-alt text-danger'></i></a></div>";

                    return btns;
                }
            }
        ]
    });
    $("#customers").on("click", ".js-delete", function (event) {
        event.preventDefault();
        var button = $(this);

        bootbox.confirm("Ви дійсно бажаєте видалити цього клієнта?", function (result) {
            if (result) {
                $.ajax({
                    url: "/api/customers/" + button.attr("data-customer-id"),
                    method: "DELETE",
                    success: function () {
                        customersTable.row(button.parents("tr")).remove().draw();
                    }
                });
            }
        });
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