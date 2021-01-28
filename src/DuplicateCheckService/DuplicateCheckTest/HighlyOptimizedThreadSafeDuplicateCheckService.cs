using System;
using Xunit;

namespace DuplicateCheckTest
{
    public class HighlyOptimizedThreadSafeDuplicateCheckService : IDuplicateCheckService
    {
        private StoreIdManager storeIdManager;

        [Fact]
        public void IsThisTheFirstTimeWeHaveSeenTest()
        {
            storeIdManager = StoreIdManager.Instance;
        }

        public bool IsThisTheFirstTimeWeHaveSeen(int id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException("id");
            }

            return storeIdManager.StoreId(id);
        }
    }
}
