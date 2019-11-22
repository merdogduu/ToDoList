using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ToDoList.Models
{
    [Table ("ToDoList")]
    public class ToDoes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(300),Required]
        public string Description { get; set; }

        public bool isDone { get; set; }
        
        public DateTime Date { get; set; }
    }
}