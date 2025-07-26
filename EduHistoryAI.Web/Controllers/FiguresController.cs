using EduHistoryAI.Infrastructure.Services.AuthServices;
using EduHistoryAI.Infrastructure.Services.HistoricalFigureServices;
using Microsoft.AspNetCore.Mvc;

namespace EduHistoryAI.Web.Controllers
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

        public async Task<IActionResult> Details(int id)
        {
            var figure = await _figureService.GetById(id);
            if (figure == null)
            {
                return Redirect("/Base/NotFound");
            }

            return View(figure);
        }

    }
}
