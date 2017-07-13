#define MyAppExePath "src\EgamiFlowScreensaver\bin\Windows\Release\Natsnudasoft.EgamiFlowScreensaver.exe"
#define MyAppName "Egami Flow Screensaver"
#define MyAppVersion GetFileVersion("src\EgamiFlowScreensaver\bin\Windows\Release\Natsnudasoft.EgamiFlowScreensaver.exe")
#define MyAppPublisher "natsnudasoft"
#define MyAppURL "https://github.com/natsnudasoft"

[Setup]
AppId={{2C8AC148-6052-45D2-9725-1411B8903B98}
ArchitecturesInstallIn64BitMode=x64
AppName={#MyAppName}
AppVersion={#MyAppVersion}
VersionInfoVersion={#MyAppVersion}
AppVerName={#MyAppName} v{#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
AppSupportURL={#MyAppURL}
AppUpdatesURL={#MyAppURL}
CreateAppDir=no
OutputBaseFilename="Egami Flow Screensaver"
Compression=lzma
SolidCompression=yes

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Files]
Source: "src\EgamiFlowScreensaver\bin\Windows\Release\Natsnudasoft.EgamiFlowScreensaver.exe"; DestDir: "{sys}"; DestName: "EgamiFlowScreensaver.scr"

[UninstallDelete]
Type: filesandordirs; Name: "{userappdata}\EgamiFlowScreensaver\images"
Type: filesandordirs; Name: "{userappdata}\EgamiFlowScreensaver\logs"
Type: files; Name: "{userappdata}\EgamiFlowScreensaver\background.*"
Type: files; Name: "{userappdata}\EgamiFlowScreensaver\settings.cfg"
Type: dirifempty; Name: "{userappdata}\EgamiFlowScreensaver"