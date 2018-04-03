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
        public IList<Opcao> Opcoes { get; set; }

        public Passo() { Opcoes = new List<Opcao>(); }
    }

    public class Fluxo
    {
        public Passo Atual { get; set; }
        public long ChatId { get; set; }
        public bool Inicio { get; set; }

        public Fluxo()
        {
            this.Inicio = true;

            Atual = Iniciar();


        }
        
        
        private Passo Iniciar()
        {
            //iniciar 
            Passo Inicio = new Passo { Id = Guid.NewGuid(), Nome = "Inicio", Pergunta = "Vamos Malhar ?" };

            //escolher modulo
            Passo EscolherModulo = new Passo { Id = Guid.NewGuid(), Nome = "EscolherModulo", Pergunta = "Legal, que tipo de treino você quer ?" };

            //passo finalizar
            Passo Final = new Passo { Id = Guid.NewGuid(), Nome = "Inicio", Pergunta = "Ok preguiçoso!!" };

            //opcoes iniciar
            Opcao Inicio1 = new Opcao { Id = Guid.NewGuid(), Nome = "Sim", Passo = Inicio, ProximoPasso = EscolherModulo };
            Opcao Inicio2 = new Opcao { Id = Guid.NewGuid(), Nome = "Não", Passo = Inicio, ProximoPasso = Final };
            Inicio.Opcoes.Add(Inicio1);
            Inicio.Opcoes.Add(Inicio2);


            //opcoes escolher modulo
            Opcao EscolherModulo1 = new Opcao { Id = Guid.NewGuid(), Nome = "Frango", Passo = EscolherModulo, ProximoPasso = Final };
            Opcao EscolherModulo2 = new Opcao { Id = Guid.NewGuid(), Nome = "Moderado", Passo = EscolherModulo, ProximoPasso = Final };
            Opcao EscolherModulo3 = new Opcao { Id = Guid.NewGuid(), Nome = "Monstro", Passo = EscolherModulo, ProximoPasso = Final };
            EscolherModulo.Opcoes.Add(EscolherModulo1);
            EscolherModulo.Opcoes.Add(EscolherModulo2);
            EscolherModulo.Opcoes.Add(EscolherModulo3);

            return Inicio;

        }


        public void MudarPasso(Passo Atual, string Escolhida)
        {

            Inicio = false;

            //colocar as condicoes
            var NovoPasso = Atual.Opcoes.FirstOrDefault(op => op.Nome == Escolhida).ProximoPasso;

            //senao encontar o passo retorna o anterior
            if (NovoPasso != null)
                this.Atual = NovoPasso;
        }
    }
}
