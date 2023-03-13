using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net.Http.Headers;
using System.Text;

namespace AlphaServer.Servises
{
    public class EmailSender: IEmailSender

        
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(email, subject, htmlMessage);
        }
        public async Task Execute (string email, string subject, string body)
        {
            HttpClient client;
            
            client = new HttpClient();

            client.BaseAddress = new Uri("https://go1.unisender.ru/ru/transactional/api/v1/");
            client.DefaultRequestHeaders.Add("6u85tsugco4ujdabb7x8drqexmw7rjbcbkutrcwa", "6u85tsugco4ujdabb7x8drqexmw7rjbcbkutrcwa");
            client.DefaultRequestHeaders.Accept.Add(
              new MediaTypeWithQualityHeaderValue("application/json"));

            string requestBody = "{"
            + "  \"message\": {"
            + "    \"recipients\": ["
            + "      {"
            + "        \"email\": \"fedalwork@gmail.com\","
            + "        \"substitutions\": {"
            + "          \"CustomerId\": 5592087,"
            + "          \"to_name\": \"Alex Fedorov\""
            + "        },"
            + "        \"metadata\": {"
            + "          \"campaign_id\": \"c77f4f4e-3561-49f7-9f07-c35be01b4f43\","
            + "          \"customer_hash\": \"b253ac7\""
            + "        }"
            + "      }"
            + "    ],"
            + "    \"template_id\": \"string\","
            + "    \"tags\": ["
            + "      \"string1\""
            + "    ],"
            + "    \"skip_unsubscribe\": 0,"
            + "    \"global_language\": \"string\","
            + "    \"template_engine\": \"simple\","
            + "    \"global_substitutions\": {"
            + "      \"property1\": \"string\","
            + "      \"property2\": \"string\""
            + "    },"
            + "    \"global_metadata\": {"
            + "      \"property1\": \"string\","
            + "      \"property2\": \"string\""
            + "    },"
            + "    \"body\": {"
            + "      \"html\": \"<b>Hello, {{to_name}}</b>\","
            + "      \"plaintext\": \"Hello, {{to_name}}\","
            + "      \"amp\": \"<!doctype html><html amp4email><head> <meta charset=\\\"utf-8\\\"><script async src=\\\"https://cdn.ampproject.org/v0.js\\\"></script> <style amp4email-boilerplate>body{visibility:hidden}</style></head><body> Hello, AMP4EMAIL world.</body></html>\""
            + "    },"
            + "    \"subject\": \"string\","
            + "    \"from_email\": \"fedalwork@gmail.com\","
            + "    \"from_name\": \"John Smith\","
            + "    \"reply_to\": \"fedalwork@gmail.com\","
            + "    \"track_links\": 0,"
            + "    \"track_read\": 0,"
            + "    \"bypass_global\": 0,"
            + "    \"bypass_unavailable\": 0,"
            + "    \"bypass_unsubscribed\": 0,"
            + "    \"bypass_complained\": 0,"
            + "    \"headers\": {"
            + "      \"X-MyHeader\": \"some data\","
            + "      \"List-Unsubscribe\": \"<mailto: unsubscribe@example.com?subject=unsubscribe>, <http://www.example.com/unsubscribe/{{CustomerId}}>\""
            + "    },"
            + "    \"attachments\": ["
            + "      {"
            + "        \"type\": \"text/plain\","
            + "        \"name\": \"readme.txt\","
            + "        \"content\": \"SGVsbG8sIHdvcmxkIQ==\""
            + "      }"
            + "    ],"
            + "    \"inline_attachments\": ["
            + "      {"
            + "        \"type\": \"image/gif\","
            + "        \"name\": \"IMAGECID1\","
            + "        \"content\": \"R0lGODdhAwADAIABAP+rAP///ywAAAAAAwADAAACBIQRBwUAOw==\""
            + "      }"
            + "    ],"
            + "    \"options\": {"
            + "      \"send_at\": \"2021-11-19 10:00:00\","
            + "      \"unsubscribe_url\": \"https://example.org/unsubscribe/{{CustomerId}}\","
            + "      \"custom_backend_id\": 0,"
            + "      \"smtp_pool_id\": \"string\""
            + "    }"
            + "  }"
            + "}";
            var content = new StringContent(requestBody, Encoding.UTF8, "application/json");

            var response = client.PostAsync("email/send.json", content).Result;
            var responseBody = response.Content.ReadAsStringAsync().Result;
        }

    }
}
