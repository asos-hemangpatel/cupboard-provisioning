namespace OrderDetails.Cupboard.Manifest
{
    using global::Cupboard;

    public sealed class ChocolateyPackages : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            foreach (var package in new[] { 
                "servicebusexplorer",
                "microsoftazurestorageexplorer",
                "azure-cosmosdb-emulator",
                "azurestorageemulator",
                "repoz", 
                "terraform", 
                "golang",
                "azure-cli",
                "linqpad6",
                "dotnet-sdk",
                "dotnetcore",
                "jetbrains-rider",
                "resharper",
                "dotnetfx",
                "dotnet4.6",
                "windows-sdk-10.0",
                "visualstudio2022professional",
                "postman",
                "docker-desktop",
                "az.powershell"
            })
            {
                context.Resource<ChocolateyPackage>(package)
                    .Ensure(PackageState.Installed)
                    .After<PowerShell>("Install Chocolatey");
            }
        }
    }
}