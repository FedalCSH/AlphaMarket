//using System;
//using System.Collections.Generic;
//using ElasticEmail.Api;
//using ElasticEmail.Client;
//using ElasticEmail.Model;
//using Microsoft.AspNetCore.Identity.UI.Services;

//namespace AlphaServer.Servises
//{
//    class ElasticEmailSenderEmails
//    {
//        public EmailSend SendTransactionalEmails()
//        {
//            Configuration config = new Configuration();

//            // Configure API key authorization: apikey
//            config.ApiKey.Add("X-ElasticEmail-ApiKey", "224C5F46B644398A2B97F48AC2928B1524A7F10D40855F7A5EBF7B0031CD503D72E8C98B4F5C518C4DE362C353437391");

//            /**
//             * Send transactional emails
//             * Example api call that sends transactional email.
//             * Limit of 50 maximum recipients.
//             */
//            var apiInstance = new EmailsApi(config);

//            var to = new List<string>();
//            to.Add("userrootovich@yahoo.com");
//            var recipients = new TransactionalRecipient(to: to);

//            EmailTransactionalMessageData emailData = new EmailTransactionalMessageData(recipients: recipients);

//            emailData.Content = new EmailContent();
//            emailData.Content.Body = new List<BodyPart>();

//            BodyPart htmlBodyPart = new BodyPart();
//            htmlBodyPart.ContentType = BodyContentType.HTML;
//            htmlBodyPart.Charset = "utf-8";
//            htmlBodyPart.Content = "<h1>Mail content</h1>";

//            BodyPart plainTextBodyPart = new BodyPart();
//            plainTextBodyPart.ContentType = BodyContentType.PlainText;
//            plainTextBodyPart.Charset = "utf-8";
//            plainTextBodyPart.Content = "Mail content";

//            emailData.Content.Body.Add(htmlBodyPart);
//            emailData.Content.Body.Add(plainTextBodyPart);

//            emailData.Content.From = "userrootovich@yahoo.com";
//            emailData.Content.Subject = "Example transactional email";

//            try
//            {
//                return apiInstance.EmailsTransactionalPost(emailData);
//            }
//            catch (ApiException e)
//            {
//                Console.WriteLine("Exception when calling EmailsApi.EmailsTransactionalPost: " + e.Message);
//                Console.WriteLine("Status Code: " + e.ErrorCode);
//                Console.WriteLine(e.StackTrace);

//                throw;
//            }
//        }
//        public EmailSend SendBulkEmails()
//        {
//            Configuration config = new Configuration();

//            // Configure API key authorization: apikey
//            config.ApiKey.Add("X-ElasticEmail-ApiKey", "224C5F46B644398A2B97F48AC2928B1524A7F10D40855F7A5EBF7B0031CD503D72E8C98B4F5C518C4DE362C353437391");

//            /**
//             * Send bulk emails
//             * Example api call that sends bulk merge email.
//             */
//            var apiInstance = new EmailsApi(config);

//            List<EmailRecipient> emailRecipients = new List<EmailRecipient>();
//            var recipients = new EmailRecipient(email: "userrootovich@yahoo.com");
//            recipients.Fields = new Dictionary<string, string>();
//            recipients.Fields.Add("name", "John");

//            emailRecipients.Add(recipients);
//            EmailMessageData emailData = new EmailMessageData(recipients: emailRecipients);

//            emailData.Content = new EmailContent();
//            emailData.Content.Body = new List<BodyPart>();

//            BodyPart htmlBodyPart = new BodyPart();
//            htmlBodyPart.ContentType = BodyContentType.HTML;
//            htmlBodyPart.Charset = "utf-8";
//            htmlBodyPart.Content = "<h1>Mail content</h1>";

//            BodyPart plainTextBodyPart = new BodyPart();
//            plainTextBodyPart.ContentType = BodyContentType.PlainText;
//            plainTextBodyPart.Charset = "utf-8";
//            plainTextBodyPart.Content = "Mail content";

//            emailData.Content.Body.Add(htmlBodyPart);
//            emailData.Content.Body.Add(plainTextBodyPart);

//            emailData.Content.From = "userrootovich@yahoo.com";
//            emailData.Content.Subject = "Example email";

//            try
//            {
//                return apiInstance.EmailsPost(emailData);
//            }
//            catch (ApiException e)
//            {
//                Console.WriteLine("Exception when calling EmailsApi.EmailsPost: " + e.Message);
//                Console.WriteLine("Status Code: " + e.ErrorCode);
//                Console.WriteLine(e.StackTrace);

//                throw;
//            }
//        }
//    }
//}
