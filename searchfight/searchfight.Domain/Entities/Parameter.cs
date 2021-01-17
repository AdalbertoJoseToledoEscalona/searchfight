using System;
using System.Collections.Generic;
using System.Text;

namespace searchfight.Domain.Entities
{
    public class Parameter
    {
        public int parameterID { get; set; }
        public int searchEngineID { get; set; }
        public int parameterTypeID { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public bool disabled { get; set; }

        public SearchEngine searchEngine { get; set; }
        public ParameterType parameterType { get; set; }
    }
}
