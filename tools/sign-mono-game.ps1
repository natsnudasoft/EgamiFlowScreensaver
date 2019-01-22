# Sign MonoGame.Framework.dll
IF (-Not (Test-Path Env:\APPVEYOR_PULL_REQUEST_NUMBER)) {
    Write-Output "Signing Monogame.Framework.dll with Natsnudasoft.snk..."
    $monoGameDllPath = Get-ChildItem $PSScriptRoot\..\packages\MonoGame.Framework.WindowsDX.*\lib\net45\MonoGame.Framework.dll
    $keyFilePath = "$PSScriptRoot\..\Natsnudasoft.snk"
    Start-Process $PSScriptRoot\..\Brutal.Dev.StrongNameSigner\build\StrongNameSigner.Console.exe -ArgumentList "-a $monoGameDllPath -k $keyFilePath" -NoNewWindow -Wait
}