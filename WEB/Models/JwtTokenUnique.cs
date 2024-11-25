using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;

namespace WEB.Models {
    public class JwtTokenUnique {
        public string alg { get; set; }
        public string typ { get; set; }
        public string email { get; set; }
        public string unique_name { get; set; }
        public string role { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public int iat { get; set; }

        public static JwtTokenUnique DescriptografarJwt(string token) {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);

            var payload = jwtSecurityToken.Payload;
            var jsonPayload = JsonSerializer.Serialize(payload);

            var options = new JsonSerializerOptions {
                PropertyNameCaseInsensitive = true,
            };
            return JsonSerializer.Deserialize<JwtTokenUnique>(jsonPayload, options);
        }
    }
}
