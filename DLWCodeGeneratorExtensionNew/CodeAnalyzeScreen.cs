﻿using EnvDTE;
using IronPython.Runtime;
using Microsoft.Scripting.Utils;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static IronPython.Modules._ast;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DLWCodeGeneratorExtensionNew
{
    public partial class CodeAnalyzeScreen : UserControl
    {
        public CodeAnalyzeScreen()
        {
            InitializeComponent();
            errorTextBox.Hide();
            ErrorLabel.Hide();
            resetButton.Hide();
            currentProjectText.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
    

        }

        private async void button6_Click(object sender, EventArgs e)
        {
                currentProjectText.Hide();
                progressBar1.Show();
                button6.Enabled = false;
                if (AnalyseModeBox.SelectedIndex.Equals(0))
                {
                    retrieveCurrentProjectSummary();
                }
                else if (AnalyseModeBox.SelectedIndex.Equals(1))
                {
                    await summarizeCurrentWindowsCode();
                }
                else
                {
                    retrieveCurrentProjectSummary();
                }
                button6.Enabled = true;
            
        }
        private async Task summarizeCurrentWindowsCode()
        {
            updateProgressBar2(10);
           
            String classesRetrieved = retrieveCurrentWindowsCode();
            var result = await retrieveCurrentWindowsCodeAnalysisAsync(classesRetrieved);
            this.currentProjectText.Show();
            this.currentProjectText.Text = result;
            updateProgressBar2(100);
        }

        private async Task<String> retrieveCurrentWindowsCodeAnalysisAsync(String classes)
        {
            String textFromResponse = "";
            try
            {
                updateProgressBar2(40);
                var client = new HttpClient();
                var formContent = new MultipartFormDataContent();
                formContent.Add(new StringContent(classes), "classes");
                updateProgressBar2(60);
                var response = await client.PostAsync("https://israilovmpythonapi.azurewebsites.net/windowAnalyzer", formContent);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return "Error in code analysis";
                }
                updateProgressBar2(80);
                var responseStream = await response.Content.ReadAsStreamAsync();
               
                using (var reader = new StreamReader(responseStream))
                {
                    var responseContent = await reader.ReadToEndAsync();
                    var responseObject = JsonConvert.DeserializeObject<string>(responseContent);
                    textFromResponse = responseObject;
                }
            }catch (Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                resetButton.Show();
                errorTextBox.Text = e.Message;
                return "";
            }
            updateProgressBar2(90);
            //addTextToCurrentWindow(textFromResponse);

            
            return textFromResponse;
        }
        public void addTextToCurrentWindow(string text)
        {
            DTE currentDte = Package.GetGlobalService(typeof(DTE)) as DTE;
            if (currentDte.ActiveDocument == null)
            {
                errorTextBox.Show();
                errorTextBox.Text = "You have to select a current document";
            }
            TextDocument activeDoc = currentDte.ActiveDocument.Object() as TextDocument;
            

            activeDoc.Selection.Text ="/*" +text+ "*/" + activeDoc.Selection.Text;

        }

        public String retrieveCurrentWindowsCode()
        {
            DTE currentDte = Package.GetGlobalService(typeof(DTE)) as DTE;
            if (currentDte.ActiveDocument == null) {
                errorTextBox.Show();
                errorTextBox.Text = "You have to select a current document";
                return "You have to select a current document"; }
            TextDocument activeDoc = currentDte.ActiveDocument.Object() as TextDocument;
            
            var text = activeDoc.Selection.Text;
            var documentCollection = currentDte.Documents;
            String classesRetrieved = "";
            foreach (var doc in documentCollection)
            {
                var doc2 = doc as Document;
                String path = doc2.FullName;

                string text2 = File.ReadAllText(path);
                Console.WriteLine(text2);
                classesRetrieved += ("<class: " + doc2.Name + ">\n");
                classesRetrieved += text2;
                classesRetrieved += ("</class:>\n");


            }
            updateProgressBar2(35);
            return classesRetrieved;
        }


        private async void retrieveCurrentProjectSummary()
        {
            try
            {
                
                errorTextBox.Hide();
                ErrorLabel.Hide();
                updateProgressBar2(10);
                String solutionDirectory = retrieveCurrentSolutionDirectory();
                updateProgressBar2(30);
                String projectDirectory = retrieveModelClassesDirectoryPath(solutionDirectory);
                updateProgressBar2(40);
                var classesObject = retrieveAllClassesFromPath(projectDirectory);
                updateProgressBar2(45);
                string modelname = retrieveModelName(solutionDirectory);
                updateProgressBar2(50);
                var result = await retrieveResultFromCodeAnalysisAsync(classesObject, modelname);
                updateProgressBar2(100);
                progressBar1.Hide();
                VS.MessageBox.Show("Code analysis completed", "Code Analysis");

            }
            catch (Exception e)
            {
                button6.Hide();
                errorTextBox.Show();
                ErrorLabel.Show();
                resetButton.Show();
                errorTextBox.Text = e.Message;
            }
        }

        public String retrieveCurrentSolutionDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string solutionName = workingDirectory.Split('\\').Last();
            if(String.IsNullOrEmpty(solutionName))
            {
                new Exception("You have to have an open Solution");
                button6.Hide();
                errorTextBox.Show();
                ErrorLabel.Show();
                resetButton.Show();
                errorTextBox.Text = "You have to have an open Solution";
            }


            return (workingDirectory + "\\" + solutionName + ".sln");
        }
        public String retrieveModelName(String solutionPath)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string solutionTextFile = File.ReadAllText(solutionPath);
            Regex regex = new Regex("\"[^\"\\\\]*\\\\[^\"\\\\]*\\.rnrproj\"");

            Match match = regex.Match(solutionTextFile);
            if(match.Success == false)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = "You have to have a model in your solution";
                new Exception(solutionPath + " does not contain a model");
                return "You have to have a model in your solution";
            }
            
            string result = match.Groups[0].Value.Replace("\"", "");
            String projectFile = workingDirectory + "\\" + result;
            string xmlFile = File.ReadAllText(projectFile);

            XDocument doc = XDocument.Parse(xmlFile);
            XNamespace ns = "http://schemas.microsoft.com/developer/msbuild/2003";
            string modelValue = doc.Descendants(ns + "Model").FirstOrDefault()?.Value;
            return modelValue;
        }
        public String retrieveModelClassesDirectoryPath(String solutionPath)
        {
            string modelValue = retrieveModelName(solutionPath);
            return "C:\\AOSService\\PackagesLocalDirectory\\" + modelValue + "\\" + modelValue + "\\AxClass";

        }
        private ClassesRequestSend retrieveAllClassesFromPath(String path)
        {
            List<String> fileNames = Directory.EnumerateFiles(path).Select(x =>x.ToString().Split('\\').Last().Replace(".xml","")).ToList();
            var files = from file in Directory.EnumerateFiles(path) select file;
            string classes = "";
            ArrayList classesArray = new ArrayList();
            foreach (var file in files)
            {
                if (file.EndsWith(".xml"))
                {
                    classes += ("<class>\n");

                    string classContents = File.ReadAllText(file);
                    classes += classContents;
                    classes += ("</class>\n");
                    classesArray.Add(classes);
                    classes = "";
                }
            }
            ClassesRequestSend classesRequestSend = new ClassesRequestSend();
            classesRequestSend.classes = classesArray;
            classesRequestSend.classNames = fileNames;
            return classesRequestSend;
        }
        private String retrieveCurrentUser()
        {
            return Environment.UserName;
        }

        private async Task<String> retrieveResultFromCodeAnalysisAsync(ClassesRequestSend classesObject, String modelname)
        {
            var json = JsonConvert.SerializeObject(classesObject.classes);
            var jsonClassNames = JsonConvert.SerializeObject(classesObject.classNames);


            var client = new HttpClient();
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(json), "classes");
            formContent.Add(new StringContent(modelname), "projectname");
            formContent.Add(new StringContent(retrieveCurrentUser()), "username");
            formContent.Add(new StringContent(jsonClassNames), "classNames");

            int timeout = 0;
            int characterLength = classesObject.classes.Select(x => x.ToString().Length).Sum();

            for (int i = 0; i < characterLength; i = i + 30000)
            {
                timeout += 125;
            }
            updateProgressBar2(60);
            client.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await client.PostAsync("https://israilovmpythonapi.azurewebsites.net/codeAnalyzer", formContent);
            updateProgressBar2(90);
            String textFromResponse = "";
            var responseStream = await response.Content.ReadAsStreamAsync();
            using (var reader = new StreamReader(responseStream))
            {
                var responseContent = await reader.ReadToEndAsync();
                var responseObject = JsonConvert.DeserializeObject<ResultObject>(responseContent);
                textFromResponse = responseObject.Detailed;
                string textFromResponseSimple = responseObject.Simple;
            }
            return textFromResponse;
        }
        private void updateProgressBar2(int value)
        {

            progressBar1.Value = value;
            progressBar1.Update();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ErrorLabel_Click(object sender, EventArgs e)
        {

        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            errorTextBox.Hide();
            ErrorLabel.Hide();
            updateProgressBar2(0);
            resetButton.Hide();
            button6.Show();
        }
    }
}
