using EduHistoryAI.Core.Dtos;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.HistoricalFigureServices
{
    public interface IHistoricalFigureService
    {
        Task<IEnumerable<HistoricalFigureViewModel>> GetAll();
        Task<HistoricalFigureViewModel> GetById(int id);
        Task<bool> Create(CreateFigureDto dto);
        Task<bool> Edit(int id, CreateFigureDto dto);
        Task<bool> Delete(int id);
    }
}
