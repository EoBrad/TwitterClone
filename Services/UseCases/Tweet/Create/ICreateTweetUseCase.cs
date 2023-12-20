using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Dtos.Tweet;

namespace TwitterClone.Services.UseCases.Tweet.Create;

public interface ICreateTweetUseCase
{
    Task Execute(CreateTweetDto createTweetDto, string token);
}
