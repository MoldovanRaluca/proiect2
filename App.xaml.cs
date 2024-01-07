using System;
using proiect2.Data;
using System.IO;
namespace proiect2
{
    public partial class App : Application
    {
        static ServListDatabase database;
        public static ServListDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                   ServListDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                   LocalApplicationData), "ShoppingList.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}