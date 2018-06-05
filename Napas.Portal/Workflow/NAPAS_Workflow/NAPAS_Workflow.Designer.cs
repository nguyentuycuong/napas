using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace Napas.Portal.Workflow.NAPAS_Workflow
{
    public sealed partial class NAPAS_Workflow
    {
        #region Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
        private void InitializeComponent()
        {
            this.CanModifyActivities = true;
            System.Workflow.Activities.CodeCondition codecondition1 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.Activities.CodeCondition codecondition2 = new System.Workflow.Activities.CodeCondition();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.spTaskActivity1 = new NAPAS.Portal.Workflow.SPTaskActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.replicatorActivity1 = new System.Workflow.Activities.ReplicatorActivity();
            this.onWorkflowActivated1 = new Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated();
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            codecondition1.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.ifTaskCompleted);
            this.ifElseBranchActivity1.Condition = codecondition1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // spTaskActivity1
            // 
            this.spTaskActivity1.Name = "spTaskActivity1";
            this.spTaskActivity1.TaskAssignedTo = null;
            this.spTaskActivity1.TaskDescription = null;
            this.spTaskActivity1.TaskDueDate = new System.DateTime(((long)(0)));
            this.spTaskActivity1.TaskTitle = null;
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // replicatorActivity1
            // 
            this.replicatorActivity1.Activities.Add(this.spTaskActivity1);
            this.replicatorActivity1.ExecutionType = System.Workflow.Activities.ExecutionType.Sequence;
            this.replicatorActivity1.Name = "replicatorActivity1";
            codecondition2.Condition += new System.EventHandler<System.Workflow.Activities.ConditionalEventArgs>(this.UntilCompleted_Condition);
            this.replicatorActivity1.UntilCondition = codecondition2;
            this.replicatorActivity1.ChildInitialized += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.replicateTasks_ChildInitialized);
            this.replicatorActivity1.ChildCompleted += new System.EventHandler<System.Workflow.Activities.ReplicatorChildEventArgs>(this.replicateTasks_ChildCompleted);
            this.replicatorActivity1.Completed += new System.EventHandler(this.replicateTasks_Completed);
            this.replicatorActivity1.Initialized += new System.EventHandler(this.replicateTasks_Initialized);
            activitybind2.Name = "NAPAS_Workflow";
            activitybind2.Path = "workflowId";
            // 
            // onWorkflowActivated1
            // 
            correlationtoken1.Name = "workflowToken";
            correlationtoken1.OwnerActivityName = "NAPAS_Workflow";
            this.onWorkflowActivated1.CorrelationToken = correlationtoken1;
            this.onWorkflowActivated1.EventName = "OnWorkflowActivated";
            this.onWorkflowActivated1.Name = "onWorkflowActivated1";
            activitybind1.Name = "NAPAS_Workflow";
            activitybind1.Path = "workflowProperties";
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onWorkflowActivated1.SetBinding(Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated.WorkflowPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // NAPAS_Workflow
            // 
            this.Activities.Add(this.onWorkflowActivated1);
            this.Activities.Add(this.replicatorActivity1);
            this.Activities.Add(this.ifElseActivity1);
            this.Name = "NAPAS_Workflow";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity ifElseBranchActivity2;

        private IfElseBranchActivity ifElseBranchActivity1;

        private IfElseActivity ifElseActivity1;

        private NAPAS.Portal.Workflow.SPTaskActivity spTaskActivity1;

        private ReplicatorActivity replicatorActivity1;

        private Microsoft.SharePoint.WorkflowActions.OnWorkflowActivated onWorkflowActivated1;







    }
}
