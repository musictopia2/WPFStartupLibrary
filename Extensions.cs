namespace WPFStartupLibrary;
public static class Extensions
{
    extension (IServiceCollection services)
    {
        public void RegisterWPFServices()
        {
            CustomWindowsClasses windows = new();
            //not important that its a different reference.
            BasicBlazorLibrary.Helpers.BlazorUIHelpers.MessageBox = windows;
            BasicBlazorLibrary.Helpers.BlazorUIHelpers.SystemError = windows;
            BasicBlazorLibrary.Helpers.BlazorUIHelpers.Exit = windows;
            services.AddSingleton<CustomWindowsClasses>();
            services.AddSingleton<ILayout>(xx => xx.GetRequiredService<CustomWindowsClasses>());
            services.AddSingleton<IExit>(xx => xx.GetRequiredService<CustomWindowsClasses>());
            services.AddSingleton<IMessageBox>(xx => xx.GetRequiredService<CustomWindowsClasses>());
            services.AddSingleton<ISystemError>(xx => xx.GetRequiredService<CustomWindowsClasses>());
            services.AddSingleton<IWindowStateManager>(xx => xx.GetRequiredService<CustomWindowsClasses>());
            aa1.OS = aa1.EnumOS.WindowsDT;
            UIPlatform.DesktopValidationError = (message) => MessageBox.Show(message);
            UIPlatform.CurrentThread = new WPFThread();
        }
    }
    extension(Window window)
    {
        public void RegisterFullScreen()
        {
            mm1.ProcessFullScreen = () =>
            {
                window.WindowStyle = WindowStyle.None;
                window.WindowState = WindowState.Maximized;
            };
        }
    }
}