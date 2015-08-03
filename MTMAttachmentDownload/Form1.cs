using Microsoft.TeamFoundation.Client;
using Microsoft.TeamFoundation.Server;
using Microsoft.TeamFoundation.TestManagement.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Controls.Linking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace DownloadFromTFS
{
    public partial class Form1 : Form
    {
        #region Members of Form1 (15)

        private ListViewColumnSorter lvwColumnSorter;
        private DialogResult _result;
        private ProjectInfo[] _selectedProjects;
        private ITestPlan _selTestPlan;
        private ITestSuiteEntry _selTestSuite;
        private IStaticTestSuite _staticTestSuite;
        private ITestSuiteEntryCollection _testCaseCollection;
        private ITestPlanCollection _testPlanCollection;
        private ITestManagementTeamProject _testproject;
        private ITestManagementService _testservice;
        private ITestSuiteEntryCollection _testSuiteCollection;
        private TfsTeamProjectCollection _tfsPrCollection;
        private TeamProjectPicker _tpp;
        private int sortColumn = -1;
        private ITestCaseResultCollection testCaseResultCollection;
        private ITestRun testRun;

        #endregion Members of Form1 (15)

        #region Constructors of Form1 (1)

        public Form1()
        {
            InitializeComponent();
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.listView1.ListViewItemSorter = lvwColumnSorter;

        }

        #endregion Constructors of Form1 (1)

        #region Methods of Form1 (35)

        public bool AttachmentLocalFileMatch(string attachmentName, string localFileName, string workItemId)
        {
            bool match = false;
            if (localFileName.Contains(workItemId) && localFileName.Contains(attachmentName))
            {
                if (localFileName.Contains(attachmentName))
                    match = true;
            }
            return match;
        }

        public void btConnectTFS_Click(object sender, EventArgs e)
        {
            try
            {
                cbTeamProjects.DataSource = GetTeamProjects();
                cbTeamProjects.SelectedIndex = -1;
                cbTestPlans.DataSource = null;
                cbTestPlans.SelectedIndex = -1;
                cbTestSuites.DataSource = null;
                cbTestSuites.SelectedIndex = -1;
                cbTestSubSuites.DataSource = null;
                cbTestSubSuites.SelectedIndex = -1;
                listView1.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void btDownload_Click(object sender, EventArgs e)
        {
            List<string> TCs = new List<string>();
            try
            {
                if (_testCaseCollection != null && _testCaseCollection.Any())
                {
                    TCs = SelectedWorkItems();

                    if (TCs.Count > 0)
                        DownloadAttachments(TCs);
                    else
                        MessageBox.Show("Please select test cases to download!!!", "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    //    DownloadAttachments();
                }
                else
                {
                    MessageBox.Show("Please select test cases to download!!!", "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
            //catch
            //{
            //    MessageBox.Show("No Test Case to Download", "Download Message", MessageBoxButtons.OK,
            //        MessageBoxIcon.Error);
            //}
        }

        public void cbTeamProjects_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!string.IsNullOrEmpty(((ComboBox)(sender)).Text))

                var selectedItem = ((ComboBox)sender).SelectedItem;
                if (selectedItem != null)
                {
                    {
                        cbTestPlans.DataSource = GetTestPlans((string)selectedItem);
                        //if (string.IsNullOrEmpty((string)selectedItem))
                        //    cbTestPlans.DataSource = null;
                        cbTestPlans.SelectedIndex = -1;
                        cbTestSuites.DataSource = null;
                        //cbTestSuites.SelectedIndex = -1;
                        cbTestSubSuites.DataSource = null;
                        //cbTestSubSuites.SelectedIndex = -1;
                        listView1.Items.Clear();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void cbTestPlans_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                //if (!string.IsNullOrEmpty(((ComboBox)(sender)).Text))

                var selectedItem = ((ComboBox)sender).SelectedItem;
                //cbTestSuites.SelectedIndex = -1;
                if (selectedItem != null)
                {
                    //if (!(string.IsNullOrEmpty(selectedItem.ToString())))

                    cbTestSuites.DataSource = GetTestSuites((string)selectedItem);
                    cbTestSubSuites.DataSource = null;
                    listView1.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void cbTestSubSuites_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = ((ComboBox)sender).SelectedItem;
                if (selectedItem != null)
                {
                    if (!(string.IsNullOrEmpty(selectedItem.ToString())))
                    {
                        var subSuite = _staticTestSuite.SubSuites.FirstOrDefault(i => i.Title == selectedItem.ToString());
                        GetTestCases(subSuite);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

            //else if (listView1 != null) listView1.Items.Clear();
        }

        public void cbTestSuites_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var selectedItem = ((ComboBox)sender).SelectedItem;
                if (selectedItem != null)
                {
                    if ((string)selectedItem == string.Empty)
                    {
                        cbTestSubSuites.DataSource = null;
                        listView1.Items.Clear();
                    }
                    else
                    {
                        cbTestSubSuites.DataSource = GetSubSuites(selectedItem.ToString());
                        cbTestSubSuites.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public void DownloadAttachments()
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            //ITestCaseCollection testcases = suite.AllTestCases;
            try
            {
                // Create target folder.
                String dumpFolder = @"C:\Download\" + DateTime.Today.ToString("yyMMdd") +
                                    DateTime.Now.ToString("HHmmss");
                DirectoryInfo directoryInfo = Directory.CreateDirectory(dumpFolder);
                //Will bring only the Test Case under a specific Test Suite.
                //WorkItemStore workItemStore = TfsPrCollection.GetService<WorkItemStore>();
                WebClient webClient = new WebClient();

                if ((_testCaseCollection != null && _testCaseCollection.Any()))
                {
                    webClient.Credentials = _tfsPrCollection.Credentials;
                    foreach (ITestSuiteEntry testcase in _testCaseCollection)
                    {
                        if (testcase.TestCase.Actions.Any())
                        {
                            foreach (ITestAction tstAction in testcase.TestCase.Actions)
                            {
                                var steptype = tstAction.GetType();
                                if (steptype.Name != "SharedStepReference")
                                {
                                    IAttachmentCollection attachments = ((ITestStep)(tstAction)).Attachments;
                                    if (attachments.Any())
                                    {
                                        foreach (ITestAttachment attachment in attachments)
                                        {
                                            string FullFilePath = Path.Combine(dumpFolder, DownloadFileName(attachment.Name, testcase.Id.ToString()));
                                            webClient.DownloadFile(attachment.Uri, FullFilePath);
                                            //webClient.DownloadFile(attachment.Uri, Path.Combine(dumpFolder, attachment.Name));
                                        }
                                    }
                                }
                            }
                        }

                        //WorkItem workItem = workItemStore.GetWorkItem(testcase.Id);
                        //foreach (Attachment attachment in workItem.Attachments)
                        //{
                        //    webClient.DownloadFile(attachment.Uri, System.IO.Path.Combine(dumpFolder, string.Format("{0} - {1}", Convert.ToString(workItem.Id), attachment.Name)));
                        //}
                    }
                    MessageBox.Show("Downloaded to - " + dumpFolder, "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No Test Case to Download", "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        public void DownloadAttachments(List<string> selectedTestCases)
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            //ITestCaseCollection testcases = suite.AllTestCases;
            try
            {
                // Create target folder.
                String dumpFolder = @"C:\Download\" + DateTime.Today.ToString("yyMMdd") +
                                    DateTime.Now.ToString("HHmmss");
                DirectoryInfo directoryInfo = Directory.CreateDirectory(dumpFolder);
                //Will bring only the Test Case under a specific Test Suite.
                //WorkItemStore workItemStore = TfsPrCollection.GetService<WorkItemStore>();
                WebClient webClient = new WebClient();

                if ((_testCaseCollection != null && _testCaseCollection.Any()))
                {
                    webClient.Credentials = _tfsPrCollection.Credentials;
                    foreach (ITestSuiteEntry testcase in _testCaseCollection)
                    {
                        if (testcase.TestCase.Actions.Any())
                        {
                            if (selectedTestCases.Contains(testcase.Id.ToString()))
                            {
                                foreach (ITestAction tstAction in testcase.TestCase.Actions)
                                {
                                    var steptype = tstAction.GetType();
                                    if (steptype.Name != "SharedStepReference")
                                    {
                                        IAttachmentCollection attachments = ((ITestStep)(tstAction)).Attachments;
                                        if (attachments.Any())
                                        {
                                            foreach (ITestAttachment attachment in attachments)
                                            {
                                                string FullFilePath = Path.Combine(dumpFolder, DownloadFileName(attachment.Name, testcase.Id.ToString()));
                                                webClient.DownloadFile(attachment.Uri, FullFilePath);
                                                //webClient.DownloadFile(attachment.Uri, Path.Combine(dumpFolder, attachment.Name));
                                            }
                                        }
                                    }
                                }
                            }
                        }

                        //WorkItem workItem = workItemStore.GetWorkItem(testcase.Id);
                        //foreach (Attachment attachment in workItem.Attachments)
                        //{
                        //    webClient.DownloadFile(attachment.Uri, System.IO.Path.Combine(dumpFolder, string.Format("{0} - {1}", Convert.ToString(workItem.Id), attachment.Name)));
                        //}
                    }
                    MessageBox.Show("Downloaded to:" + dumpFolder, "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("No Test Case to Download", "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        public string DownloadFileName(string p, string workItemID)
        {
            bool contains = p.Contains(workItemID);
            string fileName = string.Empty;
            if (!contains)
                fileName = string.Format("{0} - {1}", Convert.ToString(workItemID), p);
            else
                fileName = string.Format("{0}", p);
            return fileName;
        }

        public void GetAndUpdateTestResults(string testCaseId)
        {
            ITestCaseResult testResult = _testproject.TestResults.ByTestId(Convert.ToInt32(testCaseId)).OrderBy(testRunID => testRunID.TestRunId).LastOrDefault();
            string row = testResult.Outcome.ToString() + ", " + testResult.LastUpdated;
            ListViewItem listItem = listView1.FindItemWithText(testCaseId);
            listItem.SubItems[3].Text = row;
            listView1.FocusedItem = listItem;
        }

        public List<string> GetSubSuites(string selectedTestSuite)
        {
            //if (selectedTestSuite == null) throw new ArgumentNullException("selectedTestSuite");
            Stack<string> stack = new Stack<string>();
            try
            {
                if (!string.IsNullOrEmpty(selectedTestSuite))
                {
                    _selTestSuite = _testSuiteCollection.FirstOrDefault(i => i.Title == selectedTestSuite);

                    //if (SelTestSuite != null)

                    if (_selTestSuite != null)
                    {
                        if (_selTestSuite.EntryType == TestSuiteEntryType.DynamicTestSuite)
                        {
                            GetTestCases(_selTestSuite.TestSuite);
                        }

                        if (_selTestSuite.EntryType == TestSuiteEntryType.StaticTestSuite)
                        {
                            _staticTestSuite = _selTestSuite.TestSuite as IStaticTestSuite;
                            if (_staticTestSuite != null && _staticTestSuite.SubSuites.Count > 0)
                            {
                                foreach (ITestSuiteEntry suiteEntry in _staticTestSuite.Entries)
                                {
                                    if (suiteEntry != null && suiteEntry.EntryType != TestSuiteEntryType.TestCase)
                                        stack.Push(suiteEntry.Title.ToString(CultureInfo.InvariantCulture));
                                }
                            }
                            else GetTestCases(_selTestSuite.TestSuite);
                        }
                    }
                }
                stack.Push(string.Empty);
                return stack.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                _testCaseCollection = null;
                stack.Push(string.Empty);
                return stack.ToList(); ;
            }
        }

        public List<string> GetTeamProjects()
        {
            Stack<string> stack = new Stack<string>();
            new List<string>();
            try
            {
                //var _list = new List<string>();
                _tpp = new TeamProjectPicker(mode: TeamProjectPickerMode.MultiProject, disableCollectionChange: false);
                _result = _tpp.ShowDialog();
                _selectedProjects = _tpp.SelectedProjects;

                if (_result == DialogResult.OK && _selectedProjects.Any())
                {
                    _tfsPrCollection = _tpp.SelectedTeamProjectCollection;
                    _testservice = (ITestManagementService)_tfsPrCollection.GetService(typeof(ITestManagementService));
                    //updateConfigXML();
                    //var service = TfsPrCollection.GetService<VersionControlServer>();
                    foreach (ProjectInfo project in _selectedProjects) stack.Push(project.Name);
                }
                stack.Push(string.Empty);
                return stack.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                stack.Push(string.Empty);
                return stack.ToList();
            }
        }

        public void GetTestCases(ITestSuiteBase selectedTestSuite)
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            //ITestCaseCollection testcases = suite.AllTestCases;

            try
            {
                ITestCaseResult latestTestResult = null;
                //Will bring only the Test Case under a specific Test Suite.
                int i = 1;
                //if (listView1 != null)
                listView1.Items.Clear();
                int testCaseCount = selectedTestSuite.TestCaseCount;
                _testCaseCollection = selectedTestSuite.TestCases;
                var _allTestCaseColl = selectedTestSuite.AllTestCases;

                if (_allTestCaseColl != null)
                {
                    if (_allTestCaseColl.Any())
                    {
                        foreach (var testcase in _allTestCaseColl)
                        {
                            //ITestCaseResultCollection testResults = _testproject.TestResults.ByTestId(testcase.Id).OrderBy(datecreated => datecreated.DateCompleted);

                            ITestCaseResultCollection testResultsColl = _testproject.TestResults.ByTestId(testcase.Id);
                            var resultSort = from res in testResultsColl
                                             orderby res.LastUpdated descending
                                             select res;

                            if (resultSort != null)
                            {
                                latestTestResult = resultSort.FirstOrDefault();
                            }

                            //ITestCaseResult testResult = testResultsColl.LastOrDefault();
                            string[] row =
                            {
                                i.ToString(CultureInfo.InvariantCulture),
                                testcase.Id.ToString(CultureInfo.InvariantCulture),
                                testcase.Title.ToString(CultureInfo.InvariantCulture),
                                latestTestResult!=null?latestTestResult.Outcome.ToString() + ", " + latestTestResult.LastUpdated:string.Empty
                            };
                            ListViewItem listViewItem = new ListViewItem(row);
                            listView1.Items.Add(listViewItem);
                            i++;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                _testCaseCollection = null;
            }
        }

        public List<string> GetTestPlans(string teamProject)
        {
            Stack<string> stack = new Stack<string>();
            try
            {
                if (!string.IsNullOrEmpty(teamProject))
                {
                    if (_testservice != null)
                        _testproject = _testservice.GetTeamProject(teamProject);
                    if (_testproject != null)
                        _testPlanCollection = _testproject.TestPlans.Query("SELECT * FROM TestPlan");
                    if (_testPlanCollection != null && !string.IsNullOrEmpty(_testPlanCollection.ToString()))
                        foreach (ITestPlan testplan in _testPlanCollection) stack.Push(testplan.Name);
                }
                stack.Push(string.Empty);
                return stack.ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                _testPlanCollection = null;
                stack.Push(string.Empty);
                return stack.ToList();
            }
        }

        public void UploadAttachments(string[] files)
        {
            var fileName = string.Empty;
            WorkItemStore workItemStore = _tfsPrCollection.GetService<WorkItemStore>();
            WebClient webClient = new WebClient();
            bool FileNameMatch = false;
            if ((_testCaseCollection != null && _testCaseCollection.Any()))
            {
                webClient.Credentials = _tfsPrCollection.Credentials;
                if ((_testCaseCollection != null && _testCaseCollection.Any()))
                {
                    foreach (ITestSuiteEntry testcase in _testCaseCollection)
                    {
                        if (testcase.TestCase.Actions.Any())
                        {
                            foreach (ITestAction testAction in testcase.TestCase.Actions)
                            {
                                var steptype = testAction.GetType();
                                if (steptype.Name != "SharedStepReference")
                                {
                                    var testStep = (ITestStep)testAction;
                                    IAttachmentCollection attachments = ((ITestStep)(testStep)).Attachments;
                                    if (attachments.Any())
                                    {
                                        int count = attachments.Count();
                                        if (count == 1)
                                        {
                                            foreach (var file in files)
                                            {
                                                if (AttachmentLocalFileMatch(attachments[0].Name, Path.GetFileName(file), testcase.Id.ToString()))
                                                //if (attachments[0].Name == GetLocalFileName(attachments[0].Name, Path.GetFileName(file), testcase.Id.ToString())) ;
                                                {
                                                    FileNameMatch = true;
                                                    attachments.RemoveAt(0);
                                                    ITestAttachment attachment = testStep.CreateAttachment(file);
                                                    testStep.Attachments.Add(attachment);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (testcase.TestCase.IsDirty) testcase.TestCase.Save();
                    }
                }
                if (FileNameMatch)
                    MessageBox.Show("Upload Successful...", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Didnt upload any file!!!", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            //ITestCaseCollection testcases = suite.AllTestCases;

            // Create target folder.
            //Will bring only the Test Case under a specific Test Suite.

            //if ((TestCaseCollection != null && TestCaseCollection.Any()))
            //{
            //    foreach (ITestSuiteEntry testcase in TestCaseCollection)
            //    {
            //        if (testcase.TestCase.Actions.Any())
            //        {
            //            foreach (ITestStep testStep in testcase.TestCase.Actions)
            //            {
            //                IAttachmentCollection attachments = ((ITestStep)(testStep)).Attachments;
            //                if (attachments.Any())
            //                {
            //                    int count = attachments.Count();
            //                    if (count == 1)
            //                    {
            //                        var file[] = Path.GetFileName(files);
            //                        fileName = Path.GetFullPath(file);
            //                        attachments.RemoveAt(0);
            //                        //Create Test Step Attachment
            //                        ITestAttachment attachment = testStep.CreateAttachment(file);
            //                        testStep.Attachments.Add(attachment);
            //                    }

            //                    //foreach (ITestAttachment attachment in attachments)
            //                    //{
            //                    //    foreach (var file in files)
            //                    //    {
            //                    //        fileName = Path.GetFileName(file);
            //                    //        if (attachment.Name == fileName)
            //                    //            fileMatch = true;
            //                    //    }
            //                    //}
            //                }
            //            }
            //            testcase.TestCase.Save();
            //        }

            //        //WorkItem workItem = workItemStore.GetWorkItem(testcase.Id);
            //        //foreach (Attachment attachment in workItem.Attachments)
            //        //{
            //        //    webClient.DownloadFile(attachment.Uri, System.IO.Path.Combine(dumpFolder, string.Format("{0} - {1}", Convert.ToString(workItem.Id), attachment.Name)));
            //        //}
            //    }
            //    MessageBox.Show("Downloaded to:" + dumpFolder, "Download Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}
            //else MessageBox.Show("No Test Case to Download", "Download Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public void UploadAttachments(string[] files, List<string> selectedTestCases)
        {
            var fileName = string.Empty;
            WorkItemStore workItemStore = _tfsPrCollection.GetService<WorkItemStore>();
            WebClient webClient = new WebClient();
            bool FileNameMatch = false;
            if ((_testCaseCollection != null && _testCaseCollection.Any()))
            {
                webClient.Credentials = _tfsPrCollection.Credentials;
                if ((_testCaseCollection != null && _testCaseCollection.Any()))
                {
                    foreach (ITestSuiteEntry testcase in _testCaseCollection)
                    {
                        if (testcase.TestCase.Actions.Any())
                        {
                            if (selectedTestCases.Contains(testcase.Id.ToString()))
                            {
                                foreach (ITestAction testAction in testcase.TestCase.Actions)
                                {
                                    var steptype = testAction.GetType();
                                    if (steptype.Name != "SharedStepReference")
                                    {
                                        var testStep = (ITestStep)testAction;
                                        IAttachmentCollection attachments = ((ITestStep)(testStep)).Attachments;
                                        if (attachments.Any())
                                        {
                                            int count = attachments.Count();
                                            if (count == 1)
                                            {
                                                foreach (var file in files)
                                                {
                                                    if (AttachmentLocalFileMatch(attachments[0].Name, Path.GetFileName(file), testcase.Id.ToString()))
                                                    //if (attachments[0].Name == GetLocalFileName(attachments[0].Name, Path.GetFileName(file), testcase.Id.ToString())) ;
                                                    {
                                                        FileNameMatch = true;
                                                        attachments.RemoveAt(0);
                                                        ITestAttachment attachment = testStep.CreateAttachment(file);
                                                        testStep.Attachments.Add(attachment);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (testcase.TestCase.IsDirty) testcase.TestCase.Save();
                    }
                }
                if (FileNameMatch)
                    MessageBox.Show("Upload Successful...", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Didnt upload any file!!!", "Upload Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btUpload_Click(object sender, EventArgs e)
        {
            // show the progress bar when the associated event fires (here, a button click)
            //progressBar1.Visible = true;

            // start the long running task async
            List<string> TCs = new List<string>();
            try
            {
                if (_testCaseCollection != null && _testCaseCollection.Any())
                {
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        var files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);

                        if (files.Any())
                        {
                            TCs = SelectedWorkItems();
                            if (TCs.Count > 0) UploadAttachments(files, TCs);
                            else UploadAttachments(files);
                            //backgroundWorker1.RunWorkerAsync();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Testcases not selected!!!", "Upload Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Upload Aborted!!!" + ex.Message.ToString(), "Upload Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipTitle = "";
        }

        private void cbTestPlans_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void checkAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = true;
            }
        }

        private void checkAll_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.checkAll, "Check All");
        }

        private List<string> GetTestSuites(string selectedTestPlan)
        {
            Stack<string> stack = new Stack<string>();
            try
            {
                if (!(string.IsNullOrEmpty(selectedTestPlan)))
                {
                    _selTestPlan = _testproject.TestPlans.Query("SELECT * FROM TestPlan")
                                    .FirstOrDefault(tp => selectedTestPlan != null && tp.Name == selectedTestPlan);
                    //ITestSuiteCollection testsuites = testproject.TestSuites.Query("Select * from TestSuite");
                    if (_selTestPlan != null)
                    {
                        if (_selTestPlan.RootSuite != null)
                        {
                            _testSuiteCollection = _selTestPlan.RootSuite.Entries;
                            if (_selTestPlan.RootSuite != null && _selTestPlan.RootSuite.Entries.Count >= 1)
                            {
                                foreach (
                                    ITestSuiteEntry suiteEntry in
                                        _testSuiteCollection.Where(suiteEntry => suiteEntry != null))
                                {
                                    ITestSuiteBase testsuite = suiteEntry.TestSuite;
                                    //var dynamicSuite = suiteEntry.TestSuite as ITestSuiteBase;
                                    switch (suiteEntry.EntryType)
                                    {
                                        case TestSuiteEntryType.StaticTestSuite:
                                            if (testsuite == null) throw new ArgumentNullException("selectedTestPlan");
                                            stack.Push(testsuite.Title);
                                            //GetTestCases(testsuite);
                                            break;

                                        case TestSuiteEntryType.DynamicTestSuite:
                                            if (testsuite == null) throw new ArgumentNullException("selectedTestPlan");
                                            stack.Push(testsuite.Title);
                                            //GetTestCases(testsuite);
                                            break;
                                    }
                                }
                            }
                        }
                    }
                    else _testSuiteCollection = null;
                }

                stack.Push(string.Empty);
                return stack.ToList();
            }
            catch (Exception)
            {
                _testSuiteCollection = null;
                stack.Push(string.Empty);
                return stack.ToList();
            }
        }

        private void invertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                if (item.Checked == true) item.Checked = false;
                else item.Checked = true;
            }
        }

        private void invertSelection_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.invertSelection, "Invert");
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.listView1.Sort();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private List<string> SelectedWorkItems()
        {
            ListView.CheckedListViewItemCollection checkedItems = listView1.CheckedItems;
            List<string> testCaseList = new List<string>();
            var TestCase = string.Empty;
            if (checkedItems.Count > 0)
            {
                foreach (ListViewItem item in checkedItems)
                {
                    testCaseList.Add(item.SubItems[1].Text.ToString());

                    //testCaseList.add(item.SubItems[1].ToString());
                }
                //ExecuteTestCases(testCaseList);
            }

            return testCaseList;
        }

        private void uncheckAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Checked = false;
            }
        }

        private void uncheckAll_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(this.uncheckAll, "Uncheck All");
        }

        #endregion Methods of Form1 (35)

        public void DownloadTestResults(List<string> selectedTestCases)
        {
            //AllTestCases - Will show all the Test Cases under that Suite even in sub suites.
            //ITestCaseCollection testcases = suite.AllTestCases;
            bool attachmentFound = false;
            try
            {
                // Create target folder.
                String dumpFolder = @"C:\Download\" + DateTime.Today.ToString("yyMMdd") + DateTime.Now.ToString("HHmmss");
                DirectoryInfo directoryInfo = Directory.CreateDirectory(dumpFolder);
                //Will bring only the Test Case under a specific Test Suite.
                //WorkItemStore workItemStore = TfsPrCollection.GetService<WorkItemStore>();
                WebClient webClient = new WebClient();
                webClient.Credentials = _tfsPrCollection.Credentials;
                foreach (string testcase in selectedTestCases)
                {
                    ITestCaseResult testResult = _testproject.TestResults.ByTestId(Convert.ToInt32(testcase)).OrderBy(testRunID => testRunID.TestRunId).LastOrDefault();
                    if (testResult != null)
                    {
                        IAttachmentCollection testResultAttachments = _testproject.TestRuns.Find(testRunId: testResult.Id.TestRunId).Attachments;
                        if (testResultAttachments.Any())
                        {
                            foreach (ITestAttachment attachment in testResultAttachments)
                            {
                                if (attachment.IsComplete)
                                {
                                    attachmentFound = true;
                                    string FullFilePath = Path.Combine(dumpFolder, DownloadFileName(attachment.Name, testcase));
                                    webClient.DownloadFile(attachment.Uri, FullFilePath);
                                }
                            }
                        }
                    }
                }
                if (attachmentFound)
                    MessageBox.Show("Downloaded to:" + dumpFolder, "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                else
                    MessageBox.Show("Test results not found!!!", "Download Message", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
                return;
            }
        }

        private void btDownloadResults_Click(object sender, EventArgs e)
        {
            List<string> TCs = new List<string>();
            try
            {
                if (_testCaseCollection != null && _testCaseCollection.Any())
                {
                    TCs = SelectedWorkItems();

                    if (TCs.Count > 0)
                        DownloadTestResults(TCs);
                }
                else
                {
                    MessageBox.Show("Please select test cases to download!!!", "Download Message", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bool attachmentFound = false;
            var testCaseID = ((ListView)sender).SelectedItems[0].SubItems[1].Text;
            ITestCaseResult testResult = _testproject.TestResults.ByTestId(Convert.ToInt32(testCaseID)).OrderBy(testRunID => testRunID.TestRunId).LastOrDefault();
            if (testResult != null)
            {
                IAttachmentCollection testResultAttachments = _testproject.TestRuns.Find(testRunId: testResult.Id.TestRunId).Attachments;
                if (testResultAttachments.Any())
                {
                    //attachmentFound = true;
                    foreach (ITestAttachment attachment in testResultAttachments)
                    {
                        //if (attachment.Name.Contains("html"))
                        {
                            attachmentFound = true;
                            Process.Start(attachment.Uri.ToString());
                        }
                    }
                }
            }
            if (!attachmentFound)
                MessageBox.Show("Test results not found!!!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
        }

        public class ListViewColumnSorter : IComparer
        {
            /// <summary>
            /// Specifies the column to be sorted
            /// </summary>
            private int ColumnToSort;
            /// <summary>
            /// Specifies the order in which to sort (i.e. 'Ascending').
            /// </summary>
            private SortOrder OrderOfSort;
            /// <summary>
            /// Case insensitive comparer object
            /// </summary>
            private CaseInsensitiveComparer ObjectCompare;

            /// <summary>
            /// Class constructor.  Initializes various elements
            /// </summary>
            public ListViewColumnSorter()
            {
                // Initialize the column to '0'
                ColumnToSort = 0;

                // Initialize the sort order to 'none'
                OrderOfSort = SortOrder.None;

                // Initialize the CaseInsensitiveComparer object
                ObjectCompare = new CaseInsensitiveComparer();
            }

            /// <summary>
            /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
            /// </summary>
            /// <param name="x">First object to be compared</param>
            /// <param name="y">Second object to be compared</param>
            /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
            public int Compare(object x, object y)
            {
                int compareResult;
                ListViewItem listviewX, listviewY;

                // Cast the objects to be compared to ListViewItem objects
                listviewX = (ListViewItem)x;
                listviewY = (ListViewItem)y;

                // Compare the two items
                compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

                // Calculate correct return value based on object comparison
                if (OrderOfSort == SortOrder.Ascending)
                {
                    // Ascending sort is selected, return normal result of compare operation
                    return compareResult;
                }
                else if (OrderOfSort == SortOrder.Descending)
                {
                    // Descending sort is selected, return negative result of compare operation
                    return (-compareResult);
                }
                else
                {
                    // Return '0' to indicate they are equal
                    return 0;
                }
            }

            /// <summary>
            /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
            /// </summary>
            public int SortColumn
            {
                set
                {
                    ColumnToSort = value;
                }
                get
                {
                    return ColumnToSort;
                }
            }

            /// <summary>
            /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
            /// </summary>
            public SortOrder Order
            {
                set
                {
                    OrderOfSort = value;
                }
                get
                {
                    return OrderOfSort;
                }
            }

        }

    }
}