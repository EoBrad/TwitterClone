using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterClone.Services.Amazon;

namespace TwitterClone.Services.Configuration;

public static class AddAwsClientConfiguration
{
    public static void AddAwsClient(this IServiceCollection service, IConfiguration configuration)
    {
        var accessKey = configuration.GetSection("Aws:AccessKey").Value;
        var secretKey = configuration.GetSection("Aws:AccessKeySecret").Value;

        service.AddScoped(opt => new AmazonS3Service(accessKey, secretKey));
    }
}
