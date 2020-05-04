using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutocadPlugin.Drawer.Points;
using ParametersAndTools;

namespace AutocadPlugin.Drawer
{
    public class ModelDrawer
    {
        private readonly Point3D _startPoint = new Point3D(100, 150, 0);

        private List<Point2D> _points2d = new List<Point2D>();

        private List<Point2D> _legsPoints2d = new List<Point2D>();

        private List<Point3D> _points;

        private List<Point3D> _legsPoints;

        private readonly PictureBox _picture;

        private const double Size = 0.5;

        private float L { get; set; }
        private float W { get; set; }
        private float H { get; set; }
        private float Tb { get; set; }
        private float Lh { get; set; }
        private float Hb { get; set; }
        private float D { get; set; }

        public ModelDrawer(Parameters parameters, PictureBox picture)
        {
            _picture = picture;

            var gCLr = Graphics.FromHwnd(_picture.Handle);
            gCLr.Clear(Color.White);
            gCLr.Dispose();

            InitParameters(parameters);
            InitPoints();
        }

        private void InitParameters(Parameters parameters)
        {
            H = Convert.ToSingle(parameters.ModelParameters[ParameterType.MainPartHeight]
                .Value);

            W = Convert.ToSingle(parameters.ModelParameters[ParameterType.MainPartWidth]
                .Value);

            L = Convert.ToSingle(parameters.ModelParameters[ParameterType.MainPartLength]
                .Value);

            D = Convert.ToSingle(parameters.ModelParameters[ParameterType.LegsDiameter]
                .Value);

            Lh = Convert.ToSingle(parameters.ModelParameters[ParameterType.LegsHeight]
                .Value);

            Hb = Convert.ToSingle(parameters
                .ModelParameters[ParameterType.HeadboardHeight].Value);

            Tb = Convert.ToSingle(parameters
                .ModelParameters[ParameterType.HeadboardThickness].Value);
        }


        private List<Point2D> Calculate2D(List<Point3D> pointList)
        {
            var a = 101;
            var b = 100;

            var resultPoints = new List<Point2D>();

            foreach (var point in pointList)
            {
                var x = (-point.Z * Convert.ToSingle(Math.Sin(a)) +
                         point.X * Convert.ToSingle(Math.Cos(a))) * Size;

                var y =
                    (-(point.Z * Convert.ToSingle(Math.Cos(a)) +
                       point.X * Convert.ToSingle(Math.Sin(a))) *
                     Convert.ToSingle(Math.Sin(b)) +
                     point.Y * Convert.ToSingle(Math.Cos(b))) * Size;


                resultPoints.Add(new Point2D(Convert.ToSingle(x), Convert.ToSingle(y)));
            }

            return resultPoints;
        }

        private void InitPoints()
        {
            // в комментариях вид сверху
            _points = new List<Point3D>
            {
                // ОСНОВНАЯ ЧАСТЬ - 18 точек
                //верх
                new Point3D(0, H, 0),
                new Point3D(L, H, 0),
                new Point3D(L, H, W),
                new Point3D(0, H, W),
                new Point3D(0, H, 0),

                //низ
                new Point3D(0, 0, 0),
                new Point3D(0, 0, W),
                new Point3D(L, 0, W),
                new Point3D(L, 0, 0),
                new Point3D(0, 0, 0),

                //ребра
                //нихнее левое
                new Point3D(0, 0, 0),
                new Point3D(0, H, 0),

                //верхнее левое
                new Point3D(L, H, 0),
                new Point3D(L, 0, 0),

                //верхнее правое
                new Point3D(L, 0, W),
                new Point3D(L, H, W),

                //нижнее правое
                new Point3D(0, H, W),
                new Point3D(0, 0, W),

                // СПИНКА
                //низ
                new Point3D(L, 0, W),
                new Point3D(L, -Lh, W),
                new Point3D(L + Tb, -Lh, W),
                new Point3D(L + Tb, -Lh, 0),
                new Point3D(L, -Lh, 0),
                new Point3D(L, -Lh, W),

                //верх
                new Point3D(L, -Lh + Hb, W),
                new Point3D(L + Tb, -Lh + Hb, W),
                new Point3D(L + Tb, -Lh + Hb, 0),
                new Point3D(L, -Lh + Hb, 0),
                new Point3D(L, -Lh + Hb, W),

                //ребра
                //нихнее левое
                new Point3D(L, -Lh + Hb, W),
                new Point3D(L, -Lh, W),

                //верхнее левое
                new Point3D(L + Tb, -Lh, W),
                new Point3D(L + Tb, -Lh + Hb, W),

                //верхнее правое
                new Point3D(L + Tb, -Lh + Hb, 0),
                new Point3D(L + Tb, -Lh, 0),

                //нижнее правое
                new Point3D(L, -Lh, 0),
                new Point3D(L, -Lh + Hb, 0)
            };

            _legsPoints = new List<Point3D>
            {
                //Верх правой
                new Point3D(D / 2, 0, D / 2),
                new Point3D(D / 2 + D, 0, D / 2),
                new Point3D(D / 2 + D, 0, D / 2 + D),
                new Point3D(D / 2, 0, D / 2 + D),
                new Point3D(D / 2, 0, D / 2),

                //Низ правой
                new Point3D(D / 2, -Lh, D / 2),
                new Point3D(D / 2 + D, -Lh, D / 2),
                new Point3D(D / 2 + D, -Lh, D / 2 + D),
                new Point3D(D / 2, -Lh, D / 2 + D),
                new Point3D(D / 2, -Lh, D / 2),

                //Грани правой
                new Point3D(D / 2, 0, D / 2),
                new Point3D(D / 2 + D, 0, D / 2),
                new Point3D(D / 2 + D, -Lh, D / 2),
                new Point3D(D / 2 + D, -Lh, D / 2 + D),
                new Point3D(D / 2 + D, 0, D / 2 + D),
                new Point3D(D / 2, 0, D / 2 + D),
                new Point3D(D / 2, -Lh, D / 2 + D),

                //Верх левой
                new Point3D(D / 2, 0, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, 0, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, 0, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, 0, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, 0, D / 2 + W - 2 * D),

                //Низ левой
                new Point3D(D / 2, -Lh, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, -Lh, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, -Lh, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, -Lh, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, -Lh, D / 2 + W - 2 * D),

                //Грани левой
                new Point3D(D / 2, 0, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, 0, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, -Lh, D / 2 + W - 2 * D),
                new Point3D(D / 2 + D, -Lh, D / 2 + D + W - 2 * D),
                new Point3D(D / 2 + D, 0, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, 0, D / 2 + D + W - 2 * D),
                new Point3D(D / 2, -Lh, D / 2 + D + W - 2 * D)
            };
        }

        private void Draw()
        {
            using (var g = Graphics.FromHwnd(_picture.Handle))
            {
                var pen = new Pen(Color.Black, 1);

                for (var i = 0; i < _points2d.Count - 1; i++)
                {
                    g.DrawLine(pen, _points2d[i].X + _startPoint.X,
                        _points2d[i].Y + _startPoint.Y,
                        _points2d[i + 1].X + _startPoint.X,
                        _points2d[i + 1].Y + _startPoint.Y);
                }

                for (var i = 0; i < _legsPoints2d.Count / 2 - 1; i++)
                {
                    g.DrawLine(pen, _legsPoints2d[i].X + _startPoint.X,
                        _legsPoints2d[i].Y + _startPoint.Y,
                        _legsPoints2d[i + 1].X + _startPoint.X,
                        _legsPoints2d[i + 1].Y + _startPoint.Y);
                }

                for (var i = _legsPoints2d.Count / 2; i < _legsPoints2d.Count - 1; i++)
                {
                    g.DrawLine(pen, _legsPoints2d[i].X + _startPoint.X,
                        _legsPoints2d[i].Y + _startPoint.Y,
                        _legsPoints2d[i + 1].X + _startPoint.X,
                        _legsPoints2d[i + 1].Y + _startPoint.Y);
                }
            }
        }

        public void DrawPicture()
        {
            _points2d = Calculate2D(_points);
            _legsPoints2d = Calculate2D(_legsPoints);
            Draw();
        }
    }
}