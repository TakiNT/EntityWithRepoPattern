using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FFRepository
{
    public class PostRepository : BaseRepository<Post>
    {
        public PostRepository(IUnitOfWork unit)
            : base(unit)
        { }
    }
}
