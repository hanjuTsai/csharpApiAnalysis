using System;
namespace APITest
{
	public class Patient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Birth { get; set; }
        public string Photo { get; set; }
        public RootObject[] Appointments { get; set; }
        public Treatment[] Treatments { get; set; }
    }
	public class RootObject
    {
        public int id { get; set; }
        public int Status { get; set; }
        public int doctorId { get; set; }
        public object photos { get; set; }
        public object commands { get; set; }
        public object teeth { get; set; }
    }
    public partial class Treatment
    {
        public long Id { get; set; }
        public long Status { get; set; }
        public long DoctorId { get; set; }
        public object Photos { get; set; }
        public object Commands { get; set; }
        public object Teeth { get; set; }
    }
}
