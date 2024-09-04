using System;
using System.Collections.Generic;

namespace ProyectoEmpleo.Model;
  
public partial class Person
{  
    public long Id { get; set; }

    public long UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? DateOfBirth { get; set; }

    public string? Address { get; set; }

    public string? PhoneNumber { get; set; }

    public DateTimeOffset? CreatedAt { get; set; }

    public DateTimeOffset? UpdatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
