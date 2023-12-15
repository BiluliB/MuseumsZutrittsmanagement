using APIWebApplication.DTO.Request;
using APIWebApplication.DTO.Response;
using APIWebApplication.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIWebApplication.Interfaces
{
    public interface IAccessLogService
    {
        Task<List<AccessLogResponse>> GetAllAsync();
        Task<AccessLogResponse> GetByIdAsync(int id);
        Task<AccessLogResponse> CreatAsync(CreateAccessLogRequest model);
        Task<DeletResponse> DeletAsync(int id);
        Task<AccessLogResponse> UpdateAsync(int id, UpdateAccessLogRequest model);
    }

    public class AccessLogService : IAccessLogService
    {
        // Implementierung der Methoden...
        public Task<AccessLogResponse> CreatAsync(CreateAccessLogRequest model)
        {
            throw new NotImplementedException();
        }

        public Task<DeletResponse> DeletAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AccessLogResponse>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<AccessLogResponse> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AccessLogResponse> UpdateAsync(int id, UpdateAccessLogRequest model)
        {
            throw new NotImplementedException();
        }
    }
}

