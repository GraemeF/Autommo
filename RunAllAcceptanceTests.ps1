& msbuild .\Publish.csproj /p:Configuration=Release

if ($LastExitCode -eq 0)
{
    msbuild .\EndToEndTests\Autommo.EndToEndTests\Autommo.EndToEndTests.csproj /p:Configuration=Release /t:RunAcceptanceTests
}