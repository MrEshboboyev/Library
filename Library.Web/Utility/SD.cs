namespace Library.Web.Utility
{
    public static class SD
    {
        public static string BookAPIBase { get; set; }

        public enum ApiType
        {
            GET,
            POST, 
            PUT,
            DELETE
        }
    }
}
