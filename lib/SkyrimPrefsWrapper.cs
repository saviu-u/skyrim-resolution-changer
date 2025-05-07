using System.Text.RegularExpressions;
using IniParser;
using IniParser.Model;

namespace SkyrimResolutionChanger.Lib{
  public partial class SkyrimPrefsWrapper
  {
    private readonly FileIniDataParser iniParser;
    private readonly IniData iniData;
    public string FilePath { get; private set; }

    public SkyrimPrefsWrapper(string skyrimPrefsPath)
    {
      FilePath = ExtractFullPath(skyrimPrefsPath);
      if(!File.Exists(FilePath)) throw new FileNotFoundException($"SkyrimPrefs file not found: {FilePath}");

      iniParser = new FileIniDataParser();
      SetupParserConfiguration();

      iniData = iniParser.ReadFile(FilePath);
    }

    public void SetResolution(int width, int height)
    {
      iniData["Display"]["iSize H"] = height.ToString();
      iniData["Display"]["iSize W"] = width.ToString();
    }

    public void PersistChanges()
    {
      File.WriteAllText(
        FilePath,
        FormatSpecificSkyrimIniFormat(iniData)
      );
    }

    // Is this needed? I don't think so.
    // But Skyrim .ini files are a mess in general, this is the way they already do, this is the way I will do it.
    private void SetupParserConfiguration()
    {
      iniParser.Parser.Configuration.AssigmentSpacer = ""; // No space between key and value
    }

    // Static

    // INI files, different from JSON, don't have a standard format. The Skyrim .ini files are not standard INI files.
    // They have a specific format that is not compatible with the INI standard.
    //
    // For example, you CANNOT have empty lines between sections, so we have to manually remove them, the INI parser doesn't do that.
    private static string FormatSpecificSkyrimIniFormat(IniData iniData){
      return DoubleNewLineRegex().Replace(iniData.ToString(), "\n"); // Remove empty lines between sections
    }

    // In general, we want to keep the files at the same place on the documents folder, this is just an option if you
    // are using any trickery or mod manager that changes the location of the .ini files.
    private static string ExtractFullPath(string relativePath)
    {
      return Path.IsPathRooted(relativePath) ?
        relativePath :
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), relativePath);
    }

    [GeneratedRegex(@"(\r?\n){2,}")]
    private static partial Regex DoubleNewLineRegex();
  }
}