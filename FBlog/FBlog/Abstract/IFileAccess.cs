using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBlog.Abstract
{
    public interface IFileAccess
    {
        List<string> SelectAllRecord(string path);
        bool Add(string path, string entity);
    }
}
