# StudentGuidance.
# 🎓 Gestor de Consultas para Orientación Estudiantil

Sistema API desarrollado en .NET para la gestión de citas y seguimiento académico entre estudiantes y orientadores.

---

## 📌 Descripción

Este proyecto permite administrar de forma organizada:

- Estudiantes
- Orientadores
- Citas académicas
- Seguimientos (observaciones y recomendaciones)

El sistema facilita el control del acompañamiento académico mediante una API REST.

---

## Arquitectura

El proyecto está desarrollado utilizando una **arquitectura por capas**:

- 🟦 **Domain**: Entidades y lógica base
- 🟩 **Application**: Servicios y lógica de negocio
- 🟨 **Infrastructure**: Acceso a datos (Entity Framework)
- 🟥 **API**: Endpoints REST (ASP.NET Core)

---

## Programación Orientada a Objetos (POO)

Se aplicaron los siguientes conceptos:

- ✔ Herencia (`Persona → Estudiante / Orientador`)
- ✔ Encapsulamiento
- ✔ Abstracción (`BaseEntity`)
- ✔ Sobrecarga de constructores
- ✔ Clases abstractas

---

## Tecnologías utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server / LocalDB
- Swagger (documentación API)

---

## Base de datos

La base de datos se genera automáticamente mediante **migraciones de Entity Framework**.

---

