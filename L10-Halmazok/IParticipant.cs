using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L10_Halmazok
{
    public interface IParticipant : IComparable
    {
        // Property
        public string Name { get; }
    }

}
