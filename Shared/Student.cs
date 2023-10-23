using System;
using System.Collections.Generic;

namespace IDCARDS.Shared.Models
{
    public partial class Student
    {
        
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
        public bool? Suspended { get; set; }
        public string? NextOfKinPhone { get; set; }
        public string? ImagePath { get; set; }

        public int? UpSync { get; set; }
        public string? Program { get; set; }
        public Student()
        {

        }
        public Student(int id,
                       DateTime idExpireDate,
                       string? faculty,
                       string? department,
                       int level,
                       string? regNumber,
                       string? middleName,
                       string? lastName,
                       string? firstName,
                       string? nfcSn,
                       int syncVersion,
                       bool? suspended,
                       string? nextOfKinPhone,
                       string? imagePath,
                       int upSync,
                       string program
                        )
        {
            this.Id = id;
            this.IdExpireDate = idExpireDate;
            this.Faculty = faculty;
            this.Department = department;
            this.Level = level;
            this.RegNumber = regNumber;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.NfcSn = nfcSn;
            this.SyncVersion = syncVersion;
            this.Suspended = suspended;
            this.NextOfKinPhone = nextOfKinPhone;
            this.ImagePath = imagePath;
            this.UpSync = upSync;
            this.Program = program;
            
        }
    }
}
