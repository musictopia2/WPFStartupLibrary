namespace WPFStartupLibrary;
public static class SingleInstanceAppEnforcer
{
    private static Mutex? _mutex;
    private static bool _ownsMutex = false;

    public static bool Initialize(string mutexName)
    {
        _mutex = new Mutex(true, mutexName, out bool createdNew);
        _ownsMutex = createdNew;

        if (!_ownsMutex)
        {
            MessageBox.Show(
                "Another version of this app is already running. Please close it before starting this one.",
                "App already running",
                MessageBoxButton.OK,
                MessageBoxImage.Warning);
            return false;
        }

        return true;
    }

    public static void Cleanup()
    {
        if (_mutex != null && _ownsMutex)
        {
            _mutex.ReleaseMutex();
        }
        _mutex = null;
    }
}