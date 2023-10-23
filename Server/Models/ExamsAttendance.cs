using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDCARDS.Server.Models
{
    public partial class ExamsAttendance
    {
        [Key]
        public int Id { get; set; }
        public string? Semester { get; set; }
        public int Session { get; set; }
        public DateTime? SignIn { get; set; }
        public DateTime? SignOut { get; set; }
        public string? CourseCode { get; set; }
        public string? RegNumber { get; set; }
        public int SyncVersion { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

    }
}
