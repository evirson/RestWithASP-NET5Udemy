using EstudoRest.Data.VO;

namespace EstudoRest.Business
{
    public interface IFileBusiness
    {
        public byte[] GetFile(string filename);

        public Task<FileDetailsVO> SaveFileToDisk(IFormFile file);

        public Task<List<FileDetailsVO>> SaveFilesToDisk(IList<IFormFile> file);




    }
}
