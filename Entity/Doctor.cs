using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Doctor
    {
       
            private int doctorId;
            private string firstName;
            private string lastName;
            private string specialization;
            private string contactNumber;

            // Constructors
            public Doctor() { }

            public Doctor(int doctorId, string firstName, string lastName, string specialization, string contactNumber)
            {
                this.doctorId = doctorId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.specialization = specialization;
                this.contactNumber = contactNumber;
            }

            // Properties
            public int DoctorId { get => doctorId; set => doctorId = value; }
            public string FirstName { get => firstName; set => firstName = value; }
            public string LastName { get => lastName; set => lastName = value; }
            public string Specialization { get => specialization; set => specialization = value; }
            public string ContactNumber { get => contactNumber; set => contactNumber = value; }

            // ToString method
            public override string ToString()
            {
                return $"Doctor{{doctorId={doctorId}, firstName='{firstName}', lastName='{lastName}', specialization='{specialization}', contactNumber='{contactNumber}'}}";
            }
        }
    }


