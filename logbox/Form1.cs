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
using System.Runtime.InteropServices;
using System.Windows.Forms.Design;
using WinFormsLibrary;
using System.Diagnostics;
using static System.Net.Mime.MediaTypeNames;
using System.Security.Cryptography.Xml;

namespace logbox
{
    public partial class Form1 : Form
    {
        labmanager f1;

        public MatchCollection matches;
        public string FileName = "";
        public DialogResult dr;
        public Form1(labmanager f)
        {
            InitializeComponent();
            f1 = f;
            comboBox.Items.Clear();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            comboBox.Items.Add(addBox.Text);
            addBox.Text = "";
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog.Filter = "Text files(*.txt)|*.txt| All files(*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                string FileName = openFileDialog.FileName;
                string FileText = System.IO.File.ReadAllText(FileName);
                showTextBox.Text = FileText;

            }
            catch (Exception ex)
            {
                // Фиксирование исключения на главной форме проекта
                MessageBox.Show(ex.Message);
                // Запись исключения в текстовый файл
                string exceptionText = $"{DateTime.Now}:{ex.InnerException},\n{ex.Message},\n{ex.Source},\n{ex.StackTrace},\n{ex.TargetSite}\n";
                File.AppendAllText("exceptions.txt", exceptionText);

            }
        }

        private void SetSelectionStyle(int address, int len, FontStyle style, Color select_color, RichTextBox source)
        {
            source.Select(address, len);
            source.SelectionFont = new Font(source.SelectionFont, source.SelectionFont.Style | style);
            source.SelectionColor = select_color;
        }

        private async Task SetSelectionStyleAsync(int startIndex, int length, FontStyle style, Color color, RichTextBox richTextBox)
        {
            await Task.Delay(1); // Добавляем задержку для асинхронной обработки

            richTextBox.Invoke((Action)(() =>
            {
                richTextBox.Select(startIndex, length);
                richTextBox.SelectionFont = new Font(richTextBox.Font, style);
                richTextBox.SelectionColor = color;
            }));
        }

        private async void btnHighlight_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedSignature = string.Empty;
                comboBox.Invoke(new Action(() =>
                {
                    selectedSignature = comboBox.Text;
                }));
                ParseIt parseObj = new ParseIt(selectedSignature, showTextBox.Text);
                wordFormBox.Text = "All appearances of " + parseObj.GetSign() + " in text:" + "\r\n";

                await Task.Run(async () =>
                {

                    MatchCollection matches = await FindMatchesAsync(parseObj);

                    if (matches.Count > 0)
                    {
                        foreach (Match match in matches)
                        {
                            wordFormBox.Invoke(new Action(() =>
                            {
                                wordFormBox.Text += "Position: " + (match.Index + 1) + " - " + match.Value + "\r\n";
                            }));
                            
                            await SetSelectionStyleAsync(match.Index, match.Length, FontStyle.Bold, parseObj.GetColor(), showTextBox);
                        }
                    }
                    else
                    {
                        wordFormBox.Invoke(new Action(() =>
                        {
                            wordFormBox.Text = "No matches";
                        }));
                    }
                });
            }
            catch (Exception ex)
            {
                // Обработка исключений
                MessageBox.Show(ex.Message);
                string exceptionText = $"{DateTime.Now}:{ex.InnerException},\n{ex.Message},\n{ex.Source},\n{ex.StackTrace},\n{ex.TargetSite}\n";
                File.AppendAllText("exceptions.txt", exceptionText);
            }
        }

        private async Task<MatchCollection> FindMatchesAsync(ParseIt parseObj)
        {
            return await Task.Run(() =>
            {
                MatchCollection matches = parseObj.parseText();
                return matches;
        });
        }

        private void btnParseLogs_Click(object sender, EventArgs e)
        {
            try
            {
                var swGlobal = new Stopwatch();
                string timeOfWork = "Time status report:\n";
                swGlobal.Start();
                List<String> objCB = comboBox.Items.Cast<String>().ToList();
                wordFormBox.Text = "";
                foreach (string fileName in openFileDialog1.FileNames)
                {
                    var swFile = new Stopwatch();
                    swFile.Start();
                    string FileName = fileName;
                    string FileText = System.IO.File.ReadAllText(FileName);
                    showTextBox.Text = FileText;
                    foreach (string str in objCB)
                    {
                        var sw = new Stopwatch();
                        sw.Start();
                        ParseIt parseObj = new ParseIt(str, showTextBox.Text);
                        wordFormBox.Text += "All appearances of " + parseObj.GetSign() + " in text:" + "\r\n";
                        MatchCollection matches = parseObj.parseText();

                        if (matches.Count > 0)
                        {
                            foreach (Match match in matches)
                            {

                                wordFormBox.Text += "Postion: " + (match.Index + 1) + " - " + match.Value + "\r\n";
                                SetSelectionStyle(match.Index, match.Length, FontStyle.Bold, parseObj.GetColor(), showTextBox);
                            }

                        }
                        else
                        {
                            wordFormBox.Text = "No matches";
                        }
                        sw.Stop();
                        timeOfWork += "End of highlighting " + str + " in " + fileName + " ended in " + sw.Elapsed + "\r\n";

                    }
                    swFile.Stop();
                    timeOfWork += "End of highlighting all signatures in " + fileName + " ended in " + swFile.Elapsed + "\r\n";
                    showTextBox.Text = "";
                    

                }
                swGlobal.Stop();
                timeOfWork += "End of highlighting all signatures in all files ended in " + swGlobal.Elapsed + "\r\n";
                MessageBox.Show(timeOfWork);
            }
            catch (Exception ex)
            {
                // Фиксирование исключения на главной форме проекта
                MessageBox.Show(ex.Message);
                // Запись исключения в текстовый файл
                string exceptionText = $"{DateTime.Now}:{ex.InnerException},\n{ex.Message},\n{ex.Source},\n{ex.StackTrace},\n{ex.TargetSite}\n";
                File.AppendAllText("exceptions.txt", exceptionText);
            }
        }

        private void btnChooseFiles_Click(object sender, EventArgs e)
        {
            try
            {

                openFileDialog1.Filter = "Text files(*.txt)|*.txt| All files(*.*)|*.*";
                
                if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

            }
            catch (Exception ex)
            {
                // Фиксирование исключения на главной форме проекта
                MessageBox.Show(ex.Message);
                // Запись исключения в текстовый файл
                string exceptionText = $"{DateTime.Now}:{ex.InnerException},\n{ex.Message},\n{ex.Source},\n{ex.StackTrace},\n{ex.TargetSite}\n";
                File.AppendAllText("exceptions.txt", exceptionText);

            }
        }

    }
}
