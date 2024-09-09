$(document).ready(function () {
    $('.js-delete').on('click', function () {
        var btn = $(this);

        const swal = Swal.mixin({
            customClass: {
                confirmButton: 'btn btn-danger mx-2',
                cancelButton: 'btn btn-light'
            },
            buttonsStyling: false
        });

        swal.fire({
            title: 'Confirm Deletion',
            text: "This action is irreversible. Are you sure?",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonText: 'Yes, proceed!',
            cancelButtonText: 'No, keep it!',
            reverseButtons: true,
            backdrop: true, // Add a backdrop for emphasis
            background: '#f8f9fa', // Light background color
            color: '#333', // Dark text color
            iconColor: '#dc3545'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    url: `/Books/Delete/${btn.data('id')}`,
                    method: 'DELETE',
                    success: function () {
                        swal.fire(
                            'Deleted!',
                            'The book has been successfully removed.',
                            'success'
                        );

                        btn.parents('tr').fadeOut();
                    },
                    error: function () {
                        swal.fire(
                            'Error!',
                            'An error occurred while deleting the book.',
                            'error'
                        );
                    }
                });
            }
        });
    });
});