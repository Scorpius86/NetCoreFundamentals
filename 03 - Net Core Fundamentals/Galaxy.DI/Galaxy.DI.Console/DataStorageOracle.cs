using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.Console
{
    public class DataStorageOracle: IDataStorage
    {
        public Dictionary<int,string> DBOracle { get; }
        public int Count { get; set; }

        public DataStorageOracle()
        {
            Count = 0;
            DBOracle = new Dictionary<int, string>();
            Insert("Erick Arostegui Cunza (Oracle)");
            Insert("Miguel Salvador (Oracle)");
            Insert("Bill Gates (Oracle)");
            Insert("Steve Jobs (Oracle)");
        }

        public string Get(int id)
        {
            return DBOracle[id];
        }

        public Dictionary<int, string> List()
        {
            return DBOracle;
        }


        public void Insert(string data)
        {
            Count++;
            DBOracle.Add(Count,data);
        }

        public void Update(int id,string data)
        {
            DBOracle[id] = data;
        }

        public void Delete(int id)
        {
            DBOracle.Remove(id);
        }
    }
}
