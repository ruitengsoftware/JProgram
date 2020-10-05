using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using RuiTengDll;
using System.Threading;
using Common;
using System.IO;

namespace WindowsFormsApp1.UC
{
    public partial class UCTask : UserControl
    {
        ControllerTask mycontroller = new ControllerTask();
        string _filename = string.Empty;
        Action a = null;
        Thread t = null;
        bool stop = false;
        public UCTask()
        {
            InitializeComponent();
        }
        public UCTask(string filename)
        {
            InitializeComponent();
            lbl_filename.Text = filename;
            _filename = filename;
        }

        /// <summary>
        /// 该方法用于正文查重
        /// </summary>
        public void ZhengwenChachong()
        {
            //string zhengwen = mycontroller.GetZhengwenFromFile(_filename);
            //string md5zhengwen = mycontroller.GenerateMD5(zhengwen);
            //bool existzhengwen = mycontroller.IsExistorNot2(md5zhengwen);
            //if (existzhengwen)//如果正文存在于数据库
            //{
            //    //显示查重进度
            //    UpdateText(lbl_jindu, "进度：100.00%");
            //    Application.DoEvents();
            //    //显示重复率
            //    UpdateText(lbl_chongfulv, "重复率：重复");
            //    Application.DoEvents();                 //删除重复率100的文章
            //    if (Setting._shanchu100)
            //    {
            //        File.Delete(lbl_filename.Text);
            //    }
            //}
            //else//如果正文不在数据库内
            //{
            //    //显示查重进度
            //    UpdateText(lbl_jindu, "进度：100.00%");
            //    Application.DoEvents();
            //    //显示重复率
            //    UpdateText(lbl_chongfulv, "重复率：不重复");
            //    Application.DoEvents();
            //    if (!existzhengwen && Setting._zhengwenruku)//如果正文入库，那么入库正文
            //    {
            //        Dictionary<string, object> dic = new Dictionary<string, object>() {
            //             {"编号",md5zhengwen },
            //             {"来源",Path.GetFileName( _filename) }
            //         };
            //        mycontroller.Ruku(Setting._zhengwenbiao, dic);
            //    }

            //}
        }

        /// <summary>
        /// 该方法用于词句查重
        /// </summary>
        public void CijuChachong()
        {
            //string zhengwen = mycontroller.GetZhengwen(_filename);
            //string md5zhengwen = mycontroller.GenerateMD5(zhengwen);

            //bool existzhengwen = mycontroller.IsExistorNot2(md5zhengwen);
            //if (existzhengwen)//如果标准正文存在
            //{
            //    //显示查重进度
            //    UpdateText(lbl_jindu, "进度：100.00%");
            //    Application.DoEvents();
            //    //显示重复率
            //    UpdateText(lbl_chongfulv, "重复率：100.00%重复");
            //    Application.DoEvents();
            //    //删除重复率100的文章
            //    if (Setting._shanchu100)
            //    {
            //        File.Delete(lbl_filename.Text);
            //    }

            //}
            //else//如果标准正文不存在
            //{
            //    if (!existzhengwen && Setting._zhengwenruku)//如果正文入库，那么入库正文
            //    {
            //        Dictionary<string, object> dic = new Dictionary<string, object>() {
            //             {"编号",md5zhengwen },
            //             {"来源",Path.GetFileName( _filename) }
            //         };
            //        mycontroller.Ruku(Setting._zhengwenbiao, dic);
            //    }

            //    //2、在标准句表中进行词句查重
            //    //获得所有句子
            //    List<string> list_sentence = mycontroller.GetBiaozhunJu(_filename);
            //    int repeatnum = 0;
            //    for (int i = 0; i < list_sentence.Count; i++)
            //    {
            //        if (stop)//这里先判断用户是否手动停止了查重
            //        {
            //            return;
            //        }
            //        //判断该句是否重复
            //        string str = mycontroller.Hulue(list_sentence[i]);
            //        bool exist = mycontroller.IsExistorNot(str.Trim());
            //        //如果重复增加热度
            //        if (exist)
            //        {
            //            mycontroller.ReduPlus(str);
            //            repeatnum++;
            //        }
            //        //判断是否需要添加下划线并执行相关方法
            //        if (exist && Setting._xiahuaxian)
            //        {
            //            mycontroller.RedLine(_filename, list_sentence[i]);
            //        }
            //        //判断是否需要添加尾注并执行相关方法
            //        if (exist && Setting._weizhu)
            //        {
            //            mycontroller.AddFooter(_filename, list_sentence[i].Trim());
            //        }
            //        //根据入库设置执行是否入库
            //        if (!exist && Setting._cijuruku)
            //        {
            //            Dictionary<string, object> dic = new Dictionary<string, object>() {
            //                {"编号",mycontroller.GenerateMD5(str) },
            //                {"来源",Path.GetFileName( _filename)},
            //                 {"热度", 1},
            //                 {"内容",str.Trim() },
            //                 {"时间",mycontroller.GetDateFromFilename(_filename)}
            //            };
            //            mycontroller.Ruku(Setting._biaozhunjubiao, dic);
            //        }
            //        //显示查重进度
            //        UpdateText(lbl_jindu, "进度：" + mycontroller.GetJindu(i + 1, list_sentence.Count));
            //        Application.DoEvents();
            //        //显示重复率
            //        UpdateText(lbl_chongfulv, "重复率：" + mycontroller.GetJindu(repeatnum, list_sentence.Count));
            //        Application.DoEvents();
            //    }
            //    //删除重复率100的文章
            //    if (Setting._shanchu100)
            //    {
            //        File.Delete(lbl_filename.Text);
            //    }

            //}
        }

        /// <summary>
        /// 查重
        /// </summary>
        public void SearchRepeat()
        {
            /*由于同时存在停止查重的stopsearch方法，该方法通过改变stop的值来进行实现，为防止
            *为防止执行了一次stopsearch方法后无法重新查询，所以需要先重新赋值stop=false
            * 查重时分为两种情况，首先分离标题与正文，然后查找正文所转化的md5再标准正文表中的md5编号，如果
            * 存在那么进度显示为100%，重复率显示为100%（标准正文）
            * 如果不存在相同编号，那么连同标题进行正常的标准句查询，查询时更新进度与重复率
            * 判断setting中的设置是否入库，如果是的话需要将所有的不重复句子，以及md5加密后的正文添加进入数据库
            */
            //a = () =>
            // {
            //     stop = false;

            //     string zhengwen = mycontroller.GetZhengwen(_filename);
            //     string md5zhengwen = mycontroller.GenerateMD5(zhengwen);
            //     //1、在标准正文表中查找标准正文
            //     if (Setting._zhengwenchachong)
            //     {

            //     }
            //     if (Setting._cijuchachong)//选择词句查重时进行的流程
            //     {

            //     }
            // };
            //a.BeginInvoke(null, null);
        }
        /// <summary>
        /// 更新控件显示信息
        /// </summary>
        /// <param name="c"></param>
        /// <param name="text"></param>
        public void UpdateText(Control c, string text)
        {
            if (this.InvokeRequired)
            {
                Action<Control, string> a = UpdateText;
                this.BeginInvoke(a, c, text);
            }
            else
            {
                c.Text = text;
            }
        }
        /// <summary>
        /// 停止查重
        /// </summary>

        public void StopResearch()
        {
            stop = true;
        }
    }
}
