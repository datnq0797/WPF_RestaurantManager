//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wpf_QuanLyNhaHang.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class NHANVIEN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NHANVIEN()
        {
            this.BILLs = new HashSet<BILL>();
            this.ORDERs = new HashSet<ORDER>();
            this.PHIEUNHAPs = new HashSet<PHIEUNHAP>();
        }
    
        public int MANV { get; set; }
        public int MACV { get; set; }
        public int MATK { get; set; }
        public string TENNV { get; set; }
        public System.DateTime NGAYSINH { get; set; }
        public string QUEQUAN { get; set; }
        public string CMND { get; set; }
        public int GIOITINH { get; set; }
        public string TTGD { get; set; }
        public string HINH_ANH { get; set; }
        public string SDT { get; set; }
        public Nullable<double> LUONGCANBAN { get; set; }
        public string TRANGTHAI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BILL> BILLs { get; set; }
        public virtual CHUCVU CHUCVU { get; set; }
        public virtual TAIKHOAN TAIKHOAN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ORDER> ORDERs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PHIEUNHAP> PHIEUNHAPs { get; set; }
    }
}
