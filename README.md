# Hybrid Crypto Assignment

![.NET](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)

This project demonstrates a hybrid cryptography implementation in C#/.NET. In this assignment, a mixture of asymmetric and symmetric cryptography techniques is used to securely exchange and encrypt messages.

## Exercise Description

Most real-world applications utilize a combination of asymmetric and symmetric cryptography. This assignment focuses on employing hybrid cryptography to send messages:

- Use asymmetric cryptography in combination with key exchange to share a session key.
- Utilize symmetric cryptography to exchange messages using the session key.
- Recommended algorithms: Elliptic-curve Diffie–Hellman (ECDH) for key exchange and AES-GCM-256 for messages.

## Key Features

- **Exchange Public Keys:** Both Alice and Bob generate ECDH key pairs and simulate key exchange.
- **Derive Key:** A shared secret (session key) is derived from the original key pair and the partner's public key.
- **Encrypt and Decrypt Message:** Messages are encrypted and decrypted using AES-GCM-256 symmetric encryption with the shared session key.

## Usage

1. Clone the repository.
2. Open the solution in Visual Studio or any compatible IDE.
3. Run the program to see the demonstration of hybrid cryptography.

## Requirements

- .NET 5.0 or higher
- Visual Studio or Visual Studio Code

