using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tspk_answers.utils;

namespace tspk_answers.functions
{
    public class Mapping
    {
        public Mapping(JObject task)
        {
            var leftSideArray = task["pros"] as JArray;
            var rightSideArray = task["cons"] as JArray;

            for(int i = 0; i < leftSideArray.Count; i++)
                leftSide.Add(Utils.ConvertToPlainText(leftSideArray[i].ToString()).Replace("{(rm)}", "(...)"));
            

            for (int i = 0; i < rightSideArray.Count; i++)
                rightSide.Add(Utils.ConvertToPlainText(rightSideArray[i].ToString()));
           
        }

        public List<string> rightSide = new List<string>();
        public List<string> leftSide = new List<string>();
    }
}
