using HMS.Entity;
using HMS.Exceptionss;
using HMS.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HMS.dao
{
    public class HospitalServiceImpl : IHospitalService
    {
        Patient patient = new Patient();

        public string connectionString;
        SqlCommand cmd = null;

        public HospitalServiceImpl()
        {
            connectionString = DBConnection.GetConnectionString();
            cmd = new SqlCommand();
        }

        public bool AddPatient(Patient patient)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Patients values(@patient_id, @first_name,@last_name, @date_of_birth, @gender, @contact_number, @address)";
                cmd.Parameters.AddWithValue("@patient_id", patient.PatientId);
                cmd.Parameters.AddWithValue("@first_name", patient.FirstName);
                cmd.Parameters.AddWithValue("@@last_name", patient.LastName);
                cmd.Parameters.AddWithValue("@date_of_birth", patient.DateOfBirth);
                cmd.Parameters.AddWithValue(" @gender", patient.Gender);
                cmd.Parameters.AddWithValue("@contact_number", patient.ContactNumber);
                cmd.Parameters.AddWithValue(" @address", patient.Address);

                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine(" Patient Added Successfully............");
                    return true;
                }
            }
            return false;
        }

        public bool CancelAppointment(int appointmentId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "delete from Appointments where appointment_id=@appointment_id";
                cmd.Parameters.AddWithValue("@appointment_id", appointmentId);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("-----------------Appointment Cancelled Successfully----------------");
                    return true;
                }
            }
            return false;
        }

        public bool DeletePatient(int patientId)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
            cmd.CommandText = "delete from Patients where patient_id=@patient_id";
            cmd.Parameters.AddWithValue("@patient_id", patientId);
            cmd.Connection = sqlConnection;
            sqlConnection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("-----------------Patient Deleted Successfully----------------");
                return true;
            }
        }
            return false;
        }

        public List<Patient> GetAllPatients()
      
        {
            List<Patient> patients = new List<Patient>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Patients";
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Patient patient = new Patient();
                        patient.PatientId = (int)reader["patient_id"];
                        patient.FirstName = (string)reader["first_name"];
                        patient.LastName= (string)reader["last_name "];
                        patient.DateOfBirth = (string)reader["date_of_birth"];
                        patient.Gender = (string)reader["gender"];
                        patient.ContactNumber = (string)reader["contact_number"];
                        patient.Address = (string)reader["address"];



                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return patients;
        }


        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE DoctorId = @DoctorId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                                AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            List<Appointment> appointments = new List<Appointment>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE PatientId = @PatientId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PatientId", patientId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                                AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                
                            };

                            appointments.Add(appointment);
                        }
                    }
                }
            }

            return appointments;
        }

        public Patient GetPatientById(int patientId)
        {
            Patient patient = null;
            try
            {


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    cmd.Connection = connection;
                    connection.Open();

                    string query = "SELECT * FROM Patients WHERE patient_id = @PatientId";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@PatientId", patientId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                patient = new Patient
                                {
                                    PatientId = Convert.ToInt32(reader["patientId"]),
                                    FirstName = reader["firstName"].ToString(),
                                    LastName = reader["lastName"].ToString(),
                                    DateOfBirth = (string)(reader["dateOfBirth"]),
                                    Gender = reader["gender"].ToString(),
                                    ContactNumber = reader["contactNumber"].ToString(),
                                    Address = reader["address"].ToString(),
                                };
                            }
                            else
                            {

                                throw new PatientNotFoundException($"Patient with ID {patientId} not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return patient;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            throw new NotImplementedException();
        }

        public void UpdatePatient(Patient patient)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Patients SET FirstName = @FirstName, LastName = @LastName, " +
                                                    "DateOfBirth = @DateOfBirth, Gender = @Gender, ContactNumber = @ContactNumber, Address = @Address " +
                                                    "WHERE PatientId = @PatientId", connection);

                command.Parameters.AddWithValue("@FirstName", patient.FirstName);
                command.Parameters.AddWithValue("@LastName", patient.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", patient.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", patient.Gender);
                command.Parameters.AddWithValue("@ContactNumber", patient.ContactNumber);
                command.Parameters.AddWithValue("@Address", patient.Address);
                command.Parameters.AddWithValue("@PatientId", patient.PatientId);

                command.ExecuteNonQuery();
            }
        }

        public void UpdateAppointment(Appointment appointment)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();

                string query = "UPDATE Appointments SET PatientId = @PatientId, DoctorId = @DoctorId, AppointmentDate = @AppointmentDate, Description = @Description WHERE AppointmentId = @AppointmentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.Parameters.AddWithValue("@AppointmentId", appointment.AppointmentId);
                    command.Parameters.AddWithValue("@PatientId", appointment.PatientId);
                    command.Parameters.AddWithValue("@DoctorId", appointment.DoctorId);
                    command.Parameters.AddWithValue("@AppointmentDate", appointment.AppointmentDate);
                    command.Parameters.AddWithValue("@Description", appointment.Description);

        
                    command.ExecuteNonQuery();
                }
            }
        }



        public Appointment GetAppointmentById(int appointmentId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                cmd.Connection = connection;
                connection.Open();

                string query = "SELECT * FROM Appointments WHERE AppointmentId = @AppointmentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            Appointment appointment = new Appointment
                            {
                                AppointmentId = reader.GetInt32(reader.GetOrdinal("AppointmentId")),
                                PatientId = reader.GetInt32(reader.GetOrdinal("PatientId")),
                                DoctorId = reader.GetInt32(reader.GetOrdinal("DoctorId")),
                                AppointmentDate = reader.GetDateTime(reader.GetOrdinal("AppointmentDate")),
                                Description = reader.GetString(reader.GetOrdinal("Description")),
                                
                            };

                            return appointment;
                        }
                    }
                }
            }

            return null;
        }
    }
}
