namespace ITeam.DataAccess.Repositories
{
    public interface IHasher
    {
        string Hash(string input);
        bool Verify(string input, string hashedInput);
    }
}
