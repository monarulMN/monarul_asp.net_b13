using System;
using System.Collections.Generic;
using System.Text;

namespace MaleFashion.Domain.Utilities
{
    public class JwtSettings
    {
        public string SecretKey { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int ExpirationInMinutes { get; set; }
        public string ClientId { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
    }
}
