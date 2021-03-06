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
        [Column(Order = 0)]
        [StringLength(20)]
        public string TenDangNhap { get; set; }

        [Display(Name = "Mã sách")]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSach { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy hh:mm:ss}", ApplyFormatInEditMode=true)]
        [Display(Name = "Thời gian")]
        [Column(TypeName = "datetime")]
        public DateTime? ThoiGian { get; set; }
        
        [Display(Name="Nội dung")]
        public string NoiDung { get; set; }

        [Key]
        [Display(Name = "ID")]
        public int ID { get; set; }
        public virtual Sach Sach { get; set; }

        public virtual TaiKhoan TaiKhoan { get; set; }
    }
}
