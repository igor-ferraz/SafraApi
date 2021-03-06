﻿using RestSharp;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Safra.Domain.InfrastructureServices
{
    public interface IHttpService
    {
        Task<IRestResponse> ExecuteRequest(string url, Method method, Dictionary<string, string> headers = null, string body = null, string bodyType = null);
        T GetObjectFromJson<T>(string json);
    }
}
