using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMonitoring.Model
{
    class Student
    {
        public String PRN { get; set; }
        public String Name { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public string Course { get; set; }
        public string Batch { get; set; }
        
        public Student()
        {
        }

        public Student(string pRN, string name, string password, string email, string course, string batch)
        {
            PRN = pRN;
            Name = name;
            Password = password;
            Email = email;
            Course = course;
            Batch = batch;
        }
    }
}
