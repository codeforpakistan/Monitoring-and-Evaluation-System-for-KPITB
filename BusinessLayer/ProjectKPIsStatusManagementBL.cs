using DatabaseLayer;
using ModelLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelLayer.MainViewModel;

namespace BusinessLayer
{
    public class ProjectKPIsStatusManagementBL
    {
        public StatusModel projectKPIsStatusCreateViewBL(CreateProjectKPIsStatusVM m)
        {
            return ProjectKPIsStatusManagementDL.projectKPIsStatusCreateViewDL(m);
        }
    }
}
