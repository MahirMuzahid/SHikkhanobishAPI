using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using  OpenTokSDK;

namespace SHikkhanobishAPI.Models.Shikkhanobish
{
    public class VideoCallAPiMaker
    {
        public static int Apikey = 47280234;
        public static string ApiSecret = "4e676881b8e2f122f648ba65a2b761840fb55422";
        public static Session Session { get; protected set; }
        public static string Token { get; protected set; }
        public OpenTok OpenTok { get; protected set; }
        public VideoCallAPiMaker()
        {
            int apiKey = 0;
            string apiSecret = null;
            try
            {
                apiSecret = ApiSecret;
                apiKey = Apikey;
            }

            catch (Exception ex)
            {
                if (!(ex is ConfigurationErrorsException || ex is FormatException || ex is OverflowException))
                {
                    throw ex;
                }
            }

            finally
            {
                if (apiKey == 0 || apiSecret == null)
                {
                    Console.WriteLine(
                        "The OpenTok API Key and API Secret were not set in the application configuration. " +
                        "Set the values in App.config and try again. (apiKey = {0}, apiSecret = {1})", apiKey, apiSecret);
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            this.OpenTok = new OpenTok(apiKey, apiSecret);

            Session = this.OpenTok.CreateSession();
            Token = this.OpenTok.GenerateToken(Session.Id);
        }
    }
}