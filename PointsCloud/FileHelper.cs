using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
namespace PointsCloud
{
    class FileHelper
    {
        public static bool OpenFile()
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "文本文件|*.txt";
            of.Title = "打开文件";

            if (of.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(of.FileName);

                int i = 1;

                while (!sr.EndOfStream)
                {
                    string[] items = sr.ReadLine().Trim().Split(' ');

                    double x = double.Parse(items[0]);
                    double y = double.Parse(items[1]);
                    double z = double.Parse(items[2]);

                    string code = $"{x}-{y}-{z}";

                    MyPoint myPoint = new MyPoint(x, y, z,code,i);

                    DataCenter.PointDic[i] = myPoint;

                    i++;
                }

                return true;
            }

            return false;
        }

        public static void OutputFile(string text)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "文本文件|*.txt";
            sf.Title = "保存结果";

            if (sf.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sf.FileName);
                sw.Write(text);
                sw.Close();
            }
        }
    }
}
