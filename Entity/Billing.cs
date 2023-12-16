using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Entity
{
    public class Billing
    {
            private int billId;
            private int patientId;
            private int doctorId;
            private int appointmentId;
            private DateTime billDate;
            private decimal amount;
            private string paymentStatus;

            // Constructors
            public Billing() { }

            public Billing(int billId, int patientId, int doctorId, int appointmentId, DateTime billDate, decimal amount, string paymentStatus)
            {
                this.billId = billId;
                this.patientId = patientId;
                this.doctorId = doctorId;
                this.appointmentId = appointmentId;
                this.billDate = billDate;
                this.amount = amount;
                this.paymentStatus = paymentStatus;
            }

            // Properties
            public int BillId { get => billId; set => billId = value; }
            public int PatientId { get => patientId; set => patientId = value; }
            public int DoctorId { get => doctorId; set => doctorId = value; }
            public int AppointmentId { get => appointmentId; set => appointmentId = value; }
            public DateTime BillDate { get => billDate; set => billDate = value; }
            public decimal Amount { get => amount; set => amount = value; }
            public string PaymentStatus { get => paymentStatus; set => paymentStatus = value; }

            // ToString method
            public override string ToString()
            {
                return $"Billing{{billId={billId}, patientId={patientId}, doctorId={doctorId}, appointmentId={appointmentId}, billDate={billDate}, amount={amount}, paymentStatus='{paymentStatus}'}}";
            }
        }
    }
