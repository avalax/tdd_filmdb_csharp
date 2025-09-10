using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Xunit;

namespace AppHost.Tests;

public class ArchitectureTests
{
    private static readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(typeof(FilmDb.Adapter.In.Web.FilmController).Assembly)
        .Build();

    [Fact]
    public void Controllers_Should_Have_Correct_Name()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .ResideInNamespace("FilmDb.Adapter.In.Web")
            .Should()
            .HaveNameEndingWith("Controller")
            .Because("Controllers should follow naming convention");

        rule.Check(Architecture);
    }

    [Fact]
    public void Services_Should_Have_Correct_Name()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .ResideInNamespace("FilmDb.Application")
            .Should()
            .HaveNameEndingWith("Service")
            .Because("Application services should follow naming convention");

        rule.Check(Architecture);
    }

    [Fact]
    public void Interfaces_In_ApplicationPortIn_Should_Have_UseCase_Suffix()
    {
        var rule = ArchRuleDefinition.Interfaces()
            .That()
            .ResideInNamespace("FilmDb.Application.Port.In")
            .Should()
            .HaveNameEndingWith("UseCase")
            .Because("Input port interfaces should follow UseCase naming convention");

        rule.Check(Architecture);
    }

    [Fact]
    public void Interfaces_In_ApplicationPortOut_Should_Have_Repository_Suffix()
    {
        var rule = ArchRuleDefinition.Interfaces()
            .That()
            .ResideInNamespace("FilmDb.Application.Port.Out")
            .Should()
            .HaveNameEndingWith("Repository")
            .Because("Output port interfaces should follow Repository naming convention");

        rule.Check(Architecture);
    }

    [Fact]
    public void Domain_Entities_Should_Be_In_Domain_Namespace()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .HaveNameMatching("^Film$")
            .Should()
            .ResideInNamespace("FilmDb.Domain")
            .Because("Domain entities should be in Domain namespace");

        rule.Check(Architecture);
    }

    [Fact]
    public void Adapter_Classes_Should_Have_Correct_Namespace()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .HaveNameEndingWith("Adapter")
            .Should()
            .ResideInNamespaceMatching("FilmDb.Adapter.*")
            .Because("Adapter classes should be in Adapter namespace");

        rule.WithoutRequiringPositiveResults().Check(Architecture);
    }
}