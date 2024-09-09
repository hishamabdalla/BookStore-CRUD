$(document).ready(function () {
    $('#Cover').on('change', function () {
        const file = this.files[0];
        if (file) {
            const objectURL = window.URL.createObjectURL(file);
            const $preview = $('.cover-preview');

            $preview.attr('src', objectURL).removeClass('d-none');

            // Revoke the object URL after the image has loaded
            $preview.on('load', function () {
                window.URL.revokeObjectURL(objectURL);
            });
        }
    });
});
