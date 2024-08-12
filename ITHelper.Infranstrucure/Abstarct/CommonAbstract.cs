using ITHelper.Infranstrucure.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ITHelper.Infranstrucure.Abstarct
{
    public abstract class CommonAbstract
    {
        [ForeignKey("OlusturanKullanici")]
        public int? OlusturanKullaniciID { get; set; }
        public virtual Kullanici? OlusturanKullanici { get; set; }
        public DateTime OlusturulmaTarihi { get; set; } = DateTime.Now;

        [ForeignKey("GuncelleyenKullanici")]
        public int? GuncelleyenKullaniciID { get; set; }
        public virtual Kullanici? GuncelleyenKullanici { get; set; }
        public DateTime? GuncellemeTarihi { get; set; }
        public bool AktifMi { get; set; } = true;

    }
}
