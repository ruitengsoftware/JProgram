using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class ExcelInfo
    {
        public int _id = 0;
        public string _yuanwenjian = string.Empty;
        public string _filename = string.Empty;
        public int _hangshu = 0;

        public DataTable _data = new DataTable();
        /// <summary>
        /// 报错原因
        /// </summary>
        public string exception = string.Empty;
    }
}
