using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace G_Scores.Models
{
    [Index(nameof(toan))]
    [Index(nameof(ngu_van))]
    [Index(nameof(ngoai_ngu))]
    [Index(nameof(vat_li))]
    [Index(nameof(hoa_hoc))]
    [Index(nameof(sinh_hoc))]
    [Index(nameof(lich_su))]
    [Index(nameof(dia_li))]
    [Index(nameof(gdcd))]
    public class Student
    {
        public int Id { get; set; }
        public string? sbd { get; set; }
        public double? toan { get; set; }
        public double? ngu_van { get; set; }
        public double? ngoai_ngu { get; set; }
        public double? vat_li { get; set; }
        public double? hoa_hoc { get; set; }
        public double? sinh_hoc { get; set; }
        public double? lich_su { get; set; }
        public double? dia_li { get; set; }
        public double? gdcd { get; set; }
        public string ma_ngoai_ngu { get; set; }

        [NotMapped] 
        public double TotalScore { get; set; }
    }
}
