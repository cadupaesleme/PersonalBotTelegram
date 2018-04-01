using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Atividade
    {
        public Atividade(Guid id, string nome, TipoAtividade tipoAtividade, Aparelho aparelho)
        {
            Id = id;
            Nome = nome;
            TipoAtividade = tipoAtividade;
            Aparelho = aparelho;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoAtividade TipoAtividade { get; set; }
        public Aparelho Aparelho { get; set; }
    }

    public class Atividades
    {
        public List<Atividade> lista_atividades=new List<Atividade>();

        public Atividades()
        {
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Atividade 1", TipoAtividade.Aerobica, new Aparelhos().lista_Aparelhos[1]));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Atividade 2", TipoAtividade.Aerobica, new Aparelhos().lista_Aparelhos[3]));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Atividade 3", TipoAtividade.Muscular, new Aparelhos().lista_Aparelhos[2]));
            lista_atividades.Add(new Atividade(Guid.NewGuid(), "Atividade 4", TipoAtividade.Muscular, new Aparelhos().lista_Aparelhos[4]));
        }
    }
        public enum TipoAtividade { Aerobica, Muscular }

}
