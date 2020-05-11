using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace scholarSystem.Models
{
    public class Group
    {

        public int GroupId { get; set; }

        [Display(Name ="Grado y grupo")]
        [Required(ErrorMessage = "Este campo es requerido.")]
        public string GroupName { get; set; }
        public int GroupStudents { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
