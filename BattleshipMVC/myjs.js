var form = $('#gameForm');
$.ajax({
 
    cache: false,
    async: true,
    type: "POST",
    url: form.attr('action'),
    data: form.serialize(),
    success: function (data) {
        alert(data);
    }
});