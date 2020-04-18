using System.Windows.Forms;
using Autodesk.AutoCAD.Runtime;
using UI;
using Application = Autodesk.AutoCAD.ApplicationServices.Core.Application;

namespace ModelController
{
    /// <summary>
    ///     Менеджер команд плагина
    /// </summary>
    public class CommandManager : IExtensionApplication
    {
        [CommandMethod("BuildBed")]
        public void BuildBed()
        {
            var document = Application.DocumentManager.MdiActiveDocument;
            var mainForm = new ModelParametersForm(document);
            mainForm.Show();
        }

        public void Initialize()
        {
            MessageBox.Show(
                "Bed builder подключен! Для запуска используйте команду BUILDBED");
        }

        public void Terminate()
        {
        }
    }
}