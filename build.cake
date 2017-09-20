
#addin "Cake.Incubator"
#tool "nuget:?package=GitVersion.CommandLine"

// Script Arguments
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

// Git version global variable
GitVersion gitVersion;

Task("GitVersion")
    .Does(() =>
{
    gitVersion = GitVersion(new GitVersionSettings {
        UpdateAssemblyInfo = false
    });

    Information("AssemblySemVer: " + gitVersion.AssemblySemVer);
    Information("FullSemVer: " + gitVersion.FullSemVer);
    Information("NuGetVersion: " + gitVersion.NuGetVersion);
    Console.WriteLine(gitVersion.Dump());
});


RunTarget("GitVersion");
