using System;
using System.Collections.Generic;

namespace agendav2.contactDB;

public partial class RéseauxSociaux
{
    public int IdréseauxSociaux { get; set; }

    public string Url { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<Contact> ContactIdcontacts { get; set; } = new List<Contact>();
}
