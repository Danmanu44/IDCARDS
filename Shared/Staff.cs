using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDCARDS.Shared
{
    public partial class Staff
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; } = null!;

        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string? MiddleName { get; set; } = null!;
        public string PsnNumber { get; set; } = null!;
        public string Designation { get; set; } = null!;
        public int? Level { get; set; }
        public string Department { get; set; } = null!;
        public string Unit { get; set; } = null!;
        public string? NfcSn { get; set; } = null!;
        public int? SyncVersion { get; set; }
        public string? NextOfKinPhone { get; set; }
        public string? ImagePath { get; set; }

    }
}
