using System.Windows.Forms;

namespace DLWCodeGeneratorExtensionNew
{
    [Command(PackageIds.MyCommand)]
    internal sealed class MyCommand : BaseCommand<MyCommand>
    {
        protected override async Task ExecuteAsync(OleMenuCmdEventArgs e)
        {
            await VS.MessageBox.ShowWarningAsync("AI Warning", "Keep in mind that AI code generation can make mistakes and should always be check thoroughly.");


            Form1 form1 = new Form1();
            form1.Show();
            


        }
    }
}
