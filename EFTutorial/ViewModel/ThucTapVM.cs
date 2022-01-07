using EFTutorial.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial.ViewModel
{
    public class ThucTapVM
    {
        public long ID { get; set; }

        public string IDStudent { get; set; }

        public string FullName { get; set; }

        public DateTime? DOB { get; set; }

        public string POB { get; set; }

        public string Name { get; set; }

        public string CTyThucTap { get; set; }

        public long? IDNganh { get; set; }

        [ForeignKey("IDNganh")]
        public virtual Nganh Nganh { get; set; }
    }
}
