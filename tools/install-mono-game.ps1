# Install MonoGame
Write-Output "Downloading MonoGame..."
(New-Object Net.WebClient).DownloadFile('https://github.com/MonoGame/MonoGame/releases/download/v3.7.1/MonoGameSetup.exe', 'C:\MonoGameSetup.exe')
Write-Output "Installing MonoGame..."
Invoke-Command -ScriptBlock {C:\MonoGameSetup.exe /S /v/qn}
