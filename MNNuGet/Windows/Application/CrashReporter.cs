using System;
using System.Diagnostics;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Windows.Threading;
using Multinerd.Extensions;
using Multinerd.Windows.Application.CrashReporterDotNET;

namespace Multinerd.Windows.Application
{
    /// <summary>
    ///  AppDomain.CurrentDomain.UnhandledException += CrashReporter.CurrentDomainOnUnhandledException; // From all threads in the AppDomain.
    ///  Dispatcher.UnhandledException += CrashReporter.Dispatcher_UnhandledException; // From a single specific UI dispatcher thread.
    ///  Current.DispatcherUnhandledException += CrashReporter.CurrentOnDispatcherUnhandledException; // From the main UI dispatcher thread in your WPF application.
    /// </summary>
    public static class CrashReporter
    {
        private static string CurrentUser => UserPrincipal.Current.DisplayName;

        private static string _fromEmail;
        private static string _toEmail;
        private static string _password;
        private static int _port;
        private static string _host;

        [UsedImplicitly]
        public static void SetupCrashReporter(string from, string to, string pass, int port, string host)
        {
            _fromEmail = from;
            _toEmail = to;
            _password = pass;
            _port = port;
            _host = host;
        }

        //[UsedImplicitly]
        //public static void SetupCrashReporter(System.Windows.Application app)
        //{
        //    //if (!Debugger.IsAttached)
        //    //{
        //    //    AppDomain.CurrentDomain.UnhandledException += CurrentDomainOnUnhandledException; // From all threads in the AppDomain.
        //    //    app.Dispatcher.UnhandledException += Dispatcher_UnhandledException; // From a single specific UI dispatcher thread.
        //    //    app.DispatcherUnhandledException += CurrentOnDispatcherUnhandledException; // From the main UI dispatcher thread in your WPF application.
        //    //}
        //}

        [UsedImplicitly]
        public static void CurrentDomainOnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ReportCrash((Exception)e.ExceptionObject);
            Environment.Exit(0);
        }

        [UsedImplicitly]
        public static void Dispatcher_UnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ReportCrash(e.Exception);
            Environment.Exit(0);
        }

        [UsedImplicitly]
        public static void CurrentOnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            ReportCrash(e.Exception);
            Environment.Exit(0);
        }


        private static void ReportCrash(Exception exception)
        {
            var reportCrash = new ReportCrash
            {
                FromEmail = _fromEmail,
                ToEmail = _toEmail,
                Password = _password,
                Port = _port,
                SmtpHost = _host,
                UserName = _fromEmail,
                CaptureScreen = true,
                CurrentCulture = CultureInfo.CurrentCulture,
                DeveloperMessage = $"User: {CurrentUser}",
                EmailRequired = false,
                EnableSSL = true,
                Exception = exception,
                IncludeScreenshot = true,
            };
            reportCrash.Send(exception);
        }

    }
}
