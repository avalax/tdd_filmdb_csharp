# tdd_filmdb_csharp

## Run the application:

```bash
dotnet run --project src/AppHost
```

### Run NSwag (while the application is running)

```bash
dotnet build src/Gui -t:NSwag
```

## Create a release

### Publish
   ```bash
   dotnet publish src/AppHost -c Release -o ./publish
   ```
### Run published application
   ```bash
   cd publish
   dotnet AppHost.dll
   ```
## Run tests:

```bash
dotnet test tests/FilmDb.Tests
dotnet test tests/AppHost.Tests
```

## Code Coverage

### Generate Coverage Reports
```bash
dotnet test tests/FilmDb.Tests/FilmDb.Tests.csproj
dotnet test tests/AppHost.Tests/AppHost.Tests.csproj
```

### Generate HTML Coverage Report
**Windows (PowerShell):**
```powershell
.\generate-coverage.ps1
```

## Dependency Management:

### Check for outdated packages:
```bash
dotnet list package --outdated
```
## Routes

The API routes are built using ASP.NET Core conventions:

### Route Structure
- Base route: `api/[controller]`
- Controller name: Derived from class name minus "Controller" suffix

### Film Endpoints
- `GET api/film` - Get all films
- `GET api/film/{id}` - Get film by ID
- `POST api/film` - Create new film

### Health Check
- `GET /health` - Application health status

### Development Tools
- `GET /swagger` - API documentation (development only)
