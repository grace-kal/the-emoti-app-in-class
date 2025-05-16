using Microsoft.EntityFrameworkCore;
using MyEmotiApp.DataAccess;

namespace MyEmotiApp
{
    public partial class App : Application
    {
        public static AppDbContext MyDbContext { get; set; }
        public static UserRepo UserRepo { get; set; }
        public App()
        {
            InitializeComponent();
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "MyEmotiDb.db");

            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite($"Filename={dbPath}");

            MyDbContext = new AppDbContext(optionsBuilder.Options);
            MyDbContext.Database.EnsureCreated();

            UserRepo = new UserRepo(MyDbContext);

            // Set the MainPage
            MainPage = new AppShell();
        }
    }
}
