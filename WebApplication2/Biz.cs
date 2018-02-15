using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace WebApplication2
{
    public class Biz
    {
        public DataSet GetContentLog(Hashtable ht)
        {
            Dac wDac = new Dac();
            DataSet ds = new DataSet();
            ds = wDac.GetContentLog(ht);
            return ds;
        }
    }
}