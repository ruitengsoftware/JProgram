using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 查重工具.JJModel
{
    public class JJBaifenbi
    {
        /// <summary>
        /// 
        /// </summary>
        public double PercentA { get; set; }
        public double PercentB { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SavePath { get; set; }

        public string Leixing { get; set; }
    }
    public class JJBaifenbiList
    {
        public List<JJBaifenbi> list_baifenbi { get; set; }

    }


}
