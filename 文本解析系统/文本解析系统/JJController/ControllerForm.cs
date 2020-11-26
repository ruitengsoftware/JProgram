using Aspose.Words;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.XPath;
using 文本解析系统.JJCommon;
using 文本解析系统.JJModel;

namespace 文本解析系统.JJController
{
    public class ControllerForm
    {
        public List<string> _childdirectories = new List<string>();
        /// <summary>
        /// 获得一个文件夹下所有的子文件夹
        /// </summary>
        /// <param name="folder"></param>
        public void GetDirectory(string folder)
        {

            //判断是否含有子文件夹，如果没有，加入
            _childdirectories = new List<string>();
            //_childdirectories.Add(folder);
            DirectoryInfo mydir = new DirectoryInfo(folder);
            string[] dirs = Directory.GetDirectories(folder);
            if (dirs.Length == 0)
            {
                _childdirectories.Add(folder);
            }
            else
            {
                foreach (string item in dirs)
                {
                    GetDirectory(item);
                }
            }


        }
        MySQLHelper mysqlhelper = new MySQLHelper(MySQLHelper.str_connother);
        /// <summary>
        /// 获得所有的规则
        /// </summary>
        /// <returns></returns>
        public DataTable GetGuize()
        {
            string str_sql = $"select * from 规则信息表 where 删除=0";
            return mysqlhelper.ExecuteDataTable(str_sql, null);
        }
        /// <summary>
        /// 删除规则
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteGuize(string name)
        {
            string str_sql = $"update 规则信息表 set 删除=1 where 规则名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 删除格式,令删除字段为1
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool DeleteFormat(string name)
        {
            string str_sql = $"update 解析格式表 set 删除=1 where 格式名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 删除格式，彻底删除
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool RealDeleteFormat(string name)
        {
            string str_sql = $"delete from 解析格式表 where 格式名称='{name}'";
            int num = mysqlhelper.ExecuteNonQuery(str_sql, null);
            return num > 0 ? true : false;
        }

        /// <summary>
        /// 保存解析格式
        /// </summary>
        /// <param name="name"></param>
        /// <param name="chachong"></param>
        /// <param name="excel"></param>
        /// <param name="guize"></param>
        /// <returns></returns>
        public bool SaveFormat(string name, string chachong, string excel, bool newmd5, List<string> guize)
        {
            string str_guize = string.Join("|", guize);
            //保存之前判断格式名称是否重复
            //string str_sql = $"select count(*) from 解析格式表 where 格式名称='{name}' and 删除=0";
            //int formatnum =Convert.ToInt32 (mysqlhelper.ExecuteScalar(str_sql,null));
            //if (formatnum>0)
            //{
            //    MessageBox.Show("保存失败，格式名已存在！");
            //    return false;
            //}
            //保存格式
            string str_sql = $"insert into 解析格式表 values('{name}','{chachong}',@excel,'{str_guize}',0,@newmd5)";




            int num = mysqlhelper.ExecuteNonQuery(str_sql, new MySqlParameter[] {
            new MySqlParameter("@excel",excel),
            new MySqlParameter("@newmd5",newmd5)
            });
            return num > 0 ? true : false;

        }
        /// <summary>
        /// 获得数据库中所有解析格式的名称
        /// </summary>
        /// <returns></returns>
        public List<string> GetFormat()
        {
            List<string> list = new List<string>();
            string str_sql = $"select 格式名称 from 解析格式表 where 删除=0";
            DataTable mydt = mysqlhelper.ExecuteDataTable(str_sql, null);
            foreach (DataRow item in mydt.Rows)
            {
                list.Add(item["格式名称"].ToString());
            }
            return list;

        }
        /// <summary>
        /// 获得某格式信息
        /// </summary>
        /// <param name="formatname">解析格式名称</param>
        /// <returns></returns>
        public FormatInfo GetFormatInfo(string formatname)
        {
            List<string> list = new List<string>();
            string str_sql = $"select * from 解析格式表 where 格式名称='{formatname}' and 删除=0";
            DataRow mydr = mysqlhelper.ExecuteDataRow(str_sql, null);
            return new FormatInfo()
            {
                _formatname = mydr["格式名称"].ToString(),
                _chachongchuli = mydr["查重处理"].ToString(),
                _excelpath = mydr["excel存放"].ToString(),
                list_jiexiguize = Regex.Split(mydr["解析规则"].ToString(), @"\|").ToList(),
                _newmd5 = Convert.ToBoolean(mydr["newmd5"])
            };

        }
        /// <summary>
        /// 获得某规则信息
        /// </summary>
        /// <param name="rulename"></param>
        /// <returns></returns>
        public RuleInfo GetRuleInfo(string rulename)
        {
            List<string> list = new List<string>();
            string str_sql = $"select * from 规则信息表 where 规则名称='{rulename}' and 删除=0";
            DataRow mydr = mysqlhelper.ExecuteDataRow(str_sql, null);
            return new RuleInfo()
            {
                _guizemingcheng = mydr["规则名称"].ToString(),
                _guizeshuoming = mydr["规则说明"].ToString(),
                _chuangjianren = mydr["创建人"].ToString(),
                _chuangjianshijian = mydr["创建时间"].ToString(),
                _wenbentezheng = mydr["文本特征"].ToString(),
            };
        }




        /// <summary>
        /// 刷新dgv_jiexiguize的数据
        /// </summary>
        /// <param name="mydgv"></param>
        public void UpdateDGV(DataGridView mydgv)
        {
            mydgv.Rows.Clear();
            //更新dgv_guize的数据
            DataTable mydt = GetGuize();
            for (int i = 0; i < mydt.Rows.Count; i++)
            {
                int index = mydgv.Rows.Add();
                mydgv.Rows[index].Cells[1].Value = mydt.Rows[i]["规则名称"].ToString();
                mydgv.Rows[index].Cells[2].Value = mydt.Rows[i]["创建人"].ToString();
                mydgv.Rows[index].Cells[3].Value = mydt.Rows[i]["创建时间"].ToString();
            }
            //让所有基础解析规则固定在解析规则的第一位
            foreach (DataGridViewRow item in mydgv.Rows)
            {
                string name = item.Cells["jiexiguizemingcheng"].Value.ToString();
                if (name.Contains("基础解析规则"))
                {
                    //获得行索引
                    var index = item.Index;
                    //复制这一行
                    mydgv.Rows.Remove(item);
                    //在指定位置重新插入第一行
                    mydgv.Rows.Insert(0, item);
                }
            }
        }


        /// <summary>
        /// 解析word文档，在指定的位置保存为一个excel表格
        /// </summary>
        /// <param name="filename">word文档全名</param>
        /// <param name="savepath">保存路径</param>
        /// <param name="formatname">解析格式名称</param>
        /// <returns></returns>
        public async Task<string> JiexiAsync(string filename, string formatname)
        {
            return await Task.Run(() =>
            {
                //构造aspose.words.document 
                Aspose.Words.Document myword = new Aspose.Words.Document(filename);
                //获得他要用到的格式
                FormatInfo myfi = GetFormatInfo(formatname);

                //是否查重
                if (myfi._chachongchuli.Equals("正文"))//如果需要查重，根据 正文，全文进行MD5变换并查重
                {
                    //判断是否重复，如果重复，跳出方法
                    var sections = myword.Sections;
                    foreach (Section sec in sections)
                    {
                        var paras = sec.Body.Paragraphs;
                        foreach (Paragraph para in paras)
                        {
                            //锁定正文范围，居中显示和为零的自然段去掉
                            if (para.GetText().Trim().Equals(string.Empty) || para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                            {
                                para.Remove();
                            }
                        }
                    }
                    //获得正文内容
                    string wordtext = myword.Range.Text;
                    //转化md5
                    string str_md5 = Md5Helper.Md5(wordtext);
                    string str_sql = $"select count(*) from 正文md5表 where md5值='{str_md5}' and  删除=0";
                    int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
                    if (num > 0) return "重复";



                }
                else if (myfi._chachongchuli.Equals("全文"))
                {
                    //判断是否重复，如果重复，跳出方法
                    var sections = myword.Sections;
                    foreach (Section sec in sections)
                    {
                        var paras = sec.Body.Paragraphs;
                        foreach (Paragraph para in paras)
                        {
                            if (para.GetText().Trim().Equals(string.Empty))
                            {
                                para.Remove();
                            }
                        }
                    }
                    //获得全文内容
                    string wordtext = myword.Range.Text;
                    //转化md5
                    string str_md5 = Md5Helper.Md5(wordtext);
                    string str_sql = $"select count(*) from 全文md5表 where md5值='{str_md5}' and  删除=0";
                    int num = Convert.ToInt32(mysqlhelper.ExecuteScalar(str_sql, null));
                    if (num > 0) return "重复";
                }



                //开始解析,先解析基础规则，然后根据复制文本范围向sheet赋值
                //赋值基础规则
                //生成excel表格
                Aspose.Cells.Workbook mywbk = new Aspose.Cells.Workbook();
                Aspose.Cells.Worksheet mysht = mywbk.Worksheets[0];
                //生成基础解析格式部分
                WordInfo mywordinfo = new WordInfo(filename);
                //使用一个方法获得word文档的的所有基础解系对象集合
                mywordinfo.GetAllWenben();
                mywordinfo.AnalysisInfo();
                //赋值字段名称
                mysht.Cells[0, 0].Value = "名称";
                mysht.Cells[0, 1].Value = "文本";
                mysht.Cells[0, 2].Value = "MD5值";
                mysht.Cells[0, 3].Value = "热度";
                mysht.Cells[0, 4].Value = "字数";
                mysht.Cells[0, 5].Value = "位置类关联信息";
                mysht.Cells[0, 6].Value = "内容类关联信息";
                mysht.Cells[0, 7].Value = "关联标准段";
                //循环所有的baseinfo对象到excel表中去
                for (int i = 0; i < mywordinfo.list_baseinfo.Count; i++)
                {
                    mysht.Cells[i + 1, 0].Value = mywordinfo.list_baseinfo[i]._mingcheng;
                    mysht.Cells[i + 1, 1].Value = mywordinfo.list_baseinfo[i]._wenben;
                    mysht.Cells[i + 1, 2].Value = mywordinfo.list_baseinfo[i]._MD5;
                    mysht.Cells[i + 1, 3].Value = mywordinfo.list_baseinfo[i]._redu;
                    mysht.Cells[i + 1, 4].Value = mywordinfo.list_baseinfo[i]._zishu;
                    mysht.Cells[i + 1, 5].Value = mywordinfo.list_baseinfo[i]._weizhiguanlian;
                    mysht.Cells[i + 1, 6].Value = mywordinfo.list_baseinfo[i]._neirongguanlian;
                    mysht.Cells[i + 1, 7].Value = mywordinfo.list_baseinfo[i]._guanlianbiaozhunduan;
                }
                //赋值其他解析信息
                Dictionary<string, string> dic_result = new Dictionary<string, string>();
                for (int i = 0; i < myfi.list_jiexiguize.Count; i++)
                {
                    //获得规则信息 ruleinfo
                    RuleInfo myri = GetRuleInfo(myfi.list_jiexiguize[i]);
                    //把规则详情json反编译得到所有jiexiguize
                    JiexiGuize jiexiguize = JsonConvert.DeserializeObject<JiexiGuize>(myri._wenbentezheng);
                    //循环对特征详情进行解析
                    for (int j = 0; j < jiexiguize.ruleinfo.Count; j++)
                    {
                        RuleDetail myrd = jiexiguize.ruleinfo[j];
                        //获得文本形式的特征对象(匹配对象)，而不是自然段集合，各段落之间用“\r\n”分隔

                        string pipeiduixiang = GetPipeiduixiangStr(myword, myrd.duixiangxuanze,myrd._shunshu,myrd._daoshu);

                        //在匹配对象中获得结果
                        MatchCollection mymc = null;
                        if (myrd.fuzhi.Equals("索引句"))
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<[，、,。]){myrd.wenbentezheng}(?=[，、,。])");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }
                        }
                        else if (myrd.fuzhi.Equals("标准句"))
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<=[^。；;])[\s\S]*{myrd.wenbentezheng}[\s\S]*(?=[。；;])");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }
                        }
                        else if (myrd.fuzhi.Equals("标准段"))//返回自定义的文本特征结果
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<=[^\r\n])[\s\S]*{myrd.wenbentezheng}[\s\S]*(?=[\r\n])");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }
                        }
                        else if (myrd.fuzhi.Equals("后索引句"))//返回自定义的文本特征结果
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<{myrd.wenbentezheng}[\s\S]*[,，、。])[\s\S]+?(?=[,，、。])");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }
                        }
                        else if (myrd.fuzhi.Equals("后标准句"))//返回自定义的文本特征结果
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<{myrd.wenbentezheng}[\s\S]*[,，、。])[\s\S]+?(?=[。；：;:！!……])");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }
                        }
                        else if (myrd.fuzhi.Equals("后标准段"))//返回自定义的文本特征结果
                        {
                            mymc = Regex.Matches(pipeiduixiang, $@"(?<{myrd.wenbentezheng}[\s\S]*[,，、。])[\s\S]+?(?=\r\n)");
                            foreach (Match mymatch in mymc)
                            {
                                myrd.fuzhijieguo.Add(mymatch.Value);
                            }

                        }
                        else if (myrd.fuzhi.Equals("自定义值"))//返回自定义的文本特征结果
                        {
                            myrd.fuzhijieguo.Add(myrd._zidingyivalue);
                        }
                        #region 旧的匹配方法，循环对自然段进行匹配
                        //foreach (Paragraph para in pipeiduixiang)
                        //{
                        //    //获得自然段文本
                        //    string para_str = para.Range.Text;
                        //    //获得自然段文本结果
                        //    bool exist = Regex.IsMatch(para_str, myrd.wenbentezheng);
                        //    //如果包含的话，得到文本特征结果
                        //    if (exist)
                        //    {
                        //        //这里需要判断，如果文本特征结果是自定义的那么返回自定义值，如果不是自定义的（整句），那么就提取整句
                        //        string strresult = string.Empty;
                        //        if (myrd.wenbentezhengjieguo.Equals("仅文本"))
                        //        {
                        //            strresult = Regex.Match(para_str, myrd.wenbentezheng).Value.ToString();
                        //        }
                        //        else if (myrd.wenbentezhengjieguo.Equals("整句"))
                        //        {
                        //            strresult = Regex.Match(para_str, $@"(?<=[^。；;])[\s\S]*{myrd.wenbentezheng}[\s\S]*(?=[。；;])").Value.ToString();
                        //        }
                        //        else//返回自定义的文本特征结果
                        //        {
                        //            strresult = myrd.wenbentezhengjieguo;
                        //        }
                        //        //添加赋值结果和赋值类型到dictionary中
                        //        if (dic_result.Keys.Contains(myrd.fuzhileixing))
                        //        {
                        //            dic_result[myrd.fuzhileixing] += strresult;
                        //        }
                        //        else
                        //        {
                        //            dic_result.Add(myrd.fuzhileixing, strresult);

                        //        }
                        //    }
                        //}

                        #endregion
                        ///在解析结果表中添加相应的赋值类型和赋值结果
                        ///生成基础解析格式之外的部分
                        //获得最后一列索引
                        int lastcol = mysht.Cells.LastCell.Column;
                        mysht.Cells[0, lastcol+1].Value = myrd.fuzhileixing;
                        //判断赋值覆盖范围
                        //获得最后一行索引
                        int lastrow = mysht.Cells.LastCell.Row;
                        for (int r = 1; r < lastrow; r++)
                        {
                            //如果对象名称存在于赋值范围，那么赋值到复制类型列
                            string mingcheng = mysht.Cells[r, 0].StringValue;
                            if (myrd.fuzhifanwei.Contains(mingcheng))
                            {
                                mysht.Cells[r, lastcol+1].Value = myrd.fuzhijieguo;
                            }
                        }
                    }
                }
                //判断是否需要写入MD5值向全文/正文表格中去,如果md5选中了，那么判断正文/全文是否选中，插入到数据库中对应的表
                if (myfi._newmd5)
                {
                    if (myfi._chachongchuli.Equals("正文"))
                    {
                        var zhengwen = GetPipeiduixiang(myword, "正文");
                        string str_zhengwen = string.Empty;
                        foreach (var item in zhengwen)
                        {
                            str_zhengwen += item.Range.Text;
                        }
                        string str_sql = $"insert into 正文MD5表 values(@md5值,@记录文件名,@上传时间,@上传人,@删除)";
                        mysqlhelper.ExecuteNonQuery(str_sql, new MySqlParameter[] {
                    new MySqlParameter("@md5值",Md5Helper.Md5(str_zhengwen)),
                    new MySqlParameter("@记录文件名",filename),
                    new MySqlParameter("@上传时间",DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss")),
                    new MySqlParameter("@上传人",UserInfo._username),
                    new MySqlParameter("@删除",0)
                    });
                    }
                    else if (myfi._chachongchuli.Equals("全文"))
                    {
                        var zhengwen = GetPipeiduixiang(myword, "全文");
                        string str_quanwen = string.Empty;
                        foreach (var item in zhengwen)
                        {
                            str_quanwen += item.Range.Text;
                        }
                        string str_sql = $"insert into 全文MD5表 values(@md5值,@记录文件名,@上传时间,@上传人,@删除)";
                        mysqlhelper.ExecuteNonQuery(str_sql, new MySqlParameter[] {
                    new MySqlParameter("@md5值",Md5Helper.Md5(str_quanwen)),
                    new MySqlParameter("@记录文件名",filename),
                    new MySqlParameter("@上传时间",DateTime.Now.ToString("yyyy年MM月dd日 hh:mm:ss")),
                    new MySqlParameter("@上传人",UserInfo._username),
                    new MySqlParameter("@删除",0)
                    });

                    }
                }
                mywbk.Save($@"{myfi._excelpath}\{Path.GetFileNameWithoutExtension(filename)}.xlsx");
                //MessageBox.Show("解析完成");
                return "完成";
            });
        }



        /// <summary>
        /// 获得以自然段为单位组成的文本特征集合
        /// </summary>
        /// <param name="myword"></param>
        /// <param name="duixiang"></param>
        /// <returns></returns>
        public string GetPipeiduixiangStr(Aspose.Words.Document myword, List<string> duixiang,int shunshu,int daoshu)
        {
            List<string> result = new List<string>();
            foreach (string str in duixiang)
            {


                //对word中的所有自然段，通过格式等判断方式
                //获得全文
                if (str.Equals("全文"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Trim().Equals(string.Empty))
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                //获得正文
                else if (str.Equals("正文"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("文件名"))//获得文件名
                {
                    result.Add(myword.OriginalFileName);

                }
                else if (duixiang.Equals("主标题"))//获得主标题
                {
                    List<Paragraph> list_para = new List<Paragraph>();
                    //获得所有居中自然段，第一个就是主标题
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                            {
                                list_para.Add(para);
                            }
                        }
                    }
                    result.Add(list_para[0].Range.Text);
                    //循环所有自然段，匹配正则表达式  第一章/编
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                            {
                                bool b = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                                result.Add(para.Range.Text);
                            }
                        }
                    }





                }
                else if (duixiang.Equals("副标题"))//获得副标题
                {
                    List<Paragraph> list_para = new List<Paragraph>();
                    //获得所有居中自然段，第一个就是主标题,其余为副标题
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            if (!para.Range.Text.Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                            {
                                list_para.Add(para);
                            }
                        }
                    }
                    for (int i = 1; i < list_para.Count; i++)
                    {
                        result.Add(list_para[i].Range.Text);
                    }
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断结尾是否为标点
                            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                            //判断段落的居中
                            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                            //判断是否以第一节
                            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                            //是否以目录前言开始
                            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                            //判断文字是否为空
                            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                            if ((!empty && !alignment && !jieweifuhao) || kaitou1 || kaitou2)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }

                }
                else if (duixiang.Equals("一级标题"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                            //bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                            if (kaitou)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("二级标题"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                            // bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                            if (kaitou)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("三级标题"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?[,，][\s\S]+");
                            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[,，][\s\S]+");
                            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[,，][\s\S]+");
                            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?条[\s\S]+");
                            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?款[\s\S]+");
                            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+?项[\s\S]+");
                            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                            {
                                result.Add(para.Range.Text);
                            }

                        }
                    }
                }
                else if (duixiang.Equals("正文纲要"))//全文纲要改名为正文纲要
                {
                    //正文纲要和
                }
                else if (duixiang.Equals("一级标题纲要"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断标题级别是否为1
                            bool jibie = para.ListFormat.ListLevelNumber == 1;
                            if (jibie)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("二级标题纲要"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断标题级别是否为2
                            bool jibie = para.ListFormat.ListLevelNumber == 2;
                            if (jibie)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("三级标题纲要"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断标题级别是否为3
                            bool jibie = para.ListFormat.ListLevelNumber == 3;
                            if (jibie)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("法条"))//推后开发
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {

                        }
                    }
                }
                else if (duixiang.Equals("政策文件条款"))//推后开发
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {

                        }
                    }
                }
                else if (duixiang.Equals("语义统计分析"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {

                        }
                    }
                }
                else if (duixiang.Equals("首段"))
                {
                    //获得所有居中自然段，第二个就是首段
                    foreach (Section sec in myword.Sections)
                    {
                        for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                        {
                            bool center = sec.Body.Paragraphs[i].ParagraphFormat.Alignment == ParagraphAlignment.Center;
                            bool empty = sec.Body.Paragraphs[i].Range.Text.Trim().Equals(string.Empty);
                            if (!empty && center)
                            {
                                //获得下一段的文本，如果是空，就再向下滚动
                                string nextparatext;
                                do
                                {
                                    i++;
                                    nextparatext = sec.Body.Paragraphs[i].Range.Text.Trim();
                                } while (nextparatext.Equals(string.Empty));
                                result.Add(nextparatext);
                                break;
                            }
                        }
                    }
                }
                else if (duixiang.Equals("尾段"))
                {
                    var shouduan = myword.LastSection.Body.LastParagraph;
                    result.Add(shouduan.Range.Text);

                }
                else if (duixiang.Equals("单句段"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断是否有句号
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+。[\S\s]");
                            if (!juhao)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("普通标准段"))
                {
                    //获得首段
                    string shouduan = string.Empty;
                    foreach (Section sec in myword.Sections)
                    {
                        for (int i = 0; i < sec.Body.Paragraphs.Count; i++)
                        {
                            bool center = sec.Body.Paragraphs[i].ParagraphFormat.Alignment == ParagraphAlignment.Center;
                            bool empty = sec.Body.Paragraphs[i].Range.Text.Trim().Equals(string.Empty);
                            if (!empty && center)
                            {
                                //获得下一段的文本，如果是空，就再向下滚动
                                string nextparatext;
                                do
                                {
                                    i++;
                                    nextparatext = sec.Body.Paragraphs[i].Range.Text.Trim();
                                } while (nextparatext.Equals(string.Empty));
                                shouduan = sec.Body.Paragraphs[i].Range.Text.Trim();
                                break;
                            }
                        }
                    }
                    //获得尾端
                    string weiduan = myword.LastSection.Body.LastParagraph.Range.Text.Trim();


                    //获得单据段
                    List<string> list_danjuduan = new List<string>();
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+。[\S\s]");
                            if (!juhao)
                            {
                                list_danjuduan.Add(para.Range.Text.Trim());
                            }
                        }
                    }
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            string paratext = para.Range.Text.Trim();
                            bool b1 = shouduan.Equals(paratext);
                            bool b2 = weiduan.Equals(paratext);
                            bool b3 = list_danjuduan.Contains(paratext);
                            if (!b1 && !b2 && !b3)
                            {
                                result.Add(paratext);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("无标点标准句"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool juwei = Regex.IsMatch(para.Range.Text, $@"[\s\S]+(?![;。；……？！?!:])");
                            if (!juwei)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("有标点标准句"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool juwei = Regex.IsMatch(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");
                            if (juwei)
                            {
                                result.Add(para.Range.Text);
                            }
                        }
                    }
                }
                else if (duixiang.Equals("段首标准句"))//需要写清楚
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //获得所有标准句,取第一个集合为段首标准句
                            var matches = Regex.Matches(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");
                            result.Add(para.Range.Text);
                        }
                    }
                }
                else if (duixiang.Equals("首段标准句"))//需要写清楚
                {
                    string paratext = myword.FirstSection.Body.FirstParagraph.Range.Text;
                    //获得所有标准句,取第一个集合为段首标准句
                    var matches = Regex.Matches(paratext, $@"[\s\S]+(?![。……？！?!:])");
                    foreach (string mystr in matches)
                    {
                        result.Add(mystr);
                    }

                }
                else if (duixiang.Equals("普通标准句"))
                {
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //获得所有标准句,取第一个集合为段首标准句
                            var matches = Regex.Matches(para.Range.Text, $@"[\s\S]+(?![。……？！?!:])");
                            for (int i = 1; i < matches.Count; i++)
                            {
                                result.Add( matches[i].Value);
                            }

                        }
                    }
                }
                else if (duixiang.Equals("文件名索引句"))
                {
                    string filename = myword.OriginalFileName;
                    var matches = Regex.Matches(filename, $@"(?<[、，,。])[\s\S]+、?(?=[，,。、])");
                    foreach (Match item in matches)
                    {
                        result.Add( item.Value);
                    }
                }
                else if (duixiang.Equals("主标题索引据"))
                {
                    string mystr = string.Empty;
                    bool get = false;//记录是否已经捕捉到第一个居中的自然段

                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //获得主标题
                            if (!get && !para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                            {
                                if (Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$"))//判断结尾是否含有标点符号
                                {
                                    mystr += para.Range.Text;
                                    get = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                                }
                            }
                            else if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                        }
                    }
                    //对主标题文本开始匹配
                    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        result.Add(item.Value);
                    }
                }
                else if (duixiang.Equals("副标题索引句"))
                {
                    string mystr = string.Empty;//用于记录副标题
                    bool get1 = false;//记录是否已经捕捉到第一个居中的自然段
                    bool get2 = false;//记录是否已经捕捉到第二个居中的自然段
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断结尾是否为标点
                            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                            //判断段落的居中
                            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                            //判断是否以第一节
                            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                            //是否以目录前言开始
                            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                            //判断文字是否为空
                            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                            if (!empty && alignment && jieweifuhao)
                            {
                                if (!get1)//判断和标记第一个居中自然段
                                {
                                    get1 = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                                }
                                else if (!get2)
                                {
                                    mystr += para.Range.Text;
                                    get2 = true;
                                }

                            }
                            else if (kaitou1 && !jieweifuhao)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                            else if (kaitou2 && !jieweifuhao)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                        }
                    }
                    //对副标题文本开始匹配
                    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        result.Add( item.Value);
                    }
                }
                else if (duixiang.Equals("一级标题索引据"))
                {
                    string mystr = string.Empty;
                    //获得一级标题
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                            if (kaitou && juhao)
                            {
                                mystr += para.Range.Text;
                            }
                        }
                    }
                    //获得一级标题索引
                    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        result.Add(item.Value);
                    }


                }
                else if (duixiang.Equals("二级标题索引句"))
                {
                    string mystr = string.Empty;
                    //获得二级标题
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                            if (kaitou && juhao)
                            {
                                mystr += para.Range.Text;
                            }
                        }
                    }
                    //对二级标题开始匹配
                    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        result.Add(item.Value);
                    }
                }
                else if (duixiang.Equals("三级标题索引句"))
                {
                    string mystr = string.Empty;
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+[,，][\s\S]+");
                            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[\s\S]+");
                            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[\s\S]+");
                            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+条[\s\S]+");
                            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+款[\s\S]+");
                            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+项[\s\S]+");
                            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                            {
                                mystr += para.Range.Text;
                            }

                        }
                    }
                    //对三级标题开始匹配
                    var matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        result.Add(item.Value);
                    }
                }
                else if (duixiang.Equals("段首索引句"))
                {
                    //这里的段首索引句提取了整个文章的每一段的第一个索引句
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            var matches = Regex.Matches(para.Range.Text, $@"(?<=[、，,])[\s\S]+、?(?=[，,])");
                            if (matches.Count > 0)
                            {
                                result.Add(matches[0].Value);

                            }
                        }
                    }

                }
                else if (duixiang.Equals("法条索引句"))//以后在做
                {

                }
                else if (duixiang.Equals("政策条款索引句"))//以后再做
                {

                }
                else if (duixiang.Equals("普通索引句"))
                {
                    List<string> list_all = new List<string>();
                    //获得全部的索引据
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            var matches0 = Regex.Matches(para.Range.Text, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                            foreach (Match item in matches0)
                            {
                                list_all.Add(item.Value);
                            }
                        }
                    }

                    //建立一个字段集合，存储之前获得的所有非普通索引据
                    List<string> list = new List<string>();
                    //获得文件名索引句
                    string filename = myword.OriginalFileName;
                    var matches = Regex.Matches(filename, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //获得主标题索引句
                    string mystr = string.Empty;
                    bool get = false;//记录是否已经捕捉到第一个居中的自然段
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //获得主标题
                            if (!get && !para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment == ParagraphAlignment.Center)
                            {
                                if (Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$"))//判断结尾是否含有标点符号
                                {
                                    mystr += para.Range.Text;
                                    get = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                                }
                            }
                            else if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+[编章][\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                        }
                    }
                    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //获得副标题索引句
                    mystr = string.Empty;//用于记录副标题
                    bool get1 = false;//记录是否已经捕捉到第一个居中的自然段
                    bool get2 = false;//记录是否已经捕捉到第二个居中的自然段
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            //判断结尾是否为标点
                            bool jieweifuhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;；]$");
                            //判断段落的居中
                            var alignment = para.ParagraphFormat.Alignment == ParagraphAlignment.Center;
                            //判断是否以第一节
                            bool kaitou1 = Regex.IsMatch(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                            //是否以目录前言开始
                            bool kaitou2 = Regex.IsMatch(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                            //判断文字是否为空
                            bool empty = para.Range.Text.Trim().Equals(string.Empty);
                            if (!empty && alignment && jieweifuhao)
                            {
                                if (!get1)//判断和标记第一个居中自然段
                                {
                                    get1 = true;//如果已经找到第一个居中不为零的自然段，那么就记录下来
                                }
                                else if (!get2)
                                {
                                    mystr += para.Range.Text;
                                    get2 = true;
                                }

                            }
                            else if (kaitou1 && !jieweifuhao)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^第[\s\S]+节[\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                            else if (kaitou2 && !jieweifuhao)
                            {
                                var matches0 = Regex.Matches(para.Range.Text.Trim(), $@"^(目录|前言)[\s\S]+");
                                foreach (Match item in matches0)
                                {
                                    mystr += item.Value;
                                }
                            }
                        }
                    }
                    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //一级标题索引句
                    mystr = string.Empty;
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+、[\s\S]+(?![；。;])");
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"!(?!<。)[\s\S]+(?!。)$");
                            if (kaitou && juhao)
                            {
                                mystr += para.Range.Text;
                            }
                        }
                    }
                    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //二级标题索引句
                    mystr = string.Empty;
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou = Regex.IsMatch(para.Range.Text, $@"^[(（][一二三四五六七八九十][)）][\s\S]+");
                            bool juhao = Regex.IsMatch(para.Range.Text, $@"[\s\S]+[。;]$");
                            if (kaitou && juhao)
                            {
                                mystr += para.Range.Text;
                            }
                        }
                    }
                    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //三级标题索引句
                    mystr = string.Empty;
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            bool kaitou1 = Regex.IsMatch(para.Range.Text, $@"^[一二三四五六七八九十]+是要[\s\S]+");
                            bool kaitou2 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+[,，][\s\S]+");
                            bool kaitou3 = Regex.IsMatch(para.Range.Text, $@"^首先[\s\S]+");
                            bool kaitou4 = Regex.IsMatch(para.Range.Text, $@"^其次[\s\S]+");
                            bool kaitou5 = Regex.IsMatch(para.Range.Text, $@"^[(（]\d+[)）][\s\S]+");
                            bool kaitou6 = Regex.IsMatch(para.Range.Text, $@"^[(（][①②③④⑤⑥⑦⑧⑨⑩][)）][\s\S]+");
                            bool kaitou7 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+条[\s\S]+");
                            bool kaitou8 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+款[\s\S]+");
                            bool kaitou9 = Regex.IsMatch(para.Range.Text, $@"^第[一二三四五六七八九十]+项[\s\S]+");
                            if (kaitou1 || kaitou2 || kaitou3 || kaitou4 || kaitou5 || kaitou6 || kaitou7 | kaitou8 | kaitou9)
                            {
                                mystr += para.Range.Text;
                            }

                        }
                    }
                    //对三级标题开始匹配
                    matches = Regex.Matches(mystr, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                    foreach (Match item in matches)
                    {
                        list.Add(item.Value);
                    }
                    //段首索引句
                    foreach (Section sec in myword.Sections)
                    {
                        foreach (Paragraph para in sec.Body.Paragraphs)
                        {
                            var matches0 = Regex.Matches(para.Range.Text, $@"(?<[、，,])[\s\S]+、?(?=[，,])");
                            list.Add(matches[0].Value);
                        }
                    }
                    //法条索引句，以后做
                    //政策条款索引句，以后做
                    //排除所有的非普通索引句
                    foreach (string mystr1 in list_all)
                    {
                        if (!list.Contains(mystr1))
                        {
                            result .Add(mystr1);
                        }
                    }
                }
                else if (duixiang.Equals("顺数标准段"))
                {
                    List<string> list_paras = new List<string>();
                    foreach (Section section in myword.Sections)
                    {
                        foreach (Paragraph para in section.Body.Paragraphs)
                        {
                            string paratext = para.Range.Text.Trim();
                            if (!paratext.Equals(string.Empty))
                            {
                                list_paras.Add(paratext);
                            }
                        }
                    }
                    result.Add(list_paras[shunshu]);
                }
                else if (duixiang.Equals("倒数标准段"))
                {
                    List<string> list_paras = new List<string>();
                    foreach (Section section in myword.Sections)
                    {
                        foreach (Paragraph para in section.Body.Paragraphs)
                        {
                            string paratext = para.Range.Text.Trim();
                            if (!paratext.Equals(string.Empty))
                            {
                                list_paras.Add(paratext);
                            }
                        }
                    }
                    result.Add(list_paras[daoshu]);
                }






            }
            string str_result = string.Join("|", result);
            return str_result;
        }

        /// <summary>
        /// 获得以自然段为单位组成的文本特征集合
        /// </summary>
        /// <param name="myword"></param>
        /// <param name="duixiang"></param>
        /// <returns></returns>
        public List<Paragraph> GetPipeiduixiang(Aspose.Words.Document myword, string duixiang)
        {
            List<Paragraph> result = new List<Paragraph>();
            //获得全文
            if (duixiang.Equals("全文"))
            {


                foreach (Section sec in myword.Sections)
                {
                    foreach (Paragraph para in sec.Body.Paragraphs)
                    {
                        if (!para.Range.Text.Trim().Equals(string.Empty))
                        {
                            result.Add(para);
                        }
                    }
                }

            }
            //获得正文
            else if (duixiang.Equals("正文"))
            {
                foreach (Section sec in myword.Sections)
                {
                    foreach (Paragraph para in sec.Body.Paragraphs)
                    {
                        if (!para.Range.Text.Trim().Equals(string.Empty) && para.ParagraphFormat.Alignment != ParagraphAlignment.Center)
                        {
                            result.Add(para);
                        }
                    }
                }

            }
            return result;
        }
    }
}
