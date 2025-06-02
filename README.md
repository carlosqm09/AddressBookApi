📘 Repository Description
AddressBookApp (.NET Minimal API)

This project implements a RESTful backend for an address book application using .NET 8, Minimal APIs, and Swagger. The architecture follows Clean Architecture principles, separating concerns into well-defined layers: Domain, Application, Infrastructure, and Interface.

✅ Features
GET /contacts:
Retrieves all contacts, sorted alphabetically by name.
Supports optional filtering using the phrase query parameter (case-insensitive).

GET /contacts/{id}:
Retrieves the details of a single contact by ID.

DELETE /contacts/{id}:
Deletes a contact by ID and returns 204 No Content on success.

⚙️ Implementation Notes
A fake in-memory data source is used for demonstration and testing purposes (replacing the original fakedatabase.js).

Clean error handling:

400 Bad Request when phrase is empty (phrase=)

404 Not Found for invalid IDs or unsupported routes

405 Method Not Allowed for unsupported HTTP methods

Fully integrated with Swagger for easy testing and API documentation
