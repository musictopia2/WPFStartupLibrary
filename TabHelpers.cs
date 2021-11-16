using System.Windows.Forms;
namespace WPFStartupLibrary;
public static class TabHelpers
{
    public static void StartTabProcesses()
    {
        SendKeys.SendWait("{TAB}");
    }
}