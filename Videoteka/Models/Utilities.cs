using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Videoteka.Models
{
    public static class Utilities
    {
        public static string GetImePrezime(this System.Security.Principal.IPrincipal usr)
        {
            var imePrezimeClaim = ((ClaimsIdentity)usr.Identity).FindFirst("ImePrezime");
            if (imePrezimeClaim != null)
                return imePrezimeClaim.Value;

            return "";
        }
    }
}