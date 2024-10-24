namespace BTG.Identidade.API.Models
{
    public class LoginResponseViewModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public UsuarioTokenViewModel UserToken { get; set; }
    }
}