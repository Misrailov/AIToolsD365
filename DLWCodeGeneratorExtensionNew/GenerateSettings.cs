using Microsoft.VisualStudio.TextManager.Interop;
using Microsoft.CSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;
using System.Diagnostics;
using System.IO;
using Microsoft.Scripting.Runtime;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EnvDTE;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.PlatformUI;
using Project = Community.VisualStudio.Toolkit.Project;
using Community.VisualStudio.Toolkit;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Collections;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Scripting.Utils;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace DLWCodeGeneratorExtensionNew
{
    public partial class GenerateSettings : Form
    {
        FolderBrowserDialog folderBrowserDialog;
        private static readonly HttpClient client = new();
        private String currentModel;
        private List<String> modelsList= new List<String>();
        public GenerateSettings()
        {
            InitializeComponent();
            /*            folderBrowserDialog = new FolderBrowserDialog();
                        folderBrowserDialog.SelectedPath = "C:\\AOSService\\PackagesLocalDirectory";
                        pathTextBox.Text = folderBrowserDialog.SelectedPath;
                        progressBar1.Hide();
                        CloseButton.Hide();
                        ResultTextBox.Hide();*/
/*            onlyProjectDescriptionChkbx.BackColor = Color.WhiteSmoke;
            IntPtr parentHandle = this.Handle; // Replace this with the actual handle of the parent control
            Control parentControl = Control.FromHandle(parentHandle);
            onlyProjectDescriptionChkbx.Parent = parentControl;
*/


        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    
/*    private void label1_Click(object sender, EventArgs e)
        {

        }*/

/*        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/
        
/*        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void updateProgressBar(int value)
        {
            progressBar1.Value = value;
            progressBar1.Update();
        }*/
        private void updateProgressBar2(int value)
        {
        
            progressBar2.Value = value;
            progressBar2.Update();
        }

/*        private async Task<Stream> retrieveGeneratedBatchJobsMessageContentStream()
        {
            var client = new HttpClient();
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(textBox1.Text), "description");
            formContent.Add(new StringContent(pathTextBox.Text), "path");
            var response = await client.PostAsync("http://127.0.0.1:5000/runBatchJobGeneration", formContent);
            return  await response.Content.ReadAsStreamAsync();
        }
*/
  /*      private void succesfulBatchJobGeneration()
        {
            updateProgressBar(100);
            System.Threading.Thread.Sleep(200);
            progressBar1.Hide();
            button2.Hide();
            button1.Hide();
            textBox1.Hide();
            pathTextBox.Hide();
            ResultTextBox.Show();
            button3.Hide();
            CloseButton.Show();
            label3.Hide();
            label1.Text = "Batch Jobs generated successfully!";
            FunctionDescription.Hide();
        }*/
       /* private async void showBatchJobClassesOnScreen(Stream responseStream)
        {
            using (var reader = new StreamReader(responseStream))
            {
                var responseContent = await reader.ReadToEndAsync();

                var responseObject = JsonConvert.DeserializeObject<MyResponseObject>(responseContent);
                String contractClassNames = responseObject.ContractFile.ClassName;
                String controllerClassNames = responseObject.ControllerFile.ClassName;
                String serviceClassNames = responseObject.ServiceFile.ClassName;
                // Access the response object properties here
                ResultTextBox.Text = "Class names: " + contractClassNames + ", " + controllerClassNames + ", " + serviceClassNames;
            }
        }
        private async Task ExecuteFunction()
        {
            progressBar1.Show();
            updateProgressBar(10);
            var responseStream = await retrieveGeneratedBatchJobsMessageContentStream();
            updateProgressBar(50);
            showBatchJobClassesOnScreen(responseStream);
            succesfulBatchJobGeneration();
            return;
        }*/
        private String retrieveCurrentUser()
        {
            return Environment.UserName;
        }

/*        private void button3_Click(object sender, EventArgs e)
        {

            bool? succes = folderBrowserDialog.ShowDialog() == DialogResult.OK;
            if (succes == true)
            {
                string path = folderBrowserDialog.SelectedPath;
                pathTextBox.Text = path;
            }
        }*/

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FunctionDescription_Click(object sender, EventArgs e)
        {

        }
/*
        private async void button1_Click(object sender, EventArgs e)
        {
       
                await ExecuteFunction();
            
            

        }*/

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void button4_Click(object sender, EventArgs e)
        {
            progressBar2.Show();
            AnalyzeButton.Enabled = false;
            if (AnalyseModeComBox.SelectedIndex.Equals(AnalyseModeComBox.Items[0]))
            {
                 retrieveCurrentProjectSummary();
            }
            else if (AnalyseModeComBox.SelectedIndex.Equals(AnalyseModeComBox.Items[1]))
            {
                await summarizeCurrentWindowsCode();
            }
            else
            {
                retrieveCurrentProjectSummary();
            }
            AnalyzeButton.Enabled = true;


        }
        public String retrieveCurrentWindowsCode()
        {
            DTE currentDte = Package.GetGlobalService(typeof(DTE)) as DTE;
            if (currentDte.ActiveDocument == null) { return "You have to select a current document"; }
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

        private async Task<String> retrieveCurrentWindowsCodeAnalysisAsync(String classes)
        {
            updateProgressBar2(40);
            var client = new HttpClient();
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(classes), "classes");
            updateProgressBar2(60);
            var response = await client.PostAsync("http://127.0.0.1:5000/runCodeAnalyzer", formContent);
            if(response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return "Error in code analysis";
            }
            updateProgressBar2(80);
            var responseStream = await response.Content.ReadAsStreamAsync();
            String textFromResponse = "";
            using (var reader = new StreamReader(responseStream))
            {
                var responseContent = await reader.ReadToEndAsync();
                var responseObject = JsonConvert.DeserializeObject<MyResponseObject2>(responseContent);
                textFromResponse = responseObject.response;
            }
            updateProgressBar2(90);
            return textFromResponse;
        }

        private async Task summarizeCurrentWindowsCode()
        {
            updateProgressBar2(10); 
            String classesRetrieved = retrieveCurrentWindowsCode();
            var result = await retrieveCurrentWindowsCodeAnalysisAsync(classesRetrieved);
            updateProgressBar2(100);

        }
        private async void button4_Click_1(object sender, EventArgs e)
        {
            
                String solutionDirectory = retrieveCurrentSolutionDirectory();
                String projectDirectory = retrieveModelClassesDirectoryPath(solutionDirectory);
                var classesArray = retrieveAllClassesFromPath(projectDirectory);
                string modelname = retrieveModelName(solutionDirectory);
                var result = await retrieveResultFromCodeAnalysisAsync(classesArray,modelname);
            
        }
        private async void retrieveCurrentProjectSummary()
        {
            updateProgressBar2(10);
            String solutionDirectory = retrieveCurrentSolutionDirectory();
            updateProgressBar2(30);
            String projectDirectory = retrieveModelClassesDirectoryPath(solutionDirectory);
            updateProgressBar2(40);
            var classesArray = retrieveAllClassesFromPath(projectDirectory);
            updateProgressBar2(45);
            string modelname = retrieveModelName(solutionDirectory);
            updateProgressBar2(50);
            var result = await retrieveResultFromCodeAnalysisAsync(classesArray, modelname);
            updateProgressBar2(100);
            progressBar2.Hide();
        }

        public String retrieveCurrentSolutionDirectory()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string solutionName = workingDirectory.Split('\\').Last();

            return (workingDirectory + "\\" + solutionName + ".sln");
        }
        public String retrieveModelName(String solutionPath)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string solutionTextFile = File.ReadAllText(solutionPath);
            Regex regex = new Regex("\"[^\"\\\\]*\\\\[^\"\\\\]*\\.rnrproj\"");
            Match match = regex.Match(solutionTextFile);
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
        private ArrayList retrieveAllClassesFromPath(String path)
        {
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
            return classesArray;
        }

        private async Task<String> retrieveResultFromCodeAnalysisAsync(ArrayList classes,String modelname)
        {
            var json = JsonConvert.SerializeObject(classes);

            var client = new HttpClient();
            var formContent = new MultipartFormDataContent();
            formContent.Add(new StringContent(json), "classes");
            formContent.Add(new StringContent(modelname), "projectname");
            formContent.Add(new StringContent(retrieveCurrentUser()), "username");
            int timeout = 0;
            int characterLength= classes.Select(x => x.ToString().Length).Sum();

            for (int i = 0; i < characterLength; i=i + 30000)
            {
                timeout += 125;
            }
            updateProgressBar2(60);
            client.Timeout = TimeSpan.FromSeconds(timeout);
            var response = await client.PostAsync("", formContent);
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

        private void onlyProjectDescriptionChkbx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void SingleProjectAnalyzeTab_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void onlyProjectDescriptionChkbx_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_2(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
public class MyResponseObject
{
    public ContractFile ContractFile { get; set; }
    public ControllerFile ControllerFile { get; set; }
    public ServiceFile ServiceFile { get; set; }
}
public class ProjectMongo
{
    public string category { get; set; }
    public string promp_length { get; set; }
    public string prompt { get; set; }
    public string result { get; set; }
    public string total_time { get; set; }
    public string model { get; set; }
    public string size { get; set; }
    public string xml_result { get; set; }

}
public class GetProjectsResult
{
    public int length { get; set; }
    public List<ProjectMongo> results { get; set; }
}

public class ContractFile
{
    public string Code { get; set; }
    public string ClassName { get; set; }
    public string xml { get; set; }
}

public class ControllerFile
{
    public string Code { get; set; }
    public string ClassName { get; set; }
    public string xml { get; set; }
}

public class ServiceFile
{
    public string Code { get; set; }
    public string ClassName { get; set; }
    public string xml { get; set; }
}

public class ResultObject
{
    public string Detailed { get; set; }
    public string Simple { get; set; }
    public string projectId { get; set; }
}
public class MyResponseObject2
{
    public string response { get; set; }
}
public class ClassesRequestSend
{
    public ArrayList classes { get; set; }
    public List<String> classNames { get; set; }
}