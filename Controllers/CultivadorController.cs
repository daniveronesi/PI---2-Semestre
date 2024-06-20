using Microsoft.AspNetCore.Http;
using InnovaAgroTech.Models;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;

namespace InnovaAgroTech.Controllers
{
    public class CultivadorController : Controller
    {
        private readonly Repositories.ADO.SQLServer.CultivadorDAO repository;
        private readonly Services.ISessao sessao;

        // objeto configuration => parte do framework que permite ler o
        //                         arquivo appsettings.json - GetConnectionString => método
        //                         do framework que permite ler a chave ConnectionStrings deste arquivo.
        public CultivadorController(IConfiguration configuration, Services.ISessao sessao)
        {
            this.repository = new Repositories.ADO.SQLServer.CultivadorDAO(configuration.GetConnectionString(Configurations.Appsettings.getKeyConnectionString()));
            this.sessao = sessao;
            // Configurations.Appsettings.getKeyConnectionString() => nossa classe de configuração
            //    para trazer a chave que deve ser lida, neste caso: DefaultConnection.
        }


        // GET => getAll() : CultivadorController
        [HttpGet]
        public IActionResult ListaCultivador()
        {
            return View(this.repository.getAllCultivadores());
        }

        // GET => getByIdCultivador(id): CultivadorsController/Details/5 (id)
        [HttpGet]
        public IActionResult Details(int id)
        {
            return View(this.repository.getByIdCultivador(id));
        }

        // GET => getByIdCultivador(id): CultivadorsController/Edit/5 (id)
        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View(this.repository.getByIdCultivador(id));
        }

        // POST : CultivadorsController/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cultivador cultivador)
        {
            /* Variável login utilizada para controle e gerenciamento do acesso da Sessão. */
            var login = this.sessao.getTokenLogin();
            if (login != null) // Se não estiver nulo, está logado com um usuário.
            {
                try
                {
                    this.repository.update(id, cultivador);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            } // encerra o login do usuário.
            return View();
        }

        // GET : CultivadorsController/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST : CultivadorsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cultivador Cultivador)
        {
            try
            {
                this.repository.add(Cultivador);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET : CultivadorsController/Delete/5
        [HttpGet]
        public IActionResult Delete(int id)
        {
            this.repository.delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
