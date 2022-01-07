namespace EFTutorial.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThucTap")]
    public partial class ThucTap
    {
        public long ID { get; set; }

        [StringLength(20)]
        public string IDStudent { get; set; }

        [StringLength(50)]
        public string FullName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DOB { get; set; }

        [StringLength(50)]
        public string POB { get; set; }

        public long? IDNganh { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string CTyThucTap { get; set; }
    }
}
