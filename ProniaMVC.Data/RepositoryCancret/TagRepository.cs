using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepsitoryAbstract;
using ProniaMVC.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Data.RepositoryCancret
{
    public class TagRepository: GenericRepository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext appDbContext): base(appDbContext) { }
        
    }
}
