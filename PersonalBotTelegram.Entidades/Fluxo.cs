using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Fluxo
    {
        public Passo Atual { get; set; }
        public long ChatId { get; set; }

        public Fluxo()
        {
            Atual = Iniciar();


        }


        private Passo IniciarTreino(string treinoAux)
        {
            ITreino treino;

            //gerar o treino
            switch (treinoAux)
            {
                case "Frango":
                    treino = new TreinoFrango();
                    break;
                case "Moderado":
                    treino = new TreinoModerado();
                    break;
                case "Monstro":
                    treino = new TreinoMonstro();
                    break;
                default:
                    treino = null;
                    break;
            }

            //pegas as atividades
            Atividades atividades = new Atividades();

            //passo finalizar
            Passo Final = new Passo { Id = Guid.NewGuid(), Nome = "Fim", Pergunta = "Ok preguiçoso!!" };

            var ativ = atividades.MontarTreino(treinoAux);
            Passo inicialAtividade = new Passo { Id = Guid.NewGuid(), Nome = "Atividade", Pergunta = ativ[0], Perguntas = ativ };


            Opcao Atividade1 = new Opcao { Id = Guid.NewGuid(), Nome = "Próxima", Passo = inicialAtividade, ProximoPasso = inicialAtividade };
            Opcao Atividade2 = new Opcao { Id = Guid.NewGuid(), Nome = "Sair", Passo = inicialAtividade, ProximoPasso = Final };
            inicialAtividade.Opcoes.Add(Atividade1);
            inicialAtividade.Opcoes.Add(Atividade2);

            return inicialAtividade;
            //foreach (Atividade atividade in treino.Atividades)
            //{

            //}
        }

        private Passo MudarPassoTreino(Passo Atual)
        {

            //muda o passo do treino ate acabar as atividades

            Atual.Perguntas.Remove(Atual.Perguntas[0]);
            Atual.Pergunta = Atual.Perguntas[0];
            return Atual;
        }



        private Passo Iniciar()
        {
            //iniciar 
            Passo Inicio = new Passo { Id = Guid.NewGuid(), Nome = "Inicio", Pergunta = "Vamos Malhar ?" };

            //escolher modulo
            Passo EscolherModulo = new Passo { Id = Guid.NewGuid(), Nome = "EscolherModulo", Pergunta = "Legal, que tipo de treino você quer ?" };

            //passo finalizar

            Passo Final = new Passo { Id = Guid.NewGuid(), Nome = "Fim", Pergunta = "Ok preguiçoso!!" };

            //opcoes iniciar
            Opcao Inicio1 = new Opcao { Id = Guid.NewGuid(), Nome = "Sim", Passo = Inicio, ProximoPasso = EscolherModulo };
            Opcao Inicio2 = new Opcao { Id = Guid.NewGuid(), Nome = "Não", Passo = Inicio, ProximoPasso = Final };
            Inicio.Opcoes.Add(Inicio1);
            Inicio.Opcoes.Add(Inicio2);


            //opcoes escolher modulo
            Opcao EscolherModulo1 = new Opcao { Id = Guid.NewGuid(), Nome = "Frango", Passo = EscolherModulo, ProximoPasso = IniciarTreino("Frango") };
            Opcao EscolherModulo2 = new Opcao { Id = Guid.NewGuid(), Nome = "Moderado", Passo = EscolherModulo, ProximoPasso = IniciarTreino("Moderado") };
            Opcao EscolherModulo3 = new Opcao { Id = Guid.NewGuid(), Nome = "Monstro", Passo = EscolherModulo, ProximoPasso = IniciarTreino("Monstro") };
            EscolherModulo.Opcoes.Add(EscolherModulo1);
            EscolherModulo.Opcoes.Add(EscolherModulo2);
            EscolherModulo.Opcoes.Add(EscolherModulo3);

            return Inicio;

        }


        public void MudarPasso(Passo Atual, string Escolhida)
        {
            //colocar as condicoes
            var NovoPasso = Atual.Opcoes.FirstOrDefault(op => op.Nome == Escolhida);

            //senao encontar o passo retorna o anterior
            if (NovoPasso != null)
            {
                if (NovoPasso.ProximoPasso.Perguntas.Count > 0)
                {
                    NovoPasso.ProximoPasso.Pergunta = NovoPasso.ProximoPasso.Perguntas[0];
                    NovoPasso.ProximoPasso.Perguntas.RemoveAt(0);
                }
                else
                {
                    if (NovoPasso.Nome == "Próxima")
                    {
                        Passo Final = new Passo { Id = Guid.NewGuid(), Nome = "Fim", Pergunta = "Acabou o treino, até amanhã." };
                        NovoPasso.ProximoPasso = Final;
                    }
                }
                this.Atual = NovoPasso.ProximoPasso;
            }
            else
            {
                List<string> perguntas = new List<string>();

                Atual.Pergunta = "Não entendi, " + Atual.Pergunta.Replace("Não entendi, ","");
                this.Atual = Atual;
            }
        }

    }

}