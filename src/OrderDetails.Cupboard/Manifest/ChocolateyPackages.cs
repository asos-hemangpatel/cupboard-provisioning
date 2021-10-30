namespace OrderDetails.Cupboard.Manifest
{
    using global::Cupboard;

    public sealed class ChocolateyPackages : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            foreach (var package in new[] { 
                "servicebusexplorer", 
                "repoz", 
                "terraform", 
                "golang",
                "azure-cli",
                "linqpad6",
                "dotnet-sdk",
                "dotnetcore",
                "jetbrains-rider",
                "resharper"
            })
            {
                context.Resource<ChocolateyPackage>(package)
                    .Ensure(PackageState.Installed)
                    .After<PowerShell>("Install Chocolatey");
            }
        }
    }
}