using Bogus;

namespace PlaywrightTests.Utils
{
    public static class RandomDataGenerator
    {
        private static readonly Faker Faker = new Faker();

        public static string GetRandomEmail() => Faker.Internet.Email();
        public static string GetRandomName() => Faker.Name.FullName();
        public static string GetRandomPhone() => Faker.Phone.PhoneNumber();
        public static string GetRandomAddress() => Faker.Address.FullAddress();
        public static string GetRandomPostalCode() => Faker.Address.ZipCode();
    }
}