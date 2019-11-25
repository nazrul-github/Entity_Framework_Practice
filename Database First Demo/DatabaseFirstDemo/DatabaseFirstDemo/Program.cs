using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new MyDatabaseContext();
            tbl_PostRecord postRecord = new tbl_PostRecord
            {
                Body = "Body",
                DatePublished = DateTime.Now,
                Title = "Title",
              
            };
            context.tbl_PostRecord.Add(postRecord);
            context.SaveChanges();
        }
    }
}
