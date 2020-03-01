using System;

namespace Galaxy.DI.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Inyección de dependencia");
            System.Console.WriteLine("========================");
           

            DataStorageSQL dataStorageSQL = new DataStorageSQL();
            DataStorageOracle dataStorageOracle = new DataStorageOracle();
            DataStorageMongoDB dataStorageMongoDB = new DataStorageMongoDB();

            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros sin conyeccion de dependencias");
            System.Console.WriteLine("==================================================");
            System.Console.WriteLine("Primer registro de SQL : " + dataStorageSQL.Get(1));
            System.Console.WriteLine("Primer registro de Oracle : " + dataStorageOracle.Get(1));
            System.Console.WriteLine("Primer registro de MongoDB : " + dataStorageMongoDB.Get(1));

            //-----------------------------------------------------------------------------------------------

            ClientDIConstructor clientDIConstructor;
            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros con inyeccion de dependencias (Constructor)");
            System.Console.WriteLine("================================================================");

            clientDIConstructor = new ClientDIConstructor(new DataStorageSQL());
            System.Console.WriteLine("Primer registro de SQL : " + clientDIConstructor.Get(1));

            clientDIConstructor = new ClientDIConstructor(new DataStorageOracle());
            System.Console.WriteLine("Primer registro de Oracle : " + clientDIConstructor.Get(1));

            clientDIConstructor = new ClientDIConstructor(new DataStorageMongoDB());
            System.Console.WriteLine("Primer registro de MongoDB : " + clientDIConstructor.Get(1));

            //-----------------------------------------------------------------------------------------------

            ClientDISetter clientDISetter = new ClientDISetter();
            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros con inyeccion de dependencias (Setter)");
            System.Console.WriteLine("================================================================");

            clientDISetter.DataStorage = new DataStorageSQL();
            System.Console.WriteLine("Primer registro de SQL : " + clientDISetter.Get(1));

            clientDISetter.DataStorage = new DataStorageOracle();
            System.Console.WriteLine("Primer registro de Oracle : " + clientDISetter.Get(1));

            clientDISetter.DataStorage = new DataStorageMongoDB();
            System.Console.WriteLine("Primer registro de MongoDB : " + clientDISetter.Get(1));

            //-----------------------------------------------------------------------------------------------

            ClientDIMethod clientDIMethod = new ClientDIMethod();
            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros con inyeccion de dependencias (Metodo)");
            System.Console.WriteLine("================================================================");

            clientDIMethod.Init(new DataStorageSQL());
            System.Console.WriteLine("Primer registro de SQL : " + clientDIMethod.Get(1));

            clientDIMethod.Init(new DataStorageOracle());
            System.Console.WriteLine("Primer registro de Oracle : " + clientDIMethod.Get(1));

            clientDIMethod.Init(new DataStorageMongoDB());
            System.Console.WriteLine("Primer registro de MongoDB : " + clientDIMethod.Get(1));

            //-----------------------------------------------------------------------------------------------

            ClientDIContext clientDIContext = new ClientDIContext();
            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros con inyeccion de dependencias (Contexto)");
            System.Console.WriteLine("================================================================");

            clientDIContext.SetDataStorage(new DataStorageSQL());
            DataStorageContext.Current = clientDIContext;
            System.Console.WriteLine("Primer registro de SQL : " + DataStorageContext.Current.DataStorage.Get(1));

            clientDIContext.SetDataStorage(new DataStorageOracle());
            DataStorageContext.Current = clientDIContext;
            System.Console.WriteLine("Primer registro de Oracle : " + DataStorageContext.Current.DataStorage.Get(1));

            clientDIContext.SetDataStorage(new DataStorageMongoDB());
            DataStorageContext.Current = clientDIContext;
            System.Console.WriteLine("Primer registro de MongoDB : " + DataStorageContext.Current.DataStorage.Get(1));


            //-----------------------------------------------------------------------------------------------

            ClientServiceLocator clientServiceLocator = new ClientServiceLocator();
            System.Console.WriteLine();
            System.Console.WriteLine("Obteniendo Registros con inyeccion de dependencias (Service Locator)");
            System.Console.WriteLine("====================================================================");
            System.Console.WriteLine("Primer registro de SQL : " + clientServiceLocator.GetDataStorage<DataStorageSQL>().Get(1));
            System.Console.WriteLine("Primer registro de Oracle : " + clientServiceLocator.GetDataStorage<DataStorageOracle>().Get(1));
            System.Console.WriteLine("Primer registro de MongoDB : " + clientServiceLocator.GetDataStorage<DataStorageMongoDB>().Get(1));

            System.Console.ReadKey();
        }
    }
}
