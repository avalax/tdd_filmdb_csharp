# Generate code coverage reports
Write-Host "Running tests with coverage collection..." -ForegroundColor Green
dotnet test tests/FilmDb.Tests/FilmDb.Tests.csproj
dotnet test tests/AppHost.Tests/AppHost.Tests.csproj

# Use the configured coverage output from the projects
$filmDbCoverageFile = "tests/FilmDb.Tests/CodeCoverage/coverage.cobertura.xml"
$appHostCoverageFile = "tests/AppHost.Tests/CodeCoverage/coverage.cobertura.xml"

# Collect all coverage files
$coverageFiles = @()
if (Test-Path $filmDbCoverageFile) {
    $coverageFiles += $filmDbCoverageFile
    Write-Host "Found FilmDb coverage file: $filmDbCoverageFile" -ForegroundColor Green
}
if (Test-Path $appHostCoverageFile) {
    $coverageFiles += $appHostCoverageFile
    Write-Host "Found AppHost coverage file: $appHostCoverageFile" -ForegroundColor Green
}

if ($coverageFiles.Count -gt 0) {
    Write-Host "Generating combined HTML report from: $($coverageFiles -join ', ')" -ForegroundColor Green
    
    # Install ReportGenerator tool if not already installed
    dotnet tool install -g dotnet-reportgenerator-globaltool 2>$null
    
    # Generate HTML report using ReportGenerator with combined coverage files
    $reportsParam = $coverageFiles -join ";"
    reportgenerator `
        -reports:"$reportsParam" `
        -targetdir:"./CodeCoverage/html" `
        -reporttypes:"Html;HtmlSummary" `
        -title:"FilmDb + AppHost Coverage Report"
    
    Write-Host "HTML coverage report generated in ./CodeCoverage/html" -ForegroundColor Green
    Write-Host "Open ./CodeCoverage/html/index.html in your browser to view the report" -ForegroundColor Yellow
} else {
    Write-Host "No coverage files found!" -ForegroundColor Red
    Write-Host "Run 'dotnet test tests/FilmDb.Tests/FilmDb.Tests.csproj' and 'dotnet test tests/AppHost.Tests/AppHost.Tests.csproj' first to generate coverage data." -ForegroundColor Yellow
}