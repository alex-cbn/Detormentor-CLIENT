using Detormentor_CLIENT.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Detormentor_CLIENT.Services
{
    public class DBAccess
    {
        public class field
        {
            public string fakestring { get; set; }
        }
        readonly public SQLiteAsyncConnection database;
        public DBAccess(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<VoterItem>().Wait();
        }
        public Task<List<VoterItem>> GetAllVotersAsync()
        {
            return database.Table<VoterItem>().ToListAsync();
        }//selecteaza toti votantii
        public Task<List<VoterItem>> GetVotersByDept(string Deptname)
        {
            string qstring = "SELECT * FROM [VoterItem] WHERE [Departament] = '";
            qstring = qstring + Deptname;
            qstring = qstring + "'";
            return database.QueryAsync<VoterItem>(qstring);
        }//selecteaza votantii dupa departament
        public Task<List<field>> GetDepartamentsAsync()
        {
            return database.QueryAsync<field>("SELECT [Departament] FROM [VoterItem] GROUP BY");
        }
        public Task<VoterItem> GetItemAsync(string nume)
        {
            return database.Table<VoterItem>().Where(i => i.Nume == nume).FirstOrDefaultAsync();
        }
        public Task<VoterItem> GetItemAsync(int id)
        {
            return database.Table<VoterItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }
        public Task<int> UpdateAsync(List<VoterItem> voterlist)
        {
            return database.InsertAllAsync(voterlist);
        }
        public Task<int> CleanAsync()
        {
            return database.DropTableAsync<VoterItem>();
        }
        public void MakeTable()
        {
            database.CreateTableAsync<VoterItem>().Wait();
        }
    }   
}