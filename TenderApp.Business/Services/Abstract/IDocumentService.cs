using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface IDocumentService
    {
        Task Add(IFormFile file, Document document);
        Task Delete(IFormFile file, Document document);
        List<Document> GetListByCarId(Guid id);
        

    }
}
