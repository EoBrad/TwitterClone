using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using TwitterClone.Exeptions;
using TwitterClone.Models;
using TwitterClone.Responses;

namespace TwitterClone.Services.UseCases.Profile;

public class ProfileUseCase : IProfileUseCase
{
    private readonly IUserRepository _userRepository;

    private readonly IMapper _mapper;


    public ProfileUseCase(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
 
    public async Task<UserProfileResponse> Execute(string username)
    {
        if (username.Contains('.') || username.Contains('@'))
            throw new TwitterCloneExeption("Invalid username", (int)HttpStatusCode.BadRequest);

        username = $"@{username}";

        var user = await _userRepository.FindUserByEmailOrUsername(username);

        if (user == null)
            throw new TwitterCloneExeption("User not found", (int)HttpStatusCode.NotFound);

        return _mapper.Map<UserProfileResponse>(user);
    }
}
