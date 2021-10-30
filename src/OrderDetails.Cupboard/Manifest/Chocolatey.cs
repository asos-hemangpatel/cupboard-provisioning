namespace OrderDetails.Cupboard.Manifest
{
    using global::Cupboard;

    public sealed partial class Chocolatey : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            // Download
            context.Resource<Download>("https://chocolatey.org/install.ps1")
                .ToFile("~/install-chocolatey.ps1");

            // Set execution policy
            context.Resource<RegistryValue>("Set execution policy")
                .Path(@"HKLM:\SOFTWARE\Microsoft\PowerShell\1\ShellIds\Microsoft.PowerShell")
                .Value("ExecutionPolicy")
                .Data("Unrestricted", RegistryValueKind.String);

            // Install
            context.Resource<PowerShell>("Install Chocolatey")
                .Script("~/install-chocolatey.ps1")
                .Flavor(PowerShellFlavor.PowerShell)
                .RequireAdministrator()
                .Unless("if (Test-Path \"$($env:ProgramData)/chocolatey/choco.exe\") { exit 1 }")
                .After<RegistryValue>("Set execution policy")
                .After<Download>("https://chocolatey.org/install.ps1");

            // Install VSCode via Chocolatey
            context.Resource<ChocolateyPackage>("vscode")
                .Ensure(PackageState.Installed)
                .After<PowerShell>("Install Chocolatey");
        }
    }
}