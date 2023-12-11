using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
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

    public async Task AddPublicGrantAclAsync(string bucket, string key)
    {
        var aclResponse = await _s3Client.GetACLAsync(new GetACLRequest
        {
            BucketName = bucket,
            Key = key
        });

        var acl = aclResponse.AccessControlList;

        Owner owner = acl.Owner;

        acl.Grants.Clear();

        // Add a grant to reset the owner's full permission (the previous clear statement removed all permissions).
        S3Grant publicReadGrant = new S3Grant
        {
            Grantee = new S3Grantee { URI = "http://acs.amazonaws.com/groups/global/AllUsers" },
            Permission = S3Permission.READ
        };

        S3Grant FullAccessGrant = new S3Grant
        {
            Grantee = new S3Grantee
            {
                CanonicalUser = owner.Id  
            },
            Permission = S3Permission.FULL_CONTROL
        };

        acl.Grants.AddRange(new List<S3Grant> { publicReadGrant, FullAccessGrant });

        await _s3Client.PutACLAsync(new PutACLRequest 
        {
            BucketName = bucket,
            AccessControlList = acl,
            Key = key
        });
    }
}
