using AutoMapper;
using EduHistoryAI.Core.Constants;
using EduHistoryAI.Core.Dtos;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data;
using EduHistoryAI.Data.Models;
using EduHistoryAI.Infrastructure.Services.FileServices;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EduHistoryAI.Infrastructure.Services.HistoricalFigureServices
{
    public class HistoricalFigureService : IHistoricalFigureService
    {
        private readonly EduHistoryAIDbContext _context;
        private readonly IMapper _mapper;
        private readonly IFileService _file;

        public HistoricalFigureService(EduHistoryAIDbContext context, IFileService file, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _file = file;

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


        public async Task<bool> Create(CreateFigureDto dto)
        {
            try
            {
                var figure = _mapper.Map<HistoricalFigure>(dto);

                if (dto.ImageFile != null)
                {
                    figure.ImageUrl = await _file.SaveFile(dto.ImageFile, "Figures");
                    figure.ImageUrl =  Paths.FigurePath + figure.ImageUrl ;
                }

                _context.HistoricalFigures.Add(figure);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Edit(int id, CreateFigureDto dto)
        {
            try
            {
                var figure = await _context.HistoricalFigures.FirstOrDefaultAsync(f => f.Id == id);
                if (figure == null)
                    return false;

                figure.Name = dto.Name;
                figure.Description = dto.Description;

                if (dto.ImageFile != null)
                {
                    figure.ImageUrl = await _file.SaveFile(dto.ImageFile, "Figures");
                    figure.ImageUrl = Paths.FigurePath + figure.ImageUrl;
                }

                _context.HistoricalFigures.Update(figure);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var figure = await _context.HistoricalFigures.FirstOrDefaultAsync(f => f.Id == id);
            if (figure == null)
                return false;

            _context.HistoricalFigures.Remove(figure);
            await _context.SaveChangesAsync();
            return true;
        }



    }
}
