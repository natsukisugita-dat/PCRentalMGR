using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PCRentalMGR.Models
{
    public class Device
    {
        public int Id { get; set; }
        [Display(Name = "資産番号")]
        public string? Asset_no { get; set; } = string.Empty;

        [Display(Name = "メーカー")]
        public string? Maker { get; set; } = string.Empty;

        [Display(Name = "機種")]
        public string? Model { get; set; } = string.Empty;

        [Display(Name = "OS")]
        public string? Os { get; set; } = string.Empty;

        [Display(Name = "メモリ")]
        public string? Memory { get; set; } = string.Empty;

        [Display(Name = "容量")]
        public string? Capacity { get; set; } = string.Empty;

        [Display(Name = "グラフィックボード")]
        public string? Gpu { get; set; } = string.Empty;

        [Display(Name = "保管場所")]
        public string? Store { get; set; } = string.Empty;

        [Display(Name = "故障")]
        public string? Failure { get; set; } = string.Empty;

        [Display(Name = "利用開始日")]
        [DataType(DataType.Date)] public DateTime start { get; set; }

        [Display(Name = "使用期限")]
        [DataType(DataType.Date)] public DateTime limit { get; set; }

        [Display(Name = "備考")]
        public string? remaker { get; set; }

        //デバイス登録日
        [Display(Name = "登録日")]
        [DataType(DataType.Date)] public DateTime register_date { get; set; }

        //デバイス最終編集日
        [Display(Name = "更新日")]
        [DataType(DataType.Date)] public DateTime? edit_date { get; set; }

        [Display(Name = "返却日")]
        [DataType(DataType.Date)] public DateTime? limit_date { get; set; }

        //デバイス削除
        [Display(Name = "削除フラグ")]
        public bool? delete_flag { get; set; }


        public bool IsRented { get; set; } // 貸出中かどうかを示すフラグ
    }
}
