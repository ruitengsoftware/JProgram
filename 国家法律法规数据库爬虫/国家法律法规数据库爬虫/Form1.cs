
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 国家法律法规数据库爬虫
{
    public partial class Form1 : Form
    {


        //需要采集的五个连接
        /*
         国家法律法规数据库 https://flk.npc.gov.cn/index.html
         宪法：https://flk.npc.gov.cn/xf.html
        页面连接：https://flk.npc.gov.cn/api/?page=2&type=flfg&searchType=title%3Baccurate&sortTr=f_bbrq_s%3Bdesc&gbrqStart=&gbrqEnd=&sxrqStart=&sxrqEnd=&size=10&_=1614441622658
        区别是page的赋值，返回json结果，如见“点击页面返回json”，请保存sortTr选项 排序
      

        法律：https://flk.npc.gov.cn/fl.html
        行政法规：https://flk.npc.gov.cn/xzfg.html
        地方性法规：https://flk.npc.gov.cn/dfxfg.html
        司法解释：https://flk.npc.gov.cn/sfjs.html
         


        下载文档的连接头：https://wb.flk.npc.gov.cn/
         
         
         
         
         
         
         */


        public Form1()
        {
            InitializeComponent();
        }

        private void btn_caiji_Click(object sender, EventArgs e)
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            //chromeOptions.AddArgument("--disable-gpu");
            IWebDriver mydriver = new OpenQA.Selenium.Chrome.ChromeDriver(chromeOptions);
            mydriver.Navigate().GoToUrl("https://www.baidu.com");


        }
    }
}
