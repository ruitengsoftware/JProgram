using Aspose.Words;
using Aspose.Words.Drawing;
using Model;
using RuiTengDll;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerPicture
    {
        public string _jianqielujing = string.Empty;
        public string _rizhilujing = string.Empty;
        public string _xiangsidu = string.Empty;
        public bool _chicun = false;
        public bool _stop = false;
        public List<string> _selectpic = new List<string>();
       public MySqlHelper _sqlhelper = new MySqlHelper();
        public ControllerPicture()
        {
        }
        /// <summary>
        /// 获得数据库中所有的图片
        /// </summary>
        /// <returns></returns>
        public List<PictureInfo> GetPic()
        {
            var list_o = _sqlhelper.GetAnySet("图片表");

            List<PictureInfo> list_result = new List<PictureInfo>();
            PictureInfo pic = new PictureInfo();
            foreach (var obj in list_o)
            {
                pic = new PictureInfo();
                Dictionary<string, object> dic = obj as Dictionary<string, object>;
                pic._picName = dic["图片名"].ToString();
                pic._base64 = dic["base64"].ToString();
                list_result.Add(pic);
            }
            return list_result;
        }
        /// <summary>
        /// 删除指定格式的记录
        /// </summary>
        public void DeleteFormat(string formatname)
        {
            _sqlhelper.DeleteAnyFormat("格式名", formatname, "图片处理表");

        }
        /// <summary>
        /// 保存总体格式
        /// </summary>
        /// <param name="o"></param>
        public void SaveFormat(object o)
        {
            Dictionary<string, object> dic = o as Dictionary<string, object>;
            _sqlhelper.SaveAnyFormat(dic, "图片处理表");
        }
        /// <summary>
        /// 根据格式名称获得响应设置
        /// </summary>
        /// <param name="formatname"></param>
        /// <returns></returns>
        public Dictionary<string, object> GetForamtInfo(string formatname)
        {
            string str_sql = $"select * from 图片处理表 where 格式名='{formatname}'";
            Dictionary<string, object> dic = new Dictionary<string, object>{
                {"格式名",formatname } };
            var list = _sqlhelper.GetAnySet("图片处理表", dic);
            return list[0];

        }

        /// <summary>
        /// 获得日志历史记录
        /// </summary>
        /// <returns></returns>
        public DataTable GetRizhiDT(string filename)
        {
            StreamReader sr = new StreamReader(filename);
            MatchCollection matches = Regex.Matches(sr.ReadToEnd(), @"\d{8}.*?修改\d*条");
            DataTable mydt = new DataTable();
            mydt.Columns.Add("时间");
            mydt.Columns.Add("任务数量");
            mydt.Columns.Add("修改word文档数量");
            foreach (Match match in matches)
            {
                string record = match.Value;
                var newrow = mydt.NewRow();
                newrow["时间"] = Regex.Match(record, @"\d{8}[\s\S]*(?=\s)").Value;
                newrow["任务数量"] = Regex.Match(record, @"(?<=\s)\d*(?=条)").Value;
                newrow["修改word文档数量"] = Regex.Match(record, @"(?<=修改)\d*").Value;
                mydt.Rows.Add(newrow);
            }
            return mydt;
        }

        public void ChuliTupian(string filename, ref int zongshu, ref int shanchu)
        {
            #region 旧代码
            //string starttime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            //int chongfunum = 0;//存储修改条数

            //List<string> list_same = new List<string>();//存储修改文件

            //foreach (DataGridViewRow dgvrow in dgv_task.Rows)
            //{
            //    //判断用户是否手动停止了搜索
            //    if (_stopchuli)
            //    {
            //        break;
            //    }
            //    string filename = dgvrow.Cells[1].Value.ToString();
            //    //判断用户是否选择了对正文处理或者对文件名处理
            //    bool xiugaizhengwen = false;

            //    if (Setting._zhengwen)
            //    {
            //        //判断后缀是否为excel文件格式
            //        string houzhui = Path.GetExtension(filename);
            //        if (houzhui.Contains(".xls"))//处理excel文件
            //        {
            //            xiugaizhengwen = ChuliExcel(filename);
            //        }
            //        else//处理word文件
            //        {
            //            xiugaizhengwen = ChuliWord(filename);

            //        }

            //    }
            //    bool xiugaiwenjianming = false;
            //    if (Setting._wenjianming)
            //    {
            //        xiugaiwenjianming = ChuliWenJianMing(filename);
            //    }
            //    dgvrow.Cells[2].Value = "100%";
            //    if (xiugaizhengwen || xiugaiwenjianming)
            //    {
            //        dgvrow.Cells[3].Value = "修改";
            //        chongfunum++;
            //    }
            //    else
            //    {
            //        dgvrow.Cells[3].Value = "无";

            //    }
            //}
            ////准备写入查重日志的内容
            //StringBuilder mysb = new StringBuilder();
            //string endtime = DateTime.Now.ToString("yyyyMMdd-HH:mm");
            //mysb.AppendLine($"{starttime}————{endtime}  {dgv_task.Rows.Count}条  修改{chongfunum}条");
            //list_same.ForEach((same) => { mysb.AppendLine($"{list_same.IndexOf(same)}.{same}"); });
            //mysb.AppendLine();

            ////写入查重日志，如果没有的话创建
            //StreamWriter sw = new StreamWriter(Setting._rizhilujing, true);
            //sw.WriteLine(mysb);
            //sw.Flush();
            //sw.Close();

            #endregion
            //打开文件
            Aspose.Words.Document myword = new Aspose.Words.Document(filename);
            //获得所有图片，开始循环
            NodeCollection shapes = myword.GetChildNodes(NodeType.Shape, true);
            zongshu = shapes.Count;
            for (int i = shapes.Count-1; i>=0; i--)
            {
                try
                {
                    var shape = shapes[i] as Shape;
                    if (shape.HasImage)//判断shape是否为图片，如果是，进行相似度计算
                    {
                        MemoryStream ms = new MemoryStream();
                        shape.ImageData.Save(ms);
                        Bitmap mybmp = new Bitmap(ms);
                        //循环选中文件名字，获得数据库中的base64，转为图片
                        foreach (string picname in _selectpic)
                        {
                            var bmp = GetBmp(picname);
                            float xiangsidu = 0;
                            //如果尺寸选中，那么先对比尺寸，尺寸相同再对比相似度，如果尺寸不同，直接不相似
                            if (_chicun)
                            {
                                if (mybmp.Width == bmp.Width && mybmp.Height == bmp.Height)
                                {
                                    xiangsidu = CalcSimilarDegree(mybmp, bmp);
                                }
                                else
                                {
                                    xiangsidu = 0;
                                }
                            }
                            else//如果未选中尺寸， 直接进行对比
                            {
                                xiangsidu = CalcSimilarDegree(mybmp, bmp);
                            }
                            // 如果大于等于设定的值，删掉图片，并记录删除个数
                            if (xiangsidu >= Convert.ToDouble(_xiangsidu))
                            {
                                shape.Remove();
                                shanchu++;
                            }
                        }
                    }
                }
                catch (Exception ex) {
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
            //判断是否还含有图片如果是，剪贴到指定文件夹，
            //如果图片数量大于0，保存文档到剪切路径
            if (shanchu >0 && shanchu<zongshu)
            //if (shanchu!=zongshu)

            {
                //构造保存路径
                string savepath = $"{_jianqielujing}\\{Path.GetFileName(filename)}";
                myword.Save(savepath);
                //删除原来位置
                File.Delete(filename);
            }
            else
            {
                //保存文件名
                myword.Save(filename);
            }
        }
        /// <summary>
        /// 计算两组灰度的相似度
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="scondNum"></param>
        /// <returns></returns>
        public float GetResult(int[] firstNum, int[] scondNum)
        {
            if (firstNum.Length != scondNum.Length)
            {
                return 0;
            }
            else
            {
                float result = 0;
                int j = firstNum.Length;
                for (int i = 0; i < j; i++)
                {
                    result += 1 - GetAbs(firstNum[i], scondNum[i]);
                }
                return result / j;
            }
        }
        /// <summary>
        /// 计算两个数相减的绝对值
        /// </summary>
        /// <param name="firstNum"></param>
        /// <param name="secondNum"></param>
        /// <returns></returns>
        private float GetAbs(int firstNum, int secondNum)
        {
            float abs = Math.Abs((float)firstNum - (float)secondNum);
            float result = Math.Max(firstNum, secondNum);
            if (result == 0)
                result = 1;
            return abs / result;
        }
        /// <summary>
        /// 获得图像的灰度
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        /// <summary>
        /// 转换图片尺寸
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public Bitmap Resize(Image img)
        {
            Bitmap btp = new Bitmap(img, 256, 256);
            return btp;
        }

        /// <summary>
        /// 向数据库添加图片
        /// </summary>
        /// <param name="filename"></param>
        public void SavePic(string filename)
        {
            string base64 = ImgToBase64String(filename);
            string picname = Path.GetFileNameWithoutExtension(filename);
            Dictionary<string, object> dic = new Dictionary<string, object>(){
                {"图片名" ,picname},
                {"base64",base64 }
            };
            //先删掉相同文档名
            _sqlhelper.DeleteAnyFormat("图片名", picname, "图片表");
            _sqlhelper.SaveAnyFormat(dic, "图片表");
            System.Windows.Forms.MessageBox.Show($"图片 {picname} 保存成功！");
        }

        /// <summary>
        /// 将图片转换为base64位编码
        /// </summary>
        /// <param name="Imagefilename"></param>
        /// <returns></returns>
        public string ImgToBase64String(string Imagefilename)
        {
            try
            {
                Bitmap bmp = new Bitmap(Imagefilename);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] arr = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(arr, 0, (int)ms.Length);
                ms.Close();
                return Convert.ToBase64String(arr);
            }
            catch
            {
                return string.Empty;
            }
        }
        /// <summary>
        /// base64编码的文本转为图片
        /// </summary>
        /// <param name="base64Str"></param>
        /// <param name="savePath"></param>
        public Image Base64StringToImage(string base64Str)
        {
            //将base64头部信息替换
            base64Str = base64Str.Replace("data:image/png;base64,", "").Replace("data:image/jgp;base64,", "")
                .Replace("data:image/jpg;base64,", "").Replace("data:image/jpeg;base64,", "");
            byte[] arr = Convert.FromBase64String(base64Str);
            using (MemoryStream ms = new MemoryStream(arr))
            {
                return new Bitmap(ms);
            }
        }

        /// <summary>
        /// 从数据库中获得指定名称的图片
        /// </summary>
        /// <param name="imgname"></param>
        /// <returns></returns>
        public Bitmap GetBmp(string imgname)
        {
            var list = _sqlhelper.GetAnySet("图片表", new Dictionary<string, object> { { "图片名", imgname } });

            Dictionary<string, object> dic = list[0];
            string base64 = dic["base64"].ToString();
            Bitmap bmp = Base64StringToImage(base64) as Bitmap;
            return bmp;
        }





        public String GetHash(Image img)
        {
            Image image = ReduceSize(img);
            Byte[] grayValues = ReduceColor(image);
            Byte average = CalcAverage(grayValues);
            String result = ComputeBits(grayValues, average);
            return result;
        }

        // Step 1 : Reduce size to 8*8
        private Image ReduceSize(Image img, int width = 8, int height = 8)
        {
            Image image = img.GetThumbnailImage(width, height, () => { return false; }, IntPtr.Zero);
            return image;
        }

        // Step 2 : Reduce Color
        private Byte[] ReduceColor(Image image)
        {
            Bitmap bitMap = new Bitmap(image);
            Byte[] grayValues = new Byte[image.Width * image.Height];

            for (int x = 0; x < image.Width; x++)
                for (int y = 0; y < image.Height; y++)
                {
                    Color color = bitMap.GetPixel(x, y);
                    byte grayValue = (byte)((color.R * 30 + color.G * 59 + color.B * 11) / 100);
                    grayValues[x * image.Width + y] = grayValue;
                }
            return grayValues;
        }

        // Step 3 : Average the colors
        private Byte CalcAverage(byte[] values)
        {
            int sum = 0;
            for (int i = 0; i < values.Length; i++)
                sum += (int)values[i];
            return Convert.ToByte(sum / values.Length);
        }

        // Step 4 : Compute the bits
        private String ComputeBits(byte[] values, byte averageValue)
        {
            char[] result = new char[values.Length];
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] < averageValue)
                    result[i] = '0';
                else
                    result[i] = '1';
            }
            return new String(result);
        }

        /// <summary>
        /// 计算两个图片的相似度
        /// </summary>
        /// <param name="imga"></param>
        /// <param name="imgb"></param>
        /// <returns></returns>
        public Int32 CalcSimilarDegree(Image imga, Image imgb)
        {
            string a = GetHash(imga);
            string b = GetHash(imgb);
            if (a.Length != b.Length)
                throw new ArgumentException();
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    count++;
            }
            int result = 100 - count * 100 / a.Length;
            return result;
        }





    }
}
