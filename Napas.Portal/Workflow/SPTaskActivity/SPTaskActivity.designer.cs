using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace NAPAS.Portal.Workflow
{
    public partial class SPTaskActivity
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Runtime.CorrelationToken correlationtoken1 = new System.Workflow.Runtime.CorrelationToken();
            System.Workflow.ComponentModel.ActivityBind activitybind3 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind4 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind5 = new System.Workflow.ComponentModel.ActivityBind();
            this.onSPTaskChanged = new Microsoft.SharePoint.WorkflowActions.OnTaskChanged();
            this.createSPTask = new Microsoft.SharePoint.WorkflowActions.CreateTask();
            // 
            // onSPTaskChanged
            // 
            activitybind1.Name = "SPTaskActivity";
            activitybind1.Path = "SPAfterProperties";
            activitybind2.Name = "SPTaskActivity";
            activitybind2.Path = "SPBeforeProperties";
            correlationtoken1.Name = "taskToken";
            correlationtoken1.OwnerActivityName = "SPTaskActivity";
            this.onSPTaskChanged.CorrelationToken = correlationtoken1;
            this.onSPTaskChanged.Executor = null;
            this.onSPTaskChanged.Name = "onSPTaskChanged";
            activitybind3.Name = "SPTaskActivity";
            activitybind3.Path = "SPTaskId";
            this.onSPTaskChanged.Invoked += new System.EventHandler<System.Workflow.Activities.ExternalDataEventArgs>(this.onSPTaskChanged_Invoked);
            this.onSPTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.AfterPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            this.onSPTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.BeforePropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            this.onSPTaskChanged.SetBinding(Microsoft.SharePoint.WorkflowActions.OnTaskChanged.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind3)));
            // 
            // createSPTask
            // 
            this.createSPTask.CorrelationToken = correlationtoken1;
            this.createSPTask.ListItemId = -1;
            this.createSPTask.Name = "createSPTask";
            this.createSPTask.SpecialPermissions = null;
            activitybind4.Name = "SPTaskActivity";
            activitybind4.Path = "SPTaskId";
            activitybind5.Name = "SPTaskActivity";
            activitybind5.Path = "SPTaskProperties";
            this.createSPTask.MethodInvoking += new System.EventHandler(this.createSPTask_MethodInvoking);
            this.createSPTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskIdProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind4)));
            this.createSPTask.SetBinding(Microsoft.SharePoint.WorkflowActions.CreateTask.TaskPropertiesProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind5)));
            // 
            // SPTaskActivity
            // 
            this.Activities.Add(this.createSPTask);
            this.Activities.Add(this.onSPTaskChanged);
            this.Name = "SPTaskActivity";
            this.CanModifyActivities = false;

        }

        #endregion

        private Microsoft.SharePoint.WorkflowActions.OnTaskChanged onSPTaskChanged;

        private Microsoft.SharePoint.WorkflowActions.CreateTask createSPTask;

































    }
}
