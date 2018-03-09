namespace QuanLySach.Models
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

        [Display(Name="Mã sách")]
        [Key]
        public int MaSach { get; set; }

        [Required(ErrorMessage="Nhập tên vô")]
        [Display(Name="Tên sách")]
        [StringLength(250)]
        public string TenSach { get; set; }

        [Range(1000, 9999999, ErrorMessage="Giá trị trong khoản 1000 cho đến 999999")]
        [Display(Name = "Giá tiền")]
        public int? GiaTien { get; set; }

        [Display(Name = "Giới thiệu chung")]
        [UIHint("CKEditor")]
        [Required(ErrorMessage = "Nhập giới thiệu chung vô")]
        public string GioiThieuChung { get; set; }

        [Display(Name = "Thể loại")]
        public int TheLoai { get; set; }

        [Display(Name = "Ảnh bìa")]
        public string AnhBia { get; set; }

        [Display(Name = "Nội dung chi tiết")]
        [UIHint("CKEditor")]
        [Required(ErrorMessage = "Nhập nội dung chi tiết vô")]
        public string NoiDungChiTiet { get; set; }

        [Display(Name = "Tác giả")]
        [StringLength(250)]
        public string TacGia { get; set; }

        [Display(Name = "Ngày phát hành")]
        [Column(TypeName = "date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? NgayPhatHanh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
        public virtual LoaiSach LoaiSach { get; set; }
    }
}
