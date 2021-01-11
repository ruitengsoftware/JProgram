using Aspose.Words;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 团队任务台账管理系统.Controller;
using 团队任务台账管理系统.JJModel;

namespace 团队任务台账管理系统.WinForm
{
    public partial class WinFormTongzhi : Form
    {


        ControllerWFtongzhigonggao _myc = new ControllerWFtongzhigonggao();
        JJTongzhiInfo myinfo = new JJTongzhiInfo();


        public WinFormTongzhi()
        {
            InitializeComponent();
            richTextBox1.LoadFile(@".\tongzhi.rtf");
        }

        public WinFormTongzhi(JJTongzhiInfo info)
        {
            InitializeComponent();
            myinfo = info;
            //这里不在显示原窗体，改为word形式
            Document myword = new Document();
            DocumentBuilder myb = new DocumentBuilder(myword);
            //添加标题
            Aspose.Words.Font font = myb.Font;
            font.Size = 16;
            font.Bold = true;
            //font.Color = System.Drawing.Color.Blue;
            //font.Name = "Arial";
            //font.Underline = Underline.Dash;

            // Specify paragraph formatting
            ParagraphFormat paragraphFormat = myb.ParagraphFormat;
            //paragraphFormat.FirstLineIndent = 8;
            paragraphFormat.Alignment = ParagraphAlignment.Center;
            //paragraphFormat.KeepTogether = true;
            myb.Writeln(info._biaoti);
            //添加 签发人

            font.Size = 12;
            font.Bold = true;
            //font.Color = System.Drawing.Color.Blue;
            //font.Name = "Arial";
            //font.Underline = Underline.Dash;

            // Specify paragraph formatting
            paragraphFormat = myb.ParagraphFormat;
            //paragraphFormat.FirstLineIndent = 8;
            paragraphFormat.Alignment = ParagraphAlignment.Center;
            //paragraphFormat.KeepTogether = true;

            myb.Writeln(info._qianfaren);
            myb.Writeln("");



            //添加内容
            font.Size = 12;
            font.Bold = false;
            //font.Color = System.Drawing.Color.Blue;
            //font.Name = "Arial";
            //font.Underline = Underline.Dash;

            // Specify paragraph formatting
            paragraphFormat = myb.ParagraphFormat;
            paragraphFormat.FirstLineIndent = 8;
            paragraphFormat.Alignment = ParagraphAlignment.Justify;
            //paragraphFormat.KeepTogether = true;

            myb.Writeln(info._neirong);

            string dataDir = @".\tongzhi.rtf";
            myword.Save(dataDir, SaveFormat.Rtf);

            richTextBox1.LoadFile(@".\tongzhi.rtf");
        }



        private void lbl_yiyuezhi_Click(object sender, EventArgs e)
        {
          bool b=  _myc.Yidu(myinfo);
            if (b)
            {
                MessageBox.Show("已阅读通知！");
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
