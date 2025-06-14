using G_Scores.Data;
using G_Scores.Models;

namespace G_Scores.Services
{
    public static class DataSeeder
    {
        public static void SeedData(ApplicationDbContext context)
        {
            if (!context.Students.Any())
            {
                var lines = File.ReadAllLines("diem_thi_thpt_2024.csv");
                foreach (var line in lines.Skip(1)) // Bỏ qua header
                {
                    var parts = line.Split(',');

                    var student = new Student
                    {
                        sbd = parts[0],
                        toan = string.IsNullOrWhiteSpace(parts[1]) ? 0 : double.Parse(parts[1]),
                        ngu_van = string.IsNullOrWhiteSpace(parts[2]) ? 0 : double.Parse(parts[2]),
                        ngoai_ngu = string.IsNullOrWhiteSpace(parts[3]) ? 0 : double.Parse(parts[3]),
                        vat_li = string.IsNullOrWhiteSpace(parts[4]) ? null : double.Parse(parts[4]),
                        hoa_hoc = string.IsNullOrWhiteSpace(parts[5]) ? null : double.Parse(parts[5]),
                        sinh_hoc = string.IsNullOrWhiteSpace(parts[6]) ? null : double.Parse(parts[6]),
                        lich_su = string.IsNullOrWhiteSpace(parts[7]) ? null : double.Parse(parts[7]),
                        dia_li = string.IsNullOrWhiteSpace(parts[8]) ? null : double.Parse(parts[8]),
                        gdcd = string.IsNullOrWhiteSpace(parts[9]) ? null : double.Parse(parts[9]),
                        ma_ngoai_ngu = parts[10]
                    };

                    context.Students.Add(student);
                }

                context.SaveChanges();
            }
        }
    }

}
