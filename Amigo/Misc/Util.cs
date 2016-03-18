﻿using AmigoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Amigo
{
    public static class Util
    {
       public static Repositorio Repositorio { get; set; }
       public static IEnumerable<KeyValuePair<int,string>> ObterListaSocios()
        {
            return Repositorio.ObterLista<Pessoa>(nomeTabela: "Socios")
                .Select((p => new KeyValuePair<int,string> (p.Id, p.Nome)));
        }
        public static KeyValuePair<bool, object> CheckLogin(string login, string password)
        {
            var repo = Repositorio;
            var user = repo.Obter<Usuario>(x => x.Login.Equals(login));
            if(user==null)
            {
                return new KeyValuePair<bool, object>(false, "Usuário não encontrado");
            }
            if(PasswordSecurity.PasswordStorage.VerifyPassword(password,user.PasswordHash))
            {
                return new KeyValuePair<bool, object>(true,user);
            }


            return new KeyValuePair<bool, object>(false, "Senha inválida");
        }
    }
   
}
