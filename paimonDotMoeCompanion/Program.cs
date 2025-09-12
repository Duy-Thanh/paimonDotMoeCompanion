using OSVersionExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace paimonDotMoeCompanion
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Check Operating System section
            // 
            // We only have rounded corners (actually is uDWM hack) on Windows 11
            // On earlier OS version, we need to apply our custom rounded corner
            // that defined in EllipseControl.cs
            //
            // To check Windows version, we use OSCheckExt from NuGet package
            // manager
            // 
            // So, we have these cases:
            //
            // Case 1: If users have Windows 11: Let's use native uDWM hack (inside
            //         dwmapi.dll) and opt in system rounded corners
            // 
            // Case 2: If users doesn't have Windows 11: We need to create 
            //         custom interface to enable rounded corners that defined
            //         in EllipseControl.cs then enable them in Form1.cs
            // 
            // Note that on Windows Server 2022, we still doesn't have uDWM hack,
            // actually uDWM hack exists only on Windows 11. So if we detected
            // Windows Server Edition, we have to use our custom rounded corners
            // defined in EllipseControl.cs to enable rounded corners effect
            //
            // 9/3/2024

            OSVersionExtension.OperatingSystem osFetchData = OSVersion.GetOperatingSystem();

            // Windows 11 detected
            if (osFetchData == OSVersionExtension.OperatingSystem.Windows11)
            {
                Application.Run(new Form1(true));
            }
            else
            {
                Application.Run(new Form1(false));
            }
        }
    }
}
