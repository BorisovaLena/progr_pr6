//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ПР6
{
    using System;
    using System.Collections.Generic;
    
    public partial class Photos
    {
        public int idPhoto { get; set; }
        public int idSotr { get; set; }
        public string path { get; set; }
        public byte[] binaryPath { get; set; }
    
        public virtual Table_Sotrudniki Table_Sotrudniki { get; set; }
    }
}
