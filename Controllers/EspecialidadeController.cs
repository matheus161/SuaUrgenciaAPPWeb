using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCSuaUrgenciaWEB.DAL;
using TCCSuaUrgenciaWEB.Models;

namespace TCCSuaUrgenciaWEB.Controllers
{
    public class EspecialidadeController : Controller
    {
        EspecialidadeDAL conexao = new EspecialidadeDAL();

        public ActionResult Index()
        {
            return View();
        }


        //onde mais indicado
        public Usuario GetUser()
        {

            return (Usuario)Session["usuarioLogado"];

        }



        public ActionResult Cadastrar()
        {
            Usuario user = GetUser();
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            

            ProjetoTCCHospitalEntities conexao = new ProjetoTCCHospitalEntities();

            HospitalEspecialidade espec = new HospitalEspecialidade();
            Hospital hospital = new Hospital();
            usuarioHospital user1 = new usuarioHospital();

           
            //ViewBag.listarEspecialidades = conexao.Especialidade.ToList();
            //ViewBag.listarHospitais = conexao.HospitalEspecialidade.ToList();

            var idH = conexao.usuarioHospital.Where(x => x.idUsuario == user.IdUsuario).Select(x=>x.idHospital).FirstOrDefault();

            ViewBag.especialidadesHospital = conexao.HospitalEspecialidade.Where(x => x.IdHospital == idH).ToList();


            return View();
        }



        public ActionResult Editar(string id)
        {
            int codigo = Convert.ToInt32(id);
            HospitalEspecialidade userEditando = conexao.lista().Where(x => x.IdEspecialidade == codigo).FirstOrDefault();

            

            return View(userEditando);
        }


        //[HttpPost]
        //public ActionResult Editar(int id, string horaInicio)
        //{
        //    ProjetoTCCHospitalEntities conexao = new ProjetoTCCHospitalEntities();
        //    var idEH = conexao.HospitalEspecialidade.Where(x => x.id == id );

        //    HospitalEspecialidade hp = new HospitalEspecialidade();

        //    hp.id = Convert.ToInt32(idEH);
        //    hp.HoraInicio = horaInicio;
           
            
        //}

        
                
        
    }
}