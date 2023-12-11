namespace TwitterClone.Dtos.User;

public class UpdateUserDto
{
    public string Name { get; set; }

    public string LastName { get; set; }

    public string Bio { get; set; }

    public IFormFile Image { get; set; }
}
