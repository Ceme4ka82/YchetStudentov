//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YchetStudentov.Model.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Facultet
    {
        public int ID { get; set; }
        public string Naim { get; set; }
        public Nullable<int> IDGruppi { get; set; }
    
        public virtual Gruppa Gruppa { get; set; }
    }
}
