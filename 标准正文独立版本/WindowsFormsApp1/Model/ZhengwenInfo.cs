using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Model
{
public    class ZhengwenInfo
    {
       public string _xuhao = string.Empty;//序号
       public string _bianhao = string.Empty;//编号
       public string _laiyuan = string.Empty;//文章来源，不含目录名
       public string _zhuanzailiang = string.Empty;//转载量
       public string _zhengwenneirong = string.Empty;//二进制正文内容
       public string _shijian = string.Empty;//插入数据库时间
       public string _riqi = string.Empty;//日期，原先clickhouse用的

        public bool _exist = false;//数据库中是否存在 

        public Exception _ex = new Exception();//保存错误信息

        public bool _error = false;//是否报错





    }
}
