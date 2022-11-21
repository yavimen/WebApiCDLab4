using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public partial class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public string Position { get; set; } = null!;
        public string Department { get; set; } = null!;
    }
}
