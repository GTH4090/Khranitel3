//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Khranitel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Request
    {
        public int Id { get; set; }
        public System.DateTime StartDate { get; set; }
        public System.DateTime EndDate { get; set; }
        public int TargetId { get; set; }
        public int EmployeeId { get; set; }
        public int ClientId { get; set; }
        public string GroupName { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string DecReason { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Status Status { get; set; }
        public virtual Target Target { get; set; }
        public virtual Type Type { get; set; }
        public virtual User User { get; set; }
    }
}
