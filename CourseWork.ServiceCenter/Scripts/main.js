$(document).ready(function () {

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
            url: "/api/customers",
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