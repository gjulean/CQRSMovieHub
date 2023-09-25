using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMovieHub.Domain.Entities.Entities;

public class Movie
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Genre { get; set; }

    public DateTime FilmedAt { get; set; }

    public int DirectorId { get; set; }

    public virtual Director Director { get; set; }
}
