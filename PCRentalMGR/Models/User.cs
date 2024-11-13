using System;
using System.ComponentModel.DataAnnotations;

namespace PCRentalMGR.Models
{
    public class User
    {
        [Key] // Primary Key
        public int Id { get; set; }

        [Required]
        [Display(Name = "社員番号")]
        public string Employee_no { get; set; }

        [Required]
        [Display(Name = "名前")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "名前（カナ）")]
        public string Name_kana { get; set; }

        [Display(Name = "部署")]
        public string Department { get; set; }

        [Required]
        [Display(Name = "電話番号")]
        [Phone]
        public string Tel_no { get; set; }

        [Required]
        [Display(Name = "メールアドレス")]
        [EmailAddress]
        public string Mail_address { get; set; }

        [Required]
        [Range(18, 99, ErrorMessage = "年齢は18歳から99歳の間である必要があります。")]
        [Display(Name = "年齢")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "性別")]
        public int Gender { get; set; } // 0: 男性, 1: 女性, 2: その他

        [Required]
        [Display(Name = "役職")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "アカウントレベル")]
        public string Account_level { get; set; } // "管理者", "使用者"

        [Required]
        [Display(Name = "登録日")]
        [DataType(DataType.Date)]
        public DateTime Register_date { get; set; }

        [Required]
        [Display(Name = "更新日")]
        [DataType(DataType.Date)]
        public DateTime? Update_date { get; set; }

        [Display(Name = "退職日")]
        [DataType(DataType.Date)]
        public DateTime? Retire_date { get; set; }
    }
}
