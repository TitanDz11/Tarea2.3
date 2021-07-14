using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TareaCamara
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<imagenes>().Wait();
        }

        //Insert and Update new record
        public Task<int> SaveItemAsync(imagenes imagene)
        {
            if (imagene.CodigoID != 0)
            {
                return db.UpdateAsync(imagene);
            }
            else
            {
                return db.InsertAsync(imagene);
            }
        }

        //Delete
        public Task<int> DeleteItemAsync(imagenes imagene)
        {
            return db.DeleteAsync(imagene);
        }

        //Read All Items
        public Task<List<imagenes>> GetItemsAsync()
        {
            return db.Table<imagenes>().ToListAsync();
        }


        //Read Item
        public Task<imagenes> GetItemAsync(int CodigID)
        {
            return db.Table<imagenes>().Where(i => i.CodigoID == CodigID).FirstOrDefaultAsync();
        }
    }
}