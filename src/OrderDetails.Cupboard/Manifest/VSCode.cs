namespace OrderDetails.Cupboard.Manifest
{
    using System.Collections.Generic;
    using global::Cupboard;

    public sealed class VSCode : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            var packages = new List<string>
            {
                "ms-vscode.powershell",
                "ms-azuretools.vscode-docker",
                "ms-vscode-remote.remote-wsl",
                "vscode-icons-team.vscode-icons",
                "hediet.vscode-drawio",
                "vscode-azurerm-tools",
                "azurefunctions-vscode",
                "vscode-csharp"
            };
            
            context.Resource<ChocolateyPackage>("vscode")
                .Ensure(PackageState.Installed)
                .After<PowerShell>("Install Chocolatey");
            
            foreach (var package in packages)
            {
                context.Resource<VSCodeExtension>(package)
                    .Ensure(PackageState.Installed)
                    .After<ChocolateyPackage>("vscode");
            }
        }
    }
}