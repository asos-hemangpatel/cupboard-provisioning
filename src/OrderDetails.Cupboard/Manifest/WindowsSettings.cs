namespace OrderDetails.Cupboard.Manifest
{
    using global::Cupboard;

    public class WindowsSettings : Manifest
    {
        public override void Execute(ManifestContext context)
        {
            // File Explorer options
            context.Resource<RegistryValue>("Show hidden files in File Explorer")
                .Path(@"HKCU:\Software\Microsoft\Windows\CurrentVersion\Explorer\Advanced")
                .Value("Hidden")
                .Data(1, RegistryValueKind.DWord);
        }
    }
}