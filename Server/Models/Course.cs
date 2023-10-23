using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDCARDS.Server.Models
{
    public partial class Course
    {
        [Key]
        public int Id { get; set; }
        public int CreditUnit { get; set; }
        public string? CourseCode { get; set; }
        public string Title { get; set; }
    }
}
