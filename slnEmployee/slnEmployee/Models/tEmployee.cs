//------------------------------------------------------------------------------
// <auto-generated>
//     這個程式碼是由範本產生。
//
//     對這個檔案進行手動變更可能導致您的應用程式產生未預期的行為。
//     如果重新產生程式碼，將會覆寫對這個檔案的手動變更。
// </auto-generated>
//------------------------------------------------------------------------------

namespace slnEmployee.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class tEmployee
    {
        [DisplayName("員工編號")]
        [Required(ErrorMessage = "員工編號不可空白")]
        [StringLength(9, ErrorMessage = "員工編號必須是3~9個字元", MinimumLength = 3)]
        public string fEmpId { get; set; }

        [DisplayName("姓名")]
        [Required(ErrorMessage = "姓名不可空白")]
        public string fName { get; set; }

        [DisplayName("電話號碼")]
        [Required(ErrorMessage = "電話號碼不可空白")]
        public string fPhone { get; set; }

        [DisplayName("部門編號")]
        [Required(ErrorMessage = "部門編號不可空白")]
        public Nullable<int> fDepId { get; set; }
    }
}
