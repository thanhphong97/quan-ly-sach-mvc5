namespace QuanLySach.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Display(Name = "Tên đăng nhập")]
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mã sách")]
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [Display(Name = "Thời gian")]
        [Column(TypeName = "date")]
        public DateTime? ThoiGian { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
