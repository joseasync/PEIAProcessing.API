namespace PEIAProcessing.Domain.Common
{
    public static class RoutesManagement
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base = Root + "/" + Version;

        public static class Position
        {
            public const string GetPositions = Base + "/positions";
            public const string RoutePositionById = Base + "/position/{id}";
            public const string RoutePosition = Base + "/position";
        }
        public static class DistributorAccount
        {
            public const string GetDistributorAccounts = Base + "/distributoraccounts";
            public const string GetDistributorAccount = Base + "/distributoraccount/{id}";
        }
    }
}
