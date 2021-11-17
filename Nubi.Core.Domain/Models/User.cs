namespace Nubi.Core.Domain.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.Security.Cryptography;
    using System.Text;

    public class User : EntityBase
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }

        [MaxLength(128)]
        [MinLength(8, ErrorMessage = "You must enter at least 8 characters.")]
        [RegularExpression(@"(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$")]
        public string Password { get; set; }

        public static string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
