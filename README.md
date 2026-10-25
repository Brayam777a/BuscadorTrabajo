# BuscadorTrabajo

## Integrantes (Equipo Error404)


- Jordan del Aguila
- Brayan Florez


## Descripción del proyecto

**BuscadorTrabajo** es una plataforma web orientada al área de sistemas. Centraliza oportunidades laborales de tecnología (desarrollo de software, bases de datos, redes, ciberseguridad, DevOps, soporte, etc.) y conecta a profesionales con empresas, para evitar que el profesional tenga que revisar ofertas de otros sectores que no corresponden a su perfil.

**Objetivo general:** implementar una solución web completa (WebAPI + base de datos + interfaz Blazor WebAssembly) que permita publicar vacantes, registrar perfiles profesionales y gestionar postulaciones, con operaciones CRUD funcionales sobre las entidades principales del negocio.

## Tecnologías utilizadas

- ASP.NET Core .NET 10 (WebAPI)
- Entity Framework Core (DbContext y migraciones)
- SQL Server
- Blazor WebAssembly con Componentes Razor
- Swagger (OpenAPI) y Postman para pruebas del WebAPI
- Git y GitHub

## Estructura de la solución

| Proyecto | Responsabilidad |
|---|---|
| `BuscadorTrabajo.Shared` | Entidades, modelos o DTOs compartidos, con sus validaciones |
| `BuscadorTrabajo.WebAPI` | Acceso a datos (EF Core), SeedDb, controladores y endpoints REST |
| `BuscadorTrabajo.Frontend` | Aplicación Blazor WebAssembly: componentes Razor, formularios y servicios HTTP |

## Instrucciones básicas para ejecutar la solución

**Requisitos:** .NET 10 SDK, SQL Server (o LocalDB) y Visual Studio 2026 o VS Code.

1. Clonar el repositorio.
2. Configurar la cadena de conexión en `BuscadorTrabajo.WebAPI/appsettings.json`.
3. Aplicar las migraciones: `dotnet ef database update` (desde el proyecto WebAPI).
4. Ejecutar el WebAPI. Al iniciar, el SeedDb carga los datos iniciales.
5. Ejecutar la aplicación Blazor WebAssembly.

> **Pendiente:** indicar aquí los puertos/URL del WebAPI y del Frontend, y dónde se configura la URL base del WebAPI en Blazor.

## Entidades principales

| Entidad | Descripción |
|---|---|
| `Role` | Tipo de usuario: Desarrollador, Empresa, Cliente o Administrador |
| `User` | Usuario del sistema (persona o empresa), con su rol. Por ahora sin contraseña ni login |
| `Perfil_Profesional` | Información profesional del desarrollador, usada en sus postulaciones |
| `Educacion` | Formación académica del profesional |
| `Experiencia` | Experiencia laboral o profesional |
| `Certificacion` | Certificaciones obtenidas por el profesional |
| `Categoria` | Áreas de sistemas (Backend, Frontend, DevOps, IoT, etc.) para clasificar vacantes |
| `Publicacion` | Oferta laboral publicada por una empresa |
| `Aplicacion` | Postulación de un desarrollador a una publicación |
| `Pregunta` | Preguntas específicas asociadas a una publicación |
| `Respuesta` | Respuesta de un postulante a cada pregunta de la publicación |

## Relaciones entre entidades

- `Role` 1 → N `User`
- `User` 1 → 0..1 `Perfil_Profesional` (solo usuarios con rol Desarrollador)
- `User` 1 → N `Publicacion` (publicadas por empresas)
- `Perfil_Profesional` 1 → N `Educacion`, `Experiencia` y `Certificacion`
- `Perfil_Profesional` 1 → N `Aplicacion`
- `Categoria` 1 → N `Publicacion`
- `Publicacion` 1 → N `Aplicacion`
- `Publicacion` 1 → N `Pregunta`
- `Aplicacion` 1 → N `Respuesta`
- `Pregunta` 1 → N `Respuesta`

## Reglas de negocio y validaciones

- Solo el rol Desarrollador tiene perfil profesional y puede crear aplicaciones.
- Un desarrollador solo puede aplicar una vez a la misma publicación.
- El correo del usuario es único.
- Por indicación del profesor, en esta entrega no se manejan claves ni contraseñas: no hay login ni autenticación. El rol se usa para validar reglas del negocio (por ejemplo, que solo un usuario con rol Desarrollador tenga perfil y cree aplicaciones).
- Los campos obligatorios, longitudes y formatos se validan en `Shared` y se reflejan en los formularios de Blazor.

> **Pendiente:** completar con las validaciones exactas implementadas (campos obligatorios, rangos, formatos).

## SeedDb implementado

> **Pendiente:** describir los datos iniciales que carga el SeedDb. Plan previsto:
>
> - Roles: Desarrollador, Empresa, Cliente, Administrador.
> - Categorías: las áreas de sistemas del proyecto.
> - Usuario administrador inicial (usuario con rol Administrador, sin contraseña).
> - Datos de demostración: una empresa, un desarrollador con perfil y varias publicaciones.
>
> El SeedDb verifica si los datos ya existen antes de insertarlos, para no duplicar registros al reiniciar la aplicación.

## Usuario administrador inicial

> **Pendiente:** indicar el correo y el nombre del usuario administrador creado por el SeedDb. En esta entrega no tiene contraseña, porque no se maneja autenticación.

## Endpoints principales del WebAPI

Cada recurso expone `GET`, `GET /{id}`, `POST`, `PUT /{id}` y `DELETE /{id}`.

| Recurso | Ruta base | Notas |
|---|---|---|
| Categorías | `/api/categorias` | |
| Publicaciones | `/api/publicaciones` | Filtros opcionales: texto, categoría, modalidad, ciudad |
| Perfiles profesionales | `/api/perfiles` | |
| Educación | `/api/educaciones` | Filtro por perfil |
| Experiencia | `/api/experiencias` | Filtro por perfil |
| Certificaciones | `/api/certificaciones` | Filtro por perfil |
| Aplicaciones | `/api/aplicaciones` | Filtro por publicación o perfil |
| Preguntas | `/api/preguntas` | Filtro por publicación |
| Respuestas | `/api/respuestas` | Filtro por aplicación |
| Usuarios | `/api/usuarios` | |
| Roles | `/api/roles` | |

> **Pendiente:** confirmar las rutas finales una vez implementados los controladores.

## Video demostrativo

> **Pendiente:** pegar aquí el enlace al video (máximo 5 minutos, con la participación de todos los integrantes).

## Resumen de funcionalidades implementadas

Marcar a medida que se completen:

- [ ] Proyecto Shared con entidades, validaciones y relaciones
- [ ] WebAPI con EF Core, DbContext y base de datos real
- [ ] Migraciones aplicadas
- [ ] SeedDb con datos iniciales (mínimo 2 entidades) y usuario administrador
- [ ] SeedDb sin duplicados al reiniciar
- [ ] CRUD completo en el WebAPI (GET, GET por id, POST, PUT, DELETE)
- [ ] Pruebas en Swagger y Postman
- [ ] Blazor WebAssembly con servicios HTTP
- [ ] Componentes Razor y formularios de creación y edición
- [ ] Validaciones visuales y mensajes al usuario
- [ ] Navegación entre módulos
- [ ] Integración completa Blazor + WebAPI + base de datos

## Aportes por integrante

| Integrante | Aporte |
|---|---|
| Jordan del Aguila | _Pendiente_ |
| Brayan Florez | _Pendiente_ |


## Fuera del alcance de esta entrega

Quedan para etapas posteriores: contratación de servicios tecnológicos (solicitudes y propuestas), vacantes externas obtenidas de otras plataformas, claves y contraseñas, login y autenticación (JWT), claves de API de servicios externos, búsqueda avanzada, recomendaciones, alertas y paginación.
