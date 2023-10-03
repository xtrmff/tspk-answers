using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Xml;
using tspk_answers.functions;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace tspk_answers
{
    public partial class mainForm : Form
    {
        static string filePath;
        public mainForm()
        {
            InitializeComponent();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {

        }

        private void fileChooseBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog.SelectedPath);
                foreach (string file in files)
                {
                    if (file.Contains("moduleData.js"))
                    {
                        filePath = file;
                        break;
                    }

                }

                StreamReader reader = new StreamReader(filePath);
                string input = reader.ReadToEnd();
                reader.Close();
                input = input.Remove(0, 17);
                input = input.Remove(input.Length-1, 1);
                JObject moduleData = JsonConvert.DeserializeObject<JObject>(input);
                tspk_answers.functions.Task task = new tspk_answers.functions.Task(moduleData);
                this.Hide();
                for (int i = 0; i < task.typeList.Count; i++)
                {
                    switch (task.typeList[i]) 
                    {
                        case TaskType.Checkbox_text:
                            var checkBoxArray = moduleData["questions"] as JArray;
                            Checkbox_text checkBoxAnswer = new Checkbox_text(checkBoxArray[i] as JObject);
                            answersForm checkboxForm = new answersForm(task.typeList.Count, i, checkBoxAnswer);
                            DialogResult checkboxFormDialogResult = checkboxForm.ShowDialog();
                            if (checkboxFormDialogResult == DialogResult.OK)
                                i = checkboxForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Mapping:
                            var mappingArray = moduleData["questions"] as JArray;
                            Mapping mappingAnswer = new Mapping(mappingArray[i] as JObject);
                            answersForm mappingForm = new answersForm(task.typeList.Count, i, mappingAnswer);
                            DialogResult mappingFormDialogResult = mappingForm.ShowDialog();
                            if (mappingFormDialogResult == DialogResult.OK)
                                i = mappingForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Mapping_picture:
                            var mapping_pictureArray = moduleData["questions"] as JArray;
                            Mapping_picture mapping_PictureAnswer = new Mapping_picture(mapping_pictureArray[i] as JObject, folderBrowserDialog.SelectedPath);
                            answersForm mappingPictureForm = new answersForm(task.typeList.Count, i, mapping_PictureAnswer);
                            DialogResult mappingPictureDialogResult = mappingPictureForm.ShowDialog();
                            if (mappingPictureDialogResult == DialogResult.OK)
                                i = mappingPictureForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Menu:
                            var menuArray = moduleData["questions"] as JArray;
                            tspk_answers.functions.Menu menuAnswer = new tspk_answers.functions.Menu(menuArray[i] as JObject);
                            answersForm menuForm = new answersForm(task.typeList.Count, i, menuAnswer);
                            DialogResult menuDialogResult = menuForm.ShowDialog();
                            if (menuDialogResult == DialogResult.OK)
                                i = menuForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Radiobutton_text:
                            var radioButtonArray = moduleData["questions"] as JArray;
                            Radiobutton_text radioButtonAnswer = new Radiobutton_text(radioButtonArray[i] as JObject);
                            answersForm radioButtonForm = new answersForm(task.typeList.Count, i, radioButtonAnswer);
                            DialogResult radioButtonDialogResult = radioButtonForm.ShowDialog();
                            if (radioButtonDialogResult == DialogResult.OK)
                                i = radioButtonForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Sequence:
                            var sequenceArray = moduleData["questions"] as JArray;
                            Sequence sequenceAnswer = new Sequence(sequenceArray[i] as JObject);
                            answersForm sequenceForm = new answersForm(task.typeList.Count, i, sequenceAnswer);
                            DialogResult sequenceDialogResult = sequenceForm.ShowDialog();
                            if (sequenceDialogResult == DialogResult.OK)
                                i = sequenceForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.Sorting:
                            var sortingArray = moduleData["questions"] as JArray;
                            Sorting sortingAnswer = new Sorting(sortingArray[i] as JObject);
                            answersForm sortingForm = new answersForm(task.typeList.Count, i, sortingAnswer);
                            DialogResult sortingDialogResult = sortingForm.ShowDialog();
                            if (sortingDialogResult == DialogResult.OK)
                                i = sortingForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;

                        case TaskType.TextIn:
                            var textInArray = moduleData["questions"] as JArray;
                            TextIn textInAnswer = new TextIn(textInArray[i] as JObject);
                            answersForm textInForm = new answersForm(task.typeList.Count, i, textInAnswer);
                            DialogResult textInFormDialogResult = textInForm.ShowDialog();
                            if (textInFormDialogResult == DialogResult.OK)
                                i = textInForm.newCurrentTask - 1;
                            else
                                i = task.typeList.Count;
                        break;


                        case TaskType.None:

                        break;
                    }
                }
                this.Show();
                
            }
        }
        private void sayThankTaxtBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://qiwi.com/n/HIPAC407 ");
        }
    }
}
