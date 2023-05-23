var CurrentRow;
var loggedInUserId;
var CurrentUserIdToDelete;

$(document).ready(function () {
    loggedInUserId = $('#loggedInUserId').val();

    $.ajax({
        type: "GET",
        url: "/api/AccountWebApi",
        success: function (data) {
            $.each(data, function (index, item) {
                var $checkbox = $('<input>', {
                    type: 'checkbox',
                    id: 'activeCheckbox-' + item.Id,
                    name: 'myCheckbox',
                    value: 'true',
                });

                var $viewButton = $("<button>").addClass("btn btn-outline-success ViewUserButton")
                    .attr("type", "button")
                    .attr("data-userid", item.Id)
                    .attr("data-bs-toggle", "modal")
                    .attr("data-bs-target", "#ViewUserModel")
                    .text("View");

                var $editButton = $("<button>").addClass("btn btn-outline-light EditUserButton")
                    .attr("type", "button")
                    .attr("data-userid", item.Id)
                    .attr("data-bs-toggle", "modal")
                    .attr("data-bs-target", "#EditUserModel")
                    .text("Edit");

                var $deleteButton = $("<button>").addClass("btn btn-outline-danger DeleteUserButton")
                    .attr("type", "button")
                    .attr("data-userid", item.Id)
                    .attr("data-bs-toggle", "modal")
                    .attr("data-bs-target", "#DeleteUserModel")
                    .text("Delete");

                if (item.Active) {
                    $checkbox.prop('checked', true);
                }

                $checkbox.on('click', function () {
                    changeActiveStatus(item.Id);
                });

                if (loggedInUserId == item.Id) {
                    var $row = $('<tr>')
                        .append($('<td>').text(item.UserName))
                        .append($('<td>').text(item.Email))
                        .append($('<td>').text(item.PhoneNumber))
                        .append($('<td>').text(item.Gender))
                        .append($('<td>').text(item.Birthday))
                        .append($('<td>').append($checkbox.prop('disabled', true)))
                        .append($('<td>').append($viewButton))
                        .append($('<td>').append($editButton.prop('disabled', true)))
                        .append($('<td>').append($deleteButton.prop('disabled', true)));
                }
                else {
                    var $row = $('<tr>')
                        .append($('<td>').text(item.UserName))
                        .append($('<td>').text(item.Email))
                        .append($('<td>').text(item.PhoneNumber))
                        .append($('<td>').text(item.Gender))
                        .append($('<td>').text(item.Birthday))
                        .append($('<td>').append($checkbox))
                        .append($('<td>').append($viewButton))
                        .append($('<td>').append($editButton))
                        .append($('<td>').append($deleteButton));
                }

                $('.usersTable tbody').append($row);
            });
        },
        error: (error) => {
            alert(error);
        }
    });


    // Active status change function
    function changeActiveStatus(id) {
        var checkbox = document.getElementById(`activeCheckbox-${id}`);

        if (checkbox.checked) {
            $.ajax({
                type: "PUT",
                url: "/api/AccountWebApi/PutActiveStatus?Id=" + id + "&active=" + true,
                success: (response) => {

                },
                error: (err) => {
                    alert(err);
                }
            });
        }
        else {
            $.ajax({
                type: "PUT",
                url: "/api/AccountWebApi/PutActiveStatus?Id=" + id + "&active=" + false,
                success: (response) => {

                },
                error: (err) => {
                    alert(err);
                }
            });
        }
    }

    // Edit user details onClick function for getting existingData
    $(document).on("click", ".EditUserButton", (event) => {
        var selectedUserId = $(event.target).attr("data-userid");
        CurrentRow = $(event.target).parent().parent();

        $.ajax({
            type: "GET",
            url: "/api/AccountWebApi?Id=" + selectedUserId,
            success: (response) => {
                $("#txtEditUserName").val(response.UserName);
                $("#txtEditUserEmail").val(response.Email);
                $("#txtEditUserMobile").val(response.PhoneNumber);
            }, error: (error) => {
                alert(error);
            }
        });
    });

    // Validation for edit user information
    $("#editModelDiv input").on("change", function () {
        var userName = $("#txtEditUserName").val();
        var userEmail = $("#txtEditUserEmail").val();
        var userMobile = $("#txtEditUserMobile").val();

        if (userName == "" || userEmail == "" || userMobile == "") {
            $("#updateUserInfo").prop("disabled", true);
        }
    });

    // Update user information
    $("#updateUserInfo").click(() => {
        console.log("update clicked");
        var userName = $("#txtEditUserName").val(response.UserName);
        var userEmail = $("#txtEditUserEmail").val(response.Email);
        var userMobile = $("#txtEditUserMobile").val(response.PhoneNumber);

        $.ajax({
            type: "PUT",
            url: "api/AccountWebApi/PutUserInformation",
            data: $('form').serialize(),
            success: (response) => {

            },
            error: (err) => {
                alert(err);
            }
        });
    });

    // Delete user details onClick function for getting user data
    $(document).on("click", ".DeleteUserButton", (event) => {
        //deleteUserName span
        var selectedUserId = $(event.target).attr("data-userid");

        $.ajax({
            type: "GET",
            url: "/api/AccountWebApi?Id=" + selectedUserId,
            success: (response) => {
                $("#deleteUserName").html(response.UserName);
                CurrentUserIdToDelete = response.Id;
            }, error: (error) => {
                alert(error);
            }
        });

    });

    // Delete user information
    $("#deleteUser").click(() => {
        $.ajax({
            type: "DELETE",
            url: "/api/AccountWebApi?Id=" + CurrentUserIdToDelete,
            success: (response) => {
                location.reload();
            }, error: (error) => {
                alert(error);
            }
        });
    });

    // View user information
    $(document).on("click", ".ViewUserButton", (event) => {
        var selectedUserId = $(event.target).attr("data-userid");

        $.ajax({
            type: "GET",
            url: "/api/AccountWebApi?Id=" + selectedUserId,
            success: (response) => {
                $("#viewUserName").html(response.UserName);
                $("#viewUserEmail").html(response.Email);
                $("#viewUserMobile").html(response.PhoneNumber);
                $("#viewUserGender").html(response.Gender);
                $("#viewUserDateOfBirth").html(response.Birthday);
            }, error: (error) => {
                alert(error);
            }
        });
    });

});
