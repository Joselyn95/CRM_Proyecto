//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace C_R_M.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class EstadodeCuenta
    {
        public int Id_Empresa { get; set; }
        [DisplayName("Credito Disponible")]
        [Required(ErrorMessage = "Indique el credito")]
        public decimal Credito_Disponible { get; set; }
        [Required(ErrorMessage = "Indique la empresa")]
        public virtual Empresa Empresa { get; set; }
    }
}
