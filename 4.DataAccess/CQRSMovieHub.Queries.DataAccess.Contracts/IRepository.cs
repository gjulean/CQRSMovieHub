using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRSMovieHub.Queries.DataAccess.Contracts;

public interface IRepository<TEntity>
{
    IEnumerable<TEntity> GetAll();
    TEntity Get(int id);
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(int id);
    void Save();
}
