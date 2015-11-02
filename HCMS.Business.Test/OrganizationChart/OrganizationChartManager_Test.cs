using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using OC = HCMS.Business.OrganizationChart;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCMS.Business.Lookups;
using HCMS.Business.Security;
using HCMS.Business.WorkFlow.Exceptions;
using HCMS.Business.OrganizationChart.Exceptions;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.Business.Test.OrganizationChart
{
    [TestClass]
    public class OrganizationChartManager_Test : OrganizationManagerTestBase
    {        
        [TestMethod]
        public void OrganizationChartManager_GetByID()
        {
            const int primaryUserID = 1;
            const int testOrgCodeID = 15;
            int newOrgChartID = -1;

            try
            {
                newOrgChartID = CreateOrgChartNew("Test Generated -- Get By ID", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

                OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

                Assert.IsNotNull(chart, "Organization Chart is null");
                Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteChart(newOrgChartID);
            }
        }

        [TestMethod]
        public void OrganizationChartManager_GetByOrgCodeAndChartType()
        {
            const int testOrgCodeID = 15;
            int newOrgChartID = -1;
            int primaryUserID = 1;
            enumOrgChartType selectedChartType = enumOrgChartType.SingleOrg;

            try
            {
                OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByOrgCodeAndChartType(testOrgCodeID, selectedChartType);

                if (chart.OrganizationChartID == -1)
                    newOrgChartID = CreateOrgChartNew("OrganizationChartManager_GetByOrgCodeAndChartType", testOrgCodeID, selectedChartType, primaryUserID);
                else
                    newOrgChartID = chart.OrganizationChartID;

                chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

                Assert.IsNotNull(chart, "Organization Chart is null");
                Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                DeleteChart(newOrgChartID);
            }
        }

        [TestMethod]
        public void OrganizationChartManager_CreateOrganizationChart()
        {
            int newOrgChartID = CreateOrgChartNew("Test Generated -- Org Chart Creation", 5, enumOrgChartType.SingleOrg, 1);

            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            // now delete it -- we don't need it anymore
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it one last time
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);
        }

        [TestMethod]
        public void OrganizationChartManager_CreateOrganizationChart_FromPublished()
        {
            const int primaryUserID = 1;

            OC.OrganizationChart newChart = new OC.OrganizationChart()
            {
                OrganizationChartTypeID = enumOrgChartType.SingleOrg,
                OrgCode = new OrganizationCode()
                {
                    OrganizationCodeID = 1357
                },
                CreatedBy = new ActionUser(primaryUserID)
            };

            int newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(newChart, true);
            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            // now delete it -- we don't need it anymore
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it one last time
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);        
        }

        [TestMethod]
        public void OrganizationChartManager_DeleteOrganizationChart()
        {
            int newOrgChartID = CreateOrgChartNew("Test Generated -- Org Chart Creation", 1795, enumOrgChartType.SingleOrg, 1);

            // now try to find it
            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chart, "Could not find Organization Chart");

            // now delete
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it again
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);        
        }

        [TestMethod]
        public void OrganizationChartManager_DeleteOrganizationChart_SingleSet()
        {
            int newOrgChartID = 10073;

            // now delete
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it again
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);
        }

        [TestMethod]
        public void OrganizationChartManager_SubmitToReview_Review()
        {
            const int primaryUserID = 1;

            OC.OrganizationChart newChart = new OC.OrganizationChart()
            {
                OrganizationChartTypeID = enumOrgChartType.SingleOrg,
                OrgCode = new OrganizationCode()
                {
                    OrganizationCodeID = 1357
                },
                CreatedBy = new ActionUser(primaryUserID)
            };

            int newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(newChart, true);
            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");
            Assert.IsTrue(chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft, "New Chart is not in Draft Mode");

            // now submit to review
            OC.OrganizationChartManager.Instance.SubmitToNextStatus(newOrgChartID, enumOrgWorkflowStatus.Review, 1);

            // reload
            OC.OrganizationChart chartNewStatus = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartNewStatus, "Organization Chart is null");
            Assert.IsTrue(chartNewStatus.OrganizationChartID == newOrgChartID, "Organization Chart not found");
            Assert.IsTrue(chartNewStatus.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review, "New Chart is not in Review");

            // now delete it -- we don't need it anymore
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it one last time
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);
        }

        [TestMethod]
        public void OrganizationChartManager_SubmitToReview_Approve()
        {
            const int primaryUserID = 1;

            OC.OrganizationChart newChart = new OC.OrganizationChart()
            {
                OrganizationChartTypeID = enumOrgChartType.SingleOrg,
                OrgCode = new OrganizationCode()
                {
                    OrganizationCodeID = 1357
                },
                CreatedBy = new ActionUser(primaryUserID)
            };

            int newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(newChart, true);
            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");
            Assert.IsTrue(chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft, "New Chart is not in Draft Mode");

            // now submit to review
            OC.OrganizationChartManager.Instance.SubmitToNextStatus(newOrgChartID, enumOrgWorkflowStatus.Approval, 1);

            // reload
            OC.OrganizationChart chartNewStatus = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartNewStatus, "Organization Chart is null");
            Assert.IsTrue(chartNewStatus.OrganizationChartID == newOrgChartID, "Organization Chart not found");
            Assert.IsTrue(chartNewStatus.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval, "New Chart is not in Approval");

            // now delete it -- we don't need it anymore
            OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

            // now try to find it one last time
            OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
            Assert.IsNotNull(chartFinalCheck, "Organization Chart was not Deleted");
            Assert.IsTrue(chartFinalCheck.OrganizationChartID == -1);
        }

        [TestMethod]
        [ExpectedException(typeof(WorkflowNotSupportedException))]
        public void OrganizationChartManager_SubmitToReview_WorkflowNotSupportedException()
        {
            int newOrgChartID = -1;

            try
            {
                const int primaryUserID = 1;

                OC.OrganizationChart newChart = new OC.OrganizationChart()
                {
                    OrganizationChartTypeID = enumOrgChartType.SingleOrg,
                    OrgCode = new OrganizationCode()
                    {
                        OrganizationCodeID = 1357
                    },
                    CreatedBy = new ActionUser(primaryUserID)
                };

                newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(newChart, true);
                OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

                Assert.IsNotNull(chart, "Organization Chart is null");
                Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");
                Assert.IsTrue(chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft, "New Chart is not in Draft Mode");

                // now submit to review
                OC.OrganizationChartManager.Instance.SubmitToNextStatus(newOrgChartID, enumOrgWorkflowStatus.Published, 1);

            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteChart(newOrgChartID);
            }
        }

        //[TestMethod]
        //[ExpectedException(typeof(MissingRootNodePositionException))]
        //public void OrganizationChartManager_SubmitToReview_MissingRootNodePositionException()
        //{
        //    int newOrgChartID = -1;

        //    try
        //    {
        //        newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(enumOrgChartType.SingleOrg, 1357, 1, true);
        //        OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

        //        Assert.IsNotNull(chart, "Organization Chart is null");
        //        Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

        //        OC.OrganizationChart chartUpdate = new OC.OrganizationChart()
        //        {
        //            OrganizationChartID = newOrgChartID,
        //            UpdatedBy = new ActionUser(1)
        //        };

        //        // set null root node
        //        OC.OrganizationChartManager.Instance.UpdateRootNode(chartUpdate);

        //        // now submit to review
        //        OC.OrganizationChartManager.Instance.SubmitToNextStatus(newOrgChartID, enumOrgWorkflowStatus.Review, 1);

        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        deleteChart(newOrgChartID);
        //    }
        //}

        [TestMethod]
        public void OrganizationChartManager_UpdateRoot()
        {
            int newOrgChartID = -1;

            try
            {
                const int primaryUserID = 1;

                OC.OrganizationChart newChart = new OC.OrganizationChart()
                {
                    OrganizationChartTypeID = enumOrgChartType.SingleOrg,
                    OrgCode = new OrganizationCode()
                    {
                        OrganizationCodeID = 1357
                    },
                    CreatedBy = new ActionUser(primaryUserID)
                };

                newOrgChartID = OC.OrganizationChartManager.Instance.CreateFromPublished(newChart, true);
                OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

                Assert.IsNotNull(chart, "Organization Chart is null");
                Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");
                Assert.IsTrue(chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft, "New Chart is not in Draft Mode");

                // now submit update root
                OC.OrganizationChart chart2 = new OC.OrganizationChart()
                {
                    OrganizationChartID = newOrgChartID,
                    StartPointWFPPositionID = 1,
                    UpdatedBy = new ActionUser(1)
                };

                OC.OrganizationChartManager.Instance.UpdateRootNode(chart2);

                // reload
                OC.OrganizationChart chartNewRoot = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
                Assert.IsNotNull(chartNewRoot, "Organization Chart is null");
                Assert.IsTrue(chartNewRoot.OrganizationChartID == newOrgChartID, "Organization Chart not found");
                Assert.IsTrue(chartNewRoot.StartPointWFPPositionID == 1, "Root Not Updated");
            }
            catch
            {
                throw;
            }
            finally
            {
                DeleteChart(newOrgChartID);
            }
        }

        [TestMethod]
        public void OrganizationChartManager_Publish()
        {
            const int primaryUserID = 1;
            const int testOrgCodeID = 261;
            int newOrgChartID = CreateOrgChartNew("Test Generated -- Get By ID", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            // Now attempt to publish chart
            OC.OrganizationChartManager.Instance.Publish(newOrgChartID, primaryUserID, primaryUserID, string.Empty);

            // Final check -- chart should not be found
            chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == -1, "Organization Chart not found");
        }

        [TestMethod]
        public void OrganizationChartManager_Publish_SystemImportUser()
        {
            const int primaryUserID = 1;
            const int testOrgCodeID = 262;
            int newOrgChartID = CreateOrgChartNew("Test Generated -- Get By ID", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            // Now attempt to publish chart
            OC.OrganizationChartManager.Instance.Publish(newOrgChartID, primaryUserID, ConfigWrapper.SystemImportUserID, string.Empty);

            // Final check -- chart should not be found
            chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == -1, "Organization Chart not found");
        }

        [TestMethod]
        public void OrganizationChartManager_Publish_ApprovedAsFor()
        {
            const int primaryUserID = 1;
            const int testOrgCodeID = 263;
            int newOrgChartID = CreateOrgChartNew("Test Generated -- Get By ID", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

            OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == newOrgChartID, "Organization Chart not found");

            // Now attempt to publish chart
            OC.OrganizationChartManager.Instance.Publish(newOrgChartID, primaryUserID, primaryUserID, "James Gilligan");

            // Final check -- chart should not be found
            chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);

            Assert.IsNotNull(chart, "Organization Chart is null");
            Assert.IsTrue(chart.OrganizationChartID == -1, "Organization Chart not found");
        }

        //[TestMethod]
        //public void OrganizationChartManager_GetOrganizationChartCollectionByCodeAndChartType()
        //{
        //    const int primaryUserID = 1;
        //    const int testOrgCodeID = 15;
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Creation", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

        //    // now try to find it by Org Code and Chart Type
        //    List<OC.OrganizationChart> chartList = OC.OrganizationChartManager.Instance.GetOrganizationChartsByCodeAndChartType(enumOrgChartType.SingleOrg, testOrgCodeID);
        //    Assert.IsNotNull(chartList, "Organization Chart List is null");
        //    Assert.IsTrue(chartList.Count > 0, "Organization chart list is empty");

        //    // now check to see if new chart is in list
        //    OC.OrganizationChart chartCheck = chartList.Find(IOC => IOC.OrganizationChartID == newOrgChartID);
        //    Assert.IsNotNull(chartCheck, "Could not find newly created chart in returned chart list");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}

        //[TestMethod]
        //public void OrganizationChartManager_GetOrganizationChartsByUserAndStatus()
        //{
        //    const int primaryUserID = 1;
        //    const int testOrgCodeID = 15;
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Creation", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

        //    // now try to find it by user and workflow status
        //    List<OC.OrganizationChart> chartList = OC.OrganizationChartManager.Instance.GetOrganizationChartsByUserAndStatus(primaryUserID, enumOrgWorkflowStatus.Draft);
        //    Assert.IsNotNull(chartList, "Organization Chart List is null");
        //    Assert.IsTrue(chartList.Count > 0, "Organization chart list is empty");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}
       
        //[TestMethod]
        //public void OrganizationChartManager_SubmitToNextStatus()
        //{
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Creation", 1, enumOrgChartType.SingleOrg, 1);
            
        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");

        //    // now submit to next status
        //    OC.OrganizationChartManager.Instance.SubmitToNextStatus(newOrgChartID, enumOrgWorkflowStatus.Review, 1);

        //    // now try to find it again
        //    OC.OrganizationChart chartReFind = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chartReFind, "Could not find Organization Chart");
        //    Assert.IsTrue(chartReFind.OrganizationChartID != -1, "Organization Chart Not Found -- ID is == -1");
        //    Assert.IsTrue(chartReFind.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review, "Org Chart Workflow Status Not Set");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}


        //[TestMethod]
        //public void OrganizationChartManager_CheckIn()
        //{
        //    const int testOrgCodeID = 25;
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Creation", testOrgCodeID, enumOrgChartType.SingleOrg, 1);

        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Console.WriteLine(string.Format("Chart checked out by {0}", chart.CheckedOutBy.UserID));
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");
        //    Assert.IsTrue(chart.CheckedOutBy.UserID == 1, "Chart not checked out by User [1]");
            
        //    // after initial creation chart is checked out by created user -- try checking in now
        //    OC.OrganizationChartManager.Instance.Check(newOrgChartID, 1, enumActionType.CheckIn);

        //    // now try to find it again
        //    OC.OrganizationChart chartFind1 = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Console.WriteLine(string.Format("Chart checked in -- current value is {0}", chartFind1.CheckedOutBy.UserID));
        //    Assert.IsNotNull(chartFind1, "Could not find Organization Chart");
        //    Assert.IsTrue(chartFind1.CheckedOutBy.UserID == -1, "Chart still checked out by User [1]");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}

        //[TestMethod]
        //public void OrganizationChartManager_CheckOut()
        //{
        //    const int testOrgCodeID = 27;
        //    const int primaryUserID = 1;
        //    const int secondaryUserID = 5;
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Creation", testOrgCodeID, enumOrgChartType.SingleOrg, primaryUserID);

        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Console.WriteLine(string.Format("Chart checked out by {0}", chart.CheckedOutBy.UserID));
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");
        //    Assert.IsTrue(chart.CheckedOutBy.UserID == primaryUserID, "Chart not checked out by User [1]");

        //    // after initial creation chart is checked out by created user -- try checking in now
        //    OC.OrganizationChartManager.Instance.Check(newOrgChartID, primaryUserID, enumActionType.CheckIn);

        //    // now try to find it again
        //    OC.OrganizationChart chartFind1 = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Console.WriteLine(string.Format("Chart checked in -- current value is {0}", chartFind1.CheckedOutBy.UserID));
        //    Assert.IsNotNull(chartFind1, "Could not find Organization Chart");
        //    Assert.IsTrue(chartFind1.CheckedOutBy.UserID == -1, "Chart still checked out by User [1]");

        //    // now try to check it out now
        //    OC.OrganizationChartManager.Instance.Check(newOrgChartID, secondaryUserID, enumActionType.CheckOut);

        //    // now try to find it again
        //    chartFind1 = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Console.WriteLine(string.Format("Chart checked out by {0}", chartFind1.CheckedOutBy.UserID));
        //    Assert.IsNotNull(chartFind1, "Could not find Organization Chart");
        //    Assert.IsTrue(chartFind1.CheckedOutBy.UserID == secondaryUserID, "Chart not checked out by User [5]");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}

        //[TestMethod]
        //public void OrganizationChartManager_Update()
        //{
        //    const int primaryUserID = 5;
        //    const int secondaryUserID = 1;
        //    const string testValue = "TEST UPDATE";
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Update", primaryUserID, enumOrgChartType.SingleOrg, 1);

        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");

        //    // now try to update information
        //    chart.Header4 = testValue;
        //    chart.UpdatedBy = new ActionUser(secondaryUserID);

        //    // now update
        //    OC.OrganizationChartManager.Instance.Update(chart);

        //    // now try to find it again
        //    OC.OrganizationChart chartReFind = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chartReFind, "Could not find Organization Chart");
        //    Assert.IsTrue(chartReFind.OrganizationChartID != -1, "Organization Chart Not Found -- ID is == -1");
        //    Assert.IsTrue(chartReFind.Header4 == testValue, "Header 4 not updated");

        //    // now delete it -- we don't need it anymore
        //    OC.OrganizationChartManager.Instance.Delete(newOrgChartID);

        //    // now try to find it one last time
        //    OC.OrganizationChart chartFinalCheck = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartFinalCheck, "Organization Chart was not Deleted");
        //}

        //[TestMethod]
        //public void OrganizationChartManager_Publish()
        //{
        //    int primaryUserID = 4;
        //    int approvedByUserID = 1;
        //    int newOrgChartID = CreateOrgChart("Test Generated -- Org Chart Publish", 1, enumOrgChartType.SingleOrg, primaryUserID);

        //    // now try to find it
        //    OC.OrganizationChart chart = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNotNull(chart, "Could not find Organization Chart");

        //    // now publish it
        //    int newOrgChartLogID = OC.OrganizationChartManager.Instance.Publish(chart, approvedByUserID, "Jack Robinson", "Executive Vice President'", "Jones Griffin");

        //    // now try to find the original chart again -- chart should not be here
        //    OC.OrganizationChart chartReFind = OC.OrganizationChartManager.Instance.GetByID(newOrgChartID);
        //    Assert.IsNull(chartReFind, "Organization Chart not deleted -- still in tbl_OrganizationChart");

        //    // now try to find the new OrganizationChartLog
        //    OC.OrganizationChartLog chartLog = OC.OrganizationChartLogManager.Instance.GetByID(newOrgChartLogID);
        //    Assert.IsNotNull(chartLog, "Chart move to OrgChartLog FAIL");
        //    Assert.IsTrue(chartLog.OrganizationChartLogID != -1, "OrgChartLog is empty");
        //    Assert.IsTrue(chartLog.OrganizationChartID == newOrgChartID, "Org Chart ID values do not match");
        //}
    }
}
