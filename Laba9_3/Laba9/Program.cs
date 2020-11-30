using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba9
{
    class Program
    {
        public interface IDraw
        {
            public void draw(Shape _shape)
            {
                Console.WriteLine(_shape.side);
                Console.WriteLine(_shape.point);
                Console.WriteLine(_shape.perimetr);
                Console.WriteLine(_shape.square);
                Console.WriteLine(_shape.color);
            }
        }

        public class Shape : IDraw
        {
            public int point { get; set; }
            public float side { get; set; }
            public float perimetr { get; set; }
            public float square { get; set; }
            public string color { get; set; }

            public virtual void Init()
            {
                point = 4;
                side = 1;
            }

            public virtual void Perimetr()
            {
                perimetr = 0;
                for(int i = 0; i < 4; i++)
                {
                    perimetr += side;
                }
            }

            public virtual void Square()
            {
                square = 1;
                square = side * side;
            }

            public void draw(Shape _shape)
            {
                Console.WriteLine(_shape.side);
                Console.WriteLine(_shape.point);
                Console.WriteLine(_shape.perimetr);
                Console.WriteLine(_shape.square);
                Console.WriteLine(_shape.color);
            }
        }

        public class SquareShape : Shape, IDraw
        {
            public float sideLenght;

            public override void Init()
            {
                base.Init();
                point = 4;
                side = sideLenght;
            }

            public override void Perimetr()
            {
                base.Perimetr();
                perimetr = side * 4;
            }

            public override void Square()
            {
                base.Square();
                square = side * side;
            }
        }

        public class TriangleShape : Shape, IDraw
        {
            public float sideLenght;

            public override void Init()
            {
                base.Init();
                point = 3;
                side = sideLenght;
            }

            public override void Perimetr()
            {
                base.Perimetr();
                perimetr = side * 3;
            }

            public override void Square()
            {
                base.Square();
                square = ((side * side) * MathF.Sqrt(3))/(4);
            }
        }

        public class CircleShape : Shape, IDraw
        {
            public float radius;

            public override void Init()
            {
                base.Init();
                point = 1;
                side = radius;
            }

            public override void Perimetr()
            {
                base.Perimetr();
                perimetr = 3.14f * 2f * side;
            }

            public override void Square()
            {
                base.Square();
                square = 3.14f * MathF.Pow(side, 2);
            }
        }

        public class Picture : IDraw
        {
            public List<Shape> picture = new List<Shape>();

            public void addNew(Shape _shape)
            {
                picture.Add(_shape);
            }

            public void find(int _id)
            {
                Console.WriteLine(picture[_id]);
            }
            
            public void remove(int _id)
            {
                picture.RemoveAt(_id);
            }

            public void draw(List<Shape> _shape)
            {
                for (int i = 0; i < picture.Count; i++)
                {
                    Console.WriteLine(_shape[i].side);
                    Console.WriteLine(_shape[i].point);
                    Console.WriteLine(_shape[i].perimetr);
                    Console.WriteLine(_shape[i].square);
                    Console.WriteLine(_shape[i].color);
                }
            }
        }

        static void Main(string[] args)
        {
            Picture picture = new Picture();

            SquareShape square = new SquareShape();
            TriangleShape triangle = new TriangleShape();
            CircleShape circle = new CircleShape();

            float side = 5;

            square.sideLenght = side;
            triangle.sideLenght = side;
            circle.radius = side;

            square.Init();
            triangle.Init();
            circle.Init();

            square.Perimetr();
            triangle.Perimetr();
            circle.Perimetr();

            square.Square();
            triangle.Square();
            circle.Square();

            square.color = "red";
            triangle.color = "green";
            circle.color = "blue";

            picture.addNew(square);
            picture.addNew(square);
            picture.addNew(triangle);
            picture.addNew(triangle);
            picture.addNew(circle);
            picture.addNew(circle);

            Console.WriteLine("Triangle:");
            triangle.draw(triangle);

            for (int i = 0 ; i < picture.picture.Count; i++)
            {
                picture.draw(picture.picture);
            }
        }
   }
}