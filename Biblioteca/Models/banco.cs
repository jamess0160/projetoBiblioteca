using MySqlConnector;
using System.Collections.Generic;
using System;

namespace Biblioteca.Models
{
    public class banco
    {
        private const string address = "Database=biblioteca;Host=localhost;Username=root";
        private static MySqlConnection conexao = new MySqlConnection(address);
        private static List<usuario> usuarios;

        static public List<usuario> selectUsuarios()
        {
            if (conexao.State.ToString() == "Open")
            {
                conexao.Close();
            }
            conexao.Open();
            string select = "SELECT * FROM usuarios";
            MySqlCommand comando = new MySqlCommand(select, conexao);
            MySqlDataReader resposta = comando.ExecuteReader();
            usuarios = new List<usuario>();
            while (resposta.Read())
            {
                string[] resultado = new string[3];
                resultado[0] = resposta.GetInt32("id").ToString();
                resultado[1] = resposta.GetString("nome");
                resultado[2] = resposta.GetString("senha");
                usuario novo = new usuario(int.Parse(resultado[0]), resultado[1], resultado[2]);
                usuarios.Add(novo);
            }
            resposta.Close();
            conexao.Close();
            return usuarios;
        }

        static public void updateUsuario(int id, usuario info){
            if (conexao.State.ToString() == "Open")
            {
                conexao.Close();
            }
            conexao.Open();
            string update = $"UPDATE usuarios SET nome = '{info.nome}', senha = MD5('{info.senha}') WHERE id = {id}";
            MySqlCommand comando = new MySqlCommand(update, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        static public void deleteUsuario(int id){
            if (conexao.State.ToString() == "Open")
            {
                conexao.Close();
            }
            conexao.Open();
            string update = $"DELETE FROM usuarios WHERE id = {id}";
            MySqlCommand comando = new MySqlCommand(update, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }

        static public string checkLogin(string nome, string senha){
            if (conexao.State.ToString() == "Open")
            {
                conexao.Close();
            }
            conexao.Open();
            var validacao = "";
            string select = $"SELECT * FROM usuarios WHERE nome = '{nome}' AND senha = MD5('{senha}')";
            MySqlCommand comando = new MySqlCommand(select, conexao);
            MySqlDataReader resposta = comando.ExecuteReader();
            if(!resposta.Read()){
                validacao = "incorreto";
            }else{
                validacao = "correto";
            }
            resposta.Close();
            conexao.Close();
            return validacao;
        }

        static public void novoUsuario(string nome, string senha){
            if (conexao.State.ToString() == "Open")
            {
                conexao.Close();
            }
            conexao.Open();
            string insert = $"INSERT INTO usuarios(nome, senha) VALUES('{nome}', MD5('{senha}'))";
            MySqlCommand comando = new MySqlCommand(insert, conexao);
            comando.ExecuteNonQuery();
            conexao.Close();
        }
    }
}