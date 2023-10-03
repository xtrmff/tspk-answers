using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tspk_answers.utils;

namespace tspk_answers.functions
{
    public class Checkbox_text 
    {
        public Checkbox_text(JObject task) 
        {
            var answers = task["answers"] as JArray;

            for(int i = 0; i < answers.Count; i++)
            {
                if (answers[i]["correct"].ToString() == "true") 
                {
                    rightAnswers.Add(Utils.ConvertToPlainText(answers[i]["question"].ToString()).Replace("{(rm)}", "(...)"));
                }
            }
        }
        public List<string> rightAnswers = new List<string>();            
      
    }
}
