using System.Security.Cryptography.X509Certificates;

namespace Toci.DigitalSignature.Interfaces
{
    public interface IVerify
    {
        bool VerifyFile(byte[] inputFile, byte[] signature, X509Certificate2 certificate);
    }
}