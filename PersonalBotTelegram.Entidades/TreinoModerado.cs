using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class TreinoModerado : ITreino
    {
        public TreinoModerado()
        {
            this.Id = Guid.NewGuid();
            this.Nome = "Treino Moderado 1";
            Atividades at = new Atividades();
            this.Atividades = at.lista_atividades;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<Atividade> Atividades { get; set; }

    }
}
