using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public class NameChangedEventArgs : EventArgs // anything passing arguments inside an event should inherit from EventArgs
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
