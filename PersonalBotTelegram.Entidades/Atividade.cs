using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public enum TipoAtividade { Frango, Moderado, Monstro }
    public class Atividade
    {
        public Atividade(Guid id, string nome, TipoAtividade tipoAtividade, Aparelho aparelho, string descricao)
        {
            Id = id;
            Nome = nome;
            TipoAtividade = tipoAtividade;
            Aparelho = aparelho;
            Descricao = descricao;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoAtividade TipoAtividade { get; set; }
        public Aparelho Aparelho { get; set; }
        public string Descricao { get; set; }


       

    }

    public class Atividades
    {
        public List<Atividade> lista_atividades = new List<Atividade>();

        public Atividades()
        {
            Aparelhos ap = new Aparelhos();

            //Frango
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Supino", TipoAtividade.Frango, ap.getAparelho(1), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Remada", TipoAtividade.Frango, ap.getAparelho(2), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Cadeira Flexora", TipoAtividade.Frango, ap.getAparelho(3), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Abdominal supra reto", TipoAtividade.Frango, ap.getAparelho(4), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Lombar", TipoAtividade.Frango, ap.getAparelho(5), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));

            //Moderado
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Puxada", TipoAtividade.Moderado, ap.getAparelho(6), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Remada", TipoAtividade.Moderado, ap.getAparelho(2), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Supino", TipoAtividade.Moderado, ap.getAparelho(1), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Leg press 45", TipoAtividade.Moderado, ap.getAparelho(7), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Cadeira Flexora", TipoAtividade.Moderado, ap.getAparelho(3), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));


            //Monstro
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Supino", TipoAtividade.Monstro, ap.getAparelho(1), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Lombar", TipoAtividade.Monstro, ap.getAparelho(5), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Remada", TipoAtividade.Monstro, ap.getAparelho(2), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Leg press 45", TipoAtividade.Monstro, ap.getAparelho(7), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Cadeira Flexora", TipoAtividade.Monstro, ap.getAparelho(3), "Bla bla bla bla bla bla " + System.Environment.NewLine + " bla bla bla bla bla"));
        }


        
        public List<string> MontarTreino(string treinoAux)
        {
            var lista = lista_atividades.Where(p => p.TipoAtividade.ToString() == treinoAux).ToList();
            List<string> perguntas = new List<string>();
           if (lista.Count > 0)
            {
                for (int i = 0; i < lista.Count; i++)
                {
                    var l = lista[i];
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine(l.Nome);
                    sb.AppendLine("Aparelho: " + l.Aparelho.Nome);
                    sb.AppendLine("Descrição: " + l.Descricao);
                    sb.AppendLine("|" + l.Aparelho.Imagem);
                    perguntas.Add(sb.ToString());
                    
                }
                //lista_atividades.Remove(l);

                return perguntas;
            }
            else
            {
                return null;
            }
        }

    }

   
}
