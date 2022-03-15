$("#btnGuardar").click(function () {

    var NombrePropietario = $(".Nombre").val();

    //validar que los campos sean requeridos
    if (NombrePropietario == "") {
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
                "NombrePropietario": NombrePropietario,
            }
        })
        //Mensaje de respuesta
        datos.done(function (data) {
            if (data.success) {
                Swal.fire(
                    'Guardado con exito!',
                    data.message,
                    'success'
                );
                setTimeout(function () {
                    location.href = "../Propietario";
                }, 2000)
                
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
