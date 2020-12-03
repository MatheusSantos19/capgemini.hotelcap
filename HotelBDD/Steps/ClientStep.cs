using BoDi;
using RestSharp;
using System;
using System.Net;
using TechTalk.SpecFlow;
using Xunit;

namespace HotelBDD.Steps
{
    [Binding]
    public class ClientStep
    {
        private string _host = "https://localhost:5001/";
        private IRestClient _restClient;
        private IRestRequest _restRequest;
        private IRestResponse _restResponse;
        private IObjectContainer _objectContainer;
        private int _id;
        private int _clientId;
        private int _quartoId;
        private string _name;
        private string _cpf;
        private string _hash;
        private int _buildingFloor;
        private int _roomNum;
        private string _situation;
        private int _typeRoomId;
        private DateTime _data;
        private int _dailyAmount;
        public ClientStep(IObjectContainer objectContainer) => _objectContainer = objectContainer;

        [BeforeScenario]
        public void Setup()
        {
            _restClient = new RestClient();
            _objectContainer.RegisterInstanceAs(_restClient);
            _restRequest = new RestRequest();
            _objectContainer.RegisterInstanceAs(_restRequest);
            _restResponse = new RestResponse();
            _objectContainer.RegisterInstanceAs(_restResponse);
            _restClient.RemoteCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true;
        }

        [Given(@"que o endpoint é '(.*)'")]
        public void DadoQueAUrlDoEndPointEh(string endpoint) => _restRequest.Resource = endpoint;

        [Given(@"que o método http é '(.*)'")]
        public void DadoQueOMetodoHttpEh(string metodo)
        {
            if (string.Equals(metodo, "GET", System.StringComparison.OrdinalIgnoreCase))
                _restRequest.Method = Method.GET;

            if (string.Equals(metodo, "POST", System.StringComparison.OrdinalIgnoreCase))
                _restRequest.Method = Method.POST;

            if (string.Equals(metodo, "PUT", System.StringComparison.OrdinalIgnoreCase))
                _restRequest.Method = Method.PUT;

            if (string.Equals(metodo, "DELETE", System.StringComparison.OrdinalIgnoreCase))
                _restRequest.Method = Method.DELETE;

            if (string.Equals(metodo, "PATCH", System.StringComparison.OrdinalIgnoreCase))
                _restRequest.Method = Method.PATCH;
        }

        //Given Client
        [Given(@"que o id é (.*)")]
        public void DadoQueOIdDoClienteEh(int id) => _id = id;


        [Given(@"que o nome é (.*)")]
        public void DadoQueONomeDoClienteEh(string name) => _name = name;

        [Given(@"que o cpf é (.*)")]
        public void DadoQueOCPFEh(string cpf) => _cpf = cpf;

        [Given(@"que o hash é (.*)")]
        public void DadoQueOHashDoClienteEh(string hash) => _hash = hash;

        //Given Room

        [Given(@"que o id do quarto é (.*)")]
        public void DadoQueOIdDoQuartoEh(int id) => _quartoId = id;


        [Given(@"que o andar é (.*)")]
        public void DadoQueOAndarDoQuartoEh(int buildingFloor) => _buildingFloor = buildingFloor;

        [Given(@"que o numero do quarto é (.*)")]
        public void DadoQueONumeroDoQuartoEh(int roomnum) => _roomNum = roomnum;

        [Given(@"que o situação é (.*)")]
        public void DadoQueASituacaoDoQuartoEh(string situation) => _situation = situation;

        [Given(@"que o tipo do quarto é (.*)")]
        public void DadoQueOTipoDoQuartoEh(int typeRoom) => _typeRoomId = typeRoom;

        //Given Occupation

        [Given(@"que a quantidade de diaria é (.*)")]
        public void DadoQueAQuantidadeDeDiariaEh(int dailyAmount) => _dailyAmount = dailyAmount;

        [Given(@"que a data é (.*)")]
        public void DadoQueADataEh(DateTime dateTime) => _data = dateTime;

        [Given(@"que o id do cliente é (.*)")]
        public void DadoQueIdClienteEh(int clientId) => _clientId = clientId;
        
        [Given(@"que o id do quarto ocupacao é (.*)")]
        public void DadoQueIdQuartoEh(int quartoId) => _quartoId = quartoId;





        //When Client
        [When(@"obter o cliente")]
        public void QuandoObterOCliente() => GetClient();

        [When(@"criar o cliente")]
        public void QuandoCriarOCliente() => CreateClient();

        //When Room

        [When(@"obter o quarto")]
        public void QuandoObterOQuarto() => GetRoom();

        [When(@"criar o quarto")]
        public void CriarOQuarto() => CreateRoom();


        [When(@"alterar o quarto")]
        public void AlterarOQuarto() => UpdateRoom();

        //When Occupation
        [When(@"criar a ocupacao")]
        public void QuandoCriarAOcupacao() => CreateOccupation();






        [Then(@"a resposta sera (.*)")]
        public void EntaoARespostaSera(HttpStatusCode statusCode) => Assert.Equal(statusCode, _restResponse.StatusCode);


        //Client

        public void CreateClient()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                name = _name,
                cpf = _cpf,
                hashs = _hash
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void GetClient()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("id", _id);


            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        //Room

        public void CreateRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                buildingFloor = _buildingFloor,
                roomNum = _roomNum,
                situation = _situation,
                typeRoomId = _typeRoomId
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

        public void UpdateRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
                Id = _quartoId,
                situation = _situation
                
            };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }




        public void GetRoom()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            if (_id != 0)
                _restRequest.AddParameter("id", _id);


            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }


        //Occupation
        public void CreateOccupation()
        {
            _restRequest.AddHeader("Content-Type", "application/json");

            var request = new
            {
            DailyAmount = _dailyAmount,
            Date = _data,
            ClientId = _clientId,
            RoomId = _quartoId
        };

            _restRequest.AddJsonBody(request);

            _restClient.BaseUrl = new Uri(_host);
            _restResponse = _restClient.Execute(_restRequest);
        }

    }
}
