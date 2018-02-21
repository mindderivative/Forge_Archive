using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Specialized;

namespace Forge.Classes
{
    public class GridLikeItemsSource : IList, ZoomableCanvas.ISpatialItemsSource
    {
        public Rect Extent
        {
            get
            {
                var sqrt = Math.Sqrt(Count);
                return new Rect(0, 0, 100 * (Math.Ceiling(sqrt)), 100 * (Math.Round(sqrt)));
            }
        }

        public IEnumerable<int> Query(Rect rectangle)
        {
            rectangle.Intersect(Extent);

            var top = Math.Floor(rectangle.Top / 100);
            var left = Math.Floor(rectangle.Left / 100);
            var right = Math.Ceiling(rectangle.Right / 100);
            var bottom = Math.Ceiling(rectangle.Bottom / 100);
            var width = Math.Max(right - left, 0);
            var height = Math.Max(bottom - top, 0);

            foreach(var cell in Quadivide(new Rect(left, top, width, height)))
            {
                var x = cell.X;
                var y = cell.Y;
                var i = x > y ? Math.Pow(x, 2) + y : Math.Pow(y, 2) + 2 * y - x;

                if(i < Count)
                {
                    yield return (int)i;
                }
            }
        }

        private IEnumerable<Point> Quadivide(Rect area)
        {
            if(area.Width > 0 && area.Height > 0)
            {
                var center = area.GetCenter();
                var x = Math.Floor(center.X);
                var y = Math.Floor(center.Y);
                yield return new Point(x, y);

                var quad1 = new Rect(area.TopLeft, new Point(x, y + 1));
                var quad2 = new Rect(area.TopRight, new Point(x, y));
                var quad3 = new Rect(area.BottomLeft, new Point(x + 1, y + 1));
                var quad4 = new Rect(area.BottomRight, new Point(x + 1, y));

                var quads = new Queue<IEnumerator<Point>>();
                quads.Enqueue(Quadivide(quad1).GetEnumerator());
                quads.Enqueue(Quadivide(quad2).GetEnumerator());
                quads.Enqueue(Quadivide(quad3).GetEnumerator());
                quads.Enqueue(Quadivide(quad4).GetEnumerator());
                while(quads.Count > 0)
                {
                    var quad = quads.Dequeue();
                    if(quad.MoveNext())
                    {
                        yield return quad.Current;
                        quads.Enqueue(quad);
                    }
                }
            }
        }

        

        public event EventHandler ExtentChanged;
        public event EventHandler QueryInvalidated;

        private int count;

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
                ExtentChanged(this, EventArgs.Empty);
                QueryInvalidated(this, EventArgs.Empty);
            }
        }

        public object this[int i]
        {
            get
            {
                var rand = new Random(i);
                var sqrt = (int)Math.Sqrt(i);

                var width = rand.Next(50, 100);
                var height = rand.Next(50, 100);

                var top = Math.Min(sqrt, i - Math.Pow(sqrt, 2)) * 100 + rand.Next(100 - height);
                var left = Math.Min(sqrt, sqrt * 2 - (i - Math.Pow(sqrt, 2))) * 100 + rand.Next(100 - width);

                var type = rand.Next(3);
                var data = type == 0 ? "ellipse" :
                           type == 1 ? "rectangle" :
                           String.Format("M{0},{1} C{2},{3} {4},{5} {6},{7}",
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble(),
                                rand.NextDouble());

                var brush = new LinearGradientBrush(
                    Color.FromScRgb(1f, (float)rand.NextDouble(),
                                        (float)rand.NextDouble(),
                                        (float)rand.NextDouble()),
                    Color.FromScRgb(1f, (float)rand.NextDouble(),
                                        (float)rand.NextDouble(),
                                        (float)rand.NextDouble()),
                    180 * rand.NextDouble());

                return new { top, left, width, height, data, brush, i };
            }
            set { }
        }

        #region Irrelevant IList Members
        int IList.Add(object value)
        {
            return 0;
        }

        bool IList.Contains(object value)
        {
            return false;
        }

        void IList.Clear()
        {
            
        }

        int IList.IndexOf(object value)
        {
            return 0;
        }

        void IList.Insert(int index, object value)
        {
            
        }

        void IList.Remove(object value)
        {
            
        }

        void IList.RemoveAt(int index)
        {
           
        }

        void ICollection.CopyTo(Array array, int index)
        {
            
        }

        bool IList.IsReadOnly
        {
            get { return true; }
        }

        bool IList.IsFixedSize
        {
            get { return false; }
        }

        int ICollection.Count
        {
            get { return int.MaxValue; }
        }

        object ICollection.SyncRoot
        {
            get { return null; }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        //object IList.this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        IEnumerator IEnumerable.GetEnumerator()
        {
            yield break;
        }

        #endregion
    }
}
