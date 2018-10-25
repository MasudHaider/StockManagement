$(document).ready(function () {
    $('.form-horizontal').validate({
        rules: {
            'Name': {
                required: true
            }
        },

        messages: {
            'Name': "Please enter a category name"
        },
        submitHandler: function (form) {
            form.submit();
        }
    });
})