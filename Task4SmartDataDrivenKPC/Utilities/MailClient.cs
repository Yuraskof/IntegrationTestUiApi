using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;


namespace Task4SmartDataDrivenKPC.Utilities
{
    public static class MailClient
    {
        public static void GetMessages()
        {
            using (var client = new ImapClient())
            {
                client.Connect("imap.gmail.com", 993, SecureSocketOptions.SslOnConnect);

                client.Authenticate("adressfortests@gmail.com", "lhimrlazbfsnazzt"); 

                var inbox = client.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                //Console.WriteLine("Total messages: {0}", inbox.Count);
                //Console.WriteLine("Recent messages: {0}", inbox.Recent);

                for (int i = inbox.Count-1; i < inbox.Count-5; i--)
                {
                    var message = inbox.GetMessage(i); //.TextBody
                                                     
                }

                client.Disconnect(true);
            }
        }
    }
}
