namespace QuanLySach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TaiKhoan")]
    public partial class TaiKhoan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TaiKhoan()
        {
            BinhLuans = new HashSet<BinhLuan>();
        }

        [Required(ErrorMessage="Nhập tên đăng nhập hộ tao")]
        [Display(Name = "Tên đăng nhập")]
        [Key]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Nhập mật khẩu hộ tao")]
        [StringLength(50)]
        public string MatKhau { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinhLuan> BinhLuans { get; set; }
    }
}
