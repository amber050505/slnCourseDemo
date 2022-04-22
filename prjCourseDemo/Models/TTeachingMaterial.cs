using System;
using System.Collections.Generic;

#nullable disable

namespace prjCourseDemo.Models
{
    public partial class TTeachingMaterial
    {
        public TTeachingMaterial()
        {
            TCourseModles = new HashSet<TCourseModle>();
        }

        public string FTeachingMaterial { get; set; }
        public string FName { get; set; }
        public string FAuthor { get; set; }
        public string FPress { get; set; }
        public int? FCategory { get; set; }
        public int? FMaterialsSate { get; set; }
        public string FCreationUser { get; set; }
        public DateTime? FCreationDate { get; set; }
        public string FSaverUser { get; set; }
        public DateTime? FSaverDate { get; set; }

        public virtual ICollection<TCourseModle> TCourseModles { get; set; }
    }
}
