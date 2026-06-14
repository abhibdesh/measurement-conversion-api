# Unit Conversion API

A scalable and maintainable ASP.NET Core Web API for converting values between different units of measurement across multiple categories such as length, temperature, weight, and volume.

The solution is designed with extensibility and clean architecture principles in mind, using dependency injection, interface-based abstractions, strategy patterns, centralized exception handling, and unit testing.

---

## Features

* ASP.NET Core 8 Web API
* RESTful API design
* Conversion support for:

  * Length
  * Temperature
  * Weight / Mass
  * Volume
* Strategy-based converter architecture
* Dependency Injection
* Global exception handling middleware
* Input validation with meaningful error responses
* Swagger / OpenAPI integration
* Unit tests using xUnit
* Clean and maintainable project structure
* Unit names and categories are handled in a case-insensitive manner to improve API usability and reduce client-side input errors.


---

## Supported Conversion Categories

### Length

* Millimeter
* Centimeter
* Decimeter
* Meter
* Kilometer
* Feet
* Mile

### Temperature

* Celsius
* Fahrenheit
* Kelvin

### Weight / Mass

* Milligram
* Gram
* Kilogram
* Pound

### Volume

* Milliliter
* Liter
* Gallon

---

## API Endpoint

### Convert Units

```http
POST /api/v1/conversions
```

---

## Sample Requests

### Length Conversion

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "feet",
  "value": 10
}
```

### Temperature Conversion

```json
{
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": 100
}
```

### Weight Conversion

```json
{
  "category": "weight",
  "fromUnit": "kilogram",
  "toUnit": "pound",
  "value": 5
}
```

### Volume Conversion

```json
{
  "category": "volume",
  "fromUnit": "liter",
  "toUnit": "gallon",
  "value": 3
}
```

---

## Sample Success Response

```json
{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "feet",
  "originalValue": 10,
  "convertedValue": 32.8084
}
```

---

## Sample Error Response

```json
{
  "error": "Invalid units for length conversion."
}
```

---

## Project Structure

```text
UnitsConversionModule/
│
├── Controllers/
├── Converters/
│   ├── Base/
│   └── Interfaces/
├── Middleware/
├── Models/
│   ├── Requests/
│   └── Responses/
├── Services/
│   └── Interfaces/
├── Constants/
├── Extensions/
├── Program.cs
└── README.md

UnitsConversionModule.Tests/
```

---

## Design Decisions and Trade-offs

### Strategy-Based Converter Architecture

The solution uses the `IUnitConverter` interface to support multiple conversion categories through interchangeable converter implementations. This allows new conversion categories to be added without modifying existing conversion logic.

### Shared Abstract Base for Factor-Based Conversions

Length, weight, and volume conversions follow the same factor-based conversion pattern. To avoid duplicated logic, a shared abstract base class (`FactorBasedConverter`) was introduced for reusable conversion behavior.

Temperature conversion was intentionally implemented separately because it uses formula-based logic rather than factor normalization.

### Dependency Injection

All services and converters are registered using ASP.NET Core dependency injection to support loose coupling, maintainability, and testability.

### Base Unit Normalization

Factor-based converters normalize values through a common base unit before converting to the target unit. This avoids maintaining direct conversion mappings between every possible unit combination and improves scalability.

### Single Project API Structure

The API implementation is intentionally maintained within a single ASP.NET Core Web API project to keep the solution lightweight and appropriate for the current scope while still maintaining separation of concerns through folders, interfaces, services, middleware, and abstractions.

A separate test project was added to isolate unit tests from application logic.

### Error Handling

Global exception middleware was added to provide consistent API error responses and avoid leaking raw framework exceptions to API consumers.

### Future Scalability

Currently, unit definitions and conversion factors are maintained in-memory. The architecture allows future migration to external configuration or database-backed storage with minimal changes.

---

## Running the Application

### Prerequisites

* .NET 8 SDK

---

### Run Locally

Clone the repository:

```bash
git clone https://github.com/abhibdesh/measurement-conversion-api.git
```

Navigate to the project directory:

```bash
cd UnitsConversionModule
```

Restore dependencies:

```bash
dotnet restore
```

Run the application:

```bash
dotnet run
```

Swagger UI will be available at:

```text
HTTPS: https://localhost:7275/swagger/index.html
HTTP: http://localhost:5019/swagger/index.html
```

---

## Running Unit Tests

From the solution root:

```bash
dotnet test
```

---

## Technologies Used

* ASP.NET Core 8
* C#
* Swagger 
* xUnit
* Dependency Injection
* REST API Design
