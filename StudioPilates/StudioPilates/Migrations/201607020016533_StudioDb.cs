namespace StudioPilates.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StudioDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Alunos",
                c => new
                    {
                        AlunoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        CPF = c.String(),
                        Nasc = c.String(),
                        Celular = c.String(),
                        Telefone = c.String(),
                        AvaliacaoFisica = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.AlunoId);
            
            CreateTable(
                "dbo.Instrutor",
                c => new
                    {
                        InstrutorId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Sobrenome = c.String(),
                        CPF = c.String(),
                        Nasc = c.DateTime(nullable: false),
                        Celula = c.String(),
                        Telefone = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.InstrutorId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Instrutor");
            DropTable("dbo.Alunos");
        }
    }
}
