using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCSPayrollBillingSystem.Scripts.SystemUtility
{
    public class ProjectProcessor
    {

        QueryProcessor projectProcessor;
        IDictionary<int, string> projectInfo;
        public ProjectProcessor()
        {
            projectProcessor = new QueryProcessor();
            projectInfo = new Dictionary<int, string>();
            ExecuteSqlLoadProjectsQuery();
        }

        public IDictionary<int, string> ProjectInfo
        {
            get { return projectInfo; }
        }

        public void ExecuteSqlLoadProjectsQuery()
        {
            List<string[]> projectList = new List<string[]>();

            projectList = projectProcessor.ExecuteSqlLoadProjectsQuery(
                () =>
                {
                    Console.WriteLine("Projects successfully loaded.");
                },

                () =>
                {
                    Console.WriteLine("Problem loading projects.");
                });

            ExtractProjectName(projectList);

        }

        private IDictionary<int, string> ExtractProjectName(List<string[]> projectList)
        {
            foreach (string[] project in projectList)
            {
                int projId = project
                    .Where(value => int.TryParse(value, out _))
                    .Select(value => int.Parse(value))
                    .FirstOrDefault();

                string projName = project
                    .Where(value => !int.TryParse(value, out _))
                    .FirstOrDefault();

                if (projId != 0 && !string.IsNullOrEmpty(projName))
                {
                    projectInfo.Add(projId, projName);
                }
            }

            return projectInfo;
        }
    }
}
