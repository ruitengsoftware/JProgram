using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RuiTengDll;
using System.Threading;
using Common;
using System.IO;
using WindowsFormsApp1.Common;
using WindowsFormsApp1.Controller;
using Common.WinForm;
using System.Text.RegularExpressions;
using WindowsFormsApp1.Model;
using MySql.Data.MySqlClient;

namespace WindowsFormsApp1.UC
{
    public partial class UCTask : UserControl
    {
        //查重方法

        //对文档进行查重











        ControllerTask _mycontroller = new ControllerTask();
        string _filename = string.Empty;
        Action a = null;
        bool _stop = false;
        public string _statue = string.Empty;//保存当前状态，查询中，已暂停等等




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

        ///// <summary>
        ///// 该方法用于正文查重
        ///// </summary>
        //public void ZhengwenChachong()
        //{
        //    //string zhengwen = _mycontroller.GetZhengwenFromFile(_filename);
        //    //string md5zhengwen = _mycontroller.GenerateMD5(zhengwen);
        //    //bool existzhengwen = _mycontroller.IsExistorNot2(md5zhengwen);
        //    //if (existzhengwen)//如果正文存在于数据库
        //    //{
        //    //    //显示查重进度
        //    //    UpdateText(lbl_jindu, "进度：100.00%");
        //    //    Application.DoEvents();
        //    //    //显示重复率
        //    //    UpdateText(lbl_chongfulv, "重复率：重复");
        //    //    Application.DoEvents();                 //删除重复率100的文章
        //    //    if (Setting._shanchu100)
        //    //    {
        //    //        File.Delete(lbl_filename.Text);
        //    //    }
        //    //}
        //    //else//如果正文不在数据库内
        //    //{
        //    //    //显示查重进度
        //    //    UpdateText(lbl_jindu, "进度：100.00%");
        //    //    Application.DoEvents();
        //    //    //显示重复率
        //    //    UpdateText(lbl_chongfulv, "重复率：不重复");
        //    //    Application.DoEvents();
        //    //    if (!existzhengwen && Setting._zhengwenruku)//如果正文入库，那么入库正文
        //    //    {
        //    //        Dictionary<string, object> dic = new Dictionary<string, object>() {
        //    //             {"编号",md5zhengwen },
        //    //             {"来源",Path.GetFileName( _filename) }
        //    //         };
        //    //        _mycontroller.Ruku(Setting._zhengwenbiao, dic);
        //    //    }

        //    //}
        //}
        UIHelper _uihelper = new UIHelper();
        /// <summary>
        /// 该方法用于词句查重
        /// </summary>
        public void CijuChachong()
        {
            //string zhengwen = _mycontroller.GetZhengwen(_filename);
            //string md5zhengwen = _mycontroller.GenerateMD5(zhengwen);

            //bool existzhengwen = _mycontroller.IsExistorNot2(md5zhengwen);
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
            //        _mycontroller.Ruku(Setting._zhengwenbiao, dic);
            //    }

            //    //2、在标准句表中进行词句查重
            //    //获得所有句子
            //    List<string> list_sentence = _mycontroller.GetBiaozhunJu(_filename);
            //    int repeatnum = 0;
            //    for (int i = 0; i < list_sentence.Count; i++)
            //    {
            //        if (stop)//这里先判断用户是否手动停止了查重
            //        {
            //            return;
            //        }
            //        //判断该句是否重复
            //        string str = _mycontroller.Hulue(list_sentence[i]);
            //        bool exist = _mycontroller.IsExistorNot(str.Trim());
            //        //如果重复增加转载量
            //        if (exist)
            //        {
            //            _mycontroller.ReduPlus(str);
            //            repeatnum++;
            //        }
            //        //判断是否需要添加下划线并执行相关方法
            //        if (exist && Setting._xiahuaxian)
            //        {
            //            _mycontroller.RedLine(_filename, list_sentence[i]);
            //        }
            //        //判断是否需要添加尾注并执行相关方法
            //        if (exist && Setting._weizhu)
            //        {
            //            _mycontroller.AddFooter(_filename, list_sentence[i].Trim());
            //        }
            //        //根据入库设置执行是否入库
            //        if (!exist && Setting._cijuruku)
            //        {
            //            Dictionary<string, object> dic = new Dictionary<string, object>() {
            //                {"编号",_mycontroller.GenerateMD5(str) },
            //                {"来源",Path.GetFileName( _filename)},
            //                 {"转载量", 1},
            //                 {"内容",str.Trim() },
            //                 {"时间",_mycontroller.GetDateFromFilename(_filename)}
            //            };
            //            _mycontroller.Ruku(Setting._biaozhunjubiao, dic);
            //        }
            //        //显示查重进度
            //        UpdateText(lbl_jindu, "进度：" + _mycontroller.GetJindu(i + 1, list_sentence.Count));
            //        Application.DoEvents();
            //        //显示重复率
            //        UpdateText(lbl_chongfulv, "重复率：" + _mycontroller.GetJindu(repeatnum, list_sentence.Count));
            //        Application.DoEvents();
            //    }
            //    //删除重复率100的文章
            //    if (Setting._shanchu100)
            //    {
            //        File.Delete(lbl_filename.Text);
            //    }

            //}
        }


        public void Chachong()
        {









        }




        public void ZhengwenChachong()
        {
            _mycontroller._chongfushu = 0;
            UpdateText(lbl_time, "已用时：00:00:00");
            timer1.Start();
            string starttime = DateTime.Now.ToString("yyyyMMdd-HH:mm");

            _stop = false;
            //获得path下的所有文件
            DirectoryInfo di = new DirectoryInfo(_filename);
            List<FileInfo> list_files = di.GetFiles().ToList();

            Task mytask = null;
            foreach (UCDatabase ucdb in Setting.list_ucdb)
            {
                for (int i = 0; i < list_files.Count; i++)
                {
                    //判断是否人为终止了查重
                    if (_stop)
                    {
                        timer1.Stop();
                        break;
                    }
                    string str_filename = list_files[i].FullName;
                    //_mycontroller.SearchSingle(str_filename);

                    //WaitCallback mycallback = new WaitCallback(o => { _mycontroller.SearchSingle(o); });
                    //ThreadPool.QueueUserWorkItem(mycallback, str_filename);


                    TaskFactory tf = new TaskFactory();
                    tf.StartNew(() =>
                    {
                        // _mycontroller.SearchSingle(str_filename);
                    });

                    //thread.IsBackground = true;
                    //thread.Start(str_filename);
                    // Action<string> a = _mycontroller.SearchSingle;
                    //a.Invoke(str_filename);


                    UpdateText(lbl_jindu, $"进度：{ (i + 1).ToString()}/{list_files.Count}");
                    UpdateText(lbl_chongfulv, $"重复：{_mycontroller._chongfushu}");
                    Application.DoEvents();

                }
            }
            //写入查重日志
            StringBuilder mysb = new StringBuilder();
            string endtime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            mysb.AppendLine($"{starttime}————{endtime}  {list_files.Count}条  重复{_mycontroller._chongfushu}条");
            _mycontroller._list_same.ForEach((same) => { mysb.AppendLine($"{_mycontroller._list_same.IndexOf(same)}.{same}"); });
            mysb.AppendLine();
            //获得查重日志，如果没有的话创建
            StreamWriter sw = new StreamWriter(Setting._rizhilujing, true);
            sw.WriteLine(mysb);
            sw.Flush();
            sw.Close();
            timer1.Stop();
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
            _stop = true;
            
        }





        private void Timer1_Tick(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Action<object, EventArgs> a = Timer1_Tick;
                this.BeginInvoke(a, null, null);
            }
            else
            {
                string str_time = Regex.Match(lbl_time.Text, @"\d\d:\d\d:\d\d").ToString();
                DateTime dt = DateTime.ParseExact(str_time, "HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture);
                lbl_time.Text = $"已用时：{dt.AddSeconds(1).ToString("HH:mm:ss")}";
                
            }
        }
        /// <summary>
        /// 点击开始按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void PictureBox2_Click(object sender, EventArgs e)
        {
            _stop = false;
            _mycontroller.list_zhenweng.Clear();//清空查询文章集合
            List<ZhengwenInfo> list_result = new List<ZhengwenInfo>();
            string mysql_constr = $"Server={Properties.Settings.Default._ip};Database=qianhai;Uid=root;Pwd=111111;AllowUserVariables=false;";
            List<Task> list_task = new List<Task>();
            //判断状态，如果是暂停或者空白那么开始，并且执行查重
            if (_statue.Equals(string.Empty) || _statue.Equals("已暂停"))
            {
                _statue = "正在查询";
                lbl_statue.Text = _statue; UpdateText(lbl_time, "已用时：00:00:00");
                timer1.Start();

                /*开始查重*/
                //1、整体查重，查到所有文件的重复和不重复情况
                //获得path下的所有文件
                DirectoryInfo di = new DirectoryInfo(_filename);
                List<FileInfo> list_files = di.GetFiles().ToList();
                //开始循环所有的文档，实例化一个对应的类
                ZhengwenInfo zhengweninfo = null;

                await Task.Run(() =>
                 {
                     for (int i = 0; i < list_files.Count; i++)
                     {
                         //先判断是否人工暂停
                         if (_stop)
                         {
                             //停止计时器
                             timer1.Stop();
                             //改变运行状态属性
                             _statue = "已暂停";
                             //赋值运行状态lbl
                             lbl_statue.BeginInvoke(new Action(() =>
                             {
                                 lbl_statue.Text = _statue;
                             }));



                             break;
                         }
                         zhengweninfo = new ZhengwenInfo();

                         //文档有可能报错，保存在错误信息中
                         try
                         {
                             //1、对每一个文档新建一个线程

                             //将线程放入集合
                             lbl_jindu.BeginInvoke(new Action(() =>
                             {
                                 lbl_jindu.Text = $"进度：{i + 1}/{list_files.Count}";
                             }));
                             string filename = list_files[i].FullName;
                             string laiyuan = list_files[i].Name;
                             string laiyuanbyte = _mycontroller.String2Byte(laiyuan);
                             string zhengwen = _mycontroller.GetZhengwen(filename);//获得正文文本
                             string md5 = _mycontroller.GenerateMD5(zhengwen);//正文转换成二进制
                                                                              //string zhengwenbyte = _mycontroller.String2Byte(zhengwen);//正文转二进制
                             zhengweninfo._laiyuan = laiyuanbyte;
                             //_zhengwenneirong = zhengwenbyte,
                             //_zhengwenneirong = zhengwen,
                             zhengweninfo._bianhao = md5;
                         }
                         catch (Exception ex)
                         {
                             zhengweninfo._ex = ex;
                             zhengweninfo._error = true;
                         }
                         Task mytask = _mycontroller.IsExistAsync(zhengweninfo);
                         lbl_chongfulv.BeginInvoke(new Action(
                             ()=> {
                                 lbl_chongfulv.Text = "重复："+_mycontroller._chachonglv.ToString();
                             }
                             ));
                         list_task.Add(mytask);
                     }
                 });
                 await Task.WhenAll(list_task.ToArray());

                //2、根据是否入库和累计热度情况，对每一个文件进行操作，拼接sql的方式
                //如果是入库，那么对所有不重复的文章进行拼接sql并执行，重复的不用管
                //如果是累计热度，那么对所有重复的文档进行update更新装载量，不重复的文档不要
                lbl_statue.BeginInvoke(new  Action(()=> {
                    lbl_statue.Text = "正在更新数据";
                }));
                lbl_chongfulv.BeginInvoke(new Action(()=> {
                    lbl_chongfulv.Text ="重复："+ _mycontroller._chongfushu.ToString();
                }));
                if (Setting._zhengwenruku)
                {
                    //如果不存在，就拼接字符串
                    string str_sql = $"insert into {Setting._zhengwenrukubiao} (编号,来源,转载量,时间) values ";
                    List<string> list_values = new List<string>();
                    for (int i = 0; i < _mycontroller.list_zhenweng.Count; i++)
                    {
                        zhengweninfo = _mycontroller.list_zhenweng[i];
                        if (!zhengweninfo._exist && !zhengweninfo._error)//如果不存在 并且  没有报错，那么入库
                        {
                            list_values.Add($"('{zhengweninfo._bianhao}','{zhengweninfo._laiyuan}',1,'{DateTime.Now.ToShortDateString()}')");
                        }
                        if (list_values.Count >= 1000)//如果大于500就保存一次
                        {
                            await Task.Run(() =>
                            {
                                using (MySqlConnection mysql = new MySqlConnection(mysql_constr))
                                {

                                    mysql.Open();
                                    MySqlTransaction transaction = mysql.BeginTransaction();//开启事务
                                    using (MySqlCommand mycmd = new MySqlCommand())
                                    {
                                        mycmd.Connection = mysql;
                                        mycmd.CommandText = str_sql + string.Join(",", list_values);
                                        mycmd.Transaction = transaction;
                                        mycmd.CommandTimeout = 9999999;
                                        mycmd.ExecuteNonQuery();
                                        transaction.Commit();
                                        mysql.Close();

                                    }
                                }
                                list_values.Clear();
                            });
                        }
                    }
                    if (list_values.Count != 0)
                    {
                        using (MySqlConnection mysql = new MySqlConnection(mysql_constr))
                        {

                            mysql.Open();
                            MySqlTransaction transaction = mysql.BeginTransaction();//开启事务
                            using (MySqlCommand mycmd = new MySqlCommand())
                            {
                                mycmd.Connection = mysql;
                                mycmd.CommandText = str_sql + string.Join(",", list_values);
                                mycmd.Transaction = transaction;

                                mycmd.ExecuteNonQuery();
                                transaction.Commit();
                                mysql.Close();

                            }
                        }

                    }




                }
                if (Setting._leijiredu)
                {

                }
                //生成查重报告
                lbl_statue.BeginInvoke(new Action(() => {
                    lbl_statue.Text = "报告生成中";
                }));

                /*
                 
                 此处生成查重报告
                 
                 */


                _statue = "已暂停";
                lbl_statue.BeginInvoke(new Action(() =>
                {
                    lbl_statue.Text = "已暂停";
                }));
                timer1.Stop();


            }
            //如果是正在查询，那么要不做任何反应
            else
            {
                return;
                //_statue = "已暂停";
                //lbl_statue.Text = _statue;
                //StopResearch();
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
