param(
    [string]$SPTPath = 'E:\Games\SPT 4.1',

    [ValidateSet('Debug', 'Release')]
    [string]$Configuration = 'Release',

    [switch]$InstallBepInExPlugin
)

$ErrorActionPreference = 'Stop'

if (-not (Test-Path "$SPTPath\EscapeFromTarkov_Data\Managed\Assembly-CSharp.dll")) {
    throw "SPT not found at '$SPTPath'"
}

dotnet build "$PSScriptRoot\DontCollectMyGarbage.csproj" -c $Configuration -p:SPTPath="$SPTPath" -p:InstallBepInExPlugin=$($InstallBepInExPlugin.IsPresent)
if ($LASTEXITCODE -ne 0) { throw "dotnet build failed ($LASTEXITCODE)" }