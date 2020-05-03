using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutocadPlugin.Drawer.Points {
    public class Point3D {
        public float x { set; get; }
        public float y { set; get; }
        public float z { set; get; }

        public Point3D(float x, float y, float z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }
    }
}
