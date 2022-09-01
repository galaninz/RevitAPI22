using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitAPI22
{
    [Transaction(TransactionMode.Manual)]
    public class Main : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //Не работает

            //List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id)
            //    .OfCategory(BuiltInCategory.OST_PipeCurves)
            //    .WhereElementIsNotElementType()
            //    .Cast<FamilyInstance>()
            //    .ToList();

            //TaskDialog.Show("Pipes count", familyInstances.Count.ToString());

            var pipes = new FilteredElementCollector(doc, doc.ActiveView.Id)
                .OfClass(typeof(Pipe))
                .Cast<Pipe>()
                .ToList();

            TaskDialog.Show("Pipes quantity", pipes.Count.ToString());

            return Result.Succeeded;
        }
    }
}
