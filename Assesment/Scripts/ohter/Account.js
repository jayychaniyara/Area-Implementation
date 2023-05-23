$("#registerNewUser").click(() => {
    var username = $('#userNameInput').val();
    var email = $('#emailInput').val();
    var mobile = $('#mobileInput').val();
    var dateOfBirth = $('#dateOfBirthInput').val();
    var password = $('#passwordInput').val();
    var confirmPassword = $('#confirmPasswordInput').val();
    var gender = $("input[name='Gender']:checked").val();

    var isValid = $('form').valid();

    if (isValid == true) {
        $.ajax({
            type: "POST",
            url: "/Account/Register",
            data: { "UserName": username, "Email": email, "Mobile": mobile, "DateOfBirth": dateOfBirth, "Password": password, "ConfirmPassword": confirmPassword, "Gender": gender },

            success: function (data) {
            },
            error: (err) => {
                alert(err);
            }
        });
    }
});
