using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Core.Utilities.Result;
using TenderApp.Entities;

namespace TenderApp.Business.Services.Abstract
{
    public interface IDocumentService
    {
        Task<Result> Add(IFormFile file, Document document);
        Task<Result> Delete(Document document);
        Task<DataResult<List<Document>>> GetListByCarId(Guid id);
        Task<DataResult<Document>> GetById(Guid id);
        Task<Result>Update(Guid id, bool isActive);



    }
}
