using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Appointment
    {
            private int appointmentId;
            private int patientId;
            private int doctorId;
            private DateTime appointmentDate;
            private string description;

            // Constructors
            public Appointment() { }

            public Appointment(int appointmentId, int patientId, int doctorId, DateTime appointmentDate, string description)
            {
                this.appointmentId = appointmentId;
                this.patientId = patientId;
                this.doctorId = doctorId;
                this.appointmentDate = appointmentDate;
                this.description = description;
            }

            // Properties
            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public int PatientId { get => patientId; set => patientId = value; }
            public int DoctorId { get => doctorId; set => doctorId = value; }
            public DateTime AppointmentDate { get => appointmentDate; set => appointmentDate = value; }
            public string Description { get => description; set => description = value; }

            // ToString method
            public override string ToString()
            {
                return $"Appointment{{appointmentId={appointmentId}, patientId={patientId}, doctorId={doctorId}, appointmentDate={appointmentDate}, description='{description}'}}";
            }
        }
    }

