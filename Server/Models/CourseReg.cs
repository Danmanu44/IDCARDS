using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDCARDS.Server.Models
{
    public partial class CourseReg
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatePosted { get; set; }
        public string Session { get; set; }
        public string? Semester { get; set; }
        public string? CourseCode { get; set; }
        public int? Unit { get; set; }
        public string? RegNumber { get; set; }
        public int SyncVersion { get; set; }
    }
}
