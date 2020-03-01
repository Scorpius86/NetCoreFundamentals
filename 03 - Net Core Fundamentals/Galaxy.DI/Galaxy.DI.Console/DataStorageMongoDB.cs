using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.Console
{
    public class DataStorageMongoDB: IDataStorage
    {
        public Dictionary<int,string> DBMongoDB { get; }
        public int Count { get; set; }

        public DataStorageMongoDB()
        {
            Count = 0;
            DBMongoDB = new Dictionary<int, string>();
            Insert("Erick Arostegui Cunza (MongoDB)");
            Insert("Miguel Salvador (MongoDB)");
            Insert("Bill Gates (MongoDB)");
            Insert("Steve Jobs (MongoDB)");
        }

        public string Get(int id)
        {
            return DBMongoDB[id];
        }
        public Dictionary<int, string> List()
        {
            return DBMongoDB;
        }


        public void Insert(string data)
        {
            Count++;
            DBMongoDB.Add(Count,data);
        }

        public void Update(int id,string data)
        {
            DBMongoDB[id] = data;
        }

        public void Delete(int id)
        {
            DBMongoDB.Remove(id);
        }
    }
}
