using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tspk_answers.functions
{
    public class Mapping_picture
    {

        public Mapping_picture(JObject task, string path)
        {
            var pros = task["pros"] as JArray;
            var cons = task["cons"] as JArray;

            for(int i = 0; i < pros.Count; i++)
            {
                picturesPath.Add(path + "\\" + ((pros[i].ToString()).Split('/'))[2]);
            }

            for(int i = 0; i < cons.Count; i++)
            {
                answers.Add(cons[i].ToString().Replace("{(rm)}", "(...)"));
            }

        }
        public List<string> picturesPath = new List<string>();
        public List<string> answers = new List<string>();  
    }
}
