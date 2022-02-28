using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ComdataDevlll.Models
{
    public class Collaborator
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Identificacion")]
        public string Identification { get; set; }
        [Required]
        [DisplayName("Nombres")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Direccion")]
        public string Addres { get; set; }
        [Required]
        [DisplayName("Email")]
        [EmailAddress(ErrorMessage = "Correo electronico invalido")]
        public string Email { get; set; }
        [Required, DisplayName("Teléfono")]
        public string Phone { get; set; }
        [Required, DisplayName("Salario")]
        public string Salary { get; set; }
        [Required]
        [DisplayName("Área")]
        public string Area { get; set; }
        [Required]
        [DisplayName("Fecha Ingreso")]
        [DataType(DataType.Date)]
        public DateTime entryDate { get; set; }
        [Required]
        [DisplayName("Genero")]
        public string gender { get; set; }
        [ForeignKey("User")]
        public string AplicationUserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
    public class ConsultarCollaboradorPOST{
        [DisplayName("Identificacion")]
        public string Identification { get; set; }
    }
    public class ColaboradorViewModel:ConsultarCollaboradorPOST {
        [DisplayName("Nombres")]
        public string Name { get; set; }
        [DisplayName("Apellidos")]
        public string LastName { get; set; }
        [DisplayName("Salario")]
        public string Salary { get; set; }
        [DisplayName("Área")]
        public string Area { get; set; }
    }
}