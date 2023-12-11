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



    public UpdateUserUseCase(IUserRepository userRepository, AmazonS3Service amazonS3Service)
    {
        _amazonS3Service = amazonS3Service;
        _userRepository = userRepository;
    }
    public async Task Execute(UpdateUserDto updateUserDto, IFormFile image, string token)
    {
        var userId = Guid.Parse(Jwt.GetUserByToken(token));

        var user = await _userRepository.FindUserByIdAsync(userId);

        if (user == null)
            throw new TwitterCloneExeption("User not found", (int)HttpStatusCode.NotFound);
        
        string imageGuid = $"profileImage-{user.UserId}" + Guid.NewGuid().ToString();

        if(image != null)
        {   
            await _amazonS3Service.UploadFileAsync("twitter-clone-public-bucket", image, imageGuid);
            await _amazonS3Service.AddPublicGrantAclAsync("twitter-clone-public-bucket", imageGuid);
        }
         
        user.Bio = updateUserDto.Bio;
        user.Name = updateUserDto.Name;
        user.LastName = updateUserDto.LastName;
        user.PhotoURL = $"https://twitter-clone-public-bucket.s3.sa-east-1.amazonaws.com/{imageGuid}";

        await _userRepository.UpdateUserAsync(user);
    }   
}
