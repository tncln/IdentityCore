using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityCore.CustomValidator
{
    public class CustomIdentityValidator:IdentityErrorDescriber
    {
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() {
                Code = "PasswordTooShort",
                Description = $"Parola Minimum {length} karakter olmalıdır."
            };
        }
        public override IdentityError PasswordRequiresNonAlphanumeric()
        {
            return new IdentityError()
            {
                Code = "PasswordRequiresNonAlphanumeric",
                Description = "Parola bir Alphanumeric Karakter içermelidir"
            };
        }
        public override IdentityError DuplicateUserName(string userName)
        {
            return new IdentityError() {
                Code = "DuplicateUserName",
                Description = $"İlgili kullanıcı Adı {userName} zaten sistemde kayıtlı"
            };
        }
    }
}
