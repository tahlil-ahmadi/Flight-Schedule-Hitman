#tool "nuget:?package=xunit.runner.console"
#addin "Cake.EntityFramework"
#addin Cake.XdtTransform

var configuration = Argument("Configuration","Debug");

Task("Clean")
    .Does(()=> {
        CleanDirectories("../FlightSchedule/**/bin/" + configuration);
        CleanDirectories("../FlightSchedule/**/obj/" + configuration);
});

Task("Restore-Nuget")
    .Does(()=> {
        NuGetRestore("../FlightSchedule/FlightSchedule.sln");
});

Task("Build")
    .Does(()=>{
        MSBuild("../FlightSchedule/FlightSchedule.sln", configurator =>
            configurator.SetConfiguration(configuration)
                .SetVerbosity(Verbosity.Minimal)
                .UseToolVersion(MSBuildToolVersion.VS2015)
                .SetMSBuildPlatform(MSBuildPlatform.x86)
                .SetPlatformTarget(PlatformTarget.MSIL));
});

Task("Run-Unit-Tests")
    .Does(()=>{
        var testAssemblies = GetFiles("../FlightSchedule/**/bin/"+ configuration +"/*.Tests.Unit.dll");
        XUnit2(testAssemblies);
});

Task("Migrate-Database-To-Latest")
    .Does(()=>{

        var migrationSettings = new EfMigratorSettings
        {
            AssemblyPath = @"../FlightSchedule/FlightSchedule.Persistence.EF/bin/" + configuration + "/FlightSchedule.Persistence.EF.dll",
            ConfigurationClass = "FlightSchedule.Persistence.EF.Migrations.Configuration",
            AppConfigPath = @"../FlightSchedule/FlightSchedule.Gateways.RestApi/Web.Config",
            ConnectionString = @"Server=CLASS1\MSSQLSERVER1;Database=FlightSchedule-TDD;User ID=sa;Password=123",
            ConnectionProvider = "System.Data.SqlClient"
        };

        using (var migrator = CreateEfMigrator(migrationSettings))
        {
          migrator.MigrateToLatest();
          migrator.Commit();
        }
});

Task("Run-Integration-Tests")
    .Does(()=>{
        var testAssemblies = GetFiles("../FlightSchedule/**/bin/"+ configuration +"/*.Tests.Integration.dll");
        XUnit2(testAssemblies);
});

Task("Run-Acceptance-Tests-Api")
    .Does(()=>{
        var testAssemblies = GetFiles("../Blackbox-Tests/FlightSchedule.AcceptanceTests.Api/**/bin/"+ configuration +"/*.AcceptanceTests.*.dll");
        XUnit2(testAssemblies);
});

Task("Run-Acceptance-Tests-UI")
    .Does(()=>{
        var testAssemblies = GetFiles("../Blackbox-Tests/FlightSchedule.AcceptanceTests.UI/**/bin/"+ configuration +"/*.AcceptanceTests.*.dll");
        XUnit2(testAssemblies);
});

Task("Pack-Framework")
    .Does(()=>{
        var nuGetPackSettings   = new NuGetPackSettings {
            Id                      = "TahlilFramework",
            Version                 = "0.0.0.1",
            Description ="Leave me alone",
            Title                   = "The tile of the package",
            Authors                 = new[] {"John Doe"},
            Owners                  = new[] {"Tahlildadeh"},
            Files                   = new [] {
                    new NuSpecContent {Source = "../../Blackbox-Tests/Framework.Web.Tools/bin/" + configuration + "/Framework.Web.Tools.dll", Target = "bin"},
            },
            // BasePath                = "./src/TestNuget/bin/release",
            OutputDirectory         = "./output",
        };

     NuGetPack(nuGetPackSettings);
});
Task("Default")
    // .IsDependentOn("Clean")
    // .IsDependentOn("Restore-Nuget")
    // .IsDependentOn("Build")
    // .IsDependentOn("Run-Unit-Tests")
    // .IsDependentOn("Migrate-Database-To-Latest")
    // .IsDependentOn("Run-Integration-Tests")
    // .IsDependentOn("Run-Acceptance-Tests-Api")
    // .IsDependentOn("Run-Acceptance-Tests-UI")
    .IsDependentOn("Pack-Framework")
    ;

RunTarget("Default");