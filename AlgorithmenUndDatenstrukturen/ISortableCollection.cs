using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL
{
    public interface ISortableCollection<T> where T : IComparable<T>
    {
        int Count();
        T Get(int index);
        void Swap(int index1, int index2);
    }
}