using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCloud
{
    class DataCenter
    {
        public static Dictionary<int, MyPoint> PointDic = new Dictionary<int, MyPoint>();

        public static List<ResultLine> Result = new List<ResultLine>();

        //格网 三维数组
        public static MyGrid[,,] Grids;

        //记录格网范围
        public static int XMax1;
        public static int YMax1;
        public static int ZMax1;

        //全局均值和标准差
        public static double Mu;
        public static double Sigma;

    }
}
