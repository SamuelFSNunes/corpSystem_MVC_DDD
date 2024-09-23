using AutoMapper;
using ProjectModelDDD.Application.Interface;
using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.MVC.ViewModels;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ProjectModelDDD.MVC.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientAppService _clientAppService;
        private readonly IMapper _mapper;

        public ClientsController(IClientAppService clientAppService, IMapper mapper)
        {
            _clientAppService = clientAppService;
            _mapper = mapper;
        }

        // GET: Clients
        public ActionResult Index()
        {
            var clientViewModel = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientAppService.GetAll());
            return View(clientViewModel);
        }

        // GET: Special Clients
        public ActionResult Specials()
        {
            var clientViewModel = _mapper.Map<IEnumerable<Client>, IEnumerable<ClientViewModel>>(_clientAppService.GetSpecialClients());
            return View(clientViewModel);
        }

        // GET: Clients/Details/5
        public ActionResult Details(int id)
        {
            var client = _clientAppService.GetById(id);
            var clientViewModel = _mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ClientViewModel, Client>(client);
                _clientAppService.Add(clientDomain);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(int id)
        {
            var client = _clientAppService.GetById(id);
            var clientViewModel = _mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Clients/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClientViewModel client)
        {
            if (ModelState.IsValid)
            {
                var clientDomain = _mapper.Map<ClientViewModel, Client>(client);
                _clientAppService.Add(clientDomain);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(int id)
        {
            var client = _clientAppService.GetById(id);
            var clientViewModel = _mapper.Map<Client, ClientViewModel>(client);
            return View(clientViewModel);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var client = _clientAppService.GetById(id);
            _clientAppService.Delete(client);
            return RedirectToAction("Index");
        }
    }
}
