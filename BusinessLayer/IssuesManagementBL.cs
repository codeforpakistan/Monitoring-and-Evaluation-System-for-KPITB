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
    public class IssuesManagementBL
    {
        //CreateIssues
        public StatusModel issueCreateBL(CreateIssueVM m)
        {
            return IssuesManagementDL.issuesCreateDL(m);
        }
        //GetAllIssues
        public List<GetAllIssue> getAllIssueBL()
        {
            return IssuesManagementDL.getIssueDL();
        }
        //GetSingleIssue For Edit
        public EditIssueVM getSignleIssueBL(int IssuesID)
        {
            EditIssueVM m = IssuesManagementDL.getSignleIssueDL(IssuesID);
            return m;
        }
        //Edit
        public StatusModel issueEditBL(EditIssueVM m)
        {
            return IssuesManagementDL.issueEditDL(m);
        }
    }
}
