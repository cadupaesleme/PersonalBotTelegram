                                                                                                                                                                                                                                                                                                                                                                                                                                               using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class TreinoFrango : ITreino
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public IList<Atividade> Atividades { get; set; }

        public TreinoFrango()
        {
            this.Id = Guid.NewGuid();
            this.Nome = "Treino Frango 1";
            Atividades at = new Atividades();
            this.Atividades = at.lista_atividades;
        }
    }
}                                                                                                                                                                        