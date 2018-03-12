/// <reference path="C:\GitProjectJockey\Repo\EWebAPI\ProductServiceSecure\ProductService-Secure\Registration_Login/Login.html" />
$(document).ready()
{
    //classes
    //---------------------------------------------------------------------------------
    function serviceEndPoints(isProduction) {

        var baseDev = 'http://localhost:55749/';
        var baseProd = 'http://localhost:8081/';
        var register = 'api/account/register';
        var base = isProduction == true ? baseProd : baseDev;

        this.registerUrl = function () {
            return base + register;
        }
    };

    //events
    //----------------------------------------------------------------------------------
    $('#linkCollapseValidationError').click(function () {
        $('#validationError').hide('fade');
    });

    $('#btnCloseDialog').click(function () {
        window.location.href = '..//registration_login/login.html';
    });

    $('#btnRegister').click(function () {
        var uri = new serviceEndPoints(window.IsProductionMode).registerUrl();
        $.ajax({
            method: 'POST',
            url: uri,
            data: {
                email: $('#txtEmail').val(),
                password: $('#txtPassword').val(),
                confirmPassword: $('#txtConfirmPassword').val()
            },
            success: function () {
                $('#successModal').modal('show');
            },
            error: function (jqXHR) {
                // API returns error in jQuery xml http request object.
                $('#errorMessage').text(jqXHR.responseText);
                $('#validationError').show('fade');
            }
        });
    });
}