using Bogus;
using ExpectedObjects;
using HotelTDD.Domain;
using HotelTDD.Utils;
using Xunit;

namespace HotelTest.Client
{
    public class ClientTest
    {
        private readonly Faker _faker;

        public ClientTest()
        {
            _faker = new Faker();
        }

        [Fact]
        public void ShouldCreateTypeRoom()
        {
            var clientExpected = new Clients(_faker.Random.String(), _faker.Random.String(11), _faker.Random.Hash());

            var room = new Clients(clientExpected.Name, clientExpected.CPF, clientExpected.Hashs);

            clientExpected.ToExpectedObject().ShouldMatch(room);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNot_Create_With_Invalid_Name(string name)
        {
            Assert.Throws<DomainException>(() =>
                    ClientBuilder.New().WithName(name).Build());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNot_Create_With_Invalid_CPF(string cpf)
        {
            Assert.Throws<DomainException>(() =>
                    ClientBuilder.New().WithCPF(cpf).Build());
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void ShouldNot_Create_With_Invalid_Hash(string hash)
        {
            Assert.Throws<DomainException>(() =>
                    ClientBuilder.New().WithHash(hash).Build());
        }

    }
}
