using System;
using System.Collections.Generic;

namespace agendav2.contactDB;

public partial class Contact
{
    public int Idcontact { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string Sex { get; set; } = null!;

    public DateOnly Birth { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<RéseauxSociaux> RéseauxSociauxIdréseauxSociauxes { get; set; } = new List<RéseauxSociaux>();
}
