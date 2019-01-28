using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    public abstract class GradeTracker : IGradeTracker
    {
        public abstract void AddGrade(float grade);
        public abstract GradeStatistics ComputeStatistics();
        public abstract void WriteGrade(TextWriter destination);
        public abstract IEnumerator GetEnumerator();

        public string Name // public class members start with uppercase
        {
            get { return name; }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or empty");
                }
                if (name != value && NameChanged != null)
                {
                    NameChangedEventArgs args = new NameChangedEventArgs();
                    args.ExistingName = name;
                    args.NewName = value;
                    NameChanged(this, args);
                    // when using an event to pass data, it is customary for that event to send itself as the first parameter, and then the arguments
                }
                name = value;
            }
        }

        public event NameChangedDelegate NameChanged; // events allow you to += or -= methods to a delegate but will not let you override with =

        protected string name;
    }
}
