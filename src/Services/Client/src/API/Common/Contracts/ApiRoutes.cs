namespace Client.API.Common.Contracts
{
    public static class ApiRoutes
    {
        private const string Root = "api";
        private const string Version = "v1";
        private const string Base = Root + "/" + Version;

        public static class Note
        {
            public const string GetAll = Base + "/customer";
            public const string Get = Base + "/customer/{id:Guid}";
            public const string Add = Base + "/customer";
            public const string Update = Base + "/customer/{id:Guid}";
            public const string Delete = Base + "/customer/{id:Guid}";
        }
    }
}
