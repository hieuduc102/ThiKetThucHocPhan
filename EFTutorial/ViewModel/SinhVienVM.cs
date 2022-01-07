using EFTutorial.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTutorial.ViewModel
{
    public class SinhVienVM
    {
        public long ID { get; set; }

        public string IDStudent { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? DOB { get; set; }

        public string POB { get; set; }

        public long? IDLop { get; set; }

        [ForeignKey("IDLop")]
        public virtual LopHoc LopHoc { get; set; }
    }
}
