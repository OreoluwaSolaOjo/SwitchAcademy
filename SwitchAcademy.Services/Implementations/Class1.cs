/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace SwitchAcademy.Services.Implementations
{
    public class Class1
    {

        var client = new HttpClient();
        var request = new HttpRequestMessage


    public SendEmail() {
            {
                Method = HttpMethod.Post,
        RequestUri = new Uri("https://api.sendchamp.com/api/v1/email/send"),
        Headers =
            {
                    { "accept", "application/json" },
    },
        Content = new StringContent("{\"to\":[{\"email\":\"Email\",\"name\":\"Name\"}],\"from\":{\"email\":\"oreoluwasolaojo@gmail.com\",\"name\":\"Interswitch Academy\"},\"message_body\":{\"type\":\"String\",\"value\":\"Thank you for registering for the Switch Academy. Please do as follows\"},\"subject\":\"Thank you for registering for Interswitch Academy\"}")
        {
            Headers =
        {
            ContentType = new MediaTypeHeaderValue("application/json")
        }
        }
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                Console.WriteLine(body);
            }
        } }
}
*/