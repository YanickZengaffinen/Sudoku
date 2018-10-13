using System;
using System.Collections.Generic;
using System.Text;

namespace ZenDoku.Solver
{
    /// <summary>
    /// Exception to be called whenever there is not enough information to solve a problem
    /// </summary>
    public class NotEnoughInformationException : Exception
    {
        public NotEnoughInformationException(string message) : base(message) { }

    }
}
