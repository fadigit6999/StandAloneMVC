//when html page loads
$(document).ready(function () {
    // Get the current URL
    var currentUrl = window.location.href;

    // Extract the last part of the URL (ID)
    var id = currentUrl.split('/').pop();

    // Check if ID is a number
    if (!isNaN(id)) {
        // Convert ID to a number
        id = parseInt(id, 10);

        if (id === 1) {
            //if id is 1 then make it create alert
            Swal.fire({
                title: "Create Employee!",
                text: "Employee Created Successfully!!",
                icon: "success"
            });
        } else if (id === 2) {
            //if id is 2 then make it update alert
            Swal.fire({
                title: "Update Employee!",
                text: "Employee Updated Successfully!!",
                icon: "success"
            });
        } else if (id === 3) {
            //if id is 3 then make it delete alert
            Swal.fire({
                title: "Delete Employee!",
                text: "Employee Deleted Successfully!!",
                icon: "success"
            });
        }
    }
});