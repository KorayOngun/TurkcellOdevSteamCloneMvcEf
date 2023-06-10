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
    public class PublisherService : IPublisherService
    {
        private readonly IPublisherRepo _repo;
        private readonly IMapper _mapper;
        public PublisherService(IPublisherRepo repo,IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PublisherResponse>> GetAllPublisherAsync()
        {
            var data =  await _repo.GetAllAsync();
            return data.ConvortToDto<PublisherResponse>(_mapper);
        }
    }
}
