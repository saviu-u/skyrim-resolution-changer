using IniParser;
using IniParser.Model;

namespace SkyrimResolutionChanger.Lib
{
  class ExternalInformation
  {
    public static string INI_PATH = "skyrim_resolution_changer.ini";

    public string ExecutablePath { get; private set; } = "";
    public string SkyrimPrefsPath { get; private set; } = "";
    private readonly IniData iniData;

    public ExternalInformation()
    {
      if(!File.Exists(INI_PATH)) CreateIniFile();

      iniData = new FileIniDataParser().ReadFile(INI_PATH);

      RefreshValues();
    }

    public void RefreshValues(){
      ExecutablePath = iniData["Paths"]["ExecutablePath"].ToString().Trim('"');
      SkyrimPrefsPath = iniData["Paths"]["SkyrimPrefsPath"].ToString().Trim('"');
    }

    private void CreateIniFile(){
      using var stream = typeof(Program).Assembly.GetManifestResourceStream("SkyrimResolutionChanger.assets.skyrim_resolution_changer.ini");
      using var reader = new StreamReader(stream!);

      File.WriteAllText(INI_PATH, reader.ReadToEnd());

      Console.WriteLine("skyrim_resolution_changer.ini file created");
    }
  }
}