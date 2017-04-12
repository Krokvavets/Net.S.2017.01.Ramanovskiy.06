using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public interface IComparer
    {
         int Compare(int[] array1, int[] array2);
    }
}
