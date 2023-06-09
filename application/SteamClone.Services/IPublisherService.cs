﻿using SteamClone.Dto.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamClone.Services
{
    public interface IPublisherService
    {
        Task<IEnumerable<PublisherResponse>> GetAllPublisherAsync();
    }
}
