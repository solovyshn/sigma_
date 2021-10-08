using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class User {
        private string surname;
        private int numOfFlat;
        public string Surname {
            get { return this.surname; }
            set { this.surname = value; }
        }
        public int NumOfFlat {
            get { return this.numOfFlat; }
            set { this.numOfFlat = value; }
        }
        public User(string surname, int numOfFlat) {
            this.surname = surname;
            this.numOfFlat = numOfFlat;
        }
        public string Info() {
            return String.Format("User: {0,10} \tFlat: {1,3}", this.surname, this.numOfFlat);
        }
    }
}
