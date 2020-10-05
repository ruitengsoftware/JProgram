using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Model
{


    public class BuzhouInfo
    {
        public BuzhouInfo() { }

        public BuzhouInfo(string leixing) 
        {
            this._name = leixing;
            if (leixing.Contains("替换"))
            {
                this._zhengze = "正则表达式";
            }
            else if (leixing.Contains("添加前缀"))
            {
                this._text = "请输入……";
            }
            else if (leixing.Contains("添加后缀"))
            {
                this._text = "请输入……";

            }
            else if (leixing.Contains("清除换行符"))
            {
                this._text = "清除换行符……";

            }
        }


        /// <summary>
        /// 修改时间
        /// </summary>
        public string _updatedate = string.Empty;

        /// <summary>
        /// 用户自定义名称
        /// </summary>
        public string _selfname { get; set; }

        /// <summary>
        /// 步骤名称
        /// </summary>
        public string _name { get; set; }
        /// <summary>
        /// 正则表达式
        /// </summary>
        public string _zhengze{ get; set; }
        /// <summary>
        /// 替换词
        /// </summary>
        public string _tihuan { get; set; }
        /// <summary>
        /// 文本
        /// </summary>
        public string _text { get; set; }
    }

    public class MubanInfo
    {
        public MubanInfo() {

            _mubanname = string.Empty;
            list_buzhou = new List<BuzhouInfo>();
        }
        /// <summary>
        /// 模板名称
        /// </summary>
        public string _mubanname { get; set; }
        /// <summary>
        /// 该模板包含的步骤信息
        /// </summary>
        public List<BuzhouInfo> list_buzhou{ get; set; }
    }
}
