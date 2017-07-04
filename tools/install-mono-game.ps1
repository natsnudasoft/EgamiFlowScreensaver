# Install MonoGame
Write-Output "Downloading MonoGame..."
(New-Object Net.WebClient).DownloadFile('http://www.monogame.net/releases/v3.6/MonoGameSetup.exe', 'C:\MonoGameSetup.exe')
Write-Output "Installing MonoGame..."
Invoke-Command -ScriptBlock {C:\MonoGameSetup.exe /S /v/qn}
