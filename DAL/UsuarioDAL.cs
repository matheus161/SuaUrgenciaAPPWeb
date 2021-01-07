using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCSuaUrgenciaWEB.Models;

namespace TCCSuaUrgenciaWEB.DAL
{
    public class UsuarioDAL
    {
        ProjetoTCCHospitalEntities conexao = new ProjetoTCCHospitalEntities();

        public List<Usuario> lista()
        {
            return conexao.Usuario.ToList();
        }

    }
}