using System;
using System.Collections.Generic;
using System.Text;

namespace DuplicateCheckTest
{
    public interface IDuplicateCheckService
    {
        bool IsThisTheFirstTimeWeHaveSeen(int id);
    }
}
