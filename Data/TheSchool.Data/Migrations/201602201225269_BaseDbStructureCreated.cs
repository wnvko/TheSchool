namespace TheSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BaseDbStructureCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
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
            
            CreateTable(
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
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName", c => c.String());
            AddColumn("dbo.AspNetUsers", "DivisionId", c => c.Int());
            AddColumn("dbo.AspNetUsers", "FirstName1", c => c.String());
            AddColumn("dbo.AspNetUsers", "SecondName1", c => c.String());
            AddColumn("dbo.AspNetUsers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.AspNetUsers", "DivisionId");
            AddForeignKey("dbo.AspNetUsers", "DivisionId", "dbo.Divisions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "DivisionId", "dbo.Divisions");
            DropForeignKey("dbo.Divisions", "ClassTutorId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DisciplineTeachers", "Teacher_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.DisciplineTeachers", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Marks", "TeacherId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Marks", "StudentId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Marks", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.DisciplineDivisions", "Division_Id", "dbo.Divisions");
            DropForeignKey("dbo.DisciplineDivisions", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.DisciplineTeachers", new[] { "Teacher_Id" });
            DropIndex("dbo.DisciplineTeachers", new[] { "Discipline_Id" });
            DropIndex("dbo.DisciplineDivisions", new[] { "Division_Id" });
            DropIndex("dbo.DisciplineDivisions", new[] { "Discipline_Id" });
            DropIndex("dbo.Marks", new[] { "IsDeleted" });
            DropIndex("dbo.Marks", new[] { "TeacherId" });
            DropIndex("dbo.Marks", new[] { "DisciplineId" });
            DropIndex("dbo.Marks", new[] { "StudentId" });
            DropIndex("dbo.Disciplines", new[] { "IsDeleted" });
            DropIndex("dbo.Divisions", new[] { "IsDeleted" });
            DropIndex("dbo.Divisions", new[] { "ClassTutorId" });
            DropIndex("dbo.AspNetUsers", new[] { "DivisionId" });
            DropColumn("dbo.AspNetUsers", "Discriminator");
            DropColumn("dbo.AspNetUsers", "SecondName1");
            DropColumn("dbo.AspNetUsers", "FirstName1");
            DropColumn("dbo.AspNetUsers", "DivisionId");
            DropColumn("dbo.AspNetUsers", "SecondName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.DisciplineTeachers");
            DropTable("dbo.DisciplineDivisions");
            DropTable("dbo.Marks");
            DropTable("dbo.Disciplines");
            DropTable("dbo.Divisions");
        }
    }
}
