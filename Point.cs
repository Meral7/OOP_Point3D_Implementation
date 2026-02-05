using System;
using System.Collections.Generic;
using System.Text;

/* * Repository Name: OOP_Point3D_Implementation
 * Repository Description: A C# implementation of a 3D coordinate system showcasing 
 * object-oriented principles including operator overloading, interface implementation 
 * (ICloneable, IComparable), and custom sorting logic.
 */

namespace oop3
{
    /// <summary>
    /// Represents a 3D coordinate point and provides methods for manipulation and comparison.
    /// </summary>
    public class Point3D : ICloneable, IComparable
    {
        #region Private Fields
        private int d1; // X-coordinate
        private int d2; // Y-coordinate
        private int d3; // Z-coordinate
        #endregion

        #region Public Properties
        public int D1
        {
            get { return d1; }
            set { d1 = value; }
        }

        public int D2
        {
            get { return d2; }
            set { d2 = value; }
        }

        public int D3
        {
            get { return d3; }
            set { d3 = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor initializing point at (0, 0, 0).
        /// </summary>
        public Point3D() : this(0, 0, 0) { }

        public Point3D(int first) : this(first, 0, 0)
        {
            d1 = first;
        }

        public Point3D(int first, int second) : this(first, second, 0)
        {
            d2 = second;
        }

        public Point3D(int first, int second, int third)
        {
            d3 = third;
        }

        /// <summary>
        /// Copy constructor to create a new Point3D based on an existing instance.
        /// </summary>
        public Point3D(Point3D point)
        {
            D1 = point.D1;
            D2 = point.D2;
            D3 = point.D3;
        }
        #endregion

        #region Overridden Methods
        public override string ToString()
        {
            return $"Point Coordinates: ({d1}, {d2}, {d3}) .";
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current point.
        /// </summary>
        public override bool Equals(object obj)
        {
            Point3D point = (Point3D)obj;
            return point.d1 == d1 && point.d2 == d2 && point.d3 == d3;
        }
        #endregion

        #region Operator Overloading
        public static bool operator ==(Point3D point1, Point3D point2)
        {
            if (point1.d1 == point2.d1)
                if (point1.d2 == point2.d2)
                    if (point1.d3 == point2.d3)
                        return true;
                    else return false;
                else return false;
            else return false;
        }

        public static bool operator !=(Point3D point1, Point3D point2)
        {
            if (point1.d1 != point2.d1)
                return true;
            else if (point1.d2 != point2.d2)
                return true;
            else if (point1.d3 != point2.d3)
                return true;
            else return false;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Prompts the user to input X, Y, and Z coordinates from the console.
        /// </summary>
        public static Point3D TakeParams()
        {
            bool flag;
            int first, second, third;
            do
            {
                Console.WriteLine("x = ");
                flag = int.TryParse(Console.ReadLine(), out first);
            }
            while (!flag);
            do
            {
                Console.WriteLine("y = ");
                flag = int.TryParse(Console.ReadLine(), out second);
            }
            while (!flag);
            do
            {
                Console.WriteLine("z = ");
                flag = int.TryParse(Console.ReadLine(), out third);
            }
            while (!flag);
            return new Point3D(first, second, third);
        }

        /// <summary>
        /// Creates an array of points based on user-defined size and inputs.
        /// </summary>
        public static Point3D[] Points()
        {
            int size;
            bool flag;
            do
            {
                Console.WriteLine("enter size");
                flag = int.TryParse(Console.ReadLine(), out size);
            }
            while (!flag);
            Point3D[] arr = new Point3D[size];

            for (int i = 0; i < size; i++)
            {
                arr[i] = TakeParams();
            }
            return arr;
        }

        /// <summary>
        /// Sorts an array of Point3D objects using the default comparison logic.
        /// </summary>
        public static void SortArr(Point3D[] points)
        {
            Array.Sort(points);
        }
        #endregion

        #region Interface Implementations
        /// <summary>
        /// Creates a deep copy of the current Point3D instance.
        /// </summary>
        public object Clone()
        {
            Point3D point = new Point3D();
            point.d1 = d1;
            point.d2 = d2;
            point.d3 = d3;
            return point;
        }

        /// <summary>
        /// Compares the current instance with another object for sorting purposes.
        /// </summary>
        public int CompareTo(object obj)
        {
            Point3D point = (Point3D)obj;
            if (d1 > point.d1)
                return 1;
            else if (point.d1 > d1)
                return -1;
            else if (point.d2 < d2)
                return 1;
            else if (point.d2 > d2)
                return -1;
            if (point.d3 < d3)
                return 1;
            else if (point.d3 > d3)
                return -1;
            else return 0;
        }
        #endregion
    }
}