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
    public enum TaskType
    {
        None,
        Checkbox_text,
        Mapping,
        Mapping_picture,
        Menu,
        Radiobutton_text,
        Sequence,
        Sorting,
        TextIn
        
    }

    public class Task
    {
        public Task(JObject data)
        {
            moduleData = data;
            questionCount = Utils.AllIndexesOf(moduleData.ToString(), "answers").Count;

            var jArray = moduleData["questions"] as JArray;
            for(int i = 0; i < jArray.Count; i++)
            {
                string type = jArray[i]["typeTest"].ToString();
                switch(type)
                {
                    case "checkbox_text":
                        typeList.Add(TaskType.Checkbox_text);
                    break;

                    case "mapping":
                        typeList.Add(TaskType.Mapping);
                    break;

                    case "radiobutton_text":
                        typeList.Add(TaskType.Radiobutton_text);
                    break;

                    case "sequence":
                        typeList.Add(TaskType.Sequence);
                    break;

                    case "sorting":
                        typeList.Add(TaskType.Sorting);
                    break;

                    case "textin":
                        typeList.Add(TaskType.TextIn);
                    break;

                    case "menu":
                        typeList.Add(TaskType.Menu);
                    break;

                    case "mapping_picture":
                        typeList.Add(TaskType.Mapping_picture);
                    break;

                    default:
                        typeList.Add(TaskType.None);   
                    break;
                }
            }
        }

        public Checkbox_text GetCheckboxAnswer()
        {
            return null;
        }
        public Mapping GetMappingAnswer()
        {
            return null;
        }
        public Radiobutton_text GetRadiobuttonAnswer()
        {
            return null;
        }
        public Sequence GetSequenceAnswer()
        {
            return null;
        }
        public Sorting GetSortingAnswer()
        {
            return null;
        }
        public TextIn GetTextInAnswer()
        {
            return null;
        }

        public readonly List<TaskType> typeList = new List<TaskType>();
        public JObject moduleData { get; }
        public int questionCount { get; }
    }
}
