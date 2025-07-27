using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace EduHistoryAI.Core.Dtos
{
    public class CreateFigureDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public IFormFile? ImageFile { get; set; }
        public string ImageUrl { get; set; }
        public String? CreatedById { get; set; }
    }
}
