﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SomerenModel
{
    public class Activities
    {
        public int activityId { get; set; }
        public string Activity { get; set; }
        public DateTime dateTime { get; set; }
        //
        //Added end time for list of activities by Enes
        //
        public DateTime EndDateTime { get; set; }
    }
}
