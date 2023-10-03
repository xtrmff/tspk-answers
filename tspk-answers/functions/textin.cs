using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using HtmlAgilityPack;
using System.IO;

namespace tspk_answers.functions
{
    public class TextIn 
    {
        
        public TextIn(JObject task)
        {
            var content = task["content"] as JArray;
            for(int i = 0; i < content.Count; i++) 
            {
                text.Add(utils.Utils.ConvertToPlainText(content[i]["text"].ToString()).Replace("{(rm)}", "(...)"));

                var JAnswers = content[i]["answers"] as JArray;
                List<string> answer = new List<string>();
                for(int j = 0; j < JAnswers.Count; j++)
                {
                    answer.Add(utils.Utils.ConvertToPlainText(JAnswers[j].ToString()).Replace("{(rm)}", "(...)"));
                }
                answers.Add(answer);

            }
           
        }

        public List<string> text = new List<string>();
        public List<List<string>> answers = new List<List<string>>();
    }
}
