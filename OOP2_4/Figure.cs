using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_4 {
    class Figure : IComparable {
        private static UInt32 _number;
        private static UInt32 _nextID;

        private Point[] _points;

        public readonly UInt32 ID;
        private const int HASH_RANDOM_SEED = 3011;
        //public IEnumerator GetEnumerator() {
        //    return _points.GetEnumerator();
        //}
        public Point[] Points {
            get { return _points; }
            set {
                foreach (Point p in value) {
                    if (p == null) {
                        throw new NullReferenceException();
                    }
                }
                _points = value;
            }
        }

        public Figure(Point[] points) {
            this.Points = points;
            ID = _nextID++;
            _number++;
        }
        public Figure() : this(new Point[0]) { }
        static Figure() { _nextID = _number = 0; }
        ~Figure() { _number--; }
        public override bool Equals(object obj) {
            if (obj == null) { return false; }
            Figure f = (Figure)obj;
            if (f == null) { return false; }
            if (this.Points.Length != f.Points.Length) { return false; }
            for (UInt32 i = 0; i < this.Points.Length; i++) {
                if (!this.Points[i].Equals(f.Points[i])) { return false; }
            }
            return true;
        }

        public override int GetHashCode() {
            Random r = new Random(HASH_RANDOM_SEED);
            int result = 0;
            foreach (Point p in Points) {
                result ^= p.GetHashCode() * r.Next();
            }
            return result;
        }

        public override string ToString() {
            string result = "Figure {";
            foreach (Point p in Points) {
                result += p.ToString() + ", ";
            }
            return result.Remove(result.Length - 2) + "}";
        }

        public int CompareTo(object obj) {
            if (obj == null) throw new ArgumentException("Object is not a Figure"); 
            Figure f = obj as Figure;
            return Math.Sign(this.Points.Length - f.Points.Length);
        }
    }
}
