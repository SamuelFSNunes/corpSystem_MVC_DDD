using AutoMapper;
using ProjectModelDDD.Application.Interface;
using ProjectModelDDD.Domain.Entities;
using ProjectModelDDD.Domain.Interfaces.Services;
using ProjectModelDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectModelDDD.MVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IClientAppService _clientAppService;
        private readonly IMapper _mapper;

        public ProductsController(IProductAppService productAppService, IClientAppService clientAppService, IMapper mapper)
        {
            _productAppService = productAppService;
            _clientAppService = clientAppService;
            _mapper = mapper;
        }

        // GET: Products
        public ActionResult Index()
        {
            var productViewModel = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(_productAppService.GetAll());
            return View(productViewModel);
        }

        // GET: Products/Details/5
        public ActionResult Details(int id)
        {
            var products = _productAppService.GetById(id);
            var productViewModel = _mapper.Map<Product,  ProductViewModel>(products);
            return View(productViewModel);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "FirstName");
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = _mapper.Map<ProductViewModel, Product>(product);
                _productAppService.Add(productDomain);
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "FirstName", product.ClientId);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            var product = _productAppService.GetById(id);
            var productViewModel = _mapper.Map<Product, ProductViewModel>(product);

            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "FirstName", productViewModel.ClientId);
            return View(product);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                var productDomain = _mapper.Map<ProductViewModel, Product>(product);
                _productAppService.Update(productDomain);
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(_clientAppService.GetAll(), "ClientId", "Name", product.ClientId);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _productAppService.GetById(id);
            var productViewModel = _mapper.Map<Product, ProductViewModel>(product);
            return View(productViewModel);
        }

        // POST: Products/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var product = _productAppService.GetById(id);
            _productAppService.Delete(product);
            return RedirectToAction("Index");
        }
    }
}
