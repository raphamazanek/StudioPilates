namespace StudioPilates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudioDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agenda",
                c => new
                    {
                        AgendaId = c.Int(nullable: false, identity: true),
                        DataInicio = c.DateTime(nullable: false),
                        DataFinal = c.DateTime(nullable: false),
                        Descricao = c.String(),
                        Instrutor_InstrutorId = c.Int(),
                    })
                .PrimaryKey(t => t.AgendaId)
                .ForeignKey("dbo.Instrutor", t => t.Instrutor_InstrutorId)
                .Index(t => t.Instrutor_InstrutorId);
            
            CreateTable(
                "dbo.Plano",
                c => new
                    {
                        PlanoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.PlanoId);
            
            AddColumn("dbo.Alunos", "Agenda_AgendaId", c => c.Int());
            CreateIndex("dbo.Alunos", "Agenda_AgendaId");
            AddForeignKey("dbo.Alunos", "Agenda_AgendaId", "dbo.Agenda", "AgendaId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Agenda", "Instrutor_InstrutorId", "dbo.Instrutor");
            DropForeignKey("dbo.Alunos", "Agenda_AgendaId", "dbo.Agenda");
            DropIndex("dbo.Alunos", new[] { "Agenda_AgendaId" });
            DropIndex("dbo.Agenda", new[] { "Instrutor_InstrutorId" });
            DropColumn("dbo.Alunos", "Agenda_AgendaId");
            DropTable("dbo.Plano");
            DropTable("dbo.Agenda");
        }
    }
}
