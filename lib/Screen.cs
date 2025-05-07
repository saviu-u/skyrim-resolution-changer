using System;
using System.Windows.Forms;

namespace SkyrimResolutionChanger.Lib
{
  class Screen{
    public UInt16 Width { get; private set; }
    public UInt16 Height { get; private set; }

    public Screen() {
      RefreshScreenValues();
    }

    private void RefreshScreenValues(){
      UInt16? height = (ushort?)(System.Windows.Forms.Screen.PrimaryScreen?.Bounds.Height) ?? throw new Exception("Unable to get screen height.");
      UInt16? width = (ushort?)(System.Windows.Forms.Screen.PrimaryScreen?.Bounds.Width) ?? throw new Exception("Unable to get screen width.");

      this.Height = (UInt16)height;
      this.Width = (UInt16)width;
    }
  }
}