using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

 namespace Domain
{
    public class MyAction
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Adresse { get; set; }
    }
}
