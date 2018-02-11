using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Skcc.Transactions;

namespace eHR.Framework.Base
{
    [Transaction(TransactionOption.Required, IsolationLevel = IsolationLevel.ReadCommitted, Timeout = 600)]
    public class ShBizBase : BizBase
    {
        public ShBizBase()
        { }

    }

}
