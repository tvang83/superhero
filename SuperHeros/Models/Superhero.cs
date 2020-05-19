using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeros.Models
{
    public class Superhero
    {
        //hero table properties 
        [Key]
        public string Name { get; set; }
        public string Alter_Ego { get; set; }
        public string Primary_Ability { get; set; }
        public string Secondary_Ability { get; set; }
        public string Catchphrase { get; set; }

    }
}
