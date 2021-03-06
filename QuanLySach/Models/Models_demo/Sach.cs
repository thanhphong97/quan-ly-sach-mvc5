namespace QuanLySach.Models.Models_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sach")]
    public partial class Sach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sach()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Key]
        public int MaSach { get; set; }

        [Required]
        [StringLength(250)]
        public string TenSach { get; set; }

        public int? GiaTien { get; set; }

        [Required]
        public string GioiThieuChung { get; set; }

        public int TheLoai { get; set; }

        public string AnhBia { get; set; }

        [Required]
        public string NoiDungChiTiet { get; set; }

        [StringLength(250)]
        public string TacGia { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayPhatHanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }

        public virtual LoaiSach LoaiSach { get; set; }
    }
}
