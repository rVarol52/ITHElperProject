using ITHelper.Infranstrucure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.ViewModel.BlogViewModel
{
    public class UpdateBlogViewModel
    {
        public int BlogID { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string Ozet { get; set; }
        public List<BlogEtiket> BlogEtiketler { get; set; }
    }
}
