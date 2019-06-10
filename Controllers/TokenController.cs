using System.Net.Http;
using System.Threading.Tasks;
using DirectlineJabber.Demo.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace DirectlineJabber.Demo.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public TokenController(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        /// <summary>
        /// Returns a token for our bot using our directline secret
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Post, _configuration["directlineGenerateTokenEndpoint"]))
            {
                requestMessage.Headers.Add("Authorization", $"Bearer {_configuration["directlineSecret"]}");
                var response = await _httpClient.SendAsync(requestMessage);
                string jsonString = await response.Content.ReadAsStringAsync();
                var directlineAuth = JsonConvert.DeserializeObject<DirectLineAuthResponse>(jsonString);
                return Ok(new { Token = directlineAuth.token });
            }
        }
    }
}
