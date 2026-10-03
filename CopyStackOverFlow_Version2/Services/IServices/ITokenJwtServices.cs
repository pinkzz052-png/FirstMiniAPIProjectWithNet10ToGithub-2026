namespace CopyStackOverFlow_Version2.Services.IServices
{
    public interface ITokenJwtServices
    {
        string GenerateNewJwtToken(Guid userId, string email);

    }
}
