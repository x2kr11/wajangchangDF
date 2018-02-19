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

        public DataSet GetCacIdList(Hashtable ht)
        {
            Dac wDac = new Dac();
            DataSet ds = new DataSet();
            ds = wDac.GetCacIdList(ht);
            return ds;
        }
        
        /// <summary>
        /// 모험단 리스트 조회
        /// </summary>
        /// <returns></returns>
        public DataSet GetAdventureList()
        {
            Dac wDac = new Dac();
            DataSet ds = new DataSet();
            ds = wDac.GetAdventureList();
            return ds;
        }
    
    }
}