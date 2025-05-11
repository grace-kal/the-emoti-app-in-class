using Microsoft.EntityFrameworkCore;
using MyEmotiApp.DataAccess;

namespace MyEmotiApp
{
    public partial class App : Application
    {
        public AppDbContext MyDbContext { get; set; }
        public UserRepo UserRepo { get; set; }
        public App()
        {
            InitializeComponent();
            string? connectionString =
                "Server=localhost;Database=MyEmotiDb;Trusted_Connection=True;TrustServerCertificate=True;";

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            MyDbContext = new AppDbContext(optionsBuilder.Options);
            UserRepo = new UserRepo(MyDbContext);

            // Set the MainPage
            MainPage = new AppShell();
        }
    }
}
