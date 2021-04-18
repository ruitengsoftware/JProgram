using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace 习大大信息库标准化工具.JJCommon
{
   public class Md5Helper
    {

        public static string Md5(string value)
        {
            var result = string.Empty;
            if (string.IsNullOrEmpty(value)) return result;

            //对value进行处理，去掉其中的符号和空格
            value = Regex.Replace(value, @"[（）\s,:!！、，：；。……;]", "");



            using (var md5 = MD5.Create())
            {
                result = GetMd5Hash(md5, value);
            }
            return result;
        }

        static string GetMd5Hash(MD5 md5hash, string input)
        {
            byte[] data = md5hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            var sbuilder = new StringBuilder();
            foreach (byte t in data)
            {
                sbuilder.Append(t.ToString("x2"));
            }
            return sbuilder.ToString();
        }

        static bool VerifyMd5Hash(MD5 md5hash, string input, string hash)
        {
            var hashofinput = GetMd5Hash(md5hash, input);
            var comparer = StringComparer.OrdinalIgnoreCase;
            return 0 == comparer.Compare(hashofinput, hash);
        }
    }
}
