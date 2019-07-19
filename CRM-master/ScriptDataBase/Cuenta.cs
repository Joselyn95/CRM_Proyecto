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
    using System.ComponentModel.DataAnnotations;

    public partial class Cuenta
    {
        public int Id_Cuenta { get; set; }
        public int Servicio_Empresa { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime Fecha_Pago { get; set; }
        public double Monto_Abono { get; set; }
        public Nullable<double> Monto_Pendiente { get; set; }
        public string Descripcion { get; set; }
    
        public virtual ServicioEmpresa ServicioEmpresa { get; set; }
    }
}
