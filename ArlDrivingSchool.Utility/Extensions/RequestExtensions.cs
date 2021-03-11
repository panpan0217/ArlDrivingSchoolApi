using Microsoft.AspNetCore.Http;
using ArlDrivingSchool.Utility.Cryptography;
using System;
using System.Linq;

namespace SEO.Utility.Extensions
{
    public static class RequestExtensions
    {
        public static int GetUserId(this HttpRequest request, JWToken jwt)
        {
            var accessToken = request.Headers["Authorization"];
            var userId =  jwt.DecryptToken(accessToken).FirstOrDefault(c => c.Type == "UserId").Value;

            return Convert.ToInt32(userId);
        }

        public static string GetUserType(this HttpRequest request, JWToken jwt)
        {
            var accessToken = request.Headers["Authorization"];
            return jwt.DecryptToken(accessToken).FirstOrDefault(c => c.Type == "role").Value;
        }
    }
}
