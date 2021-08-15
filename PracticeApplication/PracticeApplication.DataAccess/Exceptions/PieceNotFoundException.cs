using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeApplication.DataAccess.Exceptions
{
    [Serializable]
    public class PieceNotFoundException : Exception
    {
        public PieceNotFoundException() { }

        public PieceNotFoundException(string message) : base(message) { }

        public PieceNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
