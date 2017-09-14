using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;
using Multinerd.Extensions;

namespace Multinerd.Windows.Application
{
    [UsedImplicitly]
    public static class InstanceChecker
    {
        private static Mutex _instanceMutex;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindowAsync(HandleRef windowHandle, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr windowHandle);


        /// <summary>
        /// Use on OnStartup override
        /// protected override void OnStartup(StartupEventArgs e)
        /// {
        ///     base.OnStartup(e);
        ///     if (InstanceChecker.IsAppRunning(Process.GetCurrentProcess(), true))
        ///         Current.Shutdown(0);
        /// 
        ///     new MainWindow().Show();
        /// }
        /// </summary>
        [UsedImplicitly]
        public static bool IsAppRunning(Process app, bool bringToFront)
        {
            _instanceMutex = new Mutex(true, $@"Global\{app.ProcessName}", out var createdNew);
            if (!createdNew)
            {
                MessageBox.Show($"{app.ProcessName} is already running.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _instanceMutex = null;
                if (bringToFront)
                {
                    Process[] objProcesses = Process.GetProcessesByName(app.ProcessName);
                    if (objProcesses.Length > 0)
                    {
                        var hWnd = objProcesses[0].MainWindowHandle;
                        ShowWindowAsync(new HandleRef(null, hWnd), 3);
                        SetForegroundWindow(objProcesses[0].MainWindowHandle);
                    }
                }
                return true;
            }
            return false;
        }


        /// <summary>
        /// Use on OnExit override
        /// protected override void OnExit(ExitEventArgs e)
        /// {
        ///     InstanceChecker.Cleanup();
        ///     base.OnExit(e);
        /// } 
        /// </summary>
        [UsedImplicitly]
        public static void Cleanup()
        {
            _instanceMutex?.ReleaseMutex();
        }
    }
}
