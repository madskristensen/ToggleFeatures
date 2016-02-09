namespace MadsKristensen.ToggleFeatures
{
    using System;
    
    /// <summary>
    /// Helper class that exposes all GUIDs used across VS Package.
    /// </summary>
    internal sealed partial class PackageGuids
    {
        public const string guidToggleFeaturesPkgString = "4ce74140-3f68-4438-92a4-a54afea98179";
        public const string guidToggleFeaturesCmdSetString = "53667d07-cf71-4f9b-b867-ec0f007418ee";
        public const string guidImagesString = "53667d07-cf71-4f9b-b867-ec0f007418ef";
        public static Guid guidToggleFeaturesPkg = new Guid(guidToggleFeaturesPkgString);
        public static Guid guidToggleFeaturesCmdSet = new Guid(guidToggleFeaturesCmdSetString);
        public static Guid guidImages = new Guid(guidImagesString);
    }
    /// <summary>
    /// Helper class that encapsulates all CommandIDs uses across VS Package.
    /// </summary>
    internal sealed partial class PackageIds
    {
        public const int ToggleGraphProvider = 0x0100;
        public const int GraphProvider = 0x0001;
    }
}
