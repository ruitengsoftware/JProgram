using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 谦海数据解析系统.JJmodel
{
    public class BiaoqianInfo
    {




        /// <summary>
        /// 库名
        /// </summary>
        public string _kuming = string.Empty;
        /// <summary>
        /// 标签名称
        /// </summary>
        public string _mingcheng = string.Empty;
        /// <summary>
        /// 标签级别
        /// </summary>
        public int _jibie = 0;
        /// <summary>
        /// 父标签名
        /// </summary>
        public string _fubiaoqianming = string.Empty;

        /// <summary>
        /// 设置的json表达方式
        /// </summary>
        public BiaoqianRoot _biaoqianRoot = new BiaoqianRoot();
        /// <summary>
        /// 设置
        /// </summary>
        public string _biaoqianSet = string.Empty;
        /// <summary>
        /// 创建人
        /// </summary>
        public string _chuangjianren = string.Empty;
        /// <summary>
        /// 创建时间
        /// </summary>
        public string _chuangjianshijian = string.Empty;
        /// <summary>
        /// 不含参数的构造函数
        /// </summary>
        public BiaoqianInfo() { }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="kuming"></param>
        /// <param name="biaoqianming"></param>
        /// <param name="jibie"></param>
        /// <param name="fubiaoqianming"></param>
        /// <param name="shezhi"></param>
        /// <param name="chuanjianren"></param>
        /// <param name="chuangjianshijian"></param>
        public BiaoqianInfo(string kuming, string biaoqianming, int jibie, string fubiaoqianming, string shezhi, string chuangjianren, string chuangjianshijian)
        {
            _kuming = kuming;
            _mingcheng = biaoqianming;
            _jibie = jibie;
            _fubiaoqianming = fubiaoqianming;
            _biaoqianSet = shezhi;
            _chuangjianren = chuangjianren;
            _chuangjianshijian = chuangjianshijian;
        }

        public class BiaoqianRoot
        {
            /// <summary>
            /// 内容标签内容
            /// </summary>
            public List<string> list_leibie = new List<string>();

            public string shuoming = string.Empty;

            public string zhengze = string.Empty;

            public List<string> list_position = new List<string>();

            public int shunshu = 0;

            public int daoshu = 0;

            public List<string> list_pipei = new List<string>();

            public string gudingzhi = string.Empty;

            public string jushouzhi = string.Empty;

            public string juzhongzhi = string.Empty;

            public string juweizhi = string.Empty;

            public string weizhiqian0 = string.Empty;

            public string weizhiqian1 = string.Empty;

            public string weizhihou0 = string.Empty;

            public string weizhihou1 = string.Empty;

            public List<string> list_neirong = new List<string>();

            public List<string> list_yupian = new List<string>();

            public string zhengzetiqu = string.Empty;

        }
    }
}
