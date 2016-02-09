using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;

namespace MadsKristensen.ToggleFeatures
{
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", Version, IconResourceID = 400)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [ProvideAutoLoad(UIContextGuids80.NoSolution)]
    [Guid(PackageGuids.guidToggleFeaturesPkgString)]
    public sealed class VSPackage : Package
    {
        public const string Version = "1.0";
        public const string Name = "Toggle Features";

        protected override void Initialize()
        {
            base.Initialize();

            GraphProviderCommand.Initialize(this);
        }
    }
}
