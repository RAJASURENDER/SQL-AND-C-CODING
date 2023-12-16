using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class LabTest
    {
            private int testId;
            private int appointmentId;
            private string testName;
            private string testResult;

            // Constructors
            public LabTest() { }

            public LabTest(int testId, int appointmentId, string testName, string testResult)
            {
                this.testId = testId;
                this.appointmentId = appointmentId;
                this.testName = testName;
                this.testResult = testResult;
            }

            // Properties
            public int TestId { get => testId; set => testId = value; }
            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public string TestName { get => testName; set => testName = value; }
            public string TestResult { get => testResult; set => testResult = value; }

            // ToString method
            public override string ToString()
            {
                return $"LabTest{{testId={testId}, appointmentId={appointmentId}, testName='{testName}', testResult='{testResult}'}}";
            }
        }
    }
