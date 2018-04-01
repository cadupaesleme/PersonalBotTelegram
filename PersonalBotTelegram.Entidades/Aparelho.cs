using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBotTelegram.Entidades
{
    public class Aparelho
    {
        public Aparelho(Guid id, string nome, string imagem)
        {
            Id = id;
            Nome = nome;
            Imagem = imagem;
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Imagem { get; set; }

       
    }

    public class Aparelhos
    {
        public List<Aparelho> lista_Aparelhos=new List<Aparelho>();

        public Aparelhos()
        {
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(),"Bicicleta Ergométrica","bike.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Banco de Supino", "1.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Banco Lombar", "2.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Extensora Sentada", "3.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Máquina Glúteo Deitado", "4.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Bicicleta Ergometrica Horizontal", "5.jpg"));
            lista_Aparelhos.Add(new Aparelho(Guid.NewGuid(), "Esteira", "6.jpg"));

        }
    }
}
