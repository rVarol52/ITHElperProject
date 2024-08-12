using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.ViewModel.BlogViewModel
{
    public class CreateBlogViewModel
    {
        [Column(TypeName = "nvarchar")]
        [StringLength(50)]
        [Required(ErrorMessage = "Başlık gereklidir")]
        public string Baslik { get; set; }
        [Required(ErrorMessage = "İçerik gereklidir")]
        public string Icerik { get; set; }
        public string Ozet { get; set; }
        public List<int> Etiketler { get; set; }
    }
}
