using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using 谦海数据解析系统.JJmodel;

namespace 谦海数据解析系统.JJwinform
{
    public partial class BzhRuleForm : Form
    {
        public RuleInfo _ruleInfo = null;
        public BzhRuleForm()
        {
            InitializeComponent();
        }

        public BzhRuleForm(RuleInfo myri)
        {
            InitializeComponent();
            _ruleInfo = myri;
        }
        /// <summary>
        /// 点击加号按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pb_tianjiabiaozhu_Click(object sender, EventArgs e)
        {
            cms_biaozhu.Show(MousePosition.X, MousePosition.Y);

        }
        /// <summary>
        /// 点击文本标注菜单之后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 正则提取ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<string> list = Regex.Split(tb_name.Text, ",").ToList();
            list.Add(((ToolStripMenuItem)sender).Text);
            tb_name.Text = string.Join(",", list);
        }

        private void lbl_quxiao_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        /// <summary>
        /// 点击保存按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbl_baocun_Click(object sender, EventArgs e)
        {
            BzhRuleRoot _myRoot = new BzhRuleRoot();
            _myRoot._shuoming = tb_explain.Text;

            //大标题
            _myRoot._dbthjType = cbb_dbthj.Text;
            _myRoot._dbthjValue = nud_dbthjvalue.Value;
            _myRoot._dbtdqType = cbb_dbtdq.Text;
            _myRoot._dbtkh =Convert.ToInt32( cbb_dbtkh.Text);
            _myRoot._dbtzt = tb_dbtzt.Text;
            _myRoot._dbtzh = nud_dbtzh.Value;
            _myRoot._dbtct = cb_dbtct.Checked;
            _myRoot._dbtsj = nud_dbtsj.Value;
            //副标题                                              ;
            _myRoot._fbthjType = cbb_fbthj.Text;
            _myRoot._fbthjValue = nud_fbthjvalue.Value;
            _myRoot._fbtdqType = cbb_fbtdq.Text;
            _myRoot._fbtkh= Convert.ToInt32(cbb_fbtkh.Text);
            _myRoot._fbtzt = tb_fbtzt.Text;
            _myRoot._fbtzh = nud_fbtzh.Value;
            _myRoot._fbtct = cb_fbtct.Checked;
            _myRoot._fbtsj = nud_fbtsj.Value;
            //正文                                               ;
            _myRoot._zwhjType = cbb_zwhj.Text;
            _myRoot._zwhjValue = nud_zwhjvalue.Value;
            _myRoot._zwdqType = cbb_zwdq.Text;
            _myRoot._zwkh= Convert.ToInt32(cbb_zwkh.Text);
            _myRoot._zwzt = tb_zwzt.Text;
            _myRoot._zwzh = nud_zwzh.Value;
            _myRoot._zwct = cb_zwct.Checked;
            _myRoot._zwsj = nud_zwsj.Value;
            //一级标题                                          ;
            _myRoot._yjbthjType = cbb_yjbthj.Text;
            _myRoot._yjbthjValue = nud_yjbthjvalue.Value;
            _myRoot._yjbtdqType = cbb_yjbtdq.Text;
            _myRoot._yjbtkh = Convert.ToInt32(cbb_yjbtkh.Text);
            _myRoot._yjbtzt = tb_yjbtzt.Text;
            _myRoot._yjbtzh = nud_yjbtzh.Value;
            _myRoot._yjbtct = cb_yjbtct.Checked;
            _myRoot._yjbtsj = nud_yjbtsj.Value;
            //二级标题                                          ;
            _myRoot._ejbthjType = cbb_ejbthj.Text;
            _myRoot._ejbthjValue = nud_ejbthjvalue.Value;
            _myRoot._ejbtdqType = cbb_ejbtdq.Text;
            _myRoot._ejbtkh = Convert.ToInt32(cbb_ejbtkh.Text);
            _myRoot._ejbtzt = tb_ejbtzt.Text;
            _myRoot._ejbtzh = nud_ejbtzh.Value;
            _myRoot._ejbtct = cb_ejbtct.Checked;
            _myRoot._ejbtsj = nud_ejbtsj.Value;
            //三级标题                                          ;
            _myRoot._sjbthjType = cbb_sjbthj.Text;
            _myRoot._sjbthjValue = nud_sjbthjvalue.Value;
            _myRoot._sjbtdqType = cbb_sjbtdq.Text;
            _myRoot._sjbtkh = Convert.ToInt32(cbb_sjbtkh.Text);
            _myRoot._sjbtzt = tb_sjbtzt.Text;
            _myRoot._sjbtzh = nud_sjbtzh.Value;
            _myRoot._sjbtct = cb_sjbtct.Checked;
            _myRoot._sjbtsj = nud_sjbtsj.Value;
            //页边距                                              ;
            _myRoot._zuobianju = nud_zuobianju.Value;
            _myRoot._youbianju = nud_youbianju.Value;
            _myRoot._shangbianju = nud_shangbianju.Value;
            _myRoot._xiabianju = nud_xiabianju.Value;
            //页眉设置                                            ;
            _myRoot._yemeinr = tb_ymnr.Text;
            _myRoot._yemeizt = tb_ymzt.Text;
            _myRoot._yemeizh = nud_ymzh.Value;
            _myRoot._yemeict = cb_ymct.Checked;
            _myRoot._yemeijz = cbb_ymjz.Text;
            //页脚设置                                            ;
            _myRoot._yjnr = tb_yjnr.Text;
            _myRoot._yjzt = tb_yjzt.Text;
            _myRoot._yjzh = nud_yjzh.Value;
            _myRoot._yjct = cb_yjct.Checked;
            _myRoot._yjjz = cbb_yjjz.Text;
            //页码设置                                            ;
            _myRoot._ymgs = cbb_ymags.Text;
            _myRoot._ymzt = cbb_ymazt.Text;
            _myRoot._ymjz = cbb_ymajz.Text;
            //文中空行消除                                        ;
            _myRoot._khxc = cb_xckh.Checked;
            //标注名称                                            ;
            _myRoot._bzmc = tb_name.Text;
            //文本范围                                            ;
            _myRoot._wbfw = tb_fanwei.Text;
            //文本内容                                            ;
            _myRoot._wbnr = tb_neirong.Text;





            //构造一个ruleinfo
            _ruleInfo = new RuleInfo(tb_rulename.Text, SystemInfo._currentModule, _myRoot, SystemInfo._userInfo._shiming,
                    DateTime.Now.ToString("yyyy-MM-dd"));
            //保存到数据库的规则信息表中
            _ruleInfo.SaveRuleInfo();
            this.DialogResult = DialogResult.OK;


        }

        private void BzhRuleForm_Load(object sender, EventArgs e)
        {
            if (_ruleInfo != null)
            {
                tb_rulename.Text = _ruleInfo.ruleName;
                BzhRuleRoot _myRoot = (_ruleInfo._root as BzhRuleRoot);
                tb_explain.Text = _myRoot._shuoming;
                //大标题
                cbb_dbthj.Text = _myRoot._dbthjType;
                nud_dbthjvalue.Value = _myRoot._dbthjValue;
                cbb_dbtdq.Text = _myRoot._dbtdqType;
                cbb_dbtkh.Text = _myRoot._dbtkh.ToString();
                tb_dbtzt.Text = _myRoot._dbtzt;
                nud_dbtzh.Value = _myRoot._dbtzh;
                cb_dbtct.Checked = _myRoot._dbtct;
                nud_dbtsj.Value = _myRoot._dbtsj;
                //副标题
                cbb_fbthj.Text = _myRoot._fbthjType;
                nud_fbthjvalue.Value = _myRoot._fbthjValue;
                cbb_fbtdq.Text = _myRoot._fbtdqType;
                cbb_fbtkh.Text = _myRoot._fbtkh.ToString();
                tb_fbtzt.Text = _myRoot._fbtzt;
                nud_fbtzh.Value = _myRoot._fbtzh;
                cb_fbtct.Checked = _myRoot._fbtct;
                nud_fbtsj.Value = _myRoot._fbtsj;
                //正文
                cbb_zwhj.Text = _myRoot._zwhjType;
                nud_zwhjvalue.Value = _myRoot._zwhjValue;
                cbb_zwdq.Text = _myRoot._zwdqType;
                cbb_zwkh.Text = _myRoot._zwkh.ToString();
                tb_zwzt.Text = _myRoot._zwzt;
                nud_zwzh.Value = _myRoot._zwzh;
                cb_zwct.Checked = _myRoot._zwct;
                nud_zwsj.Value = _myRoot._zwsj;
                //一级标题
                cbb_yjbthj.Text = _myRoot._yjbthjType;
                nud_yjbthjvalue.Value = _myRoot._yjbthjValue;
                cbb_yjbtdq.Text = _myRoot._yjbtdqType;
                cbb_yjbtkh.Text = _myRoot._yjbtkh.ToString();
                tb_yjbtzt.Text = _myRoot._yjbtzt;
                nud_yjbtzh.Value = _myRoot._yjbtzh;
                cb_yjbtct.Checked = _myRoot._yjbtct;
                nud_yjbtsj.Value = _myRoot._yjbtsj;
                //二级标题
                cbb_ejbthj.Text = _myRoot._ejbthjType;
                nud_ejbthjvalue.Value = _myRoot._ejbthjValue;
                cbb_ejbtdq.Text = _myRoot._ejbtdqType;
                cbb_ejbtkh.Text = _myRoot._ejbtkh.ToString();
                tb_ejbtzt.Text = _myRoot._ejbtzt;
                nud_ejbtzh.Value = _myRoot._ejbtzh;
                cb_ejbtct.Checked = _myRoot._ejbtct;
                nud_ejbtsj.Value = _myRoot._ejbtsj;
                //三级标题
                cbb_sjbthj.Text = _myRoot._sjbthjType;
                nud_sjbthjvalue.Value = _myRoot._sjbthjValue;
                cbb_sjbtdq.Text = _myRoot._sjbtdqType;
                cbb_sjbtkh.Text = _myRoot._sjbtkh.ToString();
                tb_sjbtzt.Text = _myRoot._sjbtzt;
                nud_sjbtzh.Value = _myRoot._sjbtzh;
                cb_sjbtct.Checked = _myRoot._sjbtct;
                nud_sjbtsj.Value = _myRoot._sjbtsj;
                //页边距
                nud_zuobianju.Value = _myRoot._zuobianju;
                nud_youbianju.Value = _myRoot._youbianju;
                nud_shangbianju.Value = _myRoot._shangbianju;
                nud_xiabianju.Value = _myRoot._xiabianju;
                //页眉设置
                tb_ymnr.Text = _myRoot._yemeinr;
                tb_ymzt.Text = _myRoot._yemeizt;
                nud_ymzh.Value = _myRoot._yemeizh;
                cb_ymct.Checked = _myRoot._yemeict;
                cbb_ymjz.Text = _myRoot._yemeijz;
                //页脚设置
                tb_yjnr.Text = _myRoot._yjnr;
                tb_yjzt.Text = _myRoot._yjzt;
                nud_yjzh.Value = _myRoot._yjzh;
                cb_yjct.Checked = _myRoot._yjct;
                cbb_yjjz.Text = _myRoot._yjjz;
                //页码设置
                cbb_ymags.Text = _myRoot._ymgs;
                cbb_ymazt.Text = _myRoot._ymzt;
                cbb_ymajz.Text = _myRoot._ymjz;
                //文中空行消除
                cb_xckh.Checked = _myRoot._khxc;
                //标注名称
                tb_name.Text = _myRoot._bzmc;
                //文本范围
                tb_fanwei.Text = _myRoot._wbfw;
                //文本内容
                tb_neirong.Text = _myRoot._wbnr;
            }
        }
        /// <summary>
        /// 点击选择大标题字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_dbtzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_dbtzt.Text = fd.Font.Name;
                nud_dbtzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_dbtct.Checked = true;
                }
                else
                {
                    cb_dbtct.Checked = false;
                }
            }
        }
        /// <summary>
        /// 点击副标题选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_fbtzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_fbtzt.Text = fd.Font.Name;
                nud_fbtzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_fbtct.Checked = true;
                }
                else
                {
                    cb_fbtct.Checked = false;
                }
            }
        }
        /// <summary>
        /// 点击正文选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_zwzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_zwzt.Text = fd.Font.Name;
                nud_zwzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_zwct.Checked = true;
                }
                else
                {
                    cb_zwct.Checked = false;
                }
            }
        }
        /// <summary>
        /// 点击一级标题选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yjbtzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_yjbtzt.Text = fd.Font.Name;
                nud_yjbtzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_yjbtct.Checked = true;
                }
                else
                {
                    cb_yjbtct.Checked = false;
                }
            }
        }
        /// <summary>
        /// 点击二级标题选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ejbtzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_ejbtzt.Text = fd.Font.Name;
                nud_ejbtzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_ejbtct.Checked = true;
                }
                else
                {
                    cb_ejbtct.Checked = false;
                }
            }

        }
        /// <summary>
        /// 点击三级标题选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sjbtzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_sjbtzt.Text = fd.Font.Name;
                nud_sjbtzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_sjbtct.Checked = true;
                }
                else
                {
                    cb_sjbtct.Checked = false;
                }
            }

        }
        /// <summary>
        /// 点击页眉设置选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_ymzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_ymzt.Text = fd.Font.Name;
                nud_ymzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_ymct.Checked = true;
                }
                else
                {
                    cb_ymct.Checked = false;
                }
            }

        }
        /// <summary>
        /// 点击页脚设置选择字体按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_yjzt_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                tb_yjzt.Text = fd.Font.Name;
                nud_yjzh.Value = Convert.ToDecimal(fd.Font.Size);
                if (fd.Font.Bold)
                {
                    cb_yjct.Checked = true;
                }
                else
                {
                    cb_yjct.Checked = false;
                }
            }
        }
    }
}
