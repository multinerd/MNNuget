using System;
using System.Deployment.Application;
using System.Diagnostics;
using System.Reflection;

namespace Multinerd.Extensions
{
    public static class ApplicationExt
    {
        [Obsolete("This class has been deprecated and moved to 'Project Maya'.\n Please reference that project instead.")]
        public static string CurrentVersion()
        {
            var fileName = Assembly.GetExecutingAssembly().Location;
            if (fileName != null)
                return System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed
                    ? ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString()
                    : FileVersionInfo.GetVersionInfo(fileName).ProductVersion;
            return "n/a";
        }

    }
}
