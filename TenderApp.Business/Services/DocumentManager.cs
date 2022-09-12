
using Microsoft.AspNetCore.Http;
using NUglify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.Core.Utilities.Result;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;
using static System.Net.Mime.MediaTypeNames;
using static TenderApp.Core.Utilities.Result.ResultStatus;

namespace TenderApp.Business.Services
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;
        private DocumentType documentType;
        public DocumentManager(IDocumentDal documentDal)
        {
            _documentDal = documentDal;
        }
        public async Task<Result> Add(IFormFile file, Document document)
        {
            string sourcePath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcePath, FileMode.Create)) { file.CopyTo(stream); }
            }
            string destFileName = CreateNewFilePath(file);
            File.Move(sourcePath, destFileName);
            document.Url = destFileName;
            document.FileName = destFileName.Split('\\').Last();
            document.IsActive = true;
            document.CreateDate = DateTime.Now;
            document.DocumentType = this.documentType;
            await _documentDal.Add(document);
            return new Result(Status.Success, "Added is successful");
        }
        public async Task<Result> Delete(Document document)
        {
            try
            {
                File.Delete(document.Url);
                await _documentDal.Delete(document);
                return new Result(Status.Success, "Document  deleted");
            }
            catch (Exception e)
            {
                return new Result(Status.Success, "Could not deleted", e);
            }
        }
        public async Task<DataResult<List<Document>>> GetListByCarId(Guid id)
        {
            var document = await _documentDal.GetAll(d => d.CarId == id);
            if (!document.Any())
                return new DataResult<List<Document>>(Status.Error, document, "Document not found");
            return new DataResult<List<Document>>(Status.Success, document, "Document found");
        }
        public async Task<DataResult<Document>> GetById(Guid id)
        {
            var data = await _documentDal.Get(d => d.Id == id);
            if (data is null)
                return new DataResult<Document>(Status.Error, data, "Document not found");
            return new DataResult<Document>(Status.Success, data, "Document found");
        }
        private string CreateNewFilePath(IFormFile file)
        {
            string path = "";
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtensions = fileInfo.Extension;
            string newPath = Guid.NewGuid().ToString() + fileExtensions;
            var extensionType = newPath.Split('.').Last();
            if (extensionType == "pdf")
            {
                path = "C:\\Users\\Berkay\\source\\repos\\TenderApp\\WebClient\\wwwroot\\documents";
                documentType = DocumentType.DocumentPdf;
            }
            else if (extensionType == "jpg" || extensionType == "png")
            {
                path = "C:\\Users\\Berkay\\source\\repos\\TenderApp\\WebClient\\wwwroot\\images";
                documentType = DocumentType.DocumentImage;
            }
            else
            {
                throw new Exception("Extension is invalid !! (png,jpg,word,pdf)");
            }
            string result = $@"{path}\{newPath}";
            return result;
        }
        public async Task<Result> Update(Guid id, bool isActive)
        {
            var document = await _documentDal.Get(d => d.Id == id);
            if (document is null)
                return new Result(Status.Error, "Document not Found");
            document.IsActive = isActive;
            await _documentDal.Update(document);
            return new Result(Status.Error, "Document  Uptaded");
        }
    }
}
