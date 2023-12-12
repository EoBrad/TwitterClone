using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TwitterClone.Responses;

public class UserProfileResponse
{
    public Guid UserId { get; set; }

    public string Name { get; set; }

    public string LastName { get; set; }

    public string PhotoURL { get; set; }

    public string Email { get; set; }

    public string Bio { get; set; }
}
