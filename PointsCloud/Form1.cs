using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointsCloud
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsmi_openFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (FileHelper.OpenFile() == true)
                {
                    tssl_isOpen.Text = "已打开";

                    int i = 0;

                    dgv_input.RowCount = DataCenter.PointDic.Count;

                    foreach(MyPoint p in DataCenter.PointDic.Values)
                    {
                        dgv_input[0, i].Value = p.X;
                        dgv_input[1, i].Value = p.Y;
                        dgv_input[2, i].Value = p.Z;
                        i++;
                    }
                }
            }
            catch
            {
                MessageBox.Show("文件格式错误");
            }


        }

        private void tsmi_compute_Click(object sender, EventArgs e)
        {
            if(tssl_isOpen.Text == "未打开")
            {
                MessageBox.Show("请先打开文件");
                return;
            }
            try
            {
                Algorithm.Compute();

                rtb_result.Text = Algorithm.GetResult();

                tabControl1.SelectedIndex = 1;

                tssl_isCompute.Text = "已计算";
            }
            catch
            {
                MessageBox.Show("计算失败");
            }
        }

        private void tsmi_output_Click(object sender, EventArgs e)
        {
            if(tssl_isCompute.Text == "未计算")
            {
                MessageBox.Show("请先计算");
                return;
            }
            try
            {
                string text = rtb_result.Text;
                FileHelper.OutputFile(text);

            }
            catch
            {
                MessageBox.Show("输出失败");
            }
        }

        private void tsb_openFile_Click(object sender, EventArgs e)
        {
            tsmi_openFile_Click(sender, e);
        }

        private void tsb_compute_Click(object sender, EventArgs e)
        {
            tsmi_compute_Click(sender, e);
        }

        private void tsb_output_Click(object sender, EventArgs e)
        {
            tsmi_output_Click(sender, e);
        }
    }
}
