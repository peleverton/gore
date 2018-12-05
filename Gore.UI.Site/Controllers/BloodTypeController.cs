using Gore.Application.Interfaces;
using Gore.Application.ViewModels;
using Gore.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Gore.UI.Site.Controllers
{
    public class BloodTypeController : BaseController
    {
        private readonly IBloodTypeAppService _bloodTypeAppService;

        public BloodTypeController(IBloodTypeAppService bloodTypeAppService,
            INotificationHandler<DomainNotification> notifications) : base(notifications)
        {
            _bloodTypeAppService = bloodTypeAppService;
        }


        [HttpGet]
        [Route("Bloodtype/ListAll")]
        public IActionResult Index()
        {
            return View(_bloodTypeAppService.GetAll());
        }

        // GET: BloodType/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BloodType/Create
        [HttpPost]
        public IActionResult Create(BloodTypeViewModel bloodTypeViewModel)
        {
            if (!ModelState.IsValid) return View(bloodTypeViewModel);
            _bloodTypeAppService.Register(bloodTypeViewModel);

            if (IsValidOperation())
                ViewData["Sucesso"] = "Tipo sanguineo, cadastrado!";

            return View(bloodTypeViewModel);
        }

        [HttpGet]
        [Route("BloodType/edit")]
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var bloodTypeViewModel = _bloodTypeAppService.GetById(id.Value);

            if (id == null)
                return NotFound();

            return View(bloodTypeViewModel);
        }

        [HttpPost]
        [Route("BloodType/edit")]
        public IActionResult Edit(BloodTypeViewModel bloodTypeViewModel)
        {
            if (!ModelState.IsValid) return View(bloodTypeViewModel);

            _bloodTypeAppService.Update(bloodTypeViewModel);

            if (IsValidOperation())
                ViewBag.Sucesso = "Registro Atualizado!";

            return View(bloodTypeViewModel);
        }

        [HttpGet]
        [Route("BloodType/remove")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var bloodTypeViewModel = _bloodTypeAppService.GetById(id.Value);

            if (id == null)
                return NotFound();

            return View(bloodTypeViewModel);
        }

        [HttpPost, ActionName("Delete")]
        [Route("BloodType/remove")]
        public IActionResult DeleteConfirmed(int id)
        {
            _bloodTypeAppService.Remove(id);

            if (!IsValidOperation()) return View(_bloodTypeAppService.GetById(id));

            ViewBag.Sucesso = "Registro Removido!";
            return RedirectToAction("Index");
        }
    }
}