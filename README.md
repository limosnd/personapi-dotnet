 PersonAPI .NET  
**Implementación de Monolito con patrón MVC y DAO — Laboratorio 1**

---

Introducción

**Pontificia Universidad Javeriana**  
**Carrera:** Ingeniería de Sistemas  
**Laboratorio:** Implementación de Monolito con patrón MVC y DAO  
**Integrantes:**  
- Diego Alejandro Jara Rojas  
- Laura Isabel Montero 
---

 Descripción general

Este proyecto consiste en la implementación de un **sistema monolítico basado en el patrón MVC (Modelo–Vista–Controlador)** con integración de un **patrón DAO (Data Access Object)** para la gestión de datos persistentes.  

Se desarrolló una aplicación **ASP.NET Core MVC (.NET 8)** con **Entity Framework Core 8** conectada a una base de datos **SQL Server 2022**, la cual se despliega mediante contenedores **Docker** orquestados con **Docker Compose**.  

La aplicación incluye un modelo de datos compuesto por las entidades:
- **Persona**
- **Profesión**
- **Estudios**
- **Teléfono**

y ofrece las operaciones CRUD correspondientes para cada entidad.

---

 Stack tecnológico

| Componente | Tecnología |
|-------------|-------------|
| Lenguaje | C# (.NET 8) |
| Framework Web | ASP.NET Core MVC |
| ORM | Entity Framework Core 8 |
| Base de datos | Microsoft SQL Server 2022 |
| Contenedorización | Docker + Docker Compose |
| Documentación API | Swagger 3 |
| IDE | Visual Studio 2022 Community |
| Patrón | MVC + DAO |

---

 Marco conceptual

- **MVC (Modelo–Vista–Controlador):** patrón arquitectónico que separa la lógica de negocio, la interfaz y el control del flujo de datos, facilitando la mantenibilidad del sistema.
- **DAO (Data Access Object):** patrón de diseño que abstrae la capa de acceso a datos del resto de la aplicación, permitiendo la independencia entre la lógica de negocio y el motor de base de datos.
- **Entity Framework Core:** ORM de Microsoft que permite interactuar con bases de datos relacionales mediante objetos de C# sin escribir consultas SQL directas.
- **Docker:** tecnología de contenedorización que permite ejecutar aplicaciones y sus dependencias en entornos aislados y reproducibles.
- **SQL Server 2022:** sistema de gestión de bases de datos relacional utilizado para almacenar la información del sistema.

---

 Diseño

El sistema sigue una **arquitectura monolítica** organizada en tres capas principales:

+----------------------------+

| Presentación | → Vistas Razor (HTML, CSS, Razor)

+----------------------------+

| Lógica de negocio | → Controladores MVC + DAO

+----------------------------+

| Acceso a datos | → Entity Framework Core + SQL Server

+----------------------------+

 Ejecución

Requisitos previos
Antes de ejecutar el proyecto, asegúrate de tener instalado y configurado lo siguiente:

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [Docker Desktop](https://www.docker.com/products/docker-desktop/)
- [Git](https://git-scm.com/downloads)
- Visual Studio 2022 (opcional, para desarrollo y depuración)

---

 Ejecución automática (recomendada)

El proyecto incluye un script automatizado llamado `init-full.bat` (para Windows), el cual realiza todo el proceso de despliegue:

```bash
init-full.bat
