using Doorang.Bussiness.Exceptions;
using Doorang.Bussiness.Service.Abstracts;
using Doorang.Core.Models;
using Doorang.Core.RepositoryAbstracts;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doorang.Bussiness.Service.Concretes
{
    public class ExplorerService : IExplorerService
    {
        private readonly IExplorerRepository _explorerRepsitory;
        private readonly IWebHostEnvironment _webHostEnvironment;


        public ExplorerService(IExplorerRepository explorerRepsitory,IWebHostEnvironment webHostEnvironment)
        {
            _explorerRepsitory = explorerRepsitory;
            _webHostEnvironment= webHostEnvironment;
        }

        public void AddExplorer(Explorer explorer)
        {
            if(explorer.ImgFile==null || explorer.ImgFile.Length == 0)
            {
                throw new ArgumentNullException("ImgFile", "File tapilmadi");
            }
            if (!explorer.ImgFile.ContentType.Contains("image/"))
            {
                throw new FileContentException("ImgFile", "Content type error");
            }
            if (explorer.ImgFile.Length > 2097125)
            {
                throw new FileSizeException("ImgFile", "Olcu boyukdur");
            }
            string fileName = Guid.NewGuid().ToString() + Path.GetExtension(explorer.ImgFile.FileName);
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "Upload", "Service", fileName);

            using (FileStream stream=new FileStream(path, FileMode.Create))
            {
                explorer.ImgFile.CopyTo(stream);
            }
            explorer.ImgUrl = fileName;
            _explorerRepsitory.Add(explorer);
            _explorerRepsitory.Commit();

        }

        public List<Explorer> GetAllExplorer(Func<Explorer, bool>? func = null)
        {
            return _explorerRepsitory.GetAll(func);
        }

        public Explorer GetExplorer(Func<Explorer, bool>? func = null)
        {
            return _explorerRepsitory.Get(func);
        }

        public void RemoveExplorer(int id)
        {
           var explorer=_explorerRepsitory.Get(x=> x.Id == id);
            if(explorer==null)
            {
                throw new Exception();
            }
            string path = _webHostEnvironment.WebRootPath + @"\Upload\Service\" + explorer.ImgUrl;
            if (!File.Exists(path))
            {
                throw new FileNameNotFoundException("ImgUrl", "file not found");
            }
            File.Delete(path);
            _explorerRepsitory.Remove(explorer);
            _explorerRepsitory.Commit();
        }

        public void Update(int id, Explorer explorer)
        {
          var oldExplorer=_explorerRepsitory.Get(x=> x.Id == id);
            if (oldExplorer == null) throw new NullReferenceException();
            if(explorer.ImgFile != null)
            {
                string fileName = explorer.ImgFile.FileName;
                string path = _webHostEnvironment.WebRootPath + @"\Upload\Service\" + explorer.ImgFile.FileName;
                using (FileStream stream=new FileStream(path, FileMode.Create))
                {
                    explorer.ImgFile.CopyTo(stream);
                }
                FileInfo fileInfo = new FileInfo(path+oldExplorer.ImgUrl);
                if(fileInfo.Exists)
                {
                    fileInfo.Delete();
                }
                oldExplorer.ImgUrl = fileName;
            }
            oldExplorer.Title = explorer.Title;
            oldExplorer.Description=explorer.Description;
            _explorerRepsitory.Commit();
        }
    }
}
