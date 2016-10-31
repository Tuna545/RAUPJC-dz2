using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raupjc_dz2_zad1
{
    public class DuplicateTodoItemException : Exception
    {
        public DuplicateTodoItemException()
            : base("Item with same Id alredy exists in database")
        {
        }
    }
}
