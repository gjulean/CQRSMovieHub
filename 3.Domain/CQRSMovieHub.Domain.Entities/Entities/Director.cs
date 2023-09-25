using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMovieHub.Domain.Entities.Entities;

public class Director
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual IEnumerable<Movie>? Movies { get; set; }
}
