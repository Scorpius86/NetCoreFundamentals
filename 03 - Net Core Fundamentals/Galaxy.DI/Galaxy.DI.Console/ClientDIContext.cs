using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.Console
{
    public class ClientDIContext:DataStorageContext
    {
        private IDataStorage _dataStorage;

        public ClientDIContext()
        {
            _dataStorage = new DataStorageSQL();
        }

        public override IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        public void SetDataStorage(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
    }
}
