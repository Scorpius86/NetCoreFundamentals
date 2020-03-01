using System;
using System.Collections.Generic;
using System.Text;

namespace Galaxy.DI.Console
{
    public class ClientServiceLocator
    {
        private IDictionary<object, object> storageContainer;

        internal ClientServiceLocator()
        {
            storageContainer = new Dictionary<object, object>();

            storageContainer.Add(typeof(DataStorageSQL), new DataStorageSQL());
            storageContainer.Add(typeof(DataStorageOracle), new DataStorageOracle());
            storageContainer.Add(typeof(DataStorageMongoDB), new DataStorageMongoDB());
        }

        public T GetDataStorage<T>()
        {
            try
            {
                return (T)storageContainer[typeof(T)];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException("Origen de datos no registrado");
            }
        }

    }
}
