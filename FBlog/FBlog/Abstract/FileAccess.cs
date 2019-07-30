using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FBlog.Abstract
{
    public class FileAccess : IFileAccess
    {
        public List<string> SelectAllRecord(string path)
        {
            List<string> result = new List<string>();
            try
            {
                string line;
                using (StreamReader reader = File.OpenText(path))
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        result.Add(line);
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        public bool Add(string path, string entity)
        {
            try
            {
                using (StreamWriter writer = File.AppendText(path))
                {
                    writer.WriteLine(entity);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
