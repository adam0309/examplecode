using System;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using Toci.DigitalSignature.Abstract;
using Toci.DigitalSignature.Interfaces;

namespace Toci.DigitalSignature.DigitalSignHandlers
{
    public class Verify: CertificateParsers, IVerify 
    {
        protected const string crypthoAlgorithm = "RSA";

        public bool VerifyFile(byte[] inputFile, byte[] signature, X509Certificate2 certificate)
        {
            if (inputFile.Equals(null) || signature == null) return false;
            var algorithmName = certificate.SignatureAlgorithm.FriendlyName.Replace(crypthoAlgorithm, String.Empty).ToUpper();
            var publicKey = (RSACryptoServiceProvider)certificate.PublicKey.Key;
            
            try
            {
                byte[] hash = HashAlgorithm.Create(algorithmName).ComputeHash(inputFile);
                return publicKey.VerifyHash(hash, CryptoConfig.MapNameToOID(algorithmName), signature);
            }
            catch (Exception)
            {
                throw new Exception("Invalid algorithm method");
            }
        }

        public bool VerifyFile(byte[] inputFile, byte[] signature, string base64SCertyficate)
        {
            X509Certificate2 certificate = Base64ToCertificate(base64SCertyficate);


            return VerifyFile(inputFile, signature, certificate);
        }

        public bool VerifyFile(string base64InputFile, string base64Signature, string base64SCertyficate)
        {
            X509Certificate2 certificate = Base64ToCertificate(base64SCertyficate);
            return VerifyFile(Convert.FromBase64String(base64InputFile), Convert.FromBase64String(base64Signature), certificate);
        }

    }
}