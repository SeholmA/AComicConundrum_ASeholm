using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AComicConundrum_ASeholm.Models;
using AComicConundrum_ASeholm.Models.Marvel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Security.Cryptography;
using System.Reflection;

namespace AComicConundrum_ASeholm.Services
{
    public class MarvelComicService
    {
        private string m_strBaseURL = "https://gateway.marvel.com:443/v1/public/";
        private string m_strPrivateAPI = "55c4c5c93bf33b3ac73c8e7bc51f7be5e4c6871c";
        private string m_strPublicAPI = "9a034a32a5eee9afa2d144456108a541";

        static HttpClient client = new HttpClient();


        /// <summary>
        /// Creates the (MD5)Hash value that needs to be added to the
        /// end of the API call and then converts it to a HexValue - private MD5 hashMD5;
        /// </summary>
        /// <param name="data">(timestamp+privateKey+publicKey)</param>
        /// <returns>Hex has value of (timestamp+privateKey+publicKey)</returns>
        public string Hash(string data)
        {
            MD5 md5 = MD5.Create();
            byte[] toBeHashedBytes = Encoding.ASCII.GetBytes(data);
            byte[] hash = md5.ComputeHash(toBeHashedBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }

            return sb.ToString();
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_title"></param>
        /// <param name="_order"></param>
        /// <param name="_limit"></param>
        /// <returns></returns>
        public async Task<Rootobject> GetComicsByTitle(string _title, string _order, string _limit)
        {
            //long unixTimestamp = new DateTimeOffset(DateTime.Now)();
            string _time = "1506630992";//DateTime.Now.ToString();
            string _param = _time + m_strPrivateAPI + m_strPublicAPI;
            string _hash = Hash(_param);

            if(_title == "" || _title == null)
                _title = "Batman";

            string URL = m_strBaseURL + "comics?ts=";
            URL += _time;
            URL += "&noVariants=true";
            URL += "&titleStartsWith=" + _title;
            URL += "&orderBy=" + _order;
            URL += "&limit=" + _limit;
            URL += "&apikey=" + m_strPublicAPI + "&hash=" + _hash;

            String json = String.Empty;
            Uri getComics = new Uri(URL);
            
            using(HttpClient hc = new HttpClient())
                json = await hc.GetStringAsync(getComics).ConfigureAwait(false);
            
            return JsonConvert.DeserializeObject<Rootobject>(json);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="_character"></param>
        /// <param name="_order"></param>
        /// <param name="_limit"></param>
        /// <returns></returns>
        public async Task<Rootobject> GetComicsByCharacter(string _character, string _order, string _limit)
        {
            //long unixTimestamp = new DateTimeOffset(DateTime.Now)();
            string _time = "1506630992";//DateTime.Now.ToString();
            string _param = _time + m_strPrivateAPI + m_strPublicAPI;
            string _hash = Hash(_param);

            if (_character == "" || _character == null)
                _character = "Batman";

            string URL = m_strBaseURL;
            URL += _time;
            URL += "&noVariants=true";
            URL += "&characters=" + _character;
            URL += "&orderBy=" + _order;
            URL += "&limit=" + _limit;
            URL += "&apikey=" + m_strPublicAPI + "&hash=" + _hash;

            String json = String.Empty;
            Uri getComics = new Uri(URL);

            using (HttpClient hc = new HttpClient())
                json = await hc.GetStringAsync(getComics).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Rootobject>(json);
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_creator"></param>
        /// <param name="_order"></param>
        /// <param name="_limit"></param>
        /// <returns></returns>
        public async Task<Rootobject> GetComicsByContributor(string _creator, string _order, string _limit)
        {
            string _time = "1506630992";//DateTime.Now.ToString();
            string _param = _time + m_strPrivateAPI + m_strPublicAPI;
            string _hash = Hash(_param);

            if (_creator == "" || _creator == null)
                _creator = "Batman";

            string URL = m_strBaseURL;
            URL += _time;
            URL += "&noVariants=true";
            URL += "&creators=" + _creator;
            URL += "&orderBy=" + _order;
            URL += "&limit=" + _limit;
            URL += "&apikey=" + m_strPublicAPI + "&hash=" + _hash;

            String json = String.Empty;
            Uri getComics = new Uri(URL);

            using (HttpClient hc = new HttpClient())
                json = await hc.GetStringAsync(getComics).ConfigureAwait(false);

            return JsonConvert.DeserializeObject<Rootobject>(json);
        }
    }
}