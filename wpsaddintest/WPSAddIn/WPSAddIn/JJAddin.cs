using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AddInDesignerObjects;
using Office;
using Word;




namespace WPSAddIn
{
    public class JJAddin:IDTExtensibility2,IRibbonExtensibility
    {
        public static Word.Application app = null;
        public static object jjword;

        public void OnConnection(object Application, ext_ConnectMode ConnectMode, object AddInInst, ref Array custom)
        {
            jjword = Application;
            app = jjword as Word.Application;
        }

        public void OnDisconnection(ext_DisconnectMode RemoveMode, ref Array custom)
        {
            throw new NotImplementedException();
        }

        public void OnAddInsUpdate(ref Array custom)
        {
            throw new NotImplementedException();
        }

        public void OnStartupComplete(ref Array custom)
        {
            throw new NotImplementedException();
        }

        public void OnBeginShutdown(ref Array custom)
        {
            throw new NotImplementedException();
        }

        public string GetCustomUI(string RibbonID)
        {
            return Properties.Resource1.MyRibbon;
        }

        public Bitmap GetRibbonImage(IRibbonControl ctrl)
        {
            switch (ctrl.Id)
            {
                case "Test":
                    return Properties.Resource1.瑞腾logo路径;
            }
            return null;
        
        }
        public void setCommonRH2(IRibbonControl ctrl)
        {
            MessageBox.Show("Hello World");
        }
    }
}
