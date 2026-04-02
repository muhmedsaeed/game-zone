

// For Image Preview
$(document).ready(function () {
    $('#Cover').change(function () {
        const file = this.files[0];
        if (file) {
            let reader = new FileReader();
            reader.onload = function (event) {
                $('.cover-preview').attr('src', event.target.result).removeClass('d-none');
            }
            reader.readAsDataURL(file);
        }
    });
});