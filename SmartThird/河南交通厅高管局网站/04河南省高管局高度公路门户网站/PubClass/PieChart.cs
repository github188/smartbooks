using System;
using System.IO;//用于文件存取
using System.Data;//用于数据访问
using System.Drawing;//提供画GDI+图形的基本功能
using System.Drawing.Text;//提供画GDI+图形的高级功能
using System.Drawing.Drawing2D;//提供画高级二维，矢量图形功能
using System.Drawing.Imaging;//提供画GDI+图形的高级功能
using System.Text;
namespace pie_write
{
    public class PieChart
    {
        public PieChart()
        {
        }
        public void Render(string title, string subTitle, int width, int height, DataSet chartData, Stream target)
        {
            const int SIDE_LENGTH = 400;
            const int PIE_DIAMETER = 200;
            DataTable dt = chartData.Tables[0];

            //通过输入参数，取得饼图中的总基数
            float sumData = 0;
            foreach (DataRow dr in dt.Rows)
            {
                sumData += Convert.ToSingle(dr[1]);
            }
            //产生一个image对象，并由此产生一个Graphics对象
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            //设置对象g的属性
            g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH,
            (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //画布和边的设定
            g.Clear(Color.White);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //画饼图标题
            g.DrawString(title, new Font("Tahoma", 24),
            Brushes.Black, new PointF(5, 5));
            //画饼图的图例
            g.DrawString(subTitle, new Font("Tahoma", 14),
            Brushes.Black, new PointF(7, 35));
            //画饼图
            float curAngle = 0;
            float totalAngle = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                curAngle = Convert.ToSingle(dt.Rows[i][1]) / sumData * 360;

                g.FillPie(new SolidBrush(ChartUtil.GetChartItemColor(i)), 100, 65, PIE_DIAMETER,
                PIE_DIAMETER, totalAngle, curAngle);
                g.DrawPie(Pens.Black, 100, 65, PIE_DIAMETER, PIE_DIAMETER,
                totalAngle, curAngle);
                totalAngle += curAngle;
            }
            //画图例框及其文字
            g.DrawRectangle(Pens.Black, 200, 300, 199, 99);
            g.DrawString("Legend", new Font("Tahoma", 12, FontStyle.Bold),
            Brushes.Black, new PointF(200, 300));

            //画图例各项
            PointF boxOrigin = new PointF(210, 330);
            PointF textOrigin = new PointF(235, 326);
            float percent = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(i)),
                boxOrigin.X, boxOrigin.Y, 20, 10);
                g.DrawRectangle(Pens.Black, boxOrigin.X, boxOrigin.Y, 20, 10);
                percent = Convert.ToSingle(dt.Rows[i][1]) / sumData * 100;
                g.DrawString(dt.Rows[i][0].ToString() + " - " + dt.Rows
                [i][1].ToString() + " (" + percent.ToString("0") + "%)", new Font("Tahoma", 10), Brushes.Black, textOrigin);
                boxOrigin.Y += 15;
                textOrigin.Y += 15;
            }
            //通过Response.OutputStream，将图形的内容发送到浏览器
            bm.Save(target, ImageFormat.Gif);
            //回收资源
            bm.Dispose();
            g.Dispose();
        }
    }
    //画条形图
    public class BarChart
    {
        public BarChart()
        {
        }
        public void Render(string title, string subTitle,
        int width, int height, DataSet chartData, Stream target, string[] question)
        {
            const int SIDE_LENGTH = 820;
            const int CHART_TOP = 75;
            const int CHART_HEIGHT = 420;
            const int CHART_LEFT = 50;
            const int CHART_WIDTH = 620;
            DataTable dt = chartData.Tables[0];

            //计算最高的点
            float highPoint = dt.Rows.Count;

            //建立一个Graphics对象实例
            Bitmap bm = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bm);
            //设置条图图形和文字属性
            g.ScaleTransform((Convert.ToSingle(width)) / SIDE_LENGTH,
            (Convert.ToSingle(height)) / SIDE_LENGTH);
            g.SmoothingMode = SmoothingMode.Default;
            g.TextRenderingHint = TextRenderingHint.AntiAlias;

            //设定画布和边

            g.Clear(Color.SkyBlue);
            g.DrawRectangle(Pens.Black, 0, 0, SIDE_LENGTH - 1, SIDE_LENGTH - 1);
            //画大标题
            g.DrawString(title, new Font("Tahoma", 15), Brushes.Black, new PointF(5, 5));
            //画小标题
            g.DrawString(subTitle, new Font("Tahoma", 10),
            Brushes.Black, new PointF(7, 35));
            //画条形图
            float barWidth = CHART_WIDTH / (30);
            PointF barOrigin = new PointF(CHART_LEFT + (barWidth / 2), 0);
            float barHeight = highPoint;
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                int Count_A = 0;
                int Count_B = 0;
                int Count_C = 0;
                g.DrawRectangle(Pens.Black, (i) * 50 + 60, 145, 40, 350);
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    switch (dt.Rows[j][i].ToString().Trim())
                    {
                        case "A": Count_A++; break;
                        case "B": Count_B++; break;
                        case "C": Count_C++; break;
                    }

                }
                StringBuilder s = new StringBuilder();


                foreach (char c in question[i].ToCharArray())
                {
                    s.AppendLine(c.ToString());
                }




                //     s.AppendLine("问").AppendLine("题").AppendLine(Convert.ToInt32(i + 1).ToString());
                g.DrawString(s.ToString(), new Font("Tahoma", 12), Brushes.Black, new PointF((i) * 50 + 65, 500));

                int hei2 = 0;
                int hei = 0;
                Double precent = 0.00;
                for (int x = 0; x < 3; x++)
                {

                    switch (x)
                    {
                        case 0: hei = Count_A; precent = (Convert.ToDouble(Count_A / highPoint) * 100 / 100); break;
                        case 1: hei = Count_B; precent = Convert.ToDouble(Count_B / highPoint) * 100 / 100; break;
                        case 2: hei = Count_C; precent = Convert.ToDouble(Count_C / highPoint) * 100 / 100; break;
                    }
                    if (hei == 0)
                        continue;
                    else
                    {

                        g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(x)),
                            (i) * 50 + 60, x == 0 ? 145 : 145 + hei2, 40, Convert.ToInt32(((hei * 350) / highPoint)));
                        //     g.DrawString((precent ).ToString() , new Font("Tahoma", 10), Brushes.Black, new PointF((i) * 50 + 60, x == 0 ? 155 : 155 + hei2));
                        int fontSize = 12;
                        //   hei = 200;
                        if (Convert.ToInt32(hei) > 100)
                        {
                            fontSize = 9;
                        }
                        if (hei.ToString().Length - highPoint.ToString().Length <= -2)
                        {

                        }
                        else
                            g.DrawString((hei).ToString() + " 票", new Font("Tahoma", fontSize), Brushes.Black, new PointF((i) * 50 + 60, x == 0 ? 145 : 145 + hei2));

                        //g.DrawString((precent*100).ToString("F2")+"%", new Font("Tahoma", 10), Brushes.Black, new PointF((i) * 50 + 60, x == 0 ? 155 : 155 + hei2));
                        hei2 += Convert.ToInt32(((hei * 350) / highPoint));

                    }

                }





            }
            //设置边
            g.DrawLine(new Pen(Color.Black, 2), new Point
            (CHART_LEFT, CHART_TOP), new Point(CHART_LEFT, CHART_TOP + CHART_HEIGHT));
            g.DrawLine(new Pen(Color.Black, 2), new Point
            (CHART_LEFT, CHART_TOP + CHART_HEIGHT), new Point
            (CHART_LEFT + CHART_WIDTH + 200, CHART_TOP + CHART_HEIGHT));
            //画图例框和文字
            g.DrawRectangle(new Pen(Color.Black, 1), 550, 650, 300, 230);
            g.DrawString("图例说明", new Font("Tahoma", 12, FontStyle.Bold),
            Brushes.Black, new PointF(550, 650));

            ////画图例
            PointF boxOrigin = new PointF(560, 750);
            PointF textOrigin = new PointF(600, 750);
            string txt = string.Empty;
            g.DrawString("共有投票: " + highPoint + " 次", new Font("Tahoma", 13), Brushes.Black, new PointF(560, 680));


            g.DrawString("↑       票数", new Font("Tahoma", 10), Brushes.Black, new PointF(686, 750));
            g.DrawString("→       问题项", new Font("Tahoma", 10), Brushes.Black, new PointF(686, 775));





            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0: txt = "满意"; break;
                    case 1: txt = "基本满意"; break;
                    case 2: txt = "不满意"; break;
                }
                g.FillRectangle(new SolidBrush(ChartUtil.GetChartItemColor(i)),
                boxOrigin.X, boxOrigin.Y, 20, 15);
                g.DrawRectangle(Pens.Black, boxOrigin.X, boxOrigin.Y, 20, 15);
                g.DrawString(txt, new Font("Tahoma", 10), Brushes.Black, textOrigin);
                boxOrigin.Y += 25;
                textOrigin.Y += 25;
            }
            //输出图形
            bm.Save(target, ImageFormat.Gif);

            //资源回收
            bm.Dispose();
            g.Dispose();
        }
    }

    public class ChartUtil
    {
        public ChartUtil()
        {
        }
        public static Color GetChartItemColor(int itemIndex)
        {
            Color selectedColor;
            switch (itemIndex)
            {
                case 0:
                    selectedColor = Color.Blue;
                    break;
                case 1:
                    selectedColor = Color.Yellow;//RoyalBlue;//
                    break;
                case 2:
                    selectedColor = Color.Red;
                    break;
                case 3:
                    selectedColor = Color.Purple;
                    break;
                default:
                    selectedColor = Color.Green;
                    break;
            }





            return selectedColor;
        }
    }
}
