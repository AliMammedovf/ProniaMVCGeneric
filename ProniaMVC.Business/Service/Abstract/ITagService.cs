using ProniaMVC.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Abstract
{
    public interface ITagService
    {
        Task AddTagAsync(Tag tag);

        void DeleteTag(int id);

        Tag GetTag(Func<Tag,bool>? func=null);

        List<Tag> GetAllTag(Func<Tag, bool>? func = null);

        void UpdateTag(Tag newTag, int id);
    }
}
