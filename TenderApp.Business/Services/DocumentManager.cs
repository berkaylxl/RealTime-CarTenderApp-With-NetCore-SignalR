
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TenderApp.Business.Services.Abstract;
using TenderApp.DataAccess.Abstract;
using TenderApp.Entities;

namespace TenderApp.Business.Services
{
    public class DocumentManager : IDocumentService
    {
        private readonly IDocumentDal _documentDal;

        public DocumentManager(IDocumentDal documentDal)
        {
            _documentDal = documentDal;
        }












        public Task Add(IFormFile file, Document document)
        {
            string sourcePath = Path.GetTempFileName();
            if (file.Length>0)
            {
                using (var stream=new FileStream(sourcePath,FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            string destFileNAm =CreateNewFilePath
        }

        public Task Delete(IFormFile file, Document document)
        {
            throw new NotImplementedException();
        }

        public List<Document> GetListByCarId(Guid id)
        {
            throw new NotImplementedException();
        }



        private static string CreateNewFilePath(IFormFile file)
        {
            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtensions = fileInfo.Extension;

            string path = Environment.CurrentDirectory + @"\wwwroot\document";
            
        
        
        }







    }
}
