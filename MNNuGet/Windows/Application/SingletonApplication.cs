using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Multinerd.Windows.Application
{
    public static class SingletonApplication
    {
        private static Mutex _instanceMutex = null;

        private static Process _instanceProcess = null;

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindowAsync(HandleRef windowHandle, int nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SetForegroundWindow(IntPtr windowHandle);


        public static bool IsAppRunning(Process app, bool bringToFront)
        {
            _instanceProcess = app;
            _instanceMutex = new Mutex(true, $@"Global\{_instanceProcess.ProcessName}", out var createdNew);
            if (!createdNew)
            {
                MessageBox.Show($"{_instanceProcess.ProcessName} is already running.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                _instanceMutex = null;
                if (bringToFront)
                {
                    Process[] objProcesses = Process.GetProcessesByName(_instanceProcess.ProcessName);
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



        public static void Cleanup()
        {
            _instanceMutex?.ReleaseMutex();
        }
    }
}
