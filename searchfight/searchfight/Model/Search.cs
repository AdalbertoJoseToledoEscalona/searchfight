using searchfight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.IO;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace searchfight.Model
{
    public class Search : ISearch
    {
        public SearchEngine searchEngine { get; set; }
        public long results { get; set; }

        public Search(SearchEngine searchEngine)
        {
            this.searchEngine = searchEngine;
        }

        public long Execute(string arg, IQueryable<Parameter> parameters, IQueryable<ParameterType> parameterTypes)
        {
            string responseString = ""; 

            string httpUrl = searchEngine.httpUrl;

            int parameterTypeID = parameterTypes.Where(y => y.name.Equals("uri") && y.disabled == false).Select(y => y.parameterTypeID).FirstOrDefault();
            var uris = parameters.Where(x => x.searchEngineID == searchEngine.searchEngineID && x.parameterTypeID == parameterTypeID && x.disabled == false);
            foreach (var item in uris)
            {
                string value = string.IsNullOrEmpty(item.value.Replace(" ", "+")) ? arg.Replace(" ", "+") : item.value;
                httpUrl.Replace("{" + item.name + "}", item.value);
            }

            parameterTypeID = parameterTypes.Where(y => y.name.Equals("query") && y.disabled == false).Select(y => y.parameterTypeID).FirstOrDefault();
            var queries = parameters.Where(x => x.searchEngineID == searchEngine.searchEngineID && x.parameterTypeID == parameterTypeID && x.disabled == false);
            foreach (var item in queries)
            {
                string value = string.IsNullOrEmpty(item.value) ? arg.Replace(" ", "+") : item.value;
                if (httpUrl.Contains('?'))
                {
                    httpUrl += "&" + item.name + "=" + value;
                }
                else
                {
                    httpUrl += "?" + item.name + "=" + value;
                }
            }

            var request = (HttpWebRequest)WebRequest.Create(httpUrl);
            request.Method = searchEngine.httpMethod;

            parameterTypeID = parameterTypes.Where(y => y.name.Equals("header") && y.disabled == false).Select(y => y.parameterTypeID).FirstOrDefault();
            var headers = parameters.Where(x => x.searchEngineID == searchEngine.searchEngineID && x.parameterTypeID == parameterTypeID && x.disabled == false);
            foreach (var item in headers)
            {
                string value = string.IsNullOrEmpty(item.value) ? arg : item.value;
                request.Headers[item.name] = value;
            }

            if (searchEngine.httpBody != null) {
                var data = Encoding.ASCII.GetBytes(searchEngine.httpBody);
                request.ContentLength = data.Length;
                using (var stream = request.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();
            using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
            using (StreamReader responseReader = new StreamReader(webStream))
            {
                string response = responseReader.ReadToEnd();
                //Console.Out.WriteLine(response);
                responseString += response;
            }

            if (!string.IsNullOrEmpty(searchEngine.beginSection)) { 
                responseString = responseString.Substring(responseString.IndexOf(searchEngine.beginSection) + searchEngine.beginSection.Length);
            }

            if (!string.IsNullOrEmpty(searchEngine.endSection))
            {
                responseString = responseString.Substring(0, responseString.IndexOf(searchEngine.endSection));
            }

            if (!string.IsNullOrEmpty(searchEngine.patternRegexpExtract))
            {
                string pattern = searchEngine.patternRegexpExtract; // continue the pattern for your needs
                Regex rx = new Regex(pattern);

                Match m = rx.Match(responseString);

                responseString = m.Value;
            }

            if (!string.IsNullOrEmpty(searchEngine.replaceOldValue))
            {
                responseString = responseString.Replace(searchEngine.replaceOldValue, searchEngine.replaceNewValue);
            }

            long r = 0;
            long.TryParse(responseString, out r);
            this.results = r;

            return this.results;
        }
    }
}
