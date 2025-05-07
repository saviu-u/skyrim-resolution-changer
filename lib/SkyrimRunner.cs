using System.IO;

namespace SkyrimResolutionChanger.Lib
{
  public class SkyrimRunner(string executablePath)
  {
    public string ExecutablePath { get; private set; } = Path.GetFullPath(executablePath);

    public void Run(){
      if(!File.Exists(ExecutablePath)) throw new FileNotFoundException($"Executable file not found: {ExecutablePath}");

      System.Diagnostics.Process.Start(ExecutablePath);
    }
  }
}