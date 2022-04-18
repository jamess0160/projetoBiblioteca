using System;

namespace Biblioteca.Models
{
    public class usuario
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }

        public usuario(){}

        public usuario(int id, string nome, string senha){
            this.id = id;
            this.nome = nome;
            this.senha = senha;
        }
    }
}