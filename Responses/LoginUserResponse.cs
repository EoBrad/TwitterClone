using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Responses;

public class LoginUserResponse
{
    public string Token { get; set; }

    public DateTime Expires { get; set; }
}
