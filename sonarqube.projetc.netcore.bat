dotnet tools\sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0\SonarScanner.MSBuild.dll /k:"project.netcore"
dotnet build sample.project.dotnetcore.sln
dotnet tools\sonar-scanner-msbuild-4.6.2.2108-netcoreapp2.0\SonarScanner.MSBuild.dll end