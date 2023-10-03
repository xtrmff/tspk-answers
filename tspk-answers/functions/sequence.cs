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
    public class Sequence
    {
        public Sequence(JObject task)
        {
           var answers = task["answers"] as JArray;
           for(int i = 0; i < answers.Count; i++)
           {
                rightSequence.Add(Utils.ConvertToPlainText(answers[i].ToString()).Replace("{(rm)}", "(...)"));
           }
        }
        public List<string> rightSequence = new List<string>();
    }
}
