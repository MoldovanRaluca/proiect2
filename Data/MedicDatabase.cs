using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;
using proiect2.Models;

namespace proiect2.Data
{
    public class MedicDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public MedicDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Medic>().Wait();
        }

        public Task<List<Medic>> GetMediciAsync()
        {
            return _database.Table<Medic>().ToListAsync();
        }

        public Task<Medic> GetMedicAsync(int id)
        {
            return _database.Table<Medic>()
                            .Where(medic => medic.ID == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveMedicAsync(Medic medic)
        {
            if (medic.ID != 0)
            {
                return _database.UpdateAsync(medic);
            }
            else
            {
                return _database.InsertAsync(medic);
            }
        }

        public Task<int> DeleteMedicAsync(Medic medic)
        {
            return _database.DeleteAsync(medic);
        }
    }
}
