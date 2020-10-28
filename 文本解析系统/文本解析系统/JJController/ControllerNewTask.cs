using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文本解析系统.JJController
{
    public class ControllerNewTask
    {
        public List<string> _childdirectories = new List<string>();
        public void GetDirectory(string folder)
        {

           //判断是否含有子文件夹，如果没有，加入



            _childdirectories = new List<string>();
            _childdirectories.Add(folder);
            DirectoryInfo mydir = new DirectoryInfo(folder);
            string[] dirs = Directory.GetDirectories(folder);
            if (dirs.Length==0)
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



    }
}
