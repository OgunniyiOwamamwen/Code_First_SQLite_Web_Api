using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Code_First_SQLite_Web_Api.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string Tag { get; set; }
        public DateTime EnrollmentDate { get; set; }

        // An ICollection of our enrolments to tournaments :
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
