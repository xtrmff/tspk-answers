using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tspk_answers.functions
{
    public class Menu
    {
        public Menu(JObject task)
        {
            var content = task["content"] as JArray;
            

            for(int i = 0; i < content.Count; i++)
            {
                text.Add(content[i]["text"].ToString());
                var options = content[i]["options"] as JArray;
                List<string> answer = new List<string>();  
                for(int j = 0 ; j < options.Count; j++)
                {
                    answer.Add(options[j][0].ToString().Replace("{(rm)}", "(...)"));
                }
                answers.Add(answer);
            }
        }
        public List<string> text = new List<string>();
        public List<List<string>> answers = new List<List<string>>();
    }
}
