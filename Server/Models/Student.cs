using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IDCARDS.Server.Models
{
    public partial class Student
    {
        [Key]
        public int Id { get; set; }
        public DateTime? IdExpireDate { get; set; }
        public string? Faculty { get; set; }
        public string? Department { get; set; }
        public int Level { get; set; }
        public string RegNumber { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? NfcSn { get; set; }
        public int SyncVersion { get; set; }
        public string? ImagePath { get; set; }
        public bool? Suspended { get; set; }
        public string? NextOfKinPhone { get; set; }
        //public string? ImagePath { get; set; }

        public int? UpSync { get; set; }
        public string? Program { get; set; }
        public Student()
        {


        }


    }
}
