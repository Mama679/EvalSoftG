using System.Security.Claims;

namespace WebApi.Authentication
{
    public class JsonWebtoken
    {
        public string Access_Token { get; set; }
        public string Token_Type { get; set; } = "bearer";
        public int Expires_in { get; set; }
        public string Refresh_Token { get; set; }

        public static dynamic ValidarToken(ClaimsIdentity identity)
        {
            try
            {
                if (identity.Claims.Count() == 0)
                {
                    return new
                    {
                        success = false,
                        mensaje = "Token Invalid",
                        result = ""
                    };
                }

                var id = identity.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

                return new
                {
                    success = true,
                    mensaje = "User Registered.",
                    result = id
                };
            }
            catch (Exception ex)
            {
                return new
                {
                    success = false,
                    mensaje = ex.Message,
                    result = ""
                };
            }
        }
    }
}
