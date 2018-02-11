using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text;

namespace WebApplication2.Library
{
    public static class Network
    {
        private static string API_KEY = "7kfcmynokMoq1AQgKMTMQ9ZBtl5KwcKS";
        private static string BASE_URL = "https://api.neople.co.kr/df/servers";
        private static string SERVER_NAME = "cain";

        private static JObject GetDFJsonResult(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.ContentType = "text/json";
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream recvStream = response.GetResponseStream();
            StreamReader readStream = new StreamReader(recvStream, Encoding.GetEncoding("utf-8"));
            string json = readStream.ReadToEnd();
            JObject Json = JObject.Parse(json);
            return Json;
        }

        public static string GetCharacterID(string CharacterName)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}/{1}/characters?characterName={2}?apikey={3}", BASE_URL, SERVER_NAME, CharacterName, API_KEY);
            JObject ResultJson = GetDFJsonResult(builder.ToString());
            if(ResultJson.Count > 0)
            {
                return ResultJson[0]["characterId"].ToString();
            }

            return null;
        }

        public static JObject GetCharacterInfo(string CharacterID)
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}/{1}/{2}?apikey={3}", BASE_URL, SERVER_NAME, CharacterID, API_KEY);
            JObject ResultJson = GetDFJsonResult(builder.ToString());

            return ResultJson;
        }
    }
}