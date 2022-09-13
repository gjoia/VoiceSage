using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Web.Models;

namespace VoiceSage.Web.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        ResponseDto responseModel { get; set; }
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
