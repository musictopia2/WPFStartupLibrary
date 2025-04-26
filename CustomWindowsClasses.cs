namespace WPFStartupLibrary;
public class CustomWindowsClasses : ILayout, IWindowStateManager
{
    //something can require a window to set here.
    public static Window? MainWindow { get; set; }
    public StartLayout? Layout { get; set; }
    bool IWindowStateManager.IsMinimized { get; }
    void IExit.ExitApp()
    {
        Application.Current.Shutdown();
    }
    void IWindowStateManager.MinimizeWindow()
    {
        if (MainWindow is not null)
        {
            MainWindow.WindowState = WindowState.Minimized;
        }
    }

    void IWindowStateManager.RestoreWindow()
    {
        if (MainWindow is not null && MainWindow.WindowState == WindowState.Minimized)
        {
            MainWindow.WindowState = WindowState.Normal;
            MainWindow.Activate();
        }
    }

    Task IMessageBox.ShowMessageAsync(string message)
    {
        MessageBox.Show(message); //use old fashioned messageboxes.
        return Task.CompletedTask;
    }
    void ISystemError.ShowSystemError(string message)
    {
        MessageBox.Show($"There was an error.  The message was {message}.");
        Application.Current.Shutdown();
    }
}