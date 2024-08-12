using ITHelper.Infranstrucure.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.ViewModel.BlogViewModel
{
    public class ResultBlogViewModel
    {
        public int BlogID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Ozet { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;
        public List<ResultBlogViewModel> Blogs { get; set; }
        public List<BlogEtiket> BlogEtiktler { get; set; }

        public string OlusturanKullaniciAdi { get; set; }
        public string OlusturanKullaniciSoyadi { get; set; }
        public int OkunmaSayisi { get; set; }


    }

}
