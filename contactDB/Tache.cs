using System;
using System.Collections.Generic;

namespace agendav2.contactDB;

public partial class Tache
{
    public int Idtache { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Check { get; set; }

    public int ToDoListIdtoDo { get; set; }

    public virtual ToDoList ToDoListIdtoDoNavigation { get; set; } = null!;
}
