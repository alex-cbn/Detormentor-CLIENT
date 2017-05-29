using Detormentor_CLIENT.Models;
using Detormentor_CLIENT.ViewModel;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detormentor_CLIENT.DataServices
{
    public class PollsDB
    {
        readonly public SQLiteAsyncConnection database;
        public PollsDB(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PollDescription>().Wait();
        }
        public Task<List<PollDescription>> GetAllPollsAsync()
        {
            return database.Table<PollDescription>().ToListAsync();
        }
        public Task<int> InsertAsync(PollDescription one)
        {
            return database.InsertAsync(one);
        }
        public Task<int> CleanAsync()
        {
            return database.DropTableAsync<PollDescription>();
        }
    }
}
