using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Galaxy.DI.Console
{
    public abstract class DataStorageContext
    {
        private static DataStorageContext current;

        public static DataStorageContext Current
        {
            get
            {
                if (current == null)
                {
                    current = new DefaultContext();
                }

                return current;
            }
            set
            {
                current = value ?? new DefaultContext();
            }
        }

        public virtual IDataStorage DataStorage { get; }
    }

    public class DefaultContext : DataStorageContext
    {
        public override IDataStorage DataStorage
        {
            get { return new DataStorageSQL(); }
        }
    }

}
