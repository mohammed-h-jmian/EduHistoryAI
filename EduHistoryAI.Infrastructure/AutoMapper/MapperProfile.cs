using AutoMapper;
using EduHistoryAI.Core.Dtos;
using EduHistoryAI.Core.ViewModels;
using EduHistoryAI.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduHistoryAI.Infrastructure.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ApplicationUser, ApplicationUserViewModel>();



            CreateMap<ChatMessage, ChatMessageViewModel>();
            CreateMap<SendMessageDto, ChatMessage>();




            CreateMap<ChatSession, ChatSessionViewModel>();
            CreateMap<HistoricalFigure, HistoricalFigureViewModel>();
            CreateMap<CreateFigureDto, HistoricalFigure>();

            //CreateMap<HistoricalFigure, FigureViewModel>();




        }
    }

}
