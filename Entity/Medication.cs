using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Medication
    {
            private int medicationId;
            private int appointmentId;
            private string medicationName;
            private string dosage;

            // Constructors
            public Medication() { }

            public Medication(int medicationId, int appointmentId, string medicationName, string dosage)
            {
                this.medicationId = medicationId;
                this.appointmentId = appointmentId;
                this.medicationName = medicationName;
                this.dosage = dosage;
            }

            // Properties
            public int MedicationId { get => medicationId; set => medicationId = value; }
            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public string MedicationName { get => medicationName; set => medicationName = value; }
            public string Dosage { get => dosage; set => dosage = value; }

            // ToString method
            public override string ToString()
            {
                return $"Medication{{medicationId={medicationId}, appointmentId={appointmentId}, medicationName='{medicationName}', dosage='{dosage}'}}";
            }
        }
    }

