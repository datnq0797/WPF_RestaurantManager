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
    
    public partial class CHITIETORDER
    {
        public int MAMONAN { get; set; }
        public int MAOD { get; set; }
        public Nullable<int> SOLUONG { get; set; }
    
        public virtual MENU MENU { get; set; }
        public virtual ORDER ORDER { get; set; }
    }
}
