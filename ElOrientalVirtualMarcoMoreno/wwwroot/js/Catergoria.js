$("#btnGuardar").click(function () {

    var nombreCategoria = $(".Nombre").val();
    var descripcionCatergoria = $(".Descripcion").val();

    //validar que los campos sean requeridos
    if (nombreCategoria == "" || descripcionCatergoria == "") {
        Swal.fire({
            icon: 'error',
            title: 'Oops...',
            text: 'Todos los campos son requeridos',
            color: 'white'
        })
    }
    else {
        //Hacer la perticion al servidor para guardar

        //utilizar ajax
        var datos = $.ajax({
            //url de destino
            url: "Crear",
            type: "POST",
            data: {
                "NombreCategoria": nombreCategoria,
                "DescripcionCategoria": descripcionCatergoria
            }
        })
        //Mensaje de respuesta
        datos.done(function (data) {
            if (data.success) {
                Swal.fire(
                    'Guardado con exito!',
                    data.message,
                    'success'
                )
                $(".Nombre").val(""),
                $(".Descripcion").val("")
            } else {
                Swal.fire(
                    'Error',
                    data.message,
                    'error'
                )
            }
        })
        datos.fail(function () {
            notif({
                msg: "Error al guardar.",
                type: "error"
            });
        })
    }
});
