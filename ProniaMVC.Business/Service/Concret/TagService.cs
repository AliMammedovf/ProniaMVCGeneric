using ProniaMVC.Business.Service.Abstract;
using ProniaMVC.Core.Models;
using ProniaMVC.Core.RepsitoryAbstract;
using ProniaMVC.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaMVC.Business.Service.Concret
{
    public class TagService : ITagService
    {
        public ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task AddTagAsync(Tag tag)
        {
            if (tag == null) throw new ArgumentNullException();
            if(!_tagRepository.GetAll().Any(x => x.Name == tag.Name))
             await _tagRepository.AddAsync(tag);
            _tagRepository.CommitAsync();
        }

        public void DeleteTag(int id)
        {
            Tag exsist= _tagRepository.Get(x=> x.Id == id);
            if (exsist != null) throw new NullReferenceException();
            _tagRepository.Delete(exsist);
            _tagRepository.Commit();
        }

        public List<Tag> GetAllTag(Func<Tag, bool>? func = null)
        {
           return _tagRepository.GetAll(func);
        }

        public Tag GetTag(Func<Tag, bool>? func = null)
        {
            return _tagRepository.Get(func);
        }

        public void UpdateTag(Tag newTag, int id)
        {
            Tag oldTag= _tagRepository.Get(x => x.Id == id);
            if (oldTag == null) throw new NullReferenceException();
            
            if(! _tagRepository.GetAll().Any(x=>x.Name == newTag.Name))
            {
                oldTag.Name = newTag.Name;
            }
        }
    }  
}
