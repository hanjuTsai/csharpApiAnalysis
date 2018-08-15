using System;
using Newtonsoft.Json;

namespace APITest
{
	public class Patient
    {
		[JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("birth")]
        public DateTimeOffset Birth { get; set; }

        [JsonProperty("photo")]
        public string Photo { get; set; }

        [JsonProperty("appointments")]
        public Appointment[] Appointments { get; set; }

        [JsonProperty("treatments")]
		public Treatment[] Treatments { get; set; }
    }

	public class Appointment
    {
		[JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("arrival")]
        public DateTimeOffset Arrival { get; set; }

        [JsonProperty("doctorId")]
        public long DoctorId { get; set; }

        [JsonProperty("reservation")]
        public bool Reservation { get; set; }
    }

    public partial class Treatment
    {
		[JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("status")]
        public long Status { get; set; }

        [JsonProperty("doctorId")]
        public long DoctorId { get; set; }

        [JsonProperty("photos")]
        public object Photos { get; set; }

        [JsonProperty("commands")]
        public object Commands { get; set; }

        [JsonProperty("teeth")]
        public object Teeth { get; set; }
    }
}
