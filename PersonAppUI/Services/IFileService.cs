using PersonAppUI.Models;

namespace PersonAppUI.Services;
public interface IFileService
{
    List<FileClass> GetAllPDFs();
}