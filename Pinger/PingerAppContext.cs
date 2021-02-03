using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;

namespace Pinger
{
    public class PingerAppContext : ApplicationContext
    {
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
                Process.Start(Settings.FileName);
            });

            var menuItemViewData = new ToolStripMenuItem("View data", null, (sender, e) =>
            {
                Process.Start(Dataset.FileName);
            });

            contextMenu.Items.AddRange(new[] { menuItemViewData, menuItemSettings, menuItemExit });

            trayIcon = new NotifyIcon(components)
            {
                ContextMenuStrip = contextMenu,
                Icon = new System.Drawing.Icon("icon.ico"),
                Text = "Pinger is collecting data!",
                Visible = true
            };
        }
    }
}
