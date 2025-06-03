# 📘 Libreta de Contactos - API REST

Este proyecto implementa una **API REST** para gestionar una libreta de contactos, creada con **.NET 8**, **Minimal API**, y principios de **Clean Architecture**. Incluye una interfaz Swagger personalizada para documentación y pruebas.

---

## 🧱 Estructura del proyecto

- **Domain**: Entidades del dominio (ej. `Contact`)
- **Application**: Interfaces como `IContactService`
- **Infrastructure**: Servicio `JsonContactService` que simula una base de datos con un archivo `fakedatabase.json`
- **API**: Punto de entrada principal con endpoints minimalistas y documentación Swagger

---

## 📂 Archivo `fakedatabase.json`

Los datos de los contactos se almacenan en `API/Infrastructure/Data/fakedatabase.json`.  
- Si el archivo no existe, se genera automáticamente con 10 contactos ficticios basados en personajes de Pokémon.
- Este diseño permite sustituir fácilmente la fuente de datos por una base real (como SQL Server o EF Core) sin modificar la capa de aplicación o la API.

---

## 🔗 Endpoints disponibles

| Método | Ruta                 | Descripción                             |
|--------|----------------------|-----------------------------------------|
| GET    | `/contacts`          | Lista todos los contactos               |
| GET    | `/contacts?phrase=xy`| Filtra por nombre (case-insensitive)    |
| GET    | `/contacts/{id}`     | Devuelve un contacto por su ID          |
| DELETE | `/contacts/{id}`     | Elimina un contacto por su ID           |

Los métodos `POST`, `PUT` y `PATCH` devolverán `405 Method Not Allowed`.

## 🧪 Pruebas con Postman

Se incluye una colección de Postman para probar los endpoints disponibles, incluyendo pruebas para códigos `405`.

- 👉 [Colección completa con variable baseUrl](https://github.com/carlosqm09/AddressBookApi/master/API/Infrastructure/AddressBook%20API.postman_collection)

Importa los archivos en Postman y asegúrate de establecer la variable `baseUrl` con tu `LOCALHOST`.

---

## 🖼 Capturas sugeridas

Puedes agregar capturas aquí para mostrar:

- Vista general de Swagger personalizada
- Resultado de los endpoints
- Vista del archivo `fakedatabase.json`

```
📷 [Agregar captura aquí]
📷 [Agregar captura aquí]
```

---

## 👨‍💻 Autor

**Carlos Quijada**  
[GitHub](https://github.com/carlosqm09) · carmanu09@gmail.com

---
