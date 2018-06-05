using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Workflow;
using Microsoft.SharePoint.WorkflowActions;

namespace Napas.Portal.Workflow.NAPAS_Workflow
{
    public sealed partial class NAPAS_Workflow : SequentialWorkflowActivity
    {
        public NAPAS_Workflow()
        {
            InitializeComponent();
        }

        public Guid workflowId = default(System.Guid);
        public SPWorkflowActivationProperties workflowProperties = new SPWorkflowActivationProperties();

        private void replicateTasks_ChildCompleted(object sender, ReplicatorChildEventArgs e)
        {

        }

        private void replicateTasks_ChildInitialized(object sender, ReplicatorChildEventArgs e)
        {

        }

        private void replicateTasks_Completed(object sender, EventArgs e)
        {

        }

        private void replicateTasks_Initialized(object sender, EventArgs e)
        {

        }

        private void UntilCompleted_Condition(object sender, ConditionalEventArgs e)
        {

        }

        private void ifTaskCompleted(object sender, ConditionalEventArgs e)
        {

        }
    }
}
