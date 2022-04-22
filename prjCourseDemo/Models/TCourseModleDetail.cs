﻿using System;
using System.Collections.Generic;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class TCourseModleDetail
    {
        public int FId { get; set; }
        public string FCourseId { get; set; }
        public int? FCourseNumber { get; set; }
        public string FSchedule { get; set; }
        public string FScheduleDetail { get; set; }
        public string FTeachingMethod { get; set; }
        public string FRemark { get; set; }
        public string FCreationUser { get; set; }
        public DateTime? FCreationDate { get; set; }
        public string FSaverUser { get; set; }
        public DateTime? FSaverDate { get; set; }

        public virtual TCourseModle FCourse { get; set; }
    }
}
