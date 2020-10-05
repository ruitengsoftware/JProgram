using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BLL
{
    public class DrawHelper
    {
        /// <summary>
        /// 更改控件的尺寸
        /// </summary>
        /// <param name="sender"></param>
        public void UpdateCSize(Control c, Padding p)
        {
            c.Margin = p;
        }

        /// <summary>
        /// 鼠标离开按钮时触发的事件
        /// </summary>
        /// <param name="sender"></param>
        public void MouseLeaveRed(Control sender)
        {
            sender.BackColor = Color.Tomato;
            sender.Margin = new Padding(2, 2, 2, 2);

        }

        /// <summary>
        /// 鼠标经过按钮时出发的事件
        /// </summary>
        /// <param name="sender"></param>
        public void MouseEnterRed(Control sender)
        {
            sender.BackColor = Color.OrangeRed;
            sender.Margin = new Padding(1, 1, 1, 1);

        }
        public void DrawRoundRect(Control label,int hudu)
        {
            float X = (float)(label.Width);
            float Y = (float)(label.Height);
            PointF[] points =
            {
                new PointF(hudu,0),
                new PointF(X-hudu,0),
                new PointF(X,hudu),
                new PointF(X,Y-hudu),
                new PointF(X-hudu,Y),
                new PointF(hudu,Y),
                new PointF(0,Y-hudu),
                new PointF(0,hudu),
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            label.Region = new Region(path);
        }

        /// <summary>
        /// 绘制label圆角
        /// </summary>
        /// <param name="label"></param>
        public void DrawRoundRect(Control label)
        {
            float X = (float)(label.Width);
            float Y = (float)(label.Height);
            PointF[] points =
            {
                new PointF(2,0),
                new PointF(X-2,0),
                new PointF(X,2),
                new PointF(X,Y-2),
                new PointF(X-2,Y),
                new PointF(2,Y),
                new PointF(0,Y-2),
                new PointF(0,2),
            };
            GraphicsPath path = new GraphicsPath();
            path.AddLines(points);
            label.Region = new Region(path);
        }
        /// <summary>
        /// 鼠标进入控件范围内触发的事件
        /// </summary>
        /// <param name="c"></param>
        public void MouseOn(Control c)
        {
            c.ForeColor = Color.Black;
            c.BackColor = Color.White;
        }
        /// <summary>
        /// 鼠标离开控件范围内触发的事件
        /// </summary>
        /// <param name="c"></param>

        public void MouseLeave(Control c)
        {
            c.ForeColor = Color.White;
            c.BackColor = Color.Transparent;
        }
    }
}
