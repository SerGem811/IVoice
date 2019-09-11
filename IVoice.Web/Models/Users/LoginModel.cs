
namespace IVoice.Models.Users
{
    public class LoginModel : BaseModel
    {
        public string _email { get; set; }
        public string _pwd { get; set; }

        public bool IsValid()
        {
            if (string.IsNullOrEmpty(_pwd) || _pwd.Length < 5)
                return false;
            else if (_email == null || !isValidEmail(_email))
                return false;
            return true;
        }

        public bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}