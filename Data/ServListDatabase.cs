using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using proiect2.Models;

namespace proiect2.Data
{
    public class ServListDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ServListDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ServList>().Wait();
            _database.CreateTableAsync<Servicii>().Wait();
            _database.CreateTableAsync<ListServicii>().Wait();
            _database.CreateTableAsync<Review>().Wait();
        }
        public Task<int> SaveProductAsync(Servicii servicii)
        {
            if (servicii.ID != 0)
            {
                return _database.UpdateAsync(servicii);
            }
            else
            {
                return _database.InsertAsync(servicii);
            }
        }
        public Task<int> DeleteProductAsync(Servicii servicii)
        {
            return _database.DeleteAsync(servicii);
        }
        public Task<List<Servicii>> GetProductsAsync()
        {
            return _database.Table<Servicii>().ToListAsync();
        }
        public Task<List<ServList>> GetShopListsAsync()
        {
            return _database.Table<ServList>().ToListAsync();
        }
        public Task<ServList> GetShopListAsync(int id)
        {
            return _database.Table<ServList>()
            .Where(i => i.ID == id)
           .FirstOrDefaultAsync();
        }
        public Task<int> SaveShopListAsync(ServList slist)
        {
            if (slist.ID != 0)
            {
                return _database.UpdateAsync(slist);
            }
            else
            {
                return _database.InsertAsync(slist);
            }
        }
        public Task<int> DeleteShopListAsync(ServList slist)
        {
            return _database.DeleteAsync(slist);
        }
        public Task<int> SaveListProductAsync(ListServicii listp)
        {
            if (listp.ID != 0)
            {
                return _database.UpdateAsync(listp);
            }
            else
            {
                return _database.InsertAsync(listp);
            }
        }
        public Task<List<Servicii>> GetListProductsAsync(int shoplistid)
        {
            return _database.QueryAsync<Servicii>(
            "select P.ID, P.Description from Servicii P"
            + " inner join ListServicii LP"
            + " on P.ID = LP.ServiciiID where LP.ServListID = ?",
            shoplistid);
        }
        public Task<List<Review>> GetReviewsAsync()
        {
            return _database.Table<Review>().ToListAsync();
        }

        public Task<int> SaveReviewAsync(Review review)
        {
            if (review.ID != 0)
            {
                return _database.UpdateAsync(review);
            }
            else
            {
                return _database.InsertAsync(review);
            }
        }
        public Task<int> DeleteReviewAsync(Review review)
        {
            return _database.DeleteAsync(review);
        }
        
    }

}


    
