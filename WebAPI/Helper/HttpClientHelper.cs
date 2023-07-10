using Azure.Core;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text;

namespace WebAPI.Helper
{
    public class HttpClientHelper
    {
        private readonly HttpClient _httpClient;

        public HttpClientHelper()
        {
            _httpClient = new HttpClient(new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, certificate, chain, sslPolicyErrors) => true
            });
        }

        public async Task<TResponse> MakeHttpRequest<TRequest,TResponse>(string requestURL, HttpMethod httpMethod, TRequest requestBody = default, Dictionary<string, string> parameters = null)
        {
            try
            {
                // Add the parameters to the URL if provided
                if (parameters != null)
                {
                    var uriBuilder = new UriBuilder(requestURL);
                    var query = new StringBuilder();
                    foreach (var parameter in parameters)
                    {
                        query.Append($"{Uri.EscapeDataString(parameter.Key)}={Uri.EscapeDataString(parameter.Value)}&");
                    }
                    uriBuilder.Query = query.ToString().TrimEnd('&');
                    requestURL = uriBuilder.ToString();
                }

                // Send the HTTP request
                HttpResponseMessage response;
                if (httpMethod == HttpMethod.Get)
                {
                    response = await _httpClient.GetAsync(requestURL);
                }
                else if (httpMethod == HttpMethod.Post)
                {
                    var content = JsonContent.Create(requestBody);
                    response = await _httpClient.PostAsync(requestURL, content);
                }
                else
                {
                    throw new NotSupportedException($"HTTP method {httpMethod} is not supported.");
                }

                // Ensure a successful response
                response.EnsureSuccessStatusCode();

                // Deserialize the response body
                var responseBody = await response.Content.ReadFromJsonAsync<TResponse>();

                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions thrown during the request
                Console.WriteLine($"Error: {ex.Message}");
                return default(TResponse);
            }
        }
        private static bool ValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            // Perform custom certificate validation logic here
            // You can validate the certificate based on various criteria, such as the certificate's subject, issuer, expiration date, etc.

            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true; // Certificate is considered valid if no errors are detected
            }

            // Custom validation logic based on specific criteria
            // For example, checking the certificate's subject name:
            if (certificate.Subject.Contains("example.com"))
            {
                return true; // Accept the certificate if it matches the expected subject
            }

            // Return false to indicate the certificate is not valid
            return false;
        }
    }
}
