using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PCRentalMGR.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Display(Name = "資産番号")]
        public string? Asset_no { get; set; }

        [Display(Name = "メーカー")]
        public string? Maker { get; set; } = string.Empty;

        [Display(Name = "機種")]
        public string? Model { get; set; } = string.Empty;

        [Display(Name = "OS")]
        public string? Os { get; set; } = string.Empty;

        [Display(Name = "保管場所")]
        public string? Store { get; set; } = string.Empty;

        [Display(Name = "社員番号")]
        public string? EmployeeNo { get; set; } // 社員番号

        [Display(Name = "社員氏名")]
        public string? Name { get; set; } // 社員氏名

        [Display(Name = "貸出日")]
        public DateTime RentalStart { get; set; }

        [Display(Name = "返却日")]
        public DateTime RentalLimit { get; set; }

        [Display(Name = "棚卸日")]
        [DataType(DataType.Date)]
        public DateTime? InventryDay { get; set; }

        [Display(Name = "備考")]
        public string? Remarks { get; set; }

        [Display(Name = "更新日")]
        [DataType(DataType.Date)]
        public DateTime? RenewDate { get; set; }

        public bool Canrental { get; set; }
        public bool Overday { get; set; }

        public int? DeviceId { get; set; }
        public Device? Device { get; set; }

        public int? UserId { get; set; } // Userの外部キー
        public User? User { get; set; }

        public bool IsRented { get; set; }
    }
}