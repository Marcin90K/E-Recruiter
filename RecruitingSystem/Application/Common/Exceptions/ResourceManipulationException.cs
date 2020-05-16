using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Exceptions
{
    public class ResourceManipulationException : Exception
    {
        public ResourceManipulationException(string message) : base(message)
        {

        }
    }
}
