using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmenUndDatenstrukturen
{
    public interface ISortStragegy<T>
    {
        void Sort(Node<T> head);
    }
}
