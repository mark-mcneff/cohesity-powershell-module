﻿using System.Management.Automation;
using Cohesity.Powershell.Common;

namespace Cohesity.Powershell.Cmdlets.Cluster
{
    /// <summary>
    /// <para type="synopsis">
    /// Gets basic information for the Cohesity Cluster.
    /// </para>
    /// <para type="description">
    /// Gets basic information for the Cohesity Cluster.
    /// </para>
    /// </summary>
    /// <example>
    ///   <para>PS&gt;</para>
    ///   <code>
    ///   Get-CohesityCluster
    ///   </code>
    ///   <para>
    ///   Gets basic information for the Cohesity Cluster.
    ///   </para>
    /// </example>
    [Cmdlet(VerbsCommon.Get, "CohesityCluster")]
    [OutputType(typeof(Models.BasicClusterInfo))]
    public class GetCohesityCluster: PSCmdlet
    {
        private Session Session
        {
            get
            {
                if (!(SessionState.PSVariable.GetValue("Session") is Session result))
                {
                    result = new Session();
                    SessionState.PSVariable.Set("Session", result);
                }
                return result;
            }
        }

        /// <summary>
        /// Process Records
        /// </summary>
        protected override void ProcessRecord()
        {
            var preparedUrl = $"/public/basicClusterInfo";
            var result = Session.NetworkClient.Get<Models.BasicClusterInfo>(preparedUrl);
            WriteObject(result, true);
        }

    }
}
