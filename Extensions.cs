﻿namespace WPFStartupLibrary;
public static class Extensions
{
    public static void RegisterWPFServices(this IServiceCollection services)
    {
        CustomWindowsClasses windows = new();
        //not important that its a different reference.
        BasicBlazorLibrary.Helpers.BlazorUIHelpers.MessageBox = windows;
        BasicBlazorLibrary.Helpers.BlazorUIHelpers.SystemError = windows;
        services.AddSingleton<CustomWindowsClasses>();
        services.AddSingleton<ILayout>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        services.AddSingleton<IExit>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        services.AddSingleton<IMessageBox>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        services.AddSingleton<ISystemError>(xx => xx.GetRequiredService<CustomWindowsClasses>());
        aa1.OS = aa1.EnumOS.WindowsDT;
        UIPlatform.DesktopValidationError = (message) => MessageBox.Show(message);
        UIPlatform.CurrentThread = new WPFThread();
    }
    public static void RegisterFullScreen(this Window window)
    {
        mm1.ProcessFullScreen = () =>
        {
            window.WindowStyle = WindowStyle.None;
            window.WindowState = WindowState.Maximized;
        };
    }
}