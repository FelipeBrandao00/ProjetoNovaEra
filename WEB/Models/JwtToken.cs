using Microsoft.EntityFrameworkCore.Storage.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace WEB.Models {
    public class JwtToken {
        public string alg { get; set; }
        public string typ { get; set; }
        public string email { get; set; }
        public List<string> role { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public int iat { get; set; }

        public static JwtToken DescriptografarJwt(string token) {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var payload = jwtSecurityToken.Payload;
            var jsonPayload = JsonSerializer.Serialize(payload);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
            };
            var jwt = JsonSerializer.Deserialize<JwtToken>(jsonPayload, options);
            return jwt;
        }
    }
}
