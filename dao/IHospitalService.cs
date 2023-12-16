using HMS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.dao
{
    public interface IHospitalService
    {
        // Patient-related operations
        Patient GetPatientById(int patientId);
        List<Patient> GetAllPatients();  //done
        public bool AddPatient(Patient patient); //done
        void UpdatePatient(Patient patient);
        public bool DeletePatient(int patientId); //done

        // Appointment-related operations
        Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAppointmentsForPatient(int patientId);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        void ScheduleAppointment(Appointment appointment); // MUST DO
        void UpdateAppointment(Appointment appointment);
        public bool CancelAppointment(int appointmentId); // done
    }
}
