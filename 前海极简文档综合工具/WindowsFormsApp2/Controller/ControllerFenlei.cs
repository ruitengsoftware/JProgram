using RuiTengDll;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp2.DLL;

namespace WindowsFormsApp2.Controller
{
    public class ControllerFenlei
    {
        //待处理文件夹
        public string _originalpath = string.Empty;
        //待处理文件夹下所有子文件夹名称
        public List<string> _list_directories = new List<string>();
        //格式名称
        public string _format = string.Empty;
        //剪切路径
        public string _path = string.Empty;
        //兼且数量
        public int _shuliang = 0;

        //是否默认名命
        public bool _moren = false;

        //新文件夹命名
        public string _wenjianjia = string.Empty;

        //数据库
        SqliteHelper mysqliter = null;
        string dbfile = $"{Environment.CurrentDirectory}\\ruitengdb.db";
        public ControllerFenlei()
        {
            
        }

        public void GetChildDirectory(string path)
        {
            DirectoryInfo mydirinfo = new DirectoryInfo(path);
            var dirs = mydirinfo.GetDirectories();
            if (dirs.Length > 0)
            {
                for (int i = 0; i < dirs.Length; i++)
                {
                    string dirpath = dirs[i].FullName;
                    GetChildDirectory(dirpath);
                }
            }

            _list_directories.Add(path);
        }



        public List<string> _list_files = new List<string>();

        public void FenLei(string filename)
        {
            List<string> list_files = new List<string>();
            //循环每一个文件夹


            //获得文件夹内的文件
            DirectoryInfo mydi = new DirectoryInfo(filename);
            for (int k = 0; k < mydi.GetFiles().Length; k++)
            {
                _list_files.Add(mydi.GetFiles()[k].FullName);
            }

            Dictionary<int, List<string>> dic = new Dictionary<int, List<string>>();
            for (int i = 0; i < _list_files.Count; i++)
            {
                //获得当前序号除1000的余数
                int index = i / _shuliang + 1;
                if (!dic.ContainsKey(index))
                {
                    dic.Add(index, new List<string>());
                }
                dic[index].Add(_list_files[i]);
            }

            //判断文件数量，如果等于_shuliang，那么移动否则添加到剩余的文件中
            foreach (KeyValuePair<int, List<string>> kv in dic)
            {
                if (kv.Value.Count == _shuliang)
                {
                    string folder = _wenjianjia;
                    _foldernum++;
                    //构造文件夹，如果存在则不需要
                    //判断文件夹内文件夹的数量
                    string path = $"{_path}\\{folder}-{_shuliang}-{(_foldernum).ToString("00")}-{DateTime.Now.ToString("yyyyMMdd")}";

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                    }
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        string str_file = kv.Value[i];
                        //将源文件复制到这个文件夹
                        File.Move(str_file, $"{path}\\{Path.GetFileName(_list_files[i])}");
                    }
                }
                else//加入剩余文件集合
                {
                    _list_files.Clear();
                    for (int i = 0; i < kv.Value.Count; i++)
                    {
                        string str_file = kv.Value[i];
                        //将源文件复制到这个文件夹
                        _list_files.Add(str_file);
                    }
                }
            }


        }

        public int _foldernum = 0;
        public void MoveLast()
        {
            //判断剩余文件数量，如果为0，跳出方法
            if (_list_files.Count==0)
            {
                return;
            }
            string folder = _wenjianjia;
            //判断保存路径文件夹内文件夹的数量
            string path = $"{_path}\\{folder}-{_shuliang}-{(_foldernum + 1).ToString("00")}-{DateTime.Now.ToString("yyyyMMdd")}";
            Directory.CreateDirectory(path);
            for (int i = 0; i < _list_files.Count; i++)
            {
                string str_file = _list_files[i];
                //将源文件复制到这个文件夹
                File.Move(str_file, $"{path}\\{Path.GetFileName(_list_files[i])}");
            }
        }

        //获得所有的格式名称
        public string[] GetFormat()
        {
            var list = _sqlhelper.GetSingleField("模板名称", "分类信息表");
            return list.ToArray();

        }



        //删除指定名称格式
        public void DeleteFormat(string formatname)
        {
            _sqlhelper.DeleteAnyFormat("模板名称", formatname, "分类信息表");
        }


        //保存格式
        public void SaveFormat(Dictionary<string, object> dic)
        {
            _sqlhelper.SaveAnyFormat(dic, "分类信息表");

        }
        MySqlHelper _sqlhelper = new MySqlHelper();
        //获得指定名称的格式记录
        public Dictionary<string, object> GetMuBan(string formatname)
        {
            string str_sql = $"select * from 分类信息表 where 模板名称='{formatname}'";
            var list = _sqlhelper.GetAnySet("分类信息表",new Dictionary<string, object>{ {"模板名称",formatname } });
            return list[0];
        }



    }
}
