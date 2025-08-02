using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCloud
{
    class MyPoint
    {
        public double X;
        public double Y;
        public double Z;

        //Code便于查找
        public string Code;

        //Num表示点的顺序
        public int Num;

        //记录所属单元，便于查找，格式是x-y-z
        public string GridCode;

        public int I;
        public int J;
        public int K;

        //候选点列表，这里只记录num,避免循环调用
        public List<int> HouxuanPointsNumList = new List<int>();

        public List<int> NearestPointsNumList = new List<int>();

        //领域点平均距离
        public double Mu;
        //标准差
        public double Sigma;

        //是否是噪声点，是则为1，否则为0
        public int IsZaosheng;

        public MyPoint(double x, double y, double z, string code, int num)
        {
            X = x;
            Y = y;
            Z = z;
            Code = code;
            Num = num;
        }

        //生成GridCode
        public void GenerateGridCode(int i, int j,int k)
        {
            I = i;
            J = j;
            K = k;
            GridCode = $"{i}-{j}-{k}";
        }
    }
}
