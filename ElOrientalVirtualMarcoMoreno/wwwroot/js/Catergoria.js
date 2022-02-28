
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
                "DescripcionCategoria":descripcionCatergoria
            }
        })

        datos.done(function (data) {
            Swal.fire({
                icon: 'success',
                title: 'Guardado con Exito.',
                showConfirmButton: false,
                timer: 1500
            })
            $(".Nombre").val(""),
            $(".Descripcion").val("")

            console.log(data)
        })
        datos.fail(function () {
            Swal.fire({
                icon: 'error',
                title: 'Oops...',
                text: 'Todos los campos son requeridos',
                color: 'white'
            })
        })
    }
});
