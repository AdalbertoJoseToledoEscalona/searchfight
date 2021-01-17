using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.Domain.Entities
{
    public class SearchEngine
    {
        public int searchEngineID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string httpMethod { get; set; }
        public string httpUrl { get; set; }
        public string httpBody { get; set; }
        public string beginSection { get; set; }
        public string endSection { get; set; }
        public string replaceOldValue { get; set; }
        public string replaceNewValue { get; set; }
        public string patternRegexpExtract { get; set; }
    }
}
