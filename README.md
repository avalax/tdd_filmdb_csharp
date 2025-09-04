# tdd_filmdb_csharp

## 1. Run the application:

```bash
dotnet run --project src/AppHost
```

## 2. Run tests:

```bash
dotnet test tests/FilmDb.Tests
```

## 3. Code Coverage:

### Generate coverage reports:
```bash
dotnet test tests/FilmDb.Tests/FilmDb.Tests.csproj
```

### Generate HTML coverage report:

**Windows (PowerShell):**
```powershell
.\generate-coverage.ps1
```

## 4. Dependency Management:

### Check for outdated packages:
```bash
dotnet list package --outdated
```
## 5. Routes

The API routes are built using ASP.NET Core conventions:

### Route Structure

- Base route: api/[controller]
- Controller name: Derived from class name minus "Controller" suffix
  → routes start with api/film

### Naming Convention

- Action methods: Use HTTP verb attributes with descriptive names
    - GetAllFilms() → GET api/film
    - GetFilm(int id) → GET api/film/{id}
    - CreateFilm() → POST api/film
