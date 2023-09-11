namespace CCSPayrollBillingSystem.Scripts
{
    public static class SessionManager
    {
        private static string _loggedInUser;

        public static string LoggedInUser
        {
            get { return _loggedInUser; }
            set { _loggedInUser = value; }
        }

        public static bool IsUserLoggedIn => !string.IsNullOrEmpty(_loggedInUser);

        public static void ClearSession()
        {
            _loggedInUser = null;
        }
    }
}
