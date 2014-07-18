/*
 * ini 配置文件操作类
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.IO;

namespace ConsoleApplication2
{
    class configINI
    {
        private string iniPath;

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(
            string section, string key, string val, string filePath);
        /*
         * 参数说明：
         * section：INI文件中的段落；
         * key：INI文件中的关键字；
         * val：INI文件中关键字的数值；
         * filePath：INI文件的完整的路径和名称。
         */
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(
            string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /*
         * 参数说明：
         * section：INI文件中的段落名称；
         * key：INI文件中的关键字；
         * def：无法读取时候时候的缺省数值；
         * retVal：读取数值；
         * size：数值的大小；
         * filePath：INI文件的完整路径和名称。
         */


        /// <summary>
        ///  构造方法
        /// </summary>
        /// <param name="INIPath">文件路径</param>
        public configINI(string INIPath)
        {
            iniPath = INIPath;
        }

        /// <summary>
        ///  写入ini文件,不存在时自动创建
        /// </summary>
        /// <param name="section">项目名称 ( 例如[user])</param>
        /// <param name="key">键</param>
        /// <param name="val">值</param>
        public void writeINI(string section, string key, string val)
        {
            WritePrivateProfileString(section, key, val, iniPath);
        }

        /// <summary>
        ///  读取 ini文件, 
        /// </summary>
        /// <param name="section"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public string readINI(string section, string key)
        {
            StringBuilder temp = new StringBuilder(500);
            int val = GetPrivateProfileString(section, key, "", temp, 500, this.iniPath);

            return temp.ToString();
        }


        /// <summary>
        ///  判断ini文件是否存在.
        /// </summary>
        /// <returns></returns>
        public bool iniExist()
        {
            return File.Exists(this.iniPath);
        }
    }
}
