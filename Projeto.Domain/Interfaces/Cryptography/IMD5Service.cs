using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Domain.Interfaces.Cryptography
{
    public interface IMD5Service
    {
        string Encrypt(string value);
    }
}
