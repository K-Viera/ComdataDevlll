## Prueba Comdata Desarollador lll

La Prueba fue realizada con .Net Framework 4.7.2, utilizando librerias como IdentityFramework para el registro de usuario administrador
y EntityFramework como ORM para la conexion con la base de datos SQLServer.

## Paso a Paso instalacion y utilizacion


Lo primero que haremos sera ingresar al archivo **Web.config** dentro de la carpeta principal.

![Config](https://user-images.githubusercontent.com/53414453/156069054-8f2d627f-82d4-415f-8d3a-63983e80adbb.jpg)

aca deberemos escribir el **conneccionString** de nuestra base de datos.</br>


luego dentro de la <strong>Consola del Administrador de paquetes</strong> escribimos el comando <strong>Update-Database</strong>.

![nuget](https://user-images.githubusercontent.com/53414453/156069365-c2afdf9e-b036-4a1c-96a2-e52e0b9c62e1.jpg)

Despues de esto iniciamos el proyecto principal, inicialmente pedira un registro de usuario administrador,
ya que la aplicacion se penso para que varias empresas o actores pudieran registrar sus colaboradores de manera independiente.


### Logger


Los logs quedan guardados en una carpeta "log" dentro del archivo principal donde se ejecute.
