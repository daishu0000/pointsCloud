using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCloud
{
    //格网类
    class MyGrid
    {
        //记录格网里的点
        public List<MyPoint> Points = new List<MyPoint>();

        public MyGrid()
        {
            ;
        }

        public void AddPoint(MyPoint point)
        {
            Points.Add(point);
        }
    }
}
