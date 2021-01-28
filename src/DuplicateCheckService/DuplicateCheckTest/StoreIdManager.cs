using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace DuplicateCheckTest
{
    public class StoreIdManager : IStoreIdManager
    {
        private static readonly Lazy<StoreIdManager> _instance = new Lazy<StoreIdManager>(() => new StoreIdManager());
        private static readonly object ThreadLock = new object();
        private ConcurrentDictionary<int, string> Storage;

        private StoreIdManager()
        {
            Storage = new ConcurrentDictionary<int, string>();
        }

        public static StoreIdManager Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public bool StoreId(int idToStore)
        {
            bool result = false;

            if (!Storage.ContainsKey(idToStore))
            {
                result = Storage.TryAdd(idToStore, idToStore.ToString());
            }

            return result;
        }
    }
}
