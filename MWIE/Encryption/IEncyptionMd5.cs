namespace MWIE.Encryption
{
    public interface IEncyptionMd5
    {
        string Encrypt(string toEncrypt, string password);
    }
}