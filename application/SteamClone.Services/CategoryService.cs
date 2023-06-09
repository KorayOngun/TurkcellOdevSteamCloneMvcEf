using AutoMapper;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using SteamClone.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _repo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<bool> CategoryControlAsync(IEnumerable<CategoryRequest> categories)
        {
            var data = categories.ConvortToDb<Category>(_mapper);
            foreach (var category in data) 
            {
                if (!await _repo.IsExistAsync(category.Id))
                {
                    return false;
                }
                continue;
            }
            return true;
        }

        public async Task<ICollection<CategoryResponse>> GetCategoriesAsync()
        {
            return _repo.GetAllAsync().GetAwaiter().GetResult().ConvortToDto<CategoryResponse>(_mapper).ToList();
        }
    }
}
