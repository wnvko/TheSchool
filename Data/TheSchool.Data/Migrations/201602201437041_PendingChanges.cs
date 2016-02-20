namespace TheSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.DisciplineDivisions", newName: "DivisionDisciplines");
            RenameTable(name: "dbo.DisciplineTeachers", newName: "TeacherDisciplines");
            RenameColumn(table: "dbo.AspNetUsers", name: "FirstName", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "SecondName", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.AspNetUsers", name: "FirstName1", newName: "FirstName");
            RenameColumn(table: "dbo.AspNetUsers", name: "SecondName1", newName: "SecondName");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "FirstName1");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__1", newName: "SecondName1");
            DropPrimaryKey("dbo.DivisionDisciplines");
            DropPrimaryKey("dbo.TeacherDisciplines");
            AddPrimaryKey("dbo.DivisionDisciplines", new[] { "Division_Id", "Discipline_Id" });
            AddPrimaryKey("dbo.TeacherDisciplines", new[] { "Teacher_Id", "Discipline_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.TeacherDisciplines");
            DropPrimaryKey("dbo.DivisionDisciplines");
            AddPrimaryKey("dbo.TeacherDisciplines", new[] { "Discipline_Id", "Teacher_Id" });
            AddPrimaryKey("dbo.DivisionDisciplines", new[] { "Discipline_Id", "Division_Id" });
            RenameColumn(table: "dbo.AspNetUsers", name: "SecondName1", newName: "__mig_tmp__1");
            RenameColumn(table: "dbo.AspNetUsers", name: "FirstName1", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.AspNetUsers", name: "SecondName", newName: "SecondName1");
            RenameColumn(table: "dbo.AspNetUsers", name: "FirstName", newName: "FirstName1");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__1", newName: "SecondName");
            RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "FirstName");
            RenameTable(name: "dbo.TeacherDisciplines", newName: "DisciplineTeachers");
            RenameTable(name: "dbo.DivisionDisciplines", newName: "DisciplineDivisions");
        }
    }
}
