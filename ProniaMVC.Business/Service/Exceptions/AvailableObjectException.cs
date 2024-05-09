using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Exceptions
{
    public class AvailableObjectException : Exception
    {
        public AvailableObjectException(string? message) : base(message)
        {
        }
    }
}
