using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WinFormsLibrary;

namespace logbox
{
    public partial class labmanager : Form
    {
        public labmanager()
        {
            InitializeComponent();
            ReadExceptionsFile();
            UpdateLogBox();
        }

        private void ReadExceptionsFile()
        {
            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = Path.GetDirectoryName(Application.ExecutablePath);
            watcher.Filter = "exceptions.txt";
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Changed += (sender, e) =>
            {
                Thread.Sleep(1000);
                using (StreamReader streamReader = new StreamReader("exceptions.txt"))
                {

                    LogBox.Invoke((MethodInvoker)(() =>
                    {
                        LogBox.Text = streamReader.ReadToEnd();
                    }));
                }
            };
            watcher.EnableRaisingEvents = true;
        }

        private void UpdateLogBox()
        {
            using (StreamReader streamReader = new StreamReader("exceptions.txt"))
            {
                LogBox.Text = streamReader.ReadToEnd();
            }
        }

        private void ClearExceptionsFile()
        {
            File.WriteAllText("exceptions.txt", "");
            LogBox.Clear();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            ClearExceptionsFile();
        }

        private void lab1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 lab1 = new Form1(this);
            lab1.Show(this);
        }

        private void btnHighlight_Click(object sender, EventArgs e)
        {
            tableLayoutPanel.Visible = true;
        }

        /*private void SetSelectionStyle(int address, int len, FontStyle style, Color select_color, RichTextBox source)
        {
            source.Select(address, len);
            source.SelectionFont = new Font(source.SelectionFont, source.SelectionFont.Style | style);
            source.SelectionColor = select_color;
        }*/

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

        private async Task<MatchCollection> FindTimeMatchesAsync(timePattern timeObj)
        {
            return await Task.Run(() =>
            {
                MatchCollection matches = timeObj.parseText();
                return matches;
            });
        }

        private async void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                tableLayoutPanel.Visible = false;
                DateTime timeSince = dateSince.Value;
                DateTime timeFor = dateFor.Value;
                string logText = LogBox.Text;
                timePattern timeObj = new timePattern(LogBox.Text, Color.Red);

                MatchCollection matches = await FindTimeMatchesAsync(timeObj);

                foreach (Match match in matches)
                {
                    DateTime time = DateTime.Parse(match.Value);
                    if (time >= timeSince && time <= timeFor)
                    {
                        int startIndex = match.Index;
                        int endIndex = logText.Length;
                        Match nextMatch = match.NextMatch();

                        if (nextMatch.Index != 0)
                        {
                            endIndex = nextMatch.Index;
                        }

                        int strLen = endIndex - startIndex;
                        Regex regexWordForm = new Regex(@"\w*dataGridView\w*");
                        string s = logText.Substring(startIndex, strLen);
                        MatchCollection matchesWord = regexWordForm.Matches(s);
                        if (matchesWord.Count > 0)
                        {
                            foreach (Match matchWord in matchesWord)
                            {
                                await SetSelectionStyleAsync(matchWord.Index + startIndex, matchWord.Length, FontStyle.Bold, Color.Red, LogBox);
                            }
                        }
                    }
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

        private async void btnShowAmount_Click(object sender, EventArgs e)
        {
            string logText = LogBox.Text;
            Dictionary<string, int> formExceptionCounts = new Dictionary<string, int>();
            Dictionary<string, long> formTimeTaken = new Dictionary<string, long>();

            await Task.Run(async () =>
            {
                Regex formRegex = new Regex(@"\w*logbox\\Form\d*\w*");
                Regex timeRegex = new Regex(@"Time taken: (\d+) ms");

                MatchCollection formMatches = formRegex.Matches(logText);

                foreach (Match formMatch in formMatches)
                {
                    string formName = formMatch.Value;
                    await SetSelectionStyleAsync(formMatch.Index, formMatch.Length, FontStyle.Underline, Color.DarkRed, LogBox);

                    int formStartIndex = formMatch.Index;
                    int formEndIndex = formStartIndex + formMatch.Length;
                    Match timeMatch = timeRegex.Match(logText, formEndIndex);

                    if (timeMatch.Success)
                    {
                        long time = long.Parse(timeMatch.Groups[1].Value);
                        formTimeTaken[formName] = time;
                    }
                    if (formExceptionCounts.ContainsKey(formName))
                    {
                        formExceptionCounts[formName]++;
                    }
                    else
                    {
                        formExceptionCounts[formName] = 1;
                    }
                }
            });

            string message = "Form exceptions and time taken:\n";

            foreach (var kvp in formExceptionCounts)
            {
                string formName = kvp.Key;
                int exceptionCount = kvp.Value;
                long timeTaken = formTimeTaken.ContainsKey(formName) ? formTimeTaken[formName] : 0;

                message += $"{formName} - Exceptions: {exceptionCount}, Time taken: {timeTaken} ms\n";
            }

            MessageBox.Show(message);
        }
    }
}


