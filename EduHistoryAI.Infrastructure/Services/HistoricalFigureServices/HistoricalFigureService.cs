using AutoMapper;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data;
using EduHistoryAI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.Services.HistoricalFigureServices
{
    public class HistoricalFigureService : IHistoricalFigureService
    {
        private readonly EduHistoryAIDbContext _context;
        private readonly IMapper _mapper;

        public HistoricalFigureService(EduHistoryAIDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<HistoricalFigureViewModel>> GetAll()
        {
            var figures = await _context.HistoricalFigures.AsNoTracking().ToListAsync();
            
                var result =_mapper.Map<IEnumerable<HistoricalFigureViewModel>>(figures);
            return result;

        }


        public async Task<HistoricalFigureViewModel?> GetById(int id)
        {
            var figure = await _context.HistoricalFigures
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.Id == id);

            return figure == null ? null : _mapper.Map<HistoricalFigureViewModel>(figure);
        }
    }
}
