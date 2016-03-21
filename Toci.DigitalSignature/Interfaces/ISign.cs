using System.Security.Cryptography.X509Certificates;

namespace Toci.DigitalSignature.Interfaces
{
    public interface ISign
    {
        byte[] SignFile(byte[] inputFile, X509Certificate2 certificate);
    }
}