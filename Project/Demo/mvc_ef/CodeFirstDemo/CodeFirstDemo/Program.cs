using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new NewContext())
            {
                Console.Write("输入新闻类型标题: ");
                var name = Console.ReadLine();

                var type_Model = new NewType { Name = name };
                db.NewTypes.Add(type_Model);
                db.SaveChanges();

                Console.WriteLine("查询新闻类型标题:");
                var search_type = Console.ReadLine();
                var query = from b in db.NewTypes
                            where b.Name == search_type
                            select b;

                Console.WriteLine("查询结果:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.Name);
                }

                Console.ReadKey();
            } 
        }
    }

    public class New
    {
        public int NewId { get; set; }
        public string Title { get; set; }

        public int NewTypeId { get; set; }
        public virtual NewType NewType { get; set; }
    }

    public class NewType
    {
        public int NewTypeId { get; set; }
        //[MaxLength(50), System.ComponentModel.DataAnnotations.Schema.Column("Name")]//Names列名修改为Name，数据不变
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual List<New> New { get; set; }
    }

    public class NewContext : DbContext
    {
        public DbSet<New> News { get; set; }
        public DbSet<NewType> NewTypes { get; set; }
    }
}
