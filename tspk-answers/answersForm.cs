using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tspk_answers.functions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace tspk_answers
{
    public partial class answersForm : Form 
    {
        int taskCount;
        int currentTask;
        public int newCurrentTask = 0;
        public answersForm()
        {
            InitializeComponent();
        }

        public answersForm(int count, int current, Checkbox_text answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawCheckboxAnswer(answer);
        }
        public answersForm(int count, int current, Mapping answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawMappingAnswer(answer);
        }
        public answersForm(int count, int current, Mapping_picture answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawMappingPictureAnswer(answer);
        }
        public answersForm(int count, int current, tspk_answers.functions.Menu answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawMenuAnswer(answer);
        }
        public answersForm(int count, int current, Radiobutton_text answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawRadiobuttonAnswer(answer);
        }
        public answersForm(int count, int current, Sequence answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawSequenceAnswer(answer);
        }
        public answersForm(int count, int current, Sorting answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawSortingAnswer(answer);
        }
        public answersForm(int count, int current, TextIn answer)
        {
            init(count, current);
            AnswersDrawing drawing = new AnswersDrawing(this, answerPanel);
            drawing.drawTextInAnswer(answer);
        }
        private void init(int count, int current)
        {
            InitializeComponent();
            taskCount = count;
            currentTask = current;
            drawButtons();
        }


        private void drawButtons()
        {
            Panel panel = new Panel
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
            };
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel 
            {
                AutoSize = true,
                AutoSizeMode = AutoSizeMode.GrowAndShrink,
                Dock = DockStyle.Fill,
                WrapContents = false,
            };


            for (int i = 0; i < taskCount; i++)
            {
                Button taskSwitcher = new Button
                {
                    Name = "task" + i,
                    Tag = i,
                    Size = new Size(25, 25),
                    TabIndex = i,
                    FlatStyle = FlatStyle.Flat
                };

                if (i == currentTask)
                    taskSwitcher.BackColor = Color.Green;
                else
                    taskSwitcher.BackColor = Color.LightGray;
                taskSwitcher.Click += new EventHandler(taskSwitcher_click);
                taskSwitcher.FlatAppearance.BorderSize = 0;

                flowLayoutPanel.Controls.Add(taskSwitcher);
            }
            
            panel.Controls.Add(flowLayoutPanel);
            panel.Paint += new PaintEventHandler(buttonPanel_Paint);
            this.Controls.Add(panel);
           
        }

        private void taskSwitcher_click(object sender, EventArgs e)
        {
           
            Button btn = sender as Button;
            newCurrentTask = Convert.ToInt32(btn.Tag);
            this.DialogResult = DialogResult.OK;
        }

        private void buttonPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            panel.Location = new Point((this.Size.Width - panel.Size.Width) / 2, this.Size.Height - 80);
        }
    }
}
