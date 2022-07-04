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
