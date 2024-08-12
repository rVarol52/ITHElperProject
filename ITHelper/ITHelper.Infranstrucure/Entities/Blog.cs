using ITHelper.Infranstrucure.Abstarct;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.Entities
{
    [Table("Blog")]
    public class Blog : CommonAbstract
    {
        [Key]
        public int BlogID { get; set; }
        [Column(TypeName ="nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Başlık gereklidir")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "İçerik gereklidir")]
        public string Icerik { get; set; }
        public string Ozet { get; set; }

        public virtual List<BlogEtiket> BlogEtiketler { get; set; }
        public int OkunmaSayisi { get; set; }


    }
}
