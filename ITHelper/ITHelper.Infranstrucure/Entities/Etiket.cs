using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.Entities
{
    public class Etiket
    {
        [Key]
        public int EtiketID { get; set; }
        public string EtiketAdi { get; set; }

        public virtual List<BlogEtiket> BlogEtiketler { get; set; }
    }
}
