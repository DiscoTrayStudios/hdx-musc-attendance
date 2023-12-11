using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MUSCAttendance.Data;
using MUSCAttendance.Models;

namespace MUSCAttendance.Pages.Forms
{
    public class IndexModel : PageModel
    {
        private readonly MUSCAttendance.Data.SchoolContext _context;

        public IndexModel(MUSCAttendance.Data.SchoolContext context)
        {
            _context = context;
        }

        public string SearchID { get; set; }
        public IList<Form> Form { get;set; } = default!;
        public string StudentId { get; set; }
        public Student Student {get;set;}



        public int HendrixCount { get; set; }
        public int UCACount { get; set; }
        public int OtherCount { get; set; }


        public async Task OnGetAsync(string studentId)
        {
            // If a student ID is provided, filter forms by that ID
            if (!string.IsNullOrEmpty(studentId))
            {
                Student = await _context.Students
                    .Where(s => s.StudentID.ToString() == studentId)
                    .FirstOrDefaultAsync();
                
                Form = Student.Forms;
            }
            else
            {
                // If no student ID provided, retrieve all forms
                Form = await _context.Forms.ToListAsync();
            }
            
            HendrixCount = Form.Count(f => f.Type.ToString() == "Hendrix");
            UCACount = Form.Count(f => f.Type.ToString() == "UCA");
            OtherCount = Form.Count(f => f.Type.ToString() == "Other");
        }
    }
}