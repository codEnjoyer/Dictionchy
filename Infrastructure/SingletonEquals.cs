using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dictionchy.Infrastructure
{
    public class SingletonEquals
    {
        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }
            return obj.GetType() == GetType();
        }
    }
}
