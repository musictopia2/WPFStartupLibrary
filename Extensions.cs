namespace WPFStartupLibrary;
public static class Extensions
{
    public static void RegisterWPFServices(this IServiceCollection services)
    {

        services.AddSingleton<CustomWindowsClasses>();
        services.AddSingleton<IExit>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        services.AddSingleton<IMessageBox>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        services.AddSingleton<ISystemError>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        aa.OS = aa.EnumOS.WindowsDT;
        UIPlatform.DesktopValidationError = (message) => MessageBox.Show(message);
        UIPlatform.CurrentThread = new WPFThread();
    }
}