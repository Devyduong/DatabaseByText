using System.IO;

namespace FBlog.Common
{
    public interface IFileValidation
    {
        bool IsExist(string filePath);
        bool IsNull(string filePath);
    }
    public class FileValidation
    {
        public static bool IsExist(string filePath)
        {
            if (File.Exists(filePath))
            {
                return true;
            }
            return false;
        }

        public static bool IsNull(string filePath)
        {
            FileInfo file = new FileInfo(filePath);
            if (file.Length == 0)
            {
                return true;
            }
            return false;
        }
    }
}
