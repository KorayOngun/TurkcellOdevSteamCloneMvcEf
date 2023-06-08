using AutoMapper;
using SteamClone.DataAccess.Repositories.IRepos;
using SteamClone.Dto.Response;
using SteamClone.Services.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public class DeveloperService : IDeveloperService
    {
        private readonly IDeveloperRepo _repo;
        private readonly IMapper _mapper;

        public DeveloperService(IDeveloperRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DeveloperResponse>> GetAllDevelopersAsync()
        {
            return _repo.GetAllAsync().GetAwaiter().GetResult().ConvortToDto<DeveloperResponse>(_mapper);
        }
    }
}
