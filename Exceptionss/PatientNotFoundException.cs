using HMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Exceptionss
{
    public class PatientNotFoundException : ApplicationException
    {
        public PatientNotFoundException() { }

        public PatientNotFoundException(string message) : base(message) { }
    
    }
}
