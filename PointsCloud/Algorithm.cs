using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PointsCloud
{
    class Algorithm
    {
        public static void Compute()
        {
            ComputeXYZ();
            ComputePointsCount();
            ComputeGrid();
            KNN();
            ComputeStatistics();
            ComputeZaosheng();
        }

        //获取结果文本
        public static string GetResult()
        {
            string resultText = "序号,说明,计算结果\n";

            int i = 1;
            foreach(ResultLine rl in DataCenter.Result)
            {
                resultText += rl.GetText(i);
                i ++;
            }

            return resultText;
        }

        //给出点P1（第一个点）的x坐标和点P6（第六个点）的y坐标以及P789（第789个点）的z坐标
        private static void ComputeXYZ()
        {
            Dictionary<int, MyPoint> pointDic = DataCenter.PointDic;

            double x1 = pointDic[1].X;
            double y6 = pointDic[6].Y;
            double z789 = pointDic[789].Z;

            ResultLine resultLine1 = new ResultLine("点 P1 的 x 坐标", x1, 3);
            ResultLine resultLine2 = new ResultLine("点 P6 的 y 坐标", y6, 3);
            ResultLine resultLine3 = new ResultLine("点 P789 的 z 坐标", z789, 3);

            DataCenter.Result.Add(resultLine1);
            DataCenter.Result.Add(resultLine2);
            DataCenter.Result.Add(resultLine3);

        }

        //计算原始点云的总点数
        private static void ComputePointsCount()
        {
            double pointsCount = DataCenter.PointDic.Count();

            ResultLine resultLine = new ResultLine("原始点云的总点数", pointsCount, 0);

            DataCenter.Result.Add(resultLine);

        }

        //进行格网划分
        //点云数据x、y、z最大值（xmax, ymax, zmax），格网xyz最小（xmin, ymin, zmin）最大值（xmax1, ymax1, zmax1）（保留3位小数），
        //网格(0,0,0)内的点个数（输出整数），点P1的网格索引（i,j,k）中的i分量(第一分量)，点P6的网格索引（i,j,k）中的j分量 (第二分量)
        private static void ComputeGrid()
        {
            double xMin = DataCenter.PointDic.Values.Select(o => o.X).Min();
            double xMax = DataCenter.PointDic.Values.Select(o => o.X).Max();

            double yMin = DataCenter.PointDic.Values.Select(o => o.Y).Min();
            double yMax = DataCenter.PointDic.Values.Select(o => o.Y).Max();

            double zMin = DataCenter.PointDic.Values.Select(o => o.Z).Min();
            double zMax = DataCenter.PointDic.Values.Select(o => o.Z).Max();

            //边长
            double length = 3.0;
            double xMax1 = Math.Floor((xMax - xMin) / length + 1);
            double yMax1 = Math.Floor((yMax - yMin) / length + 1);
            double zMax1 = Math.Floor((zMax - zMin) / length + 1);

            DataCenter.XMax1 = (int)xMax1;
            DataCenter.YMax1 = (int)yMax1;
            DataCenter.ZMax1 = (int)zMax1;

            //初始化三维数组
            DataCenter.Grids = new MyGrid[(int)xMax1, (int)yMax1, (int)zMax1];
            for(int i = 0; i < xMax1; i++)
            {
                for(int j = 0; j < yMax1; j++)
                {
                    for(int k = 0; k < zMax1; k++)
                    {
                        DataCenter.Grids[i, j, k] = new MyGrid();
                    }
                }
            }
            //计算点云所属的单元
            foreach(MyPoint p in DataCenter.PointDic.Values)
            {
                int i = (int)Math.Floor((p.X - xMin) / length);
                int j = (int)Math.Floor((p.Y - yMin) / length);
                int k = (int)Math.Floor((p.Z - zMin) / length);

                p.GenerateGridCode(i, j, k);
                DataCenter.Grids[i, j, k].AddPoint(p);

            }

            double pointsCount_0_0_0 = DataCenter.Grids[0, 0, 0].Points.Count();

            double p1_i = (double)DataCenter.PointDic[1].I;
            double p6_j = (double)DataCenter.PointDic[6].J;

            ResultLine resultLine1 = new ResultLine("点云数据x最大值", xMax, 3);
            ResultLine resultLine2 = new ResultLine("点云数据y最大值", yMax, 3);
            ResultLine resultLine3 = new ResultLine("点云数据z最大值", zMax, 3);

            ResultLine resultLine4 = new ResultLine("格网 xmin", xMin, 3);
            ResultLine resultLine5 = new ResultLine("格网 xmax1", xMax1, 3);

            ResultLine resultLine6 = new ResultLine("格网 ymin", yMin, 3);
            ResultLine resultLine7 = new ResultLine("格网 ymax1", yMax1, 3);

            ResultLine resultLine8 = new ResultLine("格网 zmin", zMin, 3);
            ResultLine resultLine9 = new ResultLine("格网 zmax1", zMax1, 3);

            ResultLine resultLine10 = new ResultLine("网格 (0,0,0) 内的点个数", pointsCount_0_0_0, 0);

            ResultLine resultLine11 = new ResultLine("点 P1 的网格索引（i,j,k）中i分量", p1_i, 0);
            ResultLine resultLine12 = new ResultLine("点 P6 的网格索引（i,j,k）中j分量", p6_j, 0);

            DataCenter.Result.Add(resultLine1);
            DataCenter.Result.Add(resultLine2);
            DataCenter.Result.Add(resultLine3);
            DataCenter.Result.Add(resultLine4);
            DataCenter.Result.Add(resultLine5);
            DataCenter.Result.Add(resultLine6);
            DataCenter.Result.Add(resultLine7);
            DataCenter.Result.Add(resultLine8);
            DataCenter.Result.Add(resultLine9);
            DataCenter.Result.Add(resultLine10);
            DataCenter.Result.Add(resultLine11);
            DataCenter.Result.Add(resultLine12);


        }

        //k邻近点搜索（k=6）
        //点P1的候选点总数（输出整数）,点P6的候选点总数（输出整数）,
        //点P1的6个邻近点序号中最大值（如“2,3,5,7,9,10”中最大值应为10） ,
        //点P6的6个邻近点序号中最大值

        private static void KNN()
        {
            int kNum = 6;

            foreach(MyPoint p in DataCenter.PointDic.Values)
            {
                int p_i = p.I;
                int p_j = p.J;
                int p_k = p.K;

                List<int> houxuanPointsNumList = new List<int>();

                List<int> nearestPointsNumList = new List<int>();

                //防止溢出，注意这里XMax1等是取不到的
                int i_min = Math.Max(p_i - 1, 0);
                int j_min = Math.Max(p_j - 1, 0);
                int k_min = Math.Max(p_k - 1, 0);

                int i_max = Math.Min(p_i + 2, DataCenter.XMax1);
                int j_max = Math.Min(p_j + 2, DataCenter.YMax1);
                int k_max = Math.Min(p_k + 2, DataCenter.ZMax1);

                for (int i = i_min; i < i_max; i++)
                {
                    for (int j = j_min; j < j_max; j++)
                    {
                        for(int k = k_min; k < k_max; k++)
                        {
                            List<MyPoint> myPoints = DataCenter.Grids[i, j, k].Points;


                            List<int> Nums =  myPoints.Select(o => o.Num).ToList();

                            foreach(int num in Nums)
                            {
                                if(num == p.Num)
                                {
                                    continue;
                                }
                                houxuanPointsNumList.Add(num);
                            }
                        }
                    }

                }

                p.HouxuanPointsNumList = houxuanPointsNumList;

                List<MyPoint> houxuanPointsList = houxuanPointsNumList.Select(o => DataCenter.PointDic[o]).ToList();

                houxuanPointsList = houxuanPointsList.OrderBy(o => GetDistance(p.X, p.Y, p.Z, o.X, o.Y, o.Z)).ToList();

                //选前六个点
                int i_1 = 0;
                foreach(MyPoint myP in houxuanPointsList)
                {
                    if (i_1 > 5)
                    {
                        break;
                    }
                    nearestPointsNumList.Add(myP.Num);
                    i_1++;
                }

                p.NearestPointsNumList = nearestPointsNumList;
            }

            double p1HouxuanCount = DataCenter.PointDic[1].HouxuanPointsNumList.Count();
            double p6HouxuanCount = DataCenter.PointDic[6].HouxuanPointsNumList.Count();

            double p1MaxNum = DataCenter.PointDic[1].NearestPointsNumList.Max();
            double p6MaxNum = DataCenter.PointDic[6].NearestPointsNumList.Max();

            ResultLine resultLine1 = new ResultLine("点 P1 的候选点总数", p1HouxuanCount, 0);
            ResultLine resultLine2 = new ResultLine("点 P6 的候选点总数", p6HouxuanCount, 0);

            ResultLine resultLine3 = new ResultLine("点 P1 的 6 个邻近点序号中最大值", p1MaxNum, 0);
            ResultLine resultLine4 = new ResultLine("点 P6 的 6 个邻近点序号中最大值", p6MaxNum, 0);

            DataCenter.Result.Add(resultLine1);
            DataCenter.Result.Add(resultLine2);
            DataCenter.Result.Add(resultLine3);
            DataCenter.Result.Add(resultLine4);

        }

        //统计特征计算 
        // 点P1的邻域平均距离u1（保留3位小数），点P1的邻域距离标准差σ₁（保留3位小数），点P6的邻域平均距离u6（保留3位小数），
        //点P6的邻域距离标准差σ₆（保留3位小数），全局平均距离均值μ（保留3位小数），全局距离标准差σ（保留3位小数）
        private static void ComputeStatistics()
        {
            //计算每个点的领域平均距离和标准差
            foreach(MyPoint p0 in DataCenter.PointDic.Values)
            {
                double x0 = p0.X;
                double y0 = p0.Y;
                double z0 = p0.Z;

                List<MyPoint> nearestPointsList = p0.NearestPointsNumList.Select(o => DataCenter.PointDic[o]).ToList();

                List<double> distanceList = new List<double>();
                foreach(MyPoint p1 in nearestPointsList)
                {
                    double x1 = p1.X;
                    double y1 = p1.Y;
                    double z1 = p1.Z;

                    double distance = GetDistance(x0, y0, z0, x1, y1, z1);

                    distanceList.Add(distance);
                }

                double mu = distanceList.Average();
                double sigma = Math.Sqrt(
                    distanceList.Select(o=>(o-mu)*(o-mu)).Average()
                    );
                p0.Mu = mu;
                p0.Sigma = sigma;
            }
            DataCenter.Mu = DataCenter.PointDic.Values.Select(o => o.Mu).Average();
            DataCenter.Sigma = DataCenter.PointDic.Values.Select(o => o.Sigma).Average();

            double mu1 = DataCenter.PointDic[1].Mu;
            double sigma1 = DataCenter.PointDic[1].Sigma;

            double mu6 = DataCenter.PointDic[6].Mu;
            double sigma6 = DataCenter.PointDic[6].Sigma;

            ResultLine resultLine1 = new ResultLine("点 P1 的邻域平均距离 u₁", mu1, 3);
            ResultLine resultLine2 = new ResultLine("点 P1 的邻域距离标准差 σ₁", sigma1, 3);

            ResultLine resultLine3 = new ResultLine("点 P6 的邻域平均距离 u₁", mu6, 3);
            ResultLine resultLine4 = new ResultLine("点 P6 的邻域距离标准差 σ₁", sigma6, 3);

            ResultLine resultLine5 = new ResultLine("全局平均距离均值 μ", DataCenter.Mu, 3);
            ResultLine resultLine6 = new ResultLine("全局距离标准差 σ", DataCenter.Sigma, 3);

            DataCenter.Result.Add(resultLine1);
            DataCenter.Result.Add(resultLine2);
            DataCenter.Result.Add(resultLine3);
            DataCenter.Result.Add(resultLine4);
            DataCenter.Result.Add(resultLine5);
            DataCenter.Result.Add(resultLine6);


        }

        //去噪结果
        //点P1是否为噪声点，点P6是否为噪声点（是=1，否=0，输出整数），
        //去噪的噪声点总数（输出整数），去噪后保留的点云总数（输出整数） 
        private static void ComputeZaosheng()
        {
            double mu = DataCenter.Mu;
            double sigma = DataCenter.Sigma;

            foreach(MyPoint p in DataCenter.PointDic.Values)
            {
                if (p.Mu > mu + 2 * sigma)
                {
                    p.IsZaosheng = 1;
                }
                else
                {
                    p.IsZaosheng = 0;
                }
            }

            int p1IsZaosheng = DataCenter.PointDic[1].IsZaosheng;
            int p6IsZaoSheng = DataCenter.PointDic[6].IsZaosheng;

            int zaoshengCount = DataCenter.PointDic.Values.Where(o => o.IsZaosheng == 0).Count();

            ResultLine resultLine1 = new ResultLine("点 P1 是否为噪声点（0、1分别表示否、是）", (double)p1IsZaosheng, 0);
            ResultLine resultLine2 = new ResultLine("点 P6 是否为噪声点（0、1分别表示否、是）", (double)p6IsZaoSheng, 0);
            ResultLine resultLine3 = new ResultLine("去噪后保留的点云总数", (double)zaoshengCount, 0);

            DataCenter.Result.Add(resultLine1);
            DataCenter.Result.Add(resultLine2);
            DataCenter.Result.Add(resultLine3);

        }

        //计算两个点距离
        private static double GetDistance(double x0,double y0,double z0,double x,double y,double z)
        {
            return Math.Sqrt((x0 - x) * (x0 - x) +
                (y0 - y) * (y0 - y) +
                (z0 - z) * (z0 - z)
                );
        }
    }
}
