using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_4 {
    class Point {
        public float X;
        public float Y;
        public Point(float X, float Y) {
            this.X = X;
            this.Y = Y;
        }
        public Point(float XY) : this(XY, XY) { }
        public override bool Equals(object obj) {
            if (obj == null) {
                return false;
            }
            Point p = (Point)obj;
            return (p != null && this.X == p.X && this.Y == p.Y);
        }

        public override int GetHashCode() {
            return (X.GetHashCode() * 3571) ^ Y.GetHashCode() * 3499;
        }

        public override string ToString() {
            return "(" + X + "," + Y + ")";
        }
    }
}
