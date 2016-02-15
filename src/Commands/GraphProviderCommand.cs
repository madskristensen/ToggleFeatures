using System;
using System.ComponentModel.Design;
using System.Windows.Forms;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace MadsKristensen.ToggleFeatures
{
    sealed class GraphProviderCommand
    {
        Package _package;
        const string _dword = "UseSolutionNavigatorGraphProvider";
        bool _isEnabled;

        GraphProviderCommand(Package package)
        {
            ServiceProvider = _package = package;

            var service = (OleMenuCommandService)ServiceProvider.GetService(typeof(IMenuCommandService));

            var cmdId = new CommandID(PackageGuids.guidToggleFeaturesCmdSet, PackageIds.ToggleGraphProvider);
            var button = new OleMenuCommand(ToggleFeature, cmdId);
            button.BeforeQueryStatus += BeforeQueryStatus;
            service.AddCommand(button);
        }

        public static GraphProviderCommand Instance { get; private set; }

        IServiceProvider ServiceProvider { get; }

        public static void Initialize(Package package)
        {
            Instance = new GraphProviderCommand(package);
        }

        void BeforeQueryStatus(object sender, EventArgs e)
        {
            var button = (OleMenuCommand)sender;

            var rawValue = _package.UserRegistryRoot.GetValue(_dword, 1);
            int value;

            int.TryParse(rawValue.ToString(), out value);

            _isEnabled = value != 0;
            button.Text = (_isEnabled ? "Disable " : "Enable ") + Vsix.Name;
        }

        void ToggleFeature(object sender, EventArgs e)
        {
            if (!_isEnabled)
            {
                _package.UserRegistryRoot.DeleteValue(_dword);
            }
            else
            {
                _package.UserRegistryRoot.SetValue(_dword, 0);
            }

            if (UserWantsToRestart(!_isEnabled))
            {
                RestartVS();
            }
        }

        void RestartVS()
        {
            var shell = (IVsShell4)ServiceProvider.GetService(typeof(SVsShell));
            shell.Restart((uint)__VSRESTARTTYPE.RESTART_Normal);
        }

        static bool UserWantsToRestart(bool willEnable)
        {
            string mode = willEnable ? "enabled" : "disabled";
            string text = $"Dynamic nodes have now been {mode}, but will not take effect before Visual Studio has been restarted.\r\rDo you wish to restart now?";
            return MessageBox.Show(text, Vsix.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}