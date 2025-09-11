using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using Xunit;

namespace AppHost.Tests;

public class ArchitectureTests
{
    private static readonly Architecture Architecture = new ArchLoader()
        .LoadAssemblies(typeof(FilmDb.Module).Assembly)
        .Build();

    [Fact]
    public void Controllers_Should_Not_Access_Output_Ports_Or_Adapters()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .ResideInNamespace("FilmDb.Adapter.In.Web")
            .Should()
            .NotDependOnAny(ArchRuleDefinition.Types()
                .That()
                .ResideInNamespace("FilmDb.Application.Port.Out")
                .Or()
                .ResideInNamespace("FilmDb.Adapter.Out"))
            .Because("Controllers should not directly access output ports or adapters");

        rule.Check(Architecture);
    }

    [Fact]
    public void Services_Should_Not_Access_Adapters()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .ResideInNamespace("FilmDb.Application")
            .Should()
            .NotDependOnAny(ArchRuleDefinition.Types()
                .That()
                .ResideInNamespace("FilmDb.Adapter"))
            .Because("Application services should not depend on adapters");

        rule.Check(Architecture);
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_Application_Or_Adapters()
    {
        var rule = ArchRuleDefinition.Classes()
            .That()
            .ResideInNamespace("FilmDb.Domain")
            .Should()
            .NotDependOnAny(ArchRuleDefinition.Types()
                .That()
                .ResideInNamespace("FilmDb.Application")
                .Or()
                .ResideInNamespace("FilmDb.Adapter"))
            .Because("Domain should not depend on application or adapter layers");

        rule.Check(Architecture);
    }
}