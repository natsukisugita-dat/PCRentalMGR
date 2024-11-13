using System.ComponentModel.DataAnnotations;

namespace PCRentalMGR.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "社員番号")]
        public string EmployeeNo { get; set; }

        [Display(Name = "氏名")]
        public string Name { get; set; }

        // その他の社員に関する情報があれば追加します
    }
}
