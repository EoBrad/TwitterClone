using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Transfer;

namespace TwitterClone.Services.Amazon;

public class AmazonS3Service
{
    public string AwsKeyId { get; private set; }

    public string AwsKeySecret { get; private set; }

    public BasicAWSCredentials AwsCredentials { get; private set; }

    private readonly IAmazonS3 _s3Client;

    public AmazonS3Service(string _awsKeyId, string _awsKeySecret)
    {
        AwsKeyId = _awsKeyId;
        AwsKeySecret = _awsKeySecret;
        AwsCredentials = new BasicAWSCredentials(AwsKeyId, AwsKeySecret);
        var config = new AmazonS3Config
        {
            RegionEndpoint = RegionEndpoint.SAEast1
        };
        _s3Client = new AmazonS3Client(AwsCredentials, config);
    }

    public async Task UploadFileAsync(string bucket, IFormFile file, string key)
    {
        using var ms = new MemoryStream();
        await file.CopyToAsync(ms);

        var fileTransferUtility = new TransferUtility(_s3Client);

        await fileTransferUtility.UploadAsync(ms, bucket, key);
    }
}
