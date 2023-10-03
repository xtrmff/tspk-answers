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
    public class Radiobutton_text 
    {
        public Radiobutton_text(JObject task)
        {
            JArray answers = task["answers"] as JArray;
            for(int i = 0; i < answers.Count; i++) 
            {
                if (answers[i]["correct"].ToString() == "true")
                {
                    rightAnswer = Utils.ConvertToPlainText(answers[i]["question"].ToString()).Replace("{(rm)}", "(...)");
                    break;
                }
            }
        }
        public string rightAnswer;
    }
}
