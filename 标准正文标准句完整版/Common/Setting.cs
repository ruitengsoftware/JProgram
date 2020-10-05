using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Setting
    {
        public static string _savepath100 = string.Empty;
        public static string _savepath = string.Empty;
        public static bool _qian = false;
        public static bool _hou = false;
        public static bool _xiahuaxian = false;
        public static bool _zhengwenruku = false;
        public static bool _weizhu = false;
        public static bool _cijuruku = false;
        public static string _zhengwenrukubiao = string.Empty;
        public static string _cijurukubiao = string.Empty;
        public static bool _zhengwenchachong = false;
        public static bool _cijuchachong = false;
        public static bool _shanchu100 = false;
        public static bool _daochu = false;
        public static string _zhengwenchachongbiao = string.Empty;
        public static string _cijuchachongbiao = string.Empty;
        public static string _currentformat = string.Empty;
        public static string _currentdb = string.Empty;
        public static string _rizhilujing = string.Empty;
    }





    public static class CommonMethod
    {
        public static void AddXuhao(DataTable mydt)
        {
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                mydt.Rows[i]["xuhao"] = i + 1;
            }
            try
            {
                mydt.Columns["xuhao"].SetOrdinal(0);
            }
            catch { }
        }
    }
}
