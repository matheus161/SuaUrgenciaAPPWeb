using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCCSuaUrgenciaWEB.Models;

namespace TCCSuaUrgenciaWEB.DAL
{
    
    public class EspecialidadeDAL
    {
        ProjetoTCCHospitalEntities conexao = new ProjetoTCCHospitalEntities();

        public List<HospitalEspecialidade> lista()
        {
            return conexao.HospitalEspecialidade.ToList();
        }

        public void cadastrar(HospitalEspecialidade especialidade)
        {
            conexao.HospitalEspecialidade.Add(especialidade);
            conexao.SaveChanges();
        }

       
    }
}