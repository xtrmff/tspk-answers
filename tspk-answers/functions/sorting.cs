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
    public class Sorting 
    {
        public Sorting(JObject task)
        {
            var Jcolumns = task["columns"] as JArray;
            for(int i = 0; i < Jcolumns.Count; i++)     
                columns.Add(Jcolumns[i]["name"].ToString());
            


            var answers = task["taskColumn"]["answers"] as JArray;

            try
            {
                for (int i = 0; i < answers.Count; i++)
                    rightColumns.Add(new Tuple<string, string>(Utils.ConvertToPlainText(answers[i]["text"].ToString()).Replace("{(rm)}", "(...)"), Utils.ConvertToPlainText(answers[i]["correctColumn"][0].ToString()).Replace("{(rm)}", "(...)")));
                return;
            }
            catch { }

            for(int i = 0; i < answers.Count; i++)
                rightColumns.Add(new Tuple<string, string>(Utils.ConvertToPlainText(answers[i]["text"].ToString()).Replace("{(rm)}", "(...)"), Utils.ConvertToPlainText(answers[i]["correctColumn"].ToString()).Replace("{(rm)}", "(...)")));
            

        }
        public List<string> columns = new List<string>();
        public List<Tuple<string, string>> rightColumns = new List<Tuple<string, string>>();
    }
}
