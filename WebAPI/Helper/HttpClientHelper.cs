using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

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

        public async Task<T> MakeHttpRequest<T>(string requestURL)
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(requestURL);

                response.EnsureSuccessStatusCode();

                T responseObject = await response.Content.ReadFromJsonAsync<T>();

                return responseObject;
            }
            catch (HttpRequestException ex)
            {
                // Handle any exceptions thrown during the request
                Console.WriteLine($"Error: {ex.Message}");
                return default(T);
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
