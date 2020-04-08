$(document).ready(function () {

    var serviceTypesTable = $('#service-types').DataTable({
        ajax: {
            url: "/api/serviceTypes",
            dataSrc: ""
        },
        columns: [
            {
                data: "name",
                render: function (data, type, service) {
                    return "<a href='/serviceTypes/edit/" + service.id + "'>" + service.name + "</a>";
                }
            },
            {
                data: "price"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/serviceTypes/edit/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
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
                        brandsTable.row(button.parents("tr")).remove().draw();
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
                data: "title",
                render: function (data, type, brand) {
                    return "<a href='/brands/edit/" + brand.id + "'>" + brand.title + "</a>";
                }
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/brands/edit/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
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
                data: "name",
                render: function (data, type, employee) {
                    return "<a href='/employees/edit/" + employee.id + "'>" + employee.name + "</a>";
                }
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
                    var btns = "<div class='actions-btn'><a href='/employee/edit/" + data + "' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
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
                data: "name",
                render: function (data, type, customer) {
                    return "<a href='/customers/edit/" + customer.id + "'>" + customer.name + "</a>";
                }
            },
            {
                data: "phone"
            },
            {
                data: "id",
                render: function (data) {
                    var btns = "<div class='actions-btn'><a href='/customers/edit/" + data +"' class='btn-link'><i class='fas fa-eye text-primary'></i></a>" +
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