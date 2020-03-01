using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.Console
{
    public class DataStorageSQL: IDataStorage
    {
        public Dictionary<int,string> DBSQL { get; }
        public int Count { get; set; }

        public DataStorageSQL()
        {
            Count = 0;
            DBSQL = new Dictionary<int, string>();
            Insert("Erick Arostegui Cunza (SQL)");
            Insert("Miguel Salvador (SQL)");
            Insert("Bill Gates (SQL)");
            Insert("Steve Jobs (SQL)");
        }

        public string Get(int id)
        {
            return DBSQL[id];
        }

        public Dictionary<int,string> List()
        {
            return DBSQL;
        }

        public void Insert(string data)
        {
            Count++;
            DBSQL.Add(Count,data);
        }

        public void Update(int id,string data)
        {
            DBSQL[id] = data;
        }

        public void Delete(int id)
        {
            DBSQL.Remove(id);
        }
    }
}
