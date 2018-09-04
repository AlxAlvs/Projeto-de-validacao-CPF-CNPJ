using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using validaCpfCnpj.Models;

namespace validaCpfCnpj.Repositorio
{
    public class EntidadeContexto
    {
        private static List<Entidade> _entidades = new List<Entidade>();

        public static void Add(Entidade entidade)
        {
            var codigo = 0;
            if (_entidades != null && _entidades.Any())
                codigo = _entidades.LastOrDefault().Id;

            entidade.Id = ++codigo;
            _entidades.Add(entidade);
        }

        public static List<Entidade> ConsultarTodos()
        {
            return _entidades;
        }
    }
}