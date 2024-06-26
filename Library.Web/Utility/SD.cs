﻿namespace Library.Web.Utility
{
    public static class SD
    {
        public static string BookAPIBase { get; set; }
        public static string AuthAPIBase { get; set; }

        // roles
        public const string RoleAdmin = "ADMIN";
        public const string RoleCustomer = "CUSTOMER";

        // cookie
        public const string TokenCookie = "JWTToken";

        public enum ApiType
        {
            GET,
            POST, 
            PUT,
            DELETE
        }
    }
}
