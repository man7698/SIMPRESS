using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PROVASIMPRESS.Controllers
{
    public class ProdutosController : Controller
    {

        Dados.Dados d;


        // GET: Produtos
        public ActionResult consulta()
        {
            d = new Dados.Dados();

            d.Consulta();

            ModelState.Clear();

            return View(d.Consulta());

        }



        [HttpGet]
        public ActionResult incluir()
        {
            

            return View();
        }


        [HttpPost]
        public ActionResult incluir(Models.Produto t)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    d = new Dados.Dados();

                    if (d.Adicionartransacao(t))
                    {
                        //ViewBag.Mensagem = "Transacao Realizada !!";
                        return View("consulta");
                    }



                }
                return View();
            }
            catch (Exception)
            {
                return View("consulta");
            }

        }



        [HttpGet]
        public ActionResult editar(int id)
        {
            d = new Dados.Dados();

            d.Consulta();

            ModelState.Clear();

            return View(d.Consulta());



        }




        public ActionResult excluir(int id)
        {
            try
            {
                d = new Dados.Dados();
                if (d.Deletartransacao(id))
                {
                    //ViewBag.Mensagem = "Dados Excluidos";
                }

                return RedirectToAction("consulta");

            }
            catch (Exception)
            {
                return View("consulta");
            }



        }











    }
}