using CommonDLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL
{
    public interface ISortStrategy<T> where T : IComparable<T>
    {
        void Sort(ISortableCollection<T> c);
    }
}
