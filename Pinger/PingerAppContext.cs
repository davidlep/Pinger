using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Pinger
{
    public class PingerAppContext : ApplicationContext
    {
        private string AppVersion = "1.0";
        private NotifyIcon trayIcon;
        private Container components = new Container();

        public PingerAppContext()
        {
            var contextMenu = new ContextMenuStrip();
            
            var menuItemExit = new ToolStripMenuItem("Exit", null, (sender, e) => 
            {
                trayIcon.Visible = false;
                Application.Exit();
            });

            var menuItemSettings = new ToolStripMenuItem("Settings", null, (sender, e) =>
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(Settings.FileName)
                {
                    UseShellExecute = true
                };
                p.Start();
            });

            var menuItemRestart = new ToolStripMenuItem("Restart", null, (sender, e) =>
            {
                Application.Restart();
            });

            var menuItemViewData = new ToolStripMenuItem("View data", null, (sender, e) =>
            {
                var p = new Process();
                p.StartInfo = new ProcessStartInfo(Dataset.FileName)
                {
                    UseShellExecute = true
                };
                p.Start();
            });

            contextMenu.Items.AddRange(new[] { menuItemViewData, menuItemSettings, menuItemRestart, menuItemExit });

            trayIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = contextMenu,
                Icon = new System.Drawing.Icon("icon.ico"),
                Text = $"Pinger is collecting data! - Version {AppVersion}",
                Visible = true,
                BalloonTipText = "Pinger as started collecting data!"
            };

            trayIcon.ShowBalloonTip(3000);
        }
    }
}
