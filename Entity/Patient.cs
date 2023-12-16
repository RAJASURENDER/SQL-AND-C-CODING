using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Patient
    {
            private int patientId;
            private string firstName;
            private string lastName;
            private string dateOfBirth;
            private string gender;
            private string contactNumber;
            private string address;

            // Constructors
            public Patient() { }

            public Patient(int patientId, string firstName, string lastName, string dateOfBirth, string gender, string contactNumber, string address)
            {
                this.patientId = patientId;
                this.firstName = firstName;
                this.lastName = lastName;
                this.dateOfBirth = dateOfBirth;
                this.gender = gender;
                this.contactNumber = contactNumber;
                this.address = address;
            }


        // Properties
            public int PatientId { get => patientId; set => patientId = value; }
            public string FirstName { get => firstName; set => firstName = value; }
            public string LastName { get => lastName; set => lastName = value; }
            public string DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
            public string Gender { get => gender; set => gender = value; }
            public string ContactNumber { get => contactNumber; set => contactNumber = value; }
            public string Address { get => address; set => address = value; }

            // ToString method
            public override string ToString()
            {
                return $"Patient{{patientId={patientId}, firstName='{firstName}', lastName='{lastName}', dateOfBirth={dateOfBirth}, gender='{gender}', contactNumber='{contactNumber}', address='{address}'}}";
            }
        }
    }
