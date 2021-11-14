namespace WPFStartupLibrary;
public class CustomWindowsClasses : IExit, ISystemError, IMessageBox
{
    void IExit.ExitApp()
    {
        Application.Current.Shutdown();
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