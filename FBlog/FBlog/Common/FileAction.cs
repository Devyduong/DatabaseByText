using System.IO;
namespace FBlog.Common
{
    public interface IFileAction
    {
        bool CreateFile(string path, string fileName);
        bool RemoveFile(string filePath);
        int GetTotalLinesInThisFile(string filePath);
        string GetFinalLine(string filePath);
        string GetLineAt(int position, string filePath);
    }
    public class FileAction : IFileAction
    {
        public bool CreateFile(string path, string fileName)
        {
            string filePath = path + fileName;
            if (FileValidation.IsExist(filePath))
            {
                return false;
            }
            FileStream fileStream = File.Create(filePath);
            return true;
        }

        public string GetFinalLine(string filePath)
        {
            string endLine = "";
            if(FileValidation.IsExist(filePath))
            {
                string line;
                using (StreamReader reader = File.OpenText(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        endLine = line;
                    }
                }
            }
            return endLine;
        }

        public string GetLineAt(int position, string filePath)
        {
            string returnline = "";
            if (FileValidation.IsExist(filePath))
            {
                string line;
                int index = 0;
                using (StreamReader reader = File.OpenText(filePath))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        index++;
                        if(index == position)
                        {
                            returnline = line;
                        }
                    }
                }
            }
            return returnline;
        }

        public int GetTotalLinesInThisFile(string filePath)
        {
            int totalLines = 0;
            if(FileValidation.IsExist(filePath))
            {
                string line;
                using (StreamReader reader = File.OpenText(filePath))
                {
                    while((line = reader.ReadLine()) != null)
                    {
                        totalLines++;
                    }
                }
            }
            return totalLines;
        }

        public bool RemoveFile(string filePath)
        {
            if (!FileValidation.IsExist(filePath))
            {
                return false;
            }
            File.Delete(filePath);
            return true;
        }
    }
}
