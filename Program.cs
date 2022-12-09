using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xingovn5
{
    internal class Garage<T> : IEnumerable<T> where T : Vehicle
    {
        private int Capacity { get; set; }
        private int Count { get; set; }
        private T[] garage;
        public Garage(int capacity)
        {
            this.Capacity = Math.Max(capacity, 1);
            garage = new T[capacity];
        }

        public virtual bool Add(T vehicle)
        {
            for (int i = 0; i < garage.Length; i++)
            {
                if (garage[i] == null)
                {
                    garage[i] = vehicle;
                    Count++;
                    return true;
                }
            }

            return false;
        }


        public IEnumerator<T> GetEnumerator()
        {
            foreach (var vehicle in garage)
            {
                //..
                if (vehicle is not null)
                    yield return vehicle;
            }
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        internal bool IsFull()
        {
            if (Count < Capacity)
                return false;
            else return true;
        }
    }
}