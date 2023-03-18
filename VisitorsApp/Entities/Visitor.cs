using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VisitorsApp.Entities
{
    public class Visitor
    {
        public int Id { get; set; }

       [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "The field {0} is required.")]
        [DisplayName("Nombre")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "The field {0} is required.")]
        [DisplayName("Apellido")]
        public string LastName { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayName("Fecha de visita")]
        public DateTime DateOfVisit { get; set; } = DateTime.Now;
    }
}
