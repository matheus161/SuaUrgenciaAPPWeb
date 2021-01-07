using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCCSuaUrgenciaWEB.DAL;
using TCCSuaUrgenciaWEB.Models;

namespace TCCSuaUrgenciaWEB.Controllers
{
    public class HomeController : Controller
    {
                                  
        
        ProjetoTCCHospitalEntities conexao = new ProjetoTCCHospitalEntities();
        UsuarioDAL dal = new UsuarioDAL();
        
        public ActionResult Index()
        {
            Usuario user = (Usuario)Session["usuarioLogado"];
            if (user == null)
            {
                return RedirectToAction("Login", "Home");
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Login(string login, string senha)
        {
           
            Usuario usuario = conexao.Usuario.ToList().FirstOrDefault(x => x.Login == login && x.Senha == senha );
    

            if (usuario != null)
            {
                Session.Add("usuarioLogado", usuario);
                
                return RedirectToAction("Cadastrar", "Especialidade");
                
            }
            else
            {
                ViewBag.SenhaErrada = "Dados Iválidos";
                return RedirectToAction("Login", "Home");
            }

           

        }
    }
}