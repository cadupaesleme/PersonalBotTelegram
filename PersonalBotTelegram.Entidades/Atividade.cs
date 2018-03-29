using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Atividade
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public TipoAtividade TipoAtividade { get; set; }
        public Aparelho Aparelho { get; set; }
    }

    public enum TipoAtividade { Aerobica, Muscular }

}
