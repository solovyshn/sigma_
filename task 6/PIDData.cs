<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class PIDData
    {
        private string pid;
        private TimeSpan time;
        private string day;
        public string Time
        {
            get
            {
                return this.time.ToString();
            }
            set
            {
                string[] str = value.Split(':');
                time = new TimeSpan(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
            }
        }
        public string Pid
        {
            get => pid;
            set
            {
                pid = value;
            }
        }
        public string Day
        {
            get => this.day;
            set
            {
                this.day = value;
            }

        }
        public PIDData(string s)
        {
            this.Parse(s);
        }
        public void Parse(string s)
        {
            string[] str = s.Split(' ');
            this.Pid = str[0];
            this.Time = str[1];
            this.Day = str[2];
        }
    }
}

=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task_6
{
    class PIDData
    {
        private string pid;
        private TimeSpan time;
        private string day;
        public string Time
        {
            get
            {
                return this.time.ToString();
            }
            set
            {
                string[] str = value.Split(':');
                time = new TimeSpan(Convert.ToInt32(str[0]), Convert.ToInt32(str[1]), Convert.ToInt32(str[2]));
            }
        }
        public string Pid
        {
            get => pid;
            set
            {
                pid = value;
            }
        }
        public string Day
        {
            get => this.day;
            set
            {
                this.day = value;
            }

        }
        public PIDData(string s)
        {
            this.Parse(s);
        }
        public void Parse(string s)
        {
            string[] str = s.Split(' ');
            this.Pid = str[0];
            this.Time = str[1];
            this.Day = str[2];
        }
    }
}

>>>>>>> 170b157a028889369263d0dff7a386e8b43528cd
