using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Galaxy.DI.Console
{
    public class ClientDISetter
    {
        private IDataStorage _dataStorage { get; set; }
        public ClientDISetter()
        {
        }
        public IDataStorage DataStorage
        {
            set { _dataStorage = value; }
        }

        public string Get(int id)
        {
            return _dataStorage.Get(id);
        }

        public Dictionary<int,string> List()
        {
            return _dataStorage.List();           
        }

        public void Insert(string data)
        {
            _dataStorage.Insert(data);
        }

        public void Delete(int id)
        {
            _dataStorage.Delete(id);
        }
    }
}
