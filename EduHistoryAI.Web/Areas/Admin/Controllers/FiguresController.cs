using EduHistoryAI.Core.Dtos;
using EduHistoryAI.Infrastructure.Services.AuthServices;
using EduHistoryAI.Infrastructure.Services.HistoricalFigureServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Areas.Admin.Controllers
{
    public class FiguresController : BaseController
    {
        private readonly IHistoricalFigureService _figureService;


        public FiguresController(IAuthService auth, IHistoricalFigureService figureService) : base(auth)
        {
            _figureService = figureService;
        }
        public async Task<IActionResult> Index()
        {
            var figures = await _figureService.GetAll();
            return View(figures);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateFigureDto dto)
        {

            dto.CreatedById = userId;
            if (!ModelState.IsValid)
            {
                return View(dto);
            }

             
            bool result = await _figureService.Create(dto);
            if (result)
            {
                TempData["SuccessMessage"] = "Historical figure added successfully!";
                return RedirectToAction("Index");
            }

            TempData["ErrorMessage"] = "Failed to add historical figure.";
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var figure = await _figureService.GetById(id);
            if (figure == null)
                return NotFound();

            var dto = new CreateFigureDto
            {
                Name = figure.Name,
                Description = figure.Description,
                ImageUrl = figure.ImageUrl
            };

            return View(dto);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CreateFigureDto dto)
        {

            //if (!ModelState.IsValid)
            //    return View(dto);

            var result = await _figureService.Edit(id, dto);

            if (result)
            {
                TempData["SuccessMessage"] = "Figure updated successfully!";
                return RedirectToAction(nameof(Index));
            }

            TempData["ErrorMessage"] = "Failed to update the figure.";
            return View(dto);
        }


        public async Task<IActionResult> Delete(int id)
        {
            var result = await _figureService.Delete(id);

            if (result)
            {
                TempData["SuccessMessage"] = "The figure has been deleted successfully!";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to delete the figure. It might not exist.";
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
