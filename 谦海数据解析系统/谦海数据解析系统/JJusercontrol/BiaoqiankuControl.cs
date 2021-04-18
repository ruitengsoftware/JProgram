using Aspose.Cells;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据解析系统.JJmodel;

namespace 谦海数据解析系统.JJusercontrol
{
    public partial class BiaoqiankuControl : UserControl
    {
        public BiaoqiankuControl()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 传递一个标签信息实例进来，显示在界面上
        /// </summary>
        /// <param name="_bqInfo">内容标签</param>
        public BiaoqiankuControl(BiaoqianInfo _bqInfo)
        {
            InitializeComponent();
            this.Dock = DockStyle.Top;
            cb_biaoqianku.Text = _bqInfo._kuming;
            //实例化一个标签info控件
            BiaoqianControl myuc = new BiaoqianControl(_bqInfo) { };
            panel_biaoqian.Controls.Add(myuc);
        }
        /// <summary>
        /// 点击生成标签库解析表按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_shengcheng_Click(object sender, EventArgs e)
        {
            //弹出保存文件对话框，在指定路径下保存一个excel表，包括两个sheet，
            SaveFileDialog sfd = new SaveFileDialog();
            //根据命名规则自动产生一个文件名
            sfd.FileName = $"{cb_biaoqianku.Text}内容图谱解析表({DateTime.Now.ToString("yyyy年MM月dd日")})";

            sfd.Filter = "97~2003 Excel工作簿|*.xls|Excel工作簿|*.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
                //生成原版
                //Worksheet originalSht = mywbk.Worksheets.Add("Original");
                //string str_sql = $"select * from 数据解析库.内容标签表 " +
                //    $"where 库名='{cb_biaoqianku.Text}' and 删除=0 " +
                //    $"order by 级别";
                //DataTable dataTable = MySqlHelper.ExecuteDataset(SystemInfo._strConn, str_sql).Tables[0];
                //SaveDT2Excel(dataTable, mywbk, "Original", sfd.FileName, sfd.Filter);
                //生成合并版
                //获得内容标签的所有子标签,内容标签是1级标签,获得树状结构都从内容标签开始
                List<BiaoqianInfo2> list_new = new List<BiaoqianInfo2>() {
                     new BiaoqianInfo2(){_dbName=cb_biaoqianku.Text,list_tag={"内容标签" } }
                };
                List<BiaoqianInfo2> list_result = new List<BiaoqianInfo2>() {
                     new BiaoqianInfo2(){_dbName=cb_biaoqianku.Text,list_tag={"内容标签" }  }

                };
                bool end = false;
                while (!end)
                {
                    end = true;
                    list_new = new List<BiaoqianInfo2>(list_result);
                    foreach (BiaoqianInfo2 bq2 in list_new)
                    {
                        List<BiaoqianInfo> list = MyMethod.GetChildNodes(bq2);
                        if (list.Count > 0)//如果有的标签信息存在子标签，那么就不能结束
                        {
                            list_result.Remove(bq2);
                            end = false;
                            //循环所有的list，构造新的标签，添加到result中
                            for (int i = 0; i < list.Count; i++)
                            {
                                BiaoqianInfo2 bq22 = new BiaoqianInfo2() {_dbName=bq2._dbName};
                                bq22.list_tag = new List<string>(bq2.list_tag);
                                bq22.list_tag.Add(list[i]._mingcheng);
                                list_result.Add(bq22);
                            }
                        }
                    }
                }
                //把list_result中的结果加载到comSht中，然后单元格合并
                Worksheet comSht = mywbk.Worksheets[0];
                comSht.Name = "Combine";
                for (int i = 0; i < list_new.Count; i++)
                {
                    comSht.Cells[i+1, 0].Value = list_new[i]._dbName;

                    for (int j = 0; j < list_new[i].list_tag.Count; j++)
                    {
                        comSht.Cells[i+1, j + 1].Value = list_new[i].list_tag[j];
                    }
                }
                //获得最后一列的列数
                int lastCol = comSht.Cells.LastCell.Column+1;
                int lastRow = comSht.Cells.LastCell.Row+1;

                //添加字段
                comSht.Cells[0, 0].Value = $"信息库名称";
                Dictionary<int, string> dicFields = new Dictionary<int, string>() {
                    {1,"一"},
                    {2,"二" },
                    {3,"三" },
                    {4,"四" },
                    {5,"五" },
                    {6,"六" },
                    {7,"七" },
                    {8,"八" },
                    {9,"九" },
                   {10,"十" }
                };
                for (int i = 1; i < lastCol; i++)
                {
                    comSht.Cells[0, i].Value = $"{dicFields[i]}级标签";
                }
                //开始合并单元格
                for (int i = 0; i < lastCol-1; i++)
                {
                    int totalRow = 1;
                    int startRow = 1;
                    for (int j = 1; j <lastRow; j++)
                    {
                        if (comSht.Cells[j+1, i].StringValue != string.Empty && comSht.Cells[j,i].StringValue== comSht.Cells[j+1, i].StringValue)
                        {
                            totalRow++;
                            continue;
                        }
                        else
                        {
                            comSht.Cells.Merge(startRow, i, totalRow, 1);
                            startRow = j + 1;
                        }
                    }
                }
                //保存工作簿
                mywbk.Save(sfd.FileName);
                MessageBox.Show($"标签库 {cb_biaoqianku.Text} 解析表生成成功！");
            }
        }


        /// <summary>
        /// 把单独的datatable导出到excel工作簿
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filename"></param>
        /// <param name="houzhui"></param>
        public void SaveDT2Excel(DataTable dt, Aspose.Cells.Workbook mywbk, string sheet, string filename, string houzhui)
        {
            //添加表头
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                mywbk.Worksheets[sheet].Cells[0, i].Value = dt.Columns[i].ColumnName;
            }
            //添加数据
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    if (dt.Rows[j][k] != null)
                    {
                        mywbk.Worksheets[sheet].Cells[j + 1, k].Value = dt.Rows[j][k].ToString();

                    }
                    else
                    {
                        mywbk.Worksheets[sheet].Cells[j + 1, k].Value = "";
                    }
                }
            }
            //if (houzhui.Equals(".xls"))
            //{
            //    mywbk.Save(filename, SaveFormat.Excel97To2003);

            //}
            //else
            //{
            //    mywbk.Save(filename, SaveFormat.Xlsx);

            //}
        }




    }
}
