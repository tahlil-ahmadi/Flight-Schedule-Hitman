#tool "nuget:?package=xunit.runner.console"
#addin "Cake.EntityFramework"

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

Task("Run-Acceptance-Tests")
    .Does(()=>{
        var testAssemblies = GetFiles("../FlightSchedule/**/bin/"+ configuration +"/*.Acceptance.Tests.dll");
        XUnit2(testAssemblies);
});


Task("Default")
    .IsDependentOn("Clean")
    .IsDependentOn("Restore-Nuget")
    .IsDependentOn("Build")
    .IsDependentOn("Run-Unit-Tests")
    .IsDependentOn("Migrate-Database-To-Latest")
    .IsDependentOn("Run-Integration-Tests")
    .IsDependentOn("Run-Acceptance-Tests")
    ;

RunTarget("Default");