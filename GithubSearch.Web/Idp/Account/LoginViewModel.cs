using System;
using System.Collections.Generic;
using System.Linq;

namespace GithubSearch.Web.Idp.Account
{
    public class LoginViewModel : LoginInputModel
    {
        public bool AllowRememberLogin { get; set; } = true;
    }
}