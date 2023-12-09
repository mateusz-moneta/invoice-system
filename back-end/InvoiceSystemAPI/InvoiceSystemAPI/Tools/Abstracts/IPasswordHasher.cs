namespace InvoiceSystemAPI.Tools.Abstracts
{
    public interface IPasswordHasher
    {
        bool Compare(string password, string hash, byte[] salt);

        string Hash(string password, byte[] salt);

        byte[] RandomSalt(int bytes);
    }
}
