using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_4 {
    public class MyLinkedList<T> : LinkedList<T> where T : IComparable {
        public MyLinkedList() : base() {
        }
        public MyLinkedList(IEnumerable<T> collection) : base(collection) {
        }
        public T this[int index] {
            get { return this.ElementAt(index); }
        }
        public void Out() {
            foreach (T elem in this) {
                Console.Write("\t" + elem + "\n");
            }
        }
        public void WriteInFile() {
            string nameFile = Convert.ToString(this.GetHashCode()) + ".txt";
            System.IO.StreamWriter sw = null;
            try {
                sw = new System.IO.StreamWriter(nameFile);
                foreach (T element in this) {
                    sw.WriteLine(element.ToString());
                }
            } finally {
                if (sw != null) {
                    sw.Close();
                }
            }
        }
        public T MaxElement() {
            T result = this.ElementAt(0);
            foreach (T element in this) {
                if (element.CompareTo(result)==1) result = element;
            }
            return result;
        }
    }
}