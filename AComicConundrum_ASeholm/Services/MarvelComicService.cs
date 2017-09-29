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
        //private string m_strApiURL = ConfigurationManager.AppSettings["9a034a32a5eee9afa2d144456108a541"]; //??? private string _key = ConfigurationManager.AppSettings["APIAppKey"];
                                                                                                           //var url = "http://gateway.marvel.com/v1/public/comics?limit=100&format=comic&formatType=comic&dateRange="+year+"-01-01%2C"+year+"-12-31&apikey="+KEY;
        private string m_strBaseURL = "https://gateway.marvel.com:443/v1/public/comics?ts=";
        private string m_strPrivateAPI = "55c4c5c93bf33b3ac73c8e7bc51f7be5e4c6871c";
        private string m_strPublicAPI = "9a034a32a5eee9afa2d144456108a541";
        private MD5 hashMD5;

        static HttpClient client = new HttpClient();


        /// <summary>
        /// Creates Hash and convers to hex
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static String GetHash<T>(Stream stream) where T : HashAlgorithm
        {
            StringBuilder sb = new StringBuilder();

            MethodInfo create = typeof(T).GetMethod("Create", new Type[] { });
            using (T crypt = (T)create.Invoke(null, null))
            {
                byte[] hashBytes = crypt.ComputeHash(stream);
                foreach (byte bt in hashBytes)
                {
                    sb.Append(bt.ToString("x2"));
                }
            }
            return sb.ToString();
        }

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

        public async Task<IEnumerable<Comic>> GetComics(int _iNoVariants = -1, string _strDateDescriptor = "", string _strTitle = "", int _iIssueNumber = -1,
                                                        string _strCreators = "", string _strOrderBy = "", int _iLimit = 1, int _iOffset = -1)
        {
            string URL = m_strBaseURL;

            //NoVariants
            if (_iNoVariants == 0)
                URL += "noVariants=false";
            else if (_iNoVariants == 1)
                URL += "noVariants=true";

            //Date Descriptor
            if (_strDateDescriptor != "")
                URL += "&dateDescriptor="+_strDateDescriptor;

            //Title
            if (_strTitle != "")
            {
                //TODO: Add title parse logic
                URL += "&title=";
            }

            //Issue Number
            if (_iIssueNumber != -1)
                URL += "&issueNumber="+_iIssueNumber;

            //Creators
            if(_strCreators != "")
            {
                //TODO: Add list parse logic
                URL += "&creators=";
            }

            //Characters

            //OrderBy
            if (_strOrderBy != "")
                URL += "&orderBy="+_strOrderBy;

            //Limit
            if (_iLimit > 100)
                URL += "&limit=100";
            else if(_iLimit < 1)
                URL += "&limit=1";
            else
                URL += "&limit=" + _iLimit;

            //Offset
            if (_iOffset > 0)
                URL += "&offset="+_iOffset;

            //TODO - ADD API KEY


            //Perform calls to get the comics
            String json = String.Empty;
            Uri getComics = new Uri(URL);

            using (HttpClient client = new HttpClient())
                json = await client.GetStringAsync(getComics).ConfigureAwait(false); //???

            IEnumerable<Comic> comics = JsonConvert.DeserializeObject<IEnumerable<Comic>>(json);
            return comics;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="_strTitle"></param>
        /// <returns></returns>
        public async Task<Rootobject> GetComicsByTitle(string _strTitle)
        {
            //long unixTimestamp = new DateTimeOffset(DateTime.Now)();
            string _time = "1506630992";//DateTime.Now.ToString();
            string _param = _time + m_strPrivateAPI + m_strPublicAPI;
            string _hash = Hash(_param);

            string URL = m_strBaseURL;
            URL += _time;
            URL += "&noVariants=true";
            URL += "&title=Spider-man";
            URL += "&orderBy=-title";
            URL += "&limit=22";
            URL += "&apikey=" + m_strPublicAPI + "&hash=" + _hash;
            //TODO: Add title parse logic
            /*if (_strTitle != "")
            {
                URL += "&title=";
            }*/
            String json = String.Empty;
            Uri getComics = new Uri(URL);

            /*using (HttpClient client = new HttpClient())
                json = await client.GetStringAsync(getComics).ConfigureAwait(false); //???*/

            //IEnumerable<Comic> comics = JsonConvert.DeserializeObject<IEnumerable<Comic>>(json);
            using(HttpClient hc = new HttpClient())
                json = await client.GetStringAsync(getComics).ConfigureAwait(false);
            
            return JsonConvert.DeserializeObject<Rootobject>(json);
            /*JArray comicParse = JArray.Parse(json);
            IEnumerable<Comic> comics = comicParse.Select(x => new Models.Comic
            {

            });*/


            //return data;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Comic>> GetComicsByIssue(int _iIssue)
        {
            Uri getComics = new Uri(m_strBaseURL + @"" + _iIssue);
            String json = String.Empty;

            using (HttpClient client = new HttpClient())
                json = await client.GetStringAsync(getComics).ConfigureAwait(false); //???

            IEnumerable<Comic> comics = JsonConvert.DeserializeObject<IEnumerable<Comic>>(json);
            return comics;
        }

        
        /// <summary>
        /// 
        /// </summary>
        public async Task<IEnumerable<Comic>> GetComicsByPublisher(string _strPublisher)
        {
            Uri getComics = new Uri(m_strBaseURL + @"" + _strPublisher);
            String json = String.Empty;

            using (HttpClient client = new HttpClient())
                json = await client.GetStringAsync(getComics).ConfigureAwait(false); //???

            IEnumerable<Comic> comics = JsonConvert.DeserializeObject<IEnumerable<Comic>>(json);
            return comics;
        }
    }
}