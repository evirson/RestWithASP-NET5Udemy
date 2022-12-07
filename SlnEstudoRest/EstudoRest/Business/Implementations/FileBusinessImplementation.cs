using EstudoRest.Data.VO;

namespace EstudoRest.Business.Implementations
{
    public class FileBusinessImplementation : IFileBusiness
    {
        private readonly string _basePath;
        private readonly IHttpContextAccessor _context;

        public FileBusinessImplementation(IHttpContextAccessor context)
        {
            _context = context;
            _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
        }

        public byte[] GetFile(string filename)
        {
            var filePath = _basePath + filename;

            return File.ReadAllBytes(filePath);
        }

        public async Task<List<FileDetailsVO>> SaveFilesToDisk(IList<IFormFile> files)
        {
            List<FileDetailsVO> list = new List<FileDetailsVO>();

            foreach (var file in files)
            {
                list.Add(await SaveFileToDisk(file));

            }

            return list;
        }

        public async Task<FileDetailsVO> SaveFileToDisk(IFormFile file)
        {
            FileDetailsVO fileDetail = new FileDetailsVO();

            var fileType = Path.GetExtension(file.FileName);

            var baseUrl = _context.HttpContext.Request.Host;

            if (fileType.ToLower() == "pdf" || fileType.ToLower() == "jpg" ||
                fileType.ToLower() == "png" || fileType.ToLower() == "jpeg") ;

            var docName = Path.GetFileName(file.FileName);

            if (file != null && file.Length > 0)
            {
                var destination = Path.Combine(_basePath, "", docName);
                fileDetail.DocumentName = docName;
                fileDetail.DocType = fileType;
                fileDetail.DocUrl = Path.Combine(baseUrl + "/api/file/v1/" + fileDetail.DocumentName);

                using var strem = new FileStream(destination, FileMode.Create);

                await file.CopyToAsync(strem);  
            }

            return fileDetail;        
        }
    }
}
