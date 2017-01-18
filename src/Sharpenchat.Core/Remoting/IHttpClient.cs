using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Sharpenchat.Core.Remoting
{
    public interface IHttpClient
    {
        Task<TResponse> PostAsync<TResponse>(string apiUrl, Func<TextWriter, Task> action);
    }
}
