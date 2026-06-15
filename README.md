# Measurement Conversion API

A scalable and maintainable ASP.NET Core Web API for converting measurement units across multiple categories such as length, temperature, weight, and volume.

The solution follows clean architecture principles and demonstrates extensibility through abstraction, dependency injection, centralized exception handling, reusable conversion logic, and unit testing.

---

## Features

* ASP.NET Core 8 Web API
* RESTful API design
* Swagger / OpenAPI integration
* Dependency Injection
* Global Exception Handling Middleware
* Input Validation
* Unit Testing using xUnit
* Extensible converter architecture
* Case-insensitive unit and category handling

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

## cURL Examples

### Length Conversion

```bash
curl -X POST "https://localhost:7275/api/v1/conversions" \
-H "Content-Type: application/json" \
-d '{
  "category": "length",
  "fromUnit": "meter",
  "toUnit": "feet",
  "value": 10
}'
```

### Temperature Conversion with Negative Value

```bash
curl -X POST "https://localhost:7275/api/v1/conversions" \
-H "Content-Type: application/json" \
-d '{
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": -40
}'
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

## Validation Rules

* Negative values are allowed only for temperature conversions.
* Length, weight, and volume conversions reject negative input values.
* Unit names and categories are handled in a case-insensitive manner.
* Invalid conversion categories or unsupported units return validation errors.

---

## Project Structure

```text
measurement-conversion-api/
│
├── UnitsConversionModule/
│   ├── Controllers/
│   ├── Converters/
│   │   ├── Base/
│   │   └── Interfaces/
│   ├── Middleware/
│   ├── Models/
│   │   ├── Requests/
│   │   └── Responses/
│   ├── Services/
│   │   └── Interfaces/
│   ├── Constants/
│   ├── Program.cs
│   └── UnitsConversionModule.csproj
│
├── UnitsConversionModule.Tests/
│
└── README.md
```

---

## Design Decisions and Trade-offs

### Strategy-Based Converter Architecture

The solution uses the `IUnitConverter` interface to support multiple conversion categories through interchangeable converter implementations. This allows new conversion categories to be added without modifying existing conversion logic.

### Shared Abstract Base for Factor-Based Conversions

Length, weight, and volume conversions follow the same factor-based conversion pattern. A shared abstract base class (`FactorBasedConverter`) was introduced to reuse common conversion logic and reduce duplication.

Temperature conversion was implemented separately because it relies on formula-based conversion rather than factor normalization.

### Dependency Injection

Services and converters are registered using ASP.NET Core dependency injection to support loose coupling, maintainability, and testability.

### Base Unit Normalization

Factor-based converters normalize values through a common base unit before converting to the target unit. This avoids maintaining direct conversion mappings between every possible unit combination.

### Error Handling

Global exception middleware was added to provide consistent and clean API error responses.

### Case-Insensitive Input Handling

Unit names and categories are handled in a case-insensitive manner to improve usability and reduce client-side input issues.

### Scalability Considerations

Currently, conversion factors are hardcoded for simplicity. The architecture allows future migration to external configuration or database-backed storage with minimal structural changes.
Future enhancements could include authentication and authorization mechanisms such as JWT-based security, rate limiting, persistent unit configuration storage, caching, and distributed deployment support depending on production requirements.

---

## Prerequisites

* .NET 8 SDK
* Visual Studio 2022 or VS Code (optional)

---

## Running the Application

### Clone the Repository

```bash
git clone https://github.com/abhibdesh/measurement-conversion-api.git
```

### Navigate to the Project

```bash
cd measurement-conversion-api
```

### Restore Dependencies

```bash
dotnet restore
```

### Run the API

Open the solution in Visual Studio and set `UnitsConversionModule` as the startup project.

Run the application using:

* `F5` for debugging
* `Ctrl + F5` to run without debugging
* or click the green Run button in Visual Studio

Alternatively, from the `UnitsConversionModule` project directory:

```bash
dotnet run
```

---

## Access Swagger UI

After running the application, Swagger UI will be available at:

```text
HTTPS: https://localhost:7275/swagger/index.html
HTTP: http://localhost:5019/swagger/index.html
```

---

## Running Unit Tests

Open the solution in Visual Studio.

Tests can be executed using:

* Test Explorer
* `Test -> Run All Tests`
* or by clicking the run icons beside individual test methods

Alternatively, from the `UnitsConversionModule.Tests` project directory:

```bash
dotnet test
```

Or from the solution root directory to execute all tests:

```bash
dotnet test
```

---

## Technologies Used

* ASP.NET Core 8
* C#
* Swagger / OpenAPI
* xUnit
* Dependency Injection
* REST API Design
* Middleware-based Exception Handling
