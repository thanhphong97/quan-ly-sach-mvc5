namespace QuanLySach.Models.Models_demo
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BinhLuan")]
    public partial class BinhLuan
    {
        [Required]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        public int MaSach { get; set; }

        public DateTime? ThoiGian { get; set; }

        public string NoiDung { get; set; }

        public int ID { get; set; }

        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
