namespace OrderDetails.Cupboard.Catalog
{
    using global::Cupboard;
    using Manifest;

    public sealed class MyWindowsComputer : Catalog
    {
        public override void Execute(CatalogContext context)
        {
            if (!context.Facts.IsWindows())
            {
                return;
            }

            context.UseManifest<Chocolatey>();
            context.UseManifest<ChocolateyPackages>();
            context.UseManifest<WindowsSettings>();
            context.UseManifest<VSCode>();
        }
    }
}