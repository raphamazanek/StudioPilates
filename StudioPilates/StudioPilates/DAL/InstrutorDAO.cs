using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudioPilates.Model;
namespace StudioPilates.DAL
{
    class InstrutorDAO
    {
        private static Context ctx = new Context();

        //add novo Instrutor
        public static bool AdicionarInstrutor(Instrutor a)
        {
            try
            {
                ctx.Instrutor.Add(a);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }

        }

        //verifica se Instrutor ja existe
        public static Instrutor VerificaInstrutorPorCPF(Instrutor a)
        {
            return ctx.Instrutor.FirstOrDefault(x => x.CPF.Equals(a.CPF));
        }

        //busca lista de Instrutors
        public static List<Instrutor> ReturnLista()
        {
            return ctx.Instrutor.ToList();
        }

        //remove cadastro do Instrutor
        public static bool RemoverInstrutor(Instrutor a)
        {
            try
            {
                ctx.Instrutor.Remove(a);
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //altera os dados do Instrutor
        public static bool AlterarInstrutor(Instrutor a)
        {
            try
            {
                ctx.Entry(a).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;

            }
        }

    }
}
