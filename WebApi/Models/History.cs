using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class History
    {
        public int Id { get; set; }
        public string PatientFullName { get; set; } = null!;
        public string PatientContacts { get; set; } = null!;
        public string Diagnosis { get; set; } = null!;
        public string Department { get; set; } = null!;
        public string Treatment { get; set; } = null!;
    }
}
