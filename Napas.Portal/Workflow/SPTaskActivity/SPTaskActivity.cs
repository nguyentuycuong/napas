using System;
using System.Workflow.Activities;

namespace NAPAS.Portal.Workflow
{
    public partial class SPTaskActivity : SequenceActivity
    {
        public SPTaskActivity()
        {
            InitializeComponent();
        }

        public Guid SPTaskId = default(System.Guid);
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties SPTaskProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();

        public string TaskTitle { get; set; }

        public string TaskDescription { get; set; }

        public string TaskAssignedTo { get; set; }

        public DateTime TaskDueDate { get; set; }

        public bool complete;

        public String SPTaskOutcome = default(System.String);

        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties SPAfterProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties SPBeforeProperties = new Microsoft.SharePoint.Workflow.SPWorkflowTaskProperties();
        public Guid TaskStatusFieldId = new Guid("c15b34c3-ce7d-490a-b133-3f4de8801b76");

        public delegate void AsyncSendEmail();

        private void createSPTask_MethodInvoking(object sender, EventArgs e)
        {
            //Create Task
            SPTaskId = Guid.NewGuid();
            SPTaskProperties.Title = TaskTitle;
            SPTaskProperties.Description = TaskDescription;
            SPTaskProperties.AssignedTo = TaskAssignedTo;
            SPTaskProperties.PercentComplete = 0;
            SPTaskProperties.StartDate = DateTime.Today;
            SPTaskProperties.DueDate = TaskDueDate;
        }

        private void onSPTaskChanged_Invoked(object sender, ExternalDataEventArgs e)
        {
            string taskStatus = SPAfterProperties.ExtendedProperties[TaskStatusFieldId].ToString();

            SPTaskOutcome = taskStatus;
        }
        
    }
}