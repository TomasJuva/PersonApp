using PersonAppUI.Models;

namespace PersonAppUI.Services;

public class FileService : IFileService
{
    private readonly IWebHostEnvironment hostingEnvironment;

    public FileService(Microsoft.AspNetCore.Hosting.IWebHostEnvironment hostingEnvironment)
    {
        this.hostingEnvironment = hostingEnvironment;
    }

    /// <summary>
    /// Get all pdf files from files directory.
    /// </summary>
    /// <returns></returns>
    public List<FileClass> GetAllPDFs()
    {
        List<FileClass> files = new();
        string path = $"{hostingEnvironment.WebRootPath}\\files\\";
        int fileId = 1;

        foreach (string pdfPath in Directory.EnumerateFiles(path, "*.pdf"))
        {
            files.Add(new FileClass()
            {
                FileId = fileId++,
                Name = Path.GetFileName(pdfPath),
                Path = pdfPath
            });
        }
        return files;
    }

}
