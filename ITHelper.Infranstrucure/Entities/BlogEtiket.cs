using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITHelper.Infranstrucure.Entities
{
    public class BlogEtiket
    {
        [Key]
        public int BlogEtiketID { get; set; }


        [ForeignKey("Blog")]
        public int BlogID { get; set; }
        public virtual Blog Blog { get; set; }



        [ForeignKey("Etiket")]
        public int EtiketID { get; set; }
        public virtual Etiket Etiket { get; set; }

    }


}
