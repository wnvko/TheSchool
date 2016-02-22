namespace TheSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Description for StyleCop :)
    /// </summary>
    public partial class PendingChanges : DbMigration
    {
        public override void Up()
        {
            this.RenameTable(name: "dbo.DisciplineDivisions", newName: "DivisionDisciplines");
            this.RenameTable(name: "dbo.DisciplineTeachers", newName: "TeacherDisciplines");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "FirstName", newName: "__mig_tmp__0");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "SecondName", newName: "__mig_tmp__1");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "FirstName1", newName: "FirstName");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "SecondName1", newName: "SecondName");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "FirstName1");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__1", newName: "SecondName1");
            this.DropPrimaryKey("dbo.DivisionDisciplines");
            this.DropPrimaryKey("dbo.TeacherDisciplines");
            this.AddPrimaryKey("dbo.DivisionDisciplines", new[] { "Division_Id", "Discipline_Id" });
            this.AddPrimaryKey("dbo.TeacherDisciplines", new[] { "Teacher_Id", "Discipline_Id" });
        }

        public override void Down()
        {
            this.DropPrimaryKey("dbo.TeacherDisciplines");
            this.DropPrimaryKey("dbo.DivisionDisciplines");
            this.AddPrimaryKey("dbo.TeacherDisciplines", new[] { "Discipline_Id", "Teacher_Id" });
            this.AddPrimaryKey("dbo.DivisionDisciplines", new[] { "Discipline_Id", "Division_Id" });
            this.RenameColumn(table: "dbo.AspNetUsers", name: "SecondName1", newName: "__mig_tmp__1");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "FirstName1", newName: "__mig_tmp__0");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "SecondName", newName: "SecondName1");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "FirstName", newName: "FirstName1");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__1", newName: "SecondName");
            this.RenameColumn(table: "dbo.AspNetUsers", name: "__mig_tmp__0", newName: "FirstName");
            this.RenameTable(name: "dbo.TeacherDisciplines", newName: "DisciplineTeachers");
            this.RenameTable(name: "dbo.DivisionDisciplines", newName: "DisciplineDivisions");
        }
    }
}
