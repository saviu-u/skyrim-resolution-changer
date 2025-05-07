using System.Diagnostics;
using System.Runtime.InteropServices;

namespace SkyrimResolutionChanger
{
  class Program
  {
    //// Start Terminal configuration

    // Safe to ignore this warning, this build is just for Windows.
    #pragma warning disable SYSLIB1054
    // AttachConsole is used to attach the console to the parent process, so we can use Console.WriteLine
    // to print messages to the console when running from a terminal.
    [DllImport("kernel32.dll")]
    static extern bool AttachConsole(int dwProcessId);
    #pragma warning restore SYSLIB1054

    const int ATTACH_PARENT_PROCESS = -1;

    //// Finish Terminal configuration

    //// Start DPI Awareness configuration
     
    [DllImport("user32.dll")]
    private static extern bool SetProcessDPIAware();

    //// Finish DPI Awareness configuration

    static void Main(string[] args)
    {
      ConfigureWindowsDlls();

      Console.WriteLine("Skyrim Resolution Changer 0.0.1");

      Lib.Screen screen = new();
      Lib.ExternalInformation externalInformation = new();
      Lib.SkyrimPrefsWrapper skyrimPrefs = new(externalInformation.SkyrimPrefsPath);

      Console.WriteLine($"Screen Width: {screen.Width}");
      Console.WriteLine($"Screen Height: {screen.Height}");

      skyrimPrefs.SetResolution(screen.Width, screen.Height);
      skyrimPrefs.PersistChanges();

      Console.WriteLine($"SkyrimPrefs file updated: {skyrimPrefs.FilePath}");
      Process.Start(externalInformation.ExecutablePath);
    }

    static void ConfigureWindowsDlls(){
      // Attach to console if run from terminal
      AttachConsole(ATTACH_PARENT_PROCESS);

      // Set DPI awareness to avoid scaling issues (E.G. If you have a 4k monitor and use 200% scaling, this will save you)
      SetProcessDPIAware();
    }
  }
}