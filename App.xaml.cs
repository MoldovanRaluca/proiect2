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
        static MedicDatabase databasem;
        public static MedicDatabase Databasem
        {
            get
            {
                if (databasem == null)
                {
                    // Nume diferit de fișier pentru a doua bază de date
                    databasem = new MedicDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MedicDatabase.db"));
                }
                return databasem;
            }
        }
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}