using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2_4 {
    class Program {
        static void Main(string[] args) {
            MyLinkedList<string> Books = new MyLinkedList<string>();
            Books.AddFirst("Дориан Грей");
            Books.AddLast("Американская трагедия");
            Books.AddLast("Сестра Кери");
            Books.AddLast("Робидзон Крузо");
            Console.WriteLine("Созданный стек: ");
            Books.Out();
            Books.Remove("Робидзон Крузо");
            Books.AddFirst("А зори здесь тихие");
            Console.WriteLine("После удаления и вставки новой книги:");
            Books.Out();
            Console.WriteLine(Books.Count());
            Console.WriteLine("Элемент из стека с индексом 2: " + Books[2]);
            Console.ReadLine();

            MyLinkedList<Figure> ListFigures = new MyLinkedList<Figure>();
            Random rand = new Random(/*758*/);
            Point[] points1 = new Point[4];
            for (int i = 0; i < points1.Length; i++) {
                points1[i] = new Point(rand.Next() % 201 - 100, rand.Next() % 201 - 100);
            }
            Point[] points2 = new Point[6];
            for (int i = 0; i < points2.Length; i++) {
                points2[i] = new Point(rand.Next() % 201 - 100, rand.Next() % 201 - 100);
            }
            Point[] points3 = new Point[5];
            for (int i = 0; i < points3.Length; i++) {
                points3[i] = new Point(rand.Next() % 201 - 100, rand.Next() % 201 - 100);
            }
            Point[] points4 = new Point[2];
            for (int i = 0; i < points4.Length; i++) {
                points4[i] = new Point(rand.Next() % 201 - 100, rand.Next() % 201 - 100);
            }
            Point[] points5 = new Point[7];
            for (int i = 0; i < points5.Length; i++) {
                points5[i] = new Point(rand.Next() % 201 - 100, rand.Next() % 201 - 100);
            }
            ListFigures.AddFirst(new Figure(points1));
            ListFigures.AddFirst(new Figure(points3));
            ListFigures.AddFirst(new Figure(points5));
            ListFigures.AddLast(new Figure(points2));
            ListFigures.AddFirst(new Figure(points4));
            Console.WriteLine("New LinkedList:");
            ListFigures.Out();
            var result = ListFigures.OrderBy(u => u.Points.Length);
            Console.WriteLine("Scort LinkedList:");
            foreach (var elem in result) {
                ListFigures.AddLast(elem);
            }
            for (int i = 0; i < result.Count(); i++) {
                ListFigures.RemoveFirst();
            }
            Console.WriteLine("----------------");
            ListFigures.Out();
            Console.WriteLine("Max object: ");
            Console.WriteLine(ListFigures.Max());
            Console.WriteLine("Object length 4: ");
            var elementLength =
                from elem in ListFigures
                where elem.Points.Length == 4
                select elem;
            foreach (var findElement in elementLength) {
                Console.WriteLine(findElement);
            }
            var notOutLength =
                from elem in ListFigures
                where elem.Points.Length >= 3
                select elem;
            if (notOutLength.Count() == ListFigures.Count())
                Console.WriteLine("All elements have mach more then 3 points.");
            else Console.WriteLine("False.");
#if DEBUG
            Console.ReadKey();
#endif
        }
    }
}
