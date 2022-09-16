using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Task4SmartDataDrivenKPC.Constants;
using Task4SmartDataDrivenKPC.Models;


namespace Task4SmartDataDrivenKPC.Utilities
{
    public static class MailClient
    {
        private static readonly ImapConfig imapConfig = FileReader.ReadJsonData<ImapConfig>(ProjectConstants.PathToImapConfig);

        public static void GetMessages()
        {
            using (var client = new ImapClient())
            {
                client.Connect(imapConfig.host, Convert.ToInt32(imapConfig.port), SecureSocketOptions.SslOnConnect);

                client.Authenticate(imapConfig.Email, imapConfig.MailPassword); 

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                //Console.WriteLine("Total messages: {0}", inbox.Count);
                //Console.WriteLine("Recent messages: {0}", inbox.Recent);

                for (int i = inbox.Count-1; i > inbox.Count-5; i--)
                {
                    var message = inbox.GetMessage(i); //.TextBody
                                                     
                }

                client.Disconnect(true);
            }
        }
    }
}
