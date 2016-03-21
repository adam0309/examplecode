using System;
using System.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Toci.DigitalSignature.Abstract
{
    public abstract class CertificateParsers
    {

        public virtual string CertificateToBase64(X509Certificate2 certificate)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine("-----BEGIN CERTIFICATE-----");
            builder.AppendLine(Convert.ToBase64String(certificate.Export(X509ContentType.SerializedCert), Base64FormattingOptions.InsertLineBreaks));
            builder.AppendLine("-----END CERTIFICATE-----");
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(builder.ToString()));
        }

        public virtual X509Certificate2 Base64ToCertificate(string base64Certyficate)
        {
            byte[] bytes = Convert.FromBase64String(base64Certyficate);
            return new X509Certificate2(bytes);
        }


        public virtual X509Certificate2 PfxFileToCertificate(byte[] pfxBytes, SecureString password)
        {
            return new X509Certificate2(pfxBytes, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
        }
        public virtual X509Certificate2 PfxFileToCertificate(string base64Certyficate, SecureString password)
        {
            
            byte[] pfxBytes = Convert.FromBase64String(base64Certyficate);
            return PfxFileToCertificate(pfxBytes, password);
        }

        public virtual X509Certificate2 PfxFileToCertificate(byte[] pfxBytes, string password)
        {
            return new X509Certificate2(pfxBytes, password, X509KeyStorageFlags.Exportable | X509KeyStorageFlags.PersistKeySet | X509KeyStorageFlags.MachineKeySet);
        }
        public virtual X509Certificate2 PfxFileToCertificate(string base64Certyficate, string password)
        {

            byte[] pfxBytes = Convert.FromBase64String(base64Certyficate);
            return PfxFileToCertificate(pfxBytes, password);
        }
    }
}