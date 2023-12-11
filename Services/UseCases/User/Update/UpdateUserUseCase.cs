using System.Net;
using AutoMapper;
using Microsoft.IdentityModel.JsonWebTokens;
using TwitterClone.Dtos.User;
using TwitterClone.Exeptions;
using TwitterClone.Models;
using TwitterClone.Services.Amazon;
using TwitterClone.Services.Utility;

namespace TwitterClone.Services.UseCases.User.Update;

public class UpdateUserUseCase : IUpdateUserUseCase
{

    private readonly IUserRepository _userRepository;

    private readonly AmazonS3Service _amazonS3Service;

    private readonly IMapper _mapper;

    public UpdateUserUseCase(IUserRepository userRepository, AmazonS3Service amazonS3Service, IMapper mapper)
    {
        _amazonS3Service = amazonS3Service;
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task Execute(UpdateUserDto updateUserDto, IFormFile image, string token)
    {
        var Useremail = Jwt.GetUserByToken(token);

        var user = await _userRepository.FindUserByEmailOrUsername(Useremail);

        if (user == null)
            throw new TwitterCloneExeption("User not found", (int)HttpStatusCode.NotFound);
        
        string imageGuid = $"profileImage{Guid.NewGuid}{user.UserId}";

        if(image != null)
            await _amazonS3Service.UploadFileAsync("twitter-clone-joao", image, imageGuid);
        
        user = _mapper.Map<Models.User>(updateUserDto);

        user.PhotoURL = imageGuid;

        await _userRepository.UpdateUserAsync();
    }   
}
