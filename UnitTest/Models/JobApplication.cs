using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest.Models
{
    public class JobApplication
    {
        public Applicant applicant { get; set; }

        public int YearsOfExperience { get; set; }

        public List<string> skills { get; set; }  // List of skills 

    }
}
