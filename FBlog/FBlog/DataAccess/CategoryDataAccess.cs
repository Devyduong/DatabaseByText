using FBlog.Abstract;
using FBlog.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FBlog.DataAccess
{
    public interface ICategoryDataAccess : IFileAccess
    {
        List<string> SelectAllCategory();
        void AddCategory(string entity);

    }
    public class CategoryDataAccess : FileAccess, ICategoryDataAccess
    {
        string database_path = CommonDefine.DATABASE_BASE_PATH + @"\Category";
        public void AddCategory(string entity)
        {
            string filePath = database_path + @"\category1.json";

            Add(filePath, entity);
        }

        public List<string> SelectAllCategory()
        {
            string filePath = database_path + @"\category1.json";
            List<string> allCategory = new List<string>();

            allCategory = SelectAllRecord(filePath);
            return allCategory;
        }
    }
}
