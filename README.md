# VentaFlash_V2-CleanCode.Back
Prueba Tecnica Venta Flash
Back - End  C# .Net
Version 2 - CLEAN CODE + Entity Framework

Pasos despues de clonar el repositorio

Para Abrir en local:

Ejecutar 

Luego...
En los archivos "appsettings.json" y "OfertonContextFactory.cs" colocar la cadena de conexión a la base de datos local o nube.

Ejemplo:
"ConnectionStrings": {
    "DB_Oferton_V2": "server=.;database=DB_Oferton_V2;Trusted_Connection=True;"
}

Ir a Herramientas / Administrador de Paquetes NuGet y
Abrir Consola del Administrador de Paquetes

Ejecutar los siguientes comandos: 
1. add-migration InitialCreateMigration -p Oferton.Repositories.EFCore -c OfertonContext -o Migrations -s Oferton.Repositories.EFCore
2. update-database -p Oferton.Repositories.EFCore -s Oferton.Repositories.EFCore


Compilar.

Los EndPoints se pueden probar en el UI Swagger: 

![image](https://user-images.githubusercontent.com/58633633/195213587-ad53cf2b-ead0-43c5-b2c2-99015b9d0b85.png)

