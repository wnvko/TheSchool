namespace TheSchool.Data.Migrations
{
    using System.Data.Entity.Migrations;

    /// <summary>
    /// Description for StyleCop :)
    /// </summary>
    public partial class BaseDbStructureCreated : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Divisions",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Grade = c.Int(nullable: false),
                    Name = c.String(nullable: false),
                    ClassTutorId = c.String(maxLength: 128),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeletedOn = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ClassTutorId)
                .Index(t => t.ClassTutorId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Disciplines",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeletedOn = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.Marks",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Value = c.Int(nullable: false),
                    StudentId = c.String(nullable: false, maxLength: 128),
                    DisciplineId = c.Int(nullable: false),
                    TeacherId = c.String(nullable: false, maxLength: 128),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeletedOn = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.StudentId, cascadeDelete: false)
                .ForeignKey("dbo.AspNetUsers", t => t.TeacherId, cascadeDelete: false)
                .Index(t => t.StudentId)
                .Index(t => t.DisciplineId)
                .Index(t => t.TeacherId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.DisciplineDivisions",
                c => new
                {
                    Discipline_Id = c.Int(nullable: false),
                    Division_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Discipline_Id, t.Division_Id })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.Divisions", t => t.Division_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Division_Id);

            this.CreateTable(
                "dbo.DisciplineTeachers",
                c => new
                {
                    Discipline_Id = c.Int(nullable: false),
                    Teacher_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.Discipline_Id, t.Teacher_Id })
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Teacher_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Teacher_Id);

            this.AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            this.AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            this.AddColumn("dbo.AspNetUsers", "DivisionId", c => c.Int());
            this.AddColumn("dbo.AspNetUsers", "FirstName1", c => c.String());
            this.AddColumn("dbo.AspNetUsers", "SecondName1", c => c.String());
            this.AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            this.CreateIndex("dbo.AspNetUsers", "DivisionId");
            this.AddForeignKey("dbo.AspNetUsers", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.AspNetUsers", "DivisionId", "dbo.Divisions");
            this.DropForeignKey("dbo.Divisions", "ClassTutorId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.DisciplineTeachers", "Teacher_Id", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.DisciplineTeachers", "Discipline_Id", "dbo.Disciplines");
            this.DropForeignKey("dbo.Marks", "TeacherId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Marks", "StudentId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Marks", "DisciplineId", "dbo.Disciplines");
            this.DropForeignKey("dbo.DisciplineDivisions", "Division_Id", "dbo.Divisions");
            this.DropForeignKey("dbo.DisciplineDivisions", "Discipline_Id", "dbo.Disciplines");
            this.DropIndex("dbo.DisciplineTeachers", new[] { "Teacher_Id" });
            this.DropIndex("dbo.DisciplineTeachers", new[] { "Discipline_Id" });
            this.DropIndex("dbo.DisciplineDivisions", new[] { "Division_Id" });
            this.DropIndex("dbo.DisciplineDivisions", new[] { "Discipline_Id" });
            this.DropIndex("dbo.Marks", new[] { "IsDeleted" });
            this.DropIndex("dbo.Marks", new[] { "TeacherId" });
            this.DropIndex("dbo.Marks", new[] { "DisciplineId" });
            this.DropIndex("dbo.Marks", new[] { "StudentId" });
            this.DropIndex("dbo.Disciplines", new[] { "IsDeleted" });
            this.DropIndex("dbo.Divisions", new[] { "IsDeleted" });
            this.DropIndex("dbo.Divisions", new[] { "ClassTutorId" });
            this.DropIndex("dbo.AspNetUsers", new[] { "DivisionId" });
            this.DropColumn("dbo.AspNetUsers", "Discriminator");
            this.DropColumn("dbo.AspNetUsers", "SecondName1");
            this.DropColumn("dbo.AspNetUsers", "FirstName1");
            this.DropColumn("dbo.AspNetUsers", "DivisionId");
            this.DropColumn("dbo.AspNetUsers", "SecondName");
            this.DropColumn("dbo.AspNetUsers", "FirstName");
            this.DropTable("dbo.DisciplineTeachers");
            this.DropTable("dbo.DisciplineDivisions");
            this.DropTable("dbo.Marks");
            this.DropTable("dbo.Disciplines");
            this.DropTable("dbo.Divisions");
        }
    }
}
