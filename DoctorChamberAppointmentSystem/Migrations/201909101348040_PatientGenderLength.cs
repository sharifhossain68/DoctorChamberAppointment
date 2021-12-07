namespace DoctorChamberAppointmentMangementSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PatientGenderLength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable: false, maxLength: 6, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Patients", "Gender", c => c.String(nullable: false, maxLength: 5, unicode: false));
        }
    }
}
