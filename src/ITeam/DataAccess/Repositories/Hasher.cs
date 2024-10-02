
namespace ITeam.DataAccess.Repositories
{
    public class Hasher : IHasher
    {
        public string Hash(string input)
        {
            return BCrypt.Net.BCrypt.HashPassword(input);
        }

        public bool Verify(string input, string hashedInput)
        {
            return BCrypt.Net.BCrypt.Verify(input, hashedInput);
        }
    }

}
