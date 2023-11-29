using pro_events.Application.DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pro_events.Application.IServices
{
    public interface ITokenService
    {
        Task<string> GenerateToken(UserSaveDto userDto);
    }
}
