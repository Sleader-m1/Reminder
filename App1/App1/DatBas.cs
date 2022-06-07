using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using AffairNamesps;


namespace DatBasNsp
{
    public class DatBas
    {
        readonly SQLiteAsyncConnection db;

        public DatBas(){}

        public DatBas(string connString)
        {
            db = new SQLiteAsyncConnection(connString);

            db.CreateTableAsync<Affair>().Wait();
        }

        public Task<List<Affair>> GetAffairsAsync()
        {
            return db.Table<Affair>().ToListAsync();
        }

        public Task<Affair> GetAffairAsync(int id)
        {
            return db.Table<Affair>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveAffairAsync(Affair affair)
        {
            if(affair.Id != 0)
            {
                return db.UpdateAsync(affair);
            }
            else
            {
                return db.InsertAsync(affair);
            }
        }

        public Task<int> DeleteAffairAsync(Affair affair)
        {
            return db.DeleteAsync(affair);
        }
    }
}