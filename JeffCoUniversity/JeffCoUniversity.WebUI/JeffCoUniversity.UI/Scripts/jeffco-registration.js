$(document).ready()
{
    //classes
    //---------------------------------------------------------------------------------
    function serviceEndPoints(isProduction) {

        var baseApiDevAddress = 'http://localhost:54025/';
        var baseApiProdAddress = 'http://localhost:8081/';
        var register = 'api/account/register';
        var baseAddress = isProduction === true ? baseApiProdAddress : baseApiDevAddress;

        this.registerUrl = function () {
            return baseAddress + register;
        };
    }

    function redirectToLogin() {
        location.href = '/Home/Index';
    }


    //events
    //----------------------------------------------------------------------------------
    $('#linkCollapseValidationError').click(function () {
        $('#validationError').hide('fade');
    });

    $('#btnCloseDialog').click(function () {
        redirectToLogin();
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
                var respJson = JSON.parse(jqXHR.responseText);
                var modelState = respJson.ModelState;
                var errorString = respJson.Message + "<br>";
                for (var key in modelState) {
                    if (modelState.hasOwnProperty(key)) {
                        errorString = (errorString === "" ? "" : errorString + "<br>") + modelState[key][0];
                    }
                }
                 
                $('#errorMessage').html(errorString);
                $('#validationError').show('fade');
            }
        });
    });
}