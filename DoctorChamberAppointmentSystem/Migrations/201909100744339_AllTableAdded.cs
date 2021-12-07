namespace DoctorChamberAppointmentMangementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        AppointmentId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Time = c.String(nullable: false, maxLength: 10, unicode: false),
                        PatientId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AppointmentId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        CountryId = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CountryId);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        DoctorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100, unicode: false),
                        Gender = c.String(nullable: false, maxLength: 10, unicode: false),
                        MedicalName = c.String(nullable: false, maxLength: 150, unicode: false),
                        InstitutionDegree = c.String(nullable: false, maxLength: 500, unicode: false),
                        Department = c.String(nullable: false, maxLength: 50, unicode: false),
                        UploadOfPhoto = c.String(nullable: false, maxLength: 500, unicode: false),
                        Speciality = c.String(nullable: false, maxLength: 150, unicode: false),
                        Degination = c.String(nullable: false, maxLength: 50, unicode: false),
                        PhoneNo = c.String(nullable: false, maxLength: 20, unicode: false),
                        ChamberOfLocation = c.String(nullable: false, maxLength: 350, unicode: false),
                        Fees = c.Double(nullable: false),
                        BMDCRegNo = c.String(nullable: false, maxLength: 10, unicode: false),
                        StartTime = c.String(nullable: false, maxLength: 10, unicode: false),
                        EndTime = c.String(nullable: false, maxLength: 10, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Description = c.String(nullable: false, maxLength: 500, unicode: false),
                    })
                .PrimaryKey(t => t.DoctorId);
            
            CreateTable(
                "dbo.Logins",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientName = c.String(nullable: false, maxLength: 150, unicode: false),
                        PhoneNumber = c.String(nullable: false, maxLength: 30, unicode: false),
                        Age = c.Int(nullable: false),
                        Gender = c.String(nullable: false, maxLength: 5, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        NationalIdNo = c.String(nullable: false, maxLength: 30, unicode: false),
                        AppointmentSerialNo = c.String(nullable: false, maxLength: 150, unicode: false),
                        DoctorId = c.Int(nullable: false),
                        Address = c.String(nullable: false, maxLength: 350, unicode: false),
                        BloodGroup = c.String(maxLength: 5, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Registers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100, unicode: false),
                        Email = c.String(nullable: false, maxLength: 150, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                        ConfirmPassword = c.String(nullable: false, maxLength: 50, unicode: false),
                        CountryId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        IsActive = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Roles");
            DropTable("dbo.Registers");
            DropTable("dbo.Patients");
            DropTable("dbo.Logins");
            DropTable("dbo.Doctors");
            DropTable("dbo.Countries");
            DropTable("dbo.Appointments");
        }
    }
}
