
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace C_R_M.Models
{

using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Correo
{

    public int Id_Correo { get; set; }
        [DataType(DataType.EmailAddress)]

        [Required(ErrorMessage = "Ingrese un correo")]

        public string Correo1 { get; set; }

    public Nullable<int> Contacto { get; set; }



    public virtual Contacto Contacto1 { get; set; }

}

}
