using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;

namespace MountingEyeCalculator.Models
{
    class ToWord
    {
        private object FileName => Path.Combine(ProgramPath, "Document", "Шаблон.docx");

        string ProgramPath
        {
            get
            {
                string s = Assembly.GetExecutingAssembly().Location;
                FileInfo fi = new FileInfo(s);
                return fi.DirectoryName;
            }
        }



        internal void Words(Dictionary<string, object> dict)
        {
            Word.Application app = new Word.Application();
            try
            {
                var missing = Type.Missing;
                Console.WriteLine(FileName);
                app.Documents.Open(FileName);            
                Word.Find find = app.Selection.Find;
                foreach (string text in dict.Keys) 
                {            
                    find.Text = text;
                    find.Replacement.Text = Convert.ToString(dict[text]);
                    Object wrap = Word.WdFindWrap.wdFindContinue;
                    Object replace = Word.WdReplace.wdReplaceAll;
                    find.Execute(FindText: Type.Missing, 
                    MatchCase: false, 
                    MatchWholeWord: true, 
                    MatchWildcards: false, 
                    MatchSoundsLike: missing,
                    MatchAllWordForms: false, 
                    Forward: true, 
                    Wrap: wrap, 
                    Format: false,
                    ReplaceWith: missing, 
                    Replace: replace);
                }           
                var falePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Ресчет монтажной проушины.docx");
                app.ActiveDocument.SaveAs2000(falePath);
                app.ActiveDocument.Close();
                app.Quit();
                MessageBox.Show("Файл сохранен в " + falePath);
                Process.Start(falePath);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                try
                {
                    app.ActiveDocument.Close();
                    app.Quit();
                    MessageBox.Show("Документ открыт в другом окне\n" + "Закройте документ и попробуйте снова\n", "Ошибка",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    MessageBox.Show(
                        "Шаблон документа не найден!\n" + $"Посмотрите находитmся ли документ по адресу + {FileName}\n" +
                        "Если файл отсутствует просьба обратиться к администратору", "Ошибка", MessageBoxButton.OK,
                        MessageBoxImage.Information);
                    app.Quit();
                }
                
                #region Kill process Word

                //string target_name = "WINWORD";
                //System.Diagnostics.Process[] local_procs = System.Diagnostics.Process.GetProcesses();
                //try
                //{
                //    System.Diagnostics.Process target_proc = local_procs.First(p => p.ProcessName == target_name);
                //    target_proc.Kill();
                //}
                //catch (InvalidOperationException)
                //{
                //    MessageBox.Show("Process " + target_name + " not found!");
                //}        

                #endregion

            }
        }
    }
}
