using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ToDoList.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<ToDoes> ToDoes { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new DatabaseCreater());
        }

    }






    public class DatabaseCreater: CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 3; i++)
            {
                ToDoes todo = new ToDoes();
                todo.Description = FakeData.TextData.GetSentence();
                todo.Date = FakeData.DateTimeData.GetDatetime();

                context.ToDoes.Add(todo); //INSERT
            }

            context.SaveChanges();

            List<ToDoes> allToDoes = context.ToDoes.ToList();
        }
    }
}