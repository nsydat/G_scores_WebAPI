using Microsoft.AspNetCore.Mvc;
using G_Scores.Data;
using G_Scores.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace G_Scores.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _context.Students.ToList(); 
            return Ok(students); 
        }

        [HttpGet("{sbd}")]
        public IActionResult GetStudentBySbd(string sbd)
        {
            var student = _context.Students.FirstOrDefault(s => s.sbd == sbd);
            if (student == null)
            {
                return NotFound($"Không tìm thấy sinh viên với số báo danh {sbd}.");
            }
            return Ok(student);
        }



        [HttpGet("TopAStudents")]
        public IActionResult GetTopAStudents()
        {
            var topAStudents = new List<Student>();

            foreach (var student in _context.Students.AsNoTracking())
            {
                student.TotalScore = (student.toan ?? 0) + (student.vat_li ?? 0) + (student.hoa_hoc ?? 0);

                if (topAStudents.Count < 10)
                {
                    topAStudents.Add(student);
                    topAStudents = topAStudents.OrderByDescending(s => s.TotalScore).ToList();
                }
                else if (student.TotalScore > topAStudents.Last().TotalScore)
                {
                    topAStudents.RemoveAt(topAStudents.Count - 1);
                    topAStudents.Add(student);
                    topAStudents = topAStudents.OrderByDescending(s => s.TotalScore).ToList();
                }
            }

            return Ok(topAStudents);
        }




        [HttpGet("ScoreStatistics")]
        public IActionResult GetScoreStatistics()
        {
            var subjects = new[]
            {
                new { Name = "toan", Selector = (Func<Student, double?>)(s => s.toan) },
                new { Name = "ngu_van", Selector = (Func<Student, double?>)(s => s.ngu_van) },
                new { Name = "ngoai_ngu", Selector = (Func<Student, double?>)(s => s.ngoai_ngu) },
                new { Name = "vat_li", Selector = (Func<Student, double?>)(s => s.vat_li) },
                new { Name = "hoa_hoc", Selector = (Func<Student, double?>)(s => s.hoa_hoc) },
                new { Name = "sinh_hoc", Selector = (Func<Student, double?>)(s => s.sinh_hoc) },
                new { Name = "lich_su", Selector = (Func<Student, double?>)(s => s.lich_su) },
                new { Name = "dia_li", Selector = (Func<Student, double?>)(s => s.dia_li) },
                new { Name = "gdcd", Selector = (Func<Student, double?>)(s => s.gdcd) }
            };

            var report = subjects.Select(subject => new
            {
                Subject = subject.Name,
                Level1 = _context.Students.Count(s => EF.Property<double?>(s, subject.Name) >= 8),
                Level2 = _context.Students.Count(s => EF.Property<double?>(s, subject.Name) >= 6 && EF.Property<double?>(s, subject.Name) < 8),
                Level3 = _context.Students.Count(s => EF.Property<double?>(s, subject.Name) >= 4 && EF.Property<double?>(s, subject.Name) < 6),
                Level4 = _context.Students.Count(s => EF.Property<double?>(s, subject.Name) < 4)
            }).ToList();

            return Ok(report);
        }
    }
}
