using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting_v1._0
{
    public class Manager
    {
        List<Category> categories = new List<Category>();
        public string object_of_diagnostic_name;
        public string folderName;
        
        public string FindingPath;
        public string finding;
        public string diagnostic_number;
        public string mainPath;

        public bool RedactorOpened = false;
        public bool JournalOpened = false;

        public void ReadMainPath() 
        {
            
        }

        public void ReadCategories(StreamReader sr) 
        {
            categories.Clear();
            while (!sr.EndOfStream) 
            {
  
                Category category = new Category(sr.ReadLine());

                categories.Add(category);
            }
           
        }

        public List<Category> TypesReader(StreamReader sr,List<Category> types) 
        {
            types.Clear();
            while (!sr.EndOfStream) 
            {
                Category currenetType = new Category(sr.ReadLine());
                types.Add(currenetType);
            }

            return types;
        }

        public List<Category> GetCategories() { return categories; }





    }
}
