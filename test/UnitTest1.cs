using medical.Models;
using medical.Repositories;
using medical.DataBase;
using System.Reflection.Metadata;
using System.Windows;
using System.Collections.ObjectModel;
using medical;

namespace test
{
    public class Tests
    {
        public Doctor doc;
        public int doc_id = 0;
        public Patient patient;
        public int patient_id = 0;
        public MedicalService service;
        public int service_id = 0;
        public Appointment appointment;

        public DoctorRepository doctorRep;
        public PatientRepository patientRep;
        public MedicalServiceRepository serviceRep;
        public AppointmentRepository appointmentRep;

        private AppDbContext _context;


        [SetUp]
        public void Setup()
        {
            _context = new AppDbContext();

            doctorRep = new DoctorRepository(_context);
            patientRep = new PatientRepository(_context);
            serviceRep = new MedicalServiceRepository(_context);
            appointmentRep = new AppointmentRepository(_context);

            doc = new Doctor
            {
                FullName = "Test",
                Specialization = "Spec"
            };

            patient = new Patient
            {
                FullName = "Test",
                BirthDate = DateTime.Now.AddDays(2000),
            };

            service = new MedicalService
            {
                Name = "Test",
                Cost = 100,
                Duration = 10,
            };
        }

        [Test]
        public void Test_01()
        {
            
            var res = doctorRep.Add(doc);

            doc_id = doc.Id;

            Assert.That(res, Is.EqualTo(1));
        }


        [Test]
        public void Test_02()
        {
            doc.Id = doc_id; 
            doc.LicenseNumber = "989898998";
            var res = doctorRep.Update(doc);

            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void Test_03()
        {
            Doctor? res = doctorRep.GetById(doc_id);

            Assert.AreEqual(res.Id, doc_id);
        }

        [Test]
        public void Test_04()
        {
            doc.Id = doc_id;
            var res = doctorRep.Delete(doc);

            Assert.That(res, Is.EqualTo(1)); ;
        }

        [Test]
        public void Test_05()
        {
            var res = doctorRep.GetAll();

            Assert.IsInstanceOf<ObservableCollection<Doctor>>(res);
        }


        [Test]
        public void Test_06()
        {

            var res = patientRep.Add(patient);

            patient_id = patient.Id;

            Assert.That(res, Is.EqualTo(1));
        }


        [Test]
        public void Test_07()
        {
            patient.Id = patient_id;
            patient.Email = "test@mail.ru";
            var res = patientRep.Update(patient);

            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void Test_08()
        {
            Patient? res = patientRep.GetById(patient_id);


            Assert.AreEqual(res.Id, patient_id);
        }

        [Test]
        public void Test_09()
        {
            patient.Id = patient_id;
            var res = patientRep.Delete(patient);

            Assert.That(res, Is.EqualTo(1)); ;
        }

        [Test]
        public void Test_10()
        {
            var res = patientRep.GetAll();

            Assert.IsInstanceOf<ObservableCollection<Patient>>(res);
        }


        [Test]
        public void Test_11()
        {
            var res = serviceRep.Add(service);

            service_id = service.Id;

            Assert.That(res, Is.EqualTo(1));
        }


        [Test]
        public void Test_12()
        {
            service.Id = service_id;
            service.Duration = 200;
            var res = serviceRep.Update(service);

            Assert.That(res, Is.EqualTo(1));
        }

        [Test]
        public void Test_13()
        {
            MedicalService? res = serviceRep.GetById(service_id);

            Assert.AreEqual(res.Id, service_id);
        }

        [Test]
        public void Test_14()
        {
            service.Id = service_id;
            var res = serviceRep.Delete(service);

            Assert.That(res, Is.EqualTo(1)); ;
        }

        [Test]
        public void Test_15()
        {
            var res = serviceRep.GetAll();

            Assert.IsInstanceOf<ObservableCollection<MedicalService>>(res);
        }


        [Test]
        public void Test_16()
        {
            var res = appointmentRep.GetAll();

            Assert.IsInstanceOf<ObservableCollection<Appointment>>(res);
        }


        [Test]
        public void Test_17()
        {
            var res = appointmentRep.GetStaistic();

            Assert.IsInstanceOf<ObservableCollection<DoctorStat>>(res);
        }

        [Test]
        public void Test_18()
        {
            var res = appointmentRep.GetStaistic_2();

            Assert.IsInstanceOf<ObservableCollection<ServiceStat>>(res);
        }

        [Test]
        public void Test_19()
        {
            var res = appointmentRep.GetByDay(DateTime.Now.Date);

            Assert.IsInstanceOf<ObservableCollection<Appointment>>(res);
        }


        [TearDown]
        public void Down()
        {
            _context.Dispose();
            _context = null;
        }
    }
}