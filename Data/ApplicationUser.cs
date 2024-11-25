using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using greenhouse.Entities;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<Plant> Plants { get; set; }
}
