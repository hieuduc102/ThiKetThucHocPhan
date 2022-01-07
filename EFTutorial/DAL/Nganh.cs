namespace EFTutorial.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nganh")]
    public partial class Nganh
    {
        [Key]
        public long IDNganh { get; set; }

        [StringLength(50)]
        public string TenNganh { get; set; }
        public virtual List<ThucTap> ThucTaps { get; set; }
    }
}
