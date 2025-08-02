using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCloud
{
    //结果类
    class ResultLine
    {
        public string Text;
        public double Num;
        //记录要保留几位小数
        public int Accurate;

        public ResultLine(string text,double num,int accurate)
        {
            Text = text;
            Num = num;
            Accurate = accurate;
        }

        //num:顺序
        public string GetText(int num)
        {
            string a = $"F{Accurate}";
            string resultText = $"{num}, {Text}, {Num.ToString(a)}\n";

            return resultText;
        }
    }
}
