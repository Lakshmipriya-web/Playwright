namespace PlaywrightTests.Config
{
    public class TestConfig
    {
        public string baseUrl { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string browser { get; set; }
        public bool headless { get; set; }
        public int timeout { get; set; }
    }
}