﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace prjCourseDemo.Models
{
    [ModelMetadataTypeAttribute(typeof(TOrderMD))]
    public partial class TOrder
    {
        public class TOrderMD
        {
            public string FOrderId { get; set; }
            [DisplayName("test")]
            public string FUserId { get; set; }
            //
            public int? FPayment { get; set; }
            public int? FOrderState { get; set; }
            public string FCreationUser { get; set; }
            public DateTime? FCreationDate { get; set; }
            public string FSaverUser { get; set; }
            public DateTime? FSaverDaate { get; set; }
        }
    }
}
