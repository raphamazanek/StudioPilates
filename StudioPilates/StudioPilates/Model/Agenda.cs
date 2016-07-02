using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudioPilates.Model
{
    [Table("Agenda")]
    class Agenda
    {
        public Agenda()
        {
            Aluno = new List<Aluno>();
            Instrutor = new Instrutor();
        }

        [Key]
        public int AgendaId { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFinal { get; set; }
        public List<Aluno> Aluno { get; set; }
        public Instrutor Instrutor { get; set; }
        public string Descricao { get; set; }
    }
}
