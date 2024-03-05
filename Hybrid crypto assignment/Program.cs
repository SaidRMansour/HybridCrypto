using System.Security.Cryptography;
using System;
using System.Text;

namespace hybridCryptoAssignment
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Create ECDH key pairs for Alice
            using var aliceEcdh = ECDiffieHellman.Create();
            aliceEcdh.KeySize = 256; // Use a 256-bit key
            var alicePublicKey = aliceEcdh.PublicKey;

            // Create ECDH key pairs for Bob
            using var bobEcdh = ECDiffieHellman.Create();
            bobEcdh.KeySize = 256;
            var bobPublicKey = bobEcdh.PublicKey;

            // Simulate key exchange (network communication would be involved in a real application)
            byte[] aliceSharedSecret = aliceEcdh.DeriveKeyMaterial(bobPublicKey);
            byte[] bobSharedSecret = bobEcdh.DeriveKeyMaterial(alicePublicKey);

            // Verify the derived keys match and encrypt/decrypt a message
            if (Convert.ToBase64String(aliceSharedSecret) == Convert.ToBase64String(bobSharedSecret))
            {
                Console.WriteLine("Derived keys match. Proceeding with message encryption and decryption.");
                EncryptAndDecryptMessage(aliceSharedSecret); // Use Alice's derived key for demo
            }
            else
            {
                Console.WriteLine("Error: Derived keys do not match.");
            }
        }

        public static void EncryptAndDecryptMessage(byte[] key)
        {
            string originalMessage = "Secret message";
            byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
            byte[] tag = new byte[AesGcm.TagByteSizes.MaxSize];
            byte[] encryptedMessage;
            byte[] decryptedMessage;

            // Generate a random nonce
            RandomNumberGenerator.Fill(nonce);

            // Encrypt the message
            using (var aesGcm = new AesGcm(key))
            {
                encryptedMessage = new byte[originalMessage.Length];
                byte[] messageBytes = Encoding.UTF8.GetBytes(originalMessage);

                // Note: Associated Data set to null in this example
                aesGcm.Encrypt(nonce, messageBytes, encryptedMessage, tag, null);

                // Decrypt the message
                decryptedMessage = new byte[encryptedMessage.Length];
                aesGcm.Decrypt(nonce, encryptedMessage, tag, decryptedMessage, null);
            }

            string decryptedText = Encoding.UTF8.GetString(decryptedMessage);
            Console.WriteLine($"Original message: {originalMessage}");
            Console.WriteLine($"Decrypted message: {decryptedText}");
        }
    }
}
