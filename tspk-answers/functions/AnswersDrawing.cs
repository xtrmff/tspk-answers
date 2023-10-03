using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace tspk_answers.functions
{
    public class AnswersDrawing
    {
        Form form;
        Panel answerPanel;
        bool drawed = false;
        public AnswersDrawing(Form _this, Panel panel)
        {
            form = _this;
            answerPanel = panel;
        }

        public void drawCheckboxAnswer(Checkbox_text answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            RichTextBox textBox = new RichTextBox
            {
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                BorderStyle = BorderStyle.None,
                BackColor = answerPanel.BackColor,
                ReadOnly = true,
                Size = new Size(700, 300)
            };
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
            textBox.ForeColor = Color.Green;

            foreach(string text in answer.rightAnswers)
                textBox.Text += text + '\n' + '\n';

            flowLayoutPanel.Controls.Add(textBox);
            answerPanel.Controls.Add(flowLayoutPanel);
        }

        public void drawMappingAnswer(Mapping answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true, 
                ColumnCount = 2,
                RowCount = answer.rightSide.Count - 1,
            };
            
            Label leftSide = new Label
            {
                Text = answer.leftSide[0] + "---\n\n",
                Font = new Font(FontFamily.GenericSansSerif, 14),
                AutoSize = true,
                MaximumSize = new Size(700, 500),
                ForeColor = Color.Green,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopRight,
            };
            tableLayoutPanel.Controls.Add(leftSide, 0, 0);

            Label rightSide = new Label
            {
                Text = "---" + answer.rightSide[0] + "\n\n",
                Font = new Font(FontFamily.GenericSansSerif, 14),
                AutoSize = true,
                MaximumSize = new Size(700, 500),
                ForeColor = Color.Green,
                Dock = DockStyle.Fill,
                TextAlign = System.Drawing.ContentAlignment.TopLeft,
            };
            tableLayoutPanel.Controls.Add(rightSide, 1, 0);

            for (int i = 1; i < answer.leftSide.Count; i++)
            {
                Label answLeft = new Label {
                    Text = answer.leftSide[i] + "---\n\n",
                    Font = new Font(FontFamily.GenericSansSerif, 14),
                    AutoSize = true,
                    MaximumSize = new Size(700, 500),
                    ForeColor = Color.Green,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.TopRight,
                };
                tableLayoutPanel.Controls.Add(answLeft, 0, i);
            }
            answerPanel.Controls.Add(tableLayoutPanel);

            for (int i = 1; i < answer.rightSide.Count; i++)
            {
                Label answRight = new Label
                {
                    Text = "---" + answer.rightSide[i] + "\n\n",
                    Font = new Font(FontFamily.GenericSansSerif, 14),
                    AutoSize = true,
                    MaximumSize = new Size(700, 500),
                    ForeColor = Color.Green,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.TopLeft,
                };
                tableLayoutPanel.Controls.Add(answRight, 1, i);
            }
            flowLayoutPanel.Controls.Add(tableLayoutPanel);
            answerPanel.Controls.Add(flowLayoutPanel);

        }
        public void drawMappingPictureAnswer(Mapping_picture answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown, Anchor = AnchorStyles.None, Dock = DockStyle.None };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);

            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = answer.answers.Count,
                RowCount = answer.answers.Count,
                Anchor = AnchorStyles.None,
            };

            for(int i = 0; i < answer.picturesPath.Count; i++)
            {
                PictureBox pictureBox = new PictureBox
                {
                    Image = Image.FromFile(answer.picturesPath[i]),
                    MinimumSize = new Size(200, 200),
                    SizeMode = PictureBoxSizeMode.Zoom,
                };
                tableLayoutPanel.Controls.Add(pictureBox, i, 0);
            }

            for(int i = 0; i < answer.answers.Count; i++)
            {
                Label answ = new Label
                {
                    Text = answer.answers[i],
                    Font = new Font(FontFamily.GenericSansSerif, 16),
                    AutoSize = true,
                    MaximumSize = new Size(700, 500),
                    ForeColor = Color.Green,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                    Anchor = AnchorStyles.None,
                };
                tableLayoutPanel.Controls.Add(answ, i, 1);
            }
            flowLayoutPanel.Controls.Add(tableLayoutPanel);
            answerPanel.Controls.Add(flowLayoutPanel);
        }
        public void drawMenuAnswer(tspk_answers.functions.Menu answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { FlowDirection = FlowDirection.TopDown, AutoSize = true};
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            RichTextBox richTextBox = new RichTextBox
            {
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                BorderStyle = BorderStyle.None,
                BackColor = answerPanel.BackColor,
                ReadOnly = true,
                Dock = DockStyle.Fill,

            };
            for (int i = 0; i < answer.answers.Count; i++)
            {
                string regularText = string.Empty;
                int lastIndex = 0;
                List<int> index = utils.Utils.AllIndexesOf(answer.text[i], "{options_");
                for (int j = 0; j <= index.Count; j++)
                {
                    if (j == index.Count)
                        for (int k = lastIndex; k < answer.text[i].Length; k++)
                            regularText += answer.text[i][k];
                    else
                    {
                        for (int k = lastIndex; k < index[j]; k++)
                            regularText += answer.text[i][k];
                        lastIndex = index[j] + 11;
                    }
                    
                   
                    AppendFormattedText(richTextBox, regularText, Color.Black, false, HorizontalAlignment.Center);
                    if (j != index.Count)
                        AppendFormattedText(richTextBox, " " + answer.answers[i][j] + " ", Color.Green, true, HorizontalAlignment.Center);
                    regularText = string.Empty;
                }
                AppendFormattedText(richTextBox, "\n\n", Color.Black, false, HorizontalAlignment.Center);
            }
            answerPanel.Controls.Add(richTextBox);
        }
        public void drawRadiobuttonAnswer(Radiobutton_text answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            Label answ = new Label
            {
                Text = answer.rightAnswer,
                Font = new Font(FontFamily.GenericSansSerif, 18),
                AutoSize = true,
                MaximumSize = new Size(700, 500),
                ForeColor = Color.Green,
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
            };
            flowLayoutPanel.Controls.Add(answ);
            answerPanel.Controls.Add(flowLayoutPanel);
        }
        public void drawSequenceAnswer(Sequence answer)
        {
           
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            RichTextBox textBox = new RichTextBox
            {
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                BorderStyle = BorderStyle.None,
                BackColor = answerPanel.BackColor,
                ReadOnly = true,
                Size = new Size(700, 300)
            };
            textBox.SelectAll();
            textBox.SelectionAlignment = HorizontalAlignment.Center;
            textBox.ForeColor = Color.Green;

            for (int i = 0; i < answer.rightSequence.Count; i++)
                textBox.Text += i + 1 + ". " + answer.rightSequence[i] + '\n' + '\n';

            flowLayoutPanel.Controls.Add(textBox);
            answerPanel.Controls.Add(flowLayoutPanel);
        }
        public void drawSortingAnswer(Sorting answer)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel { AutoSize = true, FlowDirection = FlowDirection.TopDown };
            flowLayoutPanel.Paint += new PaintEventHandler(FlowLayoutPanel_paint);
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
            {
                AutoSize = true,
                ColumnCount = answer.columns.Count,
               
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset,
            };
            for(int i = 0; i < answer.columns.Count; i++)
            {
                Label title = new Label
                {
                    Text = answer.columns[i],
                    Font = new Font(FontFamily.GenericSansSerif, 16),
                    AutoSize = true,
                    MaximumSize = new Size(700, 500),
                    ForeColor = Color.Green,
                    Dock = DockStyle.Fill,
                    TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                };
                tableLayoutPanel.Controls.Add(title, i, 0);
            }

            for(int i = 0, rowCount = 1; i < answer.columns.Count; i++)
            {
                for (int j = 0; j < answer.rightColumns.Count; j++)
                {
                    if (answer.rightColumns[j].Item2 == answer.columns[i])
                    {
                        Label row = new Label
                        {
                            Text = answer.rightColumns[j].Item1,
                            Font = new Font(FontFamily.GenericSansSerif, 14),
                            AutoSize = true,
                            MaximumSize = new Size(700, 500),
                            ForeColor = Color.Green,
                            Dock = DockStyle.Fill,
                            TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                        };
                        tableLayoutPanel.Controls.Add(row, i, rowCount);
                        rowCount++;
                    }
                }
                rowCount = 1;
            }
            flowLayoutPanel.Controls.Add(tableLayoutPanel);
            answerPanel.Controls.Add(flowLayoutPanel);  
        }
        public void drawTextInAnswer(TextIn answer)
        {
            RichTextBox richTextBox = new RichTextBox
            {
                AutoSize = true,
                Font = new Font(FontFamily.GenericSansSerif, 14),
                BorderStyle = BorderStyle.None,
                BackColor = answerPanel.BackColor,
                ReadOnly = true,
                Dock = DockStyle.Fill
            };
            for (int i = 0; i < answer.answers.Count; i++)
            {
                string regularText = string.Empty;
                int lastIndex = 0;
                List<int> index = utils.Utils.AllIndexesOf(answer.text[i], "{input");
                for (int j = 0; j <= index.Count; j++)
                {
                    if (j == index.Count)
                        for (int k = lastIndex; k < answer.text[i].Length; k++)
                            regularText += answer.text[i][k];
                    else
                    {
                        for (int k = lastIndex; k < index[j]; k++)
                            regularText += answer.text[i][k];
                        lastIndex = index[j] + 9;
                    }


                    AppendFormattedText(richTextBox, regularText, Color.Black, false, HorizontalAlignment.Center);
                    if (j != index.Count)
                        AppendFormattedText(richTextBox, " " + answer.answers[i][j] + " ", Color.Green, true, HorizontalAlignment.Center);
                    regularText = string.Empty;
                }
                AppendFormattedText(richTextBox, "\n\n", Color.Black, false, HorizontalAlignment.Center);
            }
            answerPanel.Controls.Add(richTextBox);
        }

        private void FlowLayoutPanel_paint(object sender, PaintEventArgs e)
        {
            if (!drawed)
            {
                FlowLayoutPanel panel = sender as FlowLayoutPanel;
                panel.Location = new Point((answerPanel.Width - panel.Width) / 2, (answerPanel.Height - panel.Height) / 2);
                drawed = true;
            }

        }
        private void AppendFormattedText(RichTextBox rtb, string text, Color textColor, Boolean isBold, HorizontalAlignment alignment)
        {
            int start = rtb.TextLength;
            rtb.AppendText(text);
            int end = rtb.TextLength; // now longer by length of appended text

            // Select text that was appended
            rtb.Select(start, end - start);

            rtb.SelectionColor = textColor;
            rtb.SelectionAlignment = alignment;
            rtb.SelectionFont = new Font(
                 rtb.SelectionFont.FontFamily,
                 rtb.SelectionFont.Size,
                 (isBold ? FontStyle.Bold : FontStyle.Regular));
           
            // Unselect text
            rtb.SelectionLength = 0;
        }

    }
}
