using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Passo
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Pergunta { get; set; }
        public IList<string> Opcoes { get; set; }
    }
}
