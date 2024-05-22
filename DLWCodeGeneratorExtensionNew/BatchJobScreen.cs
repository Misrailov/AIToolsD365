using Community.VisualStudio.Toolkit;
using EnvDTE;
using IronPython.Compiler.Ast;
using Microsoft.VisualStudio.Package;
using Microsoft.VisualStudio.Text.Editor.Commanding.Commands;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using static IronPython.Modules.PythonCsvModule;
using static Microsoft.VisualStudio.Shell.ThreadedWaitDialogHelper;

namespace DLWCodeGeneratorExtensionNew
{
    public partial class BatchJobScreen : UserControl
    {
        //private string uri = "https://israilovmpythonapi.azurewebsites.net/";
        private string uri = "http://localhost:8000/";
        public BatchJobScreen()
        {
            InitializeComponent();
            errorTextBox.Hide();
            ErrorLabel.Hide();
            resetButton.Hide();
        }

        public String RetrievePath()
        {
            try
            {
                String solutionDirectory = retrieveCurrentSolutionDirectory();

                String projectDirectory = retrieveModelClassesDirectoryPath(solutionDirectory);
                return projectDirectory;


            }
            catch (Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = e.Message;
                return null;
            }
        }
        public String retrieveCurrentSolutionDirectory()
        {
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string solutionName = workingDirectory.Split('\\').Last();
                if (String.IsNullOrEmpty(solutionName))
                {
                    new Exception("You have to have an open Solution");
                    button6.Hide();
                    errorTextBox.Show();
                    ErrorLabel.Show();
                    resetButton.Show();
                    errorTextBox.Text = "You have to have an open Solution";
                }


                return (workingDirectory + "\\" + solutionName + ".sln");
            }catch(Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = e.Message;
                return null;
            }
        
        }
        public String retrieveModelName(String solutionPath)
        {
            try
            {
                string workingDirectory = Environment.CurrentDirectory;
                string solutionTextFile = File.ReadAllText(solutionPath);
                Regex regex = new Regex("\"[^\"\\\\]*\\\\[^\"\\\\]*\\.rnrproj\"");

                Match match = regex.Match(solutionTextFile);
                if (match.Success == false)
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
            }catch(Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = e.Message;
                return null;
            }
        }
        public String retrieveModelClassesDirectoryPath(String solutionPath)
        {
            try
            {
                string modelValue = retrieveModelName(solutionPath);
                return "C:\\AOSService\\PackagesLocalDirectory\\" + modelValue + "\\" + modelValue + "\\AxClass";
            }catch(Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = e.Message;
                return null;
            }

        }

        private async Task<Stream> retrieveProjects()
        {
            var client = new HttpClient();
            var formContent = new MultipartFormDataContent();
            var response = await client.GetAsync("http://127.0.0.1:8000/retrieveResults");
            return await response.Content.ReadAsStreamAsync();
        }

        private async Task<Stream> RetrieveGeneratedBatchJobsMessageContentStream()
        {
            try
            {
                if(batchJobFunctionText.Text == "")
                {
                    errorTextBox.Show();
                    ErrorLabel.Show();
                    button6.Hide();
                    errorTextBox.Text = "You have to enter a function name";
                    return null;
                }
                var client = new HttpClient();
                var formContent = new MultipartFormDataContent();
                formContent.Add(new StringContent(batchJobFunctionText.Text), "description");
                string uriToRequest = uri + "batchjobgenerator";
                var response = await client.PostAsync(uriToRequest, formContent);
                return await response.Content.ReadAsStreamAsync();
            }catch(Exception e)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = e.Message;
                return null;
            }
        }


        public void SuccesfulBatchJob(){
            UpdateProgressBar(100);
            System.Threading.Thread.Sleep(200);
            progressBar1.Hide();

            VS.MessageBox.Show("Batch Job Successful");
            
        }
        public void UpdateProgressBar(int progress){
            progressBar1.Value = progress;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ExecuteFunction();
        }

        public void createXmlFileAtPath(string path,string className, string xmlFile)
        {
            FileInfo fi = new FileInfo(path +"\\" +className+ ".xml");
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }

            if (!fi.Exists)
            {
                fi.Create().Dispose();
            }
            File.WriteAllText(path + "\\"+ className + ".xml", xmlFile);
            

        }

        private void AddClassLinkToProject(string className)
        {
            var doc = new XmlDocument();
            string solutionPath = retrieveCurrentSolutionDirectory();
            string workingDirectory = Environment.CurrentDirectory;
            string solutionTextFile = File.ReadAllText(solutionPath);
            Regex regex = new Regex("\"[^\"\\\\]*\\\\[^\"\\\\]*\\.rnrproj\"");

            Match match = regex.Match(solutionTextFile);
            if (match.Success == false)
            {
                errorTextBox.Show();
                ErrorLabel.Show();
                button6.Hide();
                errorTextBox.Text = "You have to have a model in your solution";
                new Exception(solutionPath + " does not contain a model");
                return;
            }

            string result = match.Groups[0].Value.Replace("\"", "");
            String projectFile = workingDirectory + "\\" + result;
            string xmlFile = File.ReadAllText(projectFile);
            doc.Load(projectFile);


            XmlElement root = doc.DocumentElement;
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("msb", "http://schemas.microsoft.com/developer/msbuild/2003");

            // check if a node with Content Include already exists
            bool nodeExists = false;
            XmlNodeList contentNodes = doc.SelectNodes("//msb:ItemGroup/msb:Content/msb:Name", nsmgr);
            foreach (XmlNode node in contentNodes)
            {
                if (node.InnerText == className)
                {
                    nodeExists = true;
                    break;
                }
            }

            // if node with Content Include exists, add a new class node
            if (!nodeExists)
            {
                XmlNodeList nodeList = doc.SelectNodes("//msb:ItemGroup", nsmgr);
               
                foreach (XmlNode node in nodeList)
                {
                    if(node.InnerXml.Contains("Content") == true)
                    {
                        XmlNode newNode = doc.CreateElement("Content");
                        XmlAttribute subType = doc.CreateAttribute("Include");
                        
                        subType.Value = "AxClass\\" + className;
                        newNode.Attributes.Append(subType);
                        XmlElement name = doc.CreateElement("Name");
                        name.InnerText = className;
                        newNode.AppendChild(name);
                        XmlElement link = doc.CreateElement("Link");
                        link.InnerText = "Classes\\" + className;
                        newNode.AppendChild(link);
                        node.AppendChild(newNode);
                    }

                }
                doc.Save(projectFile);
            }


        }

        private async Task addClassesFromMongoToProject()
        {
            var responseStream = await retrieveProjects();
            using (var reader = new StreamReader(responseStream))
            {
                var responseContent = await reader.ReadToEndAsync();

                var responseObject = JsonConvert.DeserializeObject<GetProjectsResult>(responseContent);

                
                string path = RetrievePath();
                List<ProjectMongo> projects = responseObject.results;
                for (int i = 0; i < projects.Count; i++)
                {
                    createXmlFileAtPath(path, projects[i].category +"_" + projects[i].model+ "_"+ projects[i].size, projects[i].xml_result );
                    AddClassLinkToProject(projects[i].category + "_" + projects[i].model + "_" + projects[i].size);
                }


            }
        }

            private async Task ExecuteFunction()
        {
            progressBar1.Show();
            UpdateProgressBar(10);
            var responseStream = await RetrieveGeneratedBatchJobsMessageContentStream();
            UpdateProgressBar(50);
            //showBatchJobClassesOnScreen(responseStream);
            SuccesfulBatchJob();
            using (var reader = new StreamReader(responseStream))
            {
                var responseContent = await reader.ReadToEndAsync();

                var responseObject = JsonConvert.DeserializeObject<MyResponseObject>(responseContent);
                
                string path = RetrievePath();
                createXmlFileAtPath(path, responseObject.ContractFile.ClassName, responseObject.ContractFile.xml);
                createXmlFileAtPath(path, responseObject.ServiceFile.ClassName, responseObject.ServiceFile.xml);
                createXmlFileAtPath(path, responseObject.ControllerFile.ClassName, responseObject.ControllerFile.xml);
                AddClassLinkToProject(responseObject.ContractFile.ClassName);
                AddClassLinkToProject(responseObject.ServiceFile.ClassName);
                AddClassLinkToProject(responseObject.ControllerFile.ClassName);

            }

            return;
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            errorTextBox.Hide();
            ErrorLabel.Hide();
            UpdateProgressBar(0);
            resetButton.Hide();
            button6.Show();
        }
    }
}
