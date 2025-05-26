## Documentación

Este proyecto implementa un sistema tipo "To-Do empresarial", diseñado para gestionar tareas con reglas de negocio específicas, buenas prácticas de desarrollo y principios de diseño limpio.

1. **Requisitos previos:**
- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) o LocalDB
- [Visual Studio 2022+](https://visualstudio.microsoft.com/)
- Entity Framework Core CLI (ya viene con el SDK)

### ¿Cómo correr el proyecto?

1. Clonar el repositorio
2. Configurar la base de datos
    1. Modifica el archivo `appsettings.json` del proyecto para establecer tu cadena de conexión
        
        "ConnectionStrings": {
        "ConexionTareas": "Server=.;Database=TareasDb;Trusted_Connection=True;TrustServerCertificate=True;"
        }
        
    2. Ejecutar migraciones y crear la base de datos:
        
        dotnet ef database update --project Infrastructure
        
3. Correr el proyecto

### Mi enfoque

Este proyecto fue desarrollado siguiendo principios de **Clean Architecture**, dividiendo la solución en capas bien definidas:

- `Dominio`: Contiene las entidades, interfaces y reglas de negocio puras.
- `Aplicacion`: Contiene los casos de uso y la lógica de aplicación. Se aplican validaciones, filtros, reglas y lógica sin dependencia de frameworks externos.
- `Infraestructura`: Implementa persistencia de datos usando Entity Framework Core.
- `Api`: Capa de entrada que expone la API REST usando ASP.NET Core.

Los métodos de acceso a datos y lógica de aplicación son asíncronos usando `async/await` para mejorar el rendimiento y escalabilidad de la API.

Se usa **LINQ** para aplicar filtros por estado y ordenamiento por prioridad.

### Mejoras

Este proyecto puede expandirse con:

1. **Soporte para adjuntar archivos o comentarios a las tareas.**
2. **Notificaciones (por mail) cuando una tarea se acerque a la fecha de vencimiento.**
3. **Panel web frontend  para consumir la API.**
4. **Paginar resultados en el listado de tareas.**
5. **Implementar pruebas unitarias y de integración con xUnit y Moq.**
