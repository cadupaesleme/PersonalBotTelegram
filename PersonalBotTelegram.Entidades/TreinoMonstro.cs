using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class TreinoMonstro : ITreino
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<Atividade> Atividades { get; set; }


        public TreinoMonstro()
        {
            this.Id = Guid.NewGuid();
            this.Nome = "Treino Monstro 1";
            Atividades at = new Atividades();
            this.Atividades = at.lista_atividades;
        }
    }
}
