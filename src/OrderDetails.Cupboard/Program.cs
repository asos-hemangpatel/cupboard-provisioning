
namespace OrderDetails.Cupboard
{
    using Catalog;
    using global::Cupboard;
    using Manifest;

    public static class Program
    {
        public static int Main(string[] args)
        {
            return CupboardHost.CreateBuilder()
                .AddCatalog<MyWindowsComputer>()
                .Run(args);
        }
        
        
    }
}