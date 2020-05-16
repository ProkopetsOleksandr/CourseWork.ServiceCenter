$(document).ready(function () {
    $('#name-field').val(".");


    $(".tabs-menu a").click(function (e) {
        e.preventDefault();

        /* Change active tab style */
        $(".tabs-menu .active").removeClass("active");
        $(this).addClass("active");

        /* Change tab content */
        var tab = $(this).attr('href');
        $('.tab').not(tab).css({ 'display': 'none' });
        $(tab).fadeIn(400);

    });


    document.getElementById('customer-toggle').addEventListener("change", (event) => {
        if (event.target.checked) {
            $('#customer-name').fadeIn(300);
            $('#name-field').val("");
        } else {
            $('#customer-name').fadeOut(300);
            $('#name-field').val(".");
        }
    });


    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('phone'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers/getcustomersbyphone?phone=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer-phone').typeahead(
        {
            minLength: 2,
            highlight: true
        },
        {
            name: 'customers',
            display: 'phone',
            source: customers
        }
    );




    $('#next').on('click', function (e) {
        e.preventDefault();

        var phoneField = $('#customer-phone');
        var nameField = $('#name-field');

        if (phoneField.valid() & nameField.valid()) {
            var tab1 = $('#tab1');
            var tab2 = $('#tab2');

            tab1.removeClass('active');
            tab1.css({ 'display': 'none' });
            $("a[href='#tab1'").removeClass('active');
            $("a[href='#tab2'").removeClass('disabled').addClass('active');
            tab2.css({ 'display': 'block' });
        } else {
            $("a[href='#tab2'").addClass('disabled');
        }

    });
});