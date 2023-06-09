using SteamClone.Dto.Request;
using SteamClone.Dto.Response;
using SteamClone.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public interface ICategoryService
    {
        Task<ICollection<CategoryResponse>> GetCategoriesAsync();
        Task<bool> CategoryControlAsync(IEnumerable<CategoryRequest> categories);
    }
}
