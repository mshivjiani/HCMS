using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Telerik.Web.UI;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups ;
using System.Web.UI.HtmlControls;
using System.Text;

namespace HCMS.JNP.Controls.Search
{
    public partial class ctrlSearchKSA : UserControlBase
    {

        #region Properties

        private RadComboBox _ksaComboBox;
        private Label _searchMssgLabel;
        private List<KSAEntity> _ksaList;
        
        public RadComboBox KSAComboBox
        {
            get { return this._ksaComboBox; }
            set { this._ksaComboBox = value; }
        }

        public Label SearchMessageLabel
        {
            get { return this._searchMssgLabel; }
            set { this._searchMssgLabel = value; }
        }

        public string KeywordSearched
        {
            get { return txtKeyword.Text; }
        }

        public bool ShowAllGradesChecked
        {
            get { return chkAllGrades.Checked; }
        }

        public List<KSAEntity> KSAList
        {
            get { return this._ksaList; }
            set { this._ksaList = value; }
        }

        public int SeriesID
        {
            get
            {
                if (ViewState["SeriesID"] == null)
                    ViewState["SeriesID"] = -1;

                return (int)ViewState["SeriesID"];
            }
            set
            {
                ViewState["SeriesID"] = value;
            }
        }

        public int CurrentGrade
        {
            get
            {
                if (ViewState["CurrentGrade"] == null)
                {
                    ViewState["CurrentGrade"] = 0;

                }
                return (int)ViewState["CurrentGrade"];
            }
            set { ViewState["CurrentGrade"] = value; }
        }

        #endregion

        #region Events Delegates

        public delegate void KSASearchCompletedHandler(object sender, EventArgs e);
        public event KSASearchCompletedHandler KSASearchCompleted;
        public delegate void KSASearchCancelCompleteHandler(object sender, EventArgs e);
        public event KSASearchCancelCompleteHandler KSASearchCancelCompleted;
        public delegate void KSASearchClearCompleteHandler(object sender, EventArgs e);
        public event KSASearchClearCompleteHandler KSASearchClearCompleted;

        public delegate void KSASearchUnckeckedHandler(object sender, EventArgs e);
        public event KSASearchUnckeckedHandler KSASearchUnckecked;

        //public delegate void KSAImageClickRequiredFieldHandler(object sender, EventArgs e);
        //public event KSAImageClickRequiredFieldHandler KSAImangeClickForReqValidation;

        #endregion

        public string SetSearchResultMessage()
        {
            string mssg = "";
            var keywordSearch = "";
            if (txtKeyword.Text.Length > 0) keywordSearch = ". Searched on keyword: " + txtKeyword.Text;
            if (chkAllGrades.Checked)
                mssg = string.Format("Search KSA in Series:{0}" + keywordSearch, SeriesID.ToString());
            else
                mssg = string.Format("Search KSA in Series:{0} - Grade:{1}" + keywordSearch, SeriesID.ToString(), CurrentGrade.ToString());
            return mssg;
        }

        public void SetSearchResultMessage(ref Label messageLabel)
        {
            if (messageLabel != null) messageLabel.Text = SetSearchResultMessage();
        }

        public void SetSearchResultMessage(ref Literal messageLabel)
        {
            if (messageLabel != null) messageLabel.Text = SetSearchResultMessage();
        }



        protected void chkAllGrades_OnCheckedChanged(object sender, EventArgs e)
        {
            btnSearch_Click(sender, e);
            if (!chkAllGrades.Checked && KSASearchUnckecked != null) KSASearchUnckecked(sender, e);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            RunSearchFillKSAList();
            if (KSASearchCompleted != null) KSASearchCompleted(sender, e);
            // If a link to a search status/message label was provided, show search message
            if (SearchMessageLabel != null) SearchMessageLabel.Text = SetSearchResultMessage();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtKeyword.Text = string.Empty;
            //chkAllGrades.Checked = false;
            RunSearchFillKSAList();
            if (KSASearchClearCompleted != null) KSASearchClearCompleted(sender, e);
            if (SearchMessageLabel != null) SearchMessageLabel.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            spanright.Visible = false;
            if (KSASearchCancelCompleted != null) KSASearchCancelCompleted(sender, e);
            if (SearchMessageLabel != null) SearchMessageLabel.Text = "";
        }

        private List<KSAEntity> GetKSAList()
        {
            List<Grade> selectedgrades = new List<Grade>();
            bool selectallgrades = chkAllGrades.Checked;
            if (selectallgrades)
            {
                selectedgrades = LookupManager.GetAllGrades();
            }
            else
            {
                selectedgrades.Add(new Grade() { GradeID = CurrentGrade });
            }

            var ksalist = KSAEntityManager.GetKSAEntityList(SeriesID, selectedgrades, txtKeyword.Text);
            var orderedList = ksalist.OrderBy(o => o.KSAText).ToList();
            return orderedList;
        }

        public void RunSearchFillKSAList()
        {
            var items = GetKSAList();
            AddKSAItemsToComboBox(items);
        }

        private void AddKSAItemsToComboBox(List<KSAEntity> items)
        {
            items.RemoveAll(m => m.KSAText == UserControlBase.OTHERKSATEXT);
            var orderedItems = items.OrderBy(o => o.KSAText).ToList();
            orderedItems.Insert(0, new KSAEntity() { KSAID = 0, KSAText = UserControlBase.OTHERKSATEXT  });
            
            // Set KSA list property for external use
            KSAList = orderedItems;

            // If search has linked KSA combo box, go ahead and fill it
            if (KSAComboBox != null)
            {
                KSAComboBox.Items.Clear();

                //KSAComboBox.Items.Insert(0, new RadComboBoxItem("<<-- Select KSA -->>", "-1"));
                //foreach (KSAEntity item in orderedItems)
                //    KSAComboBox.Items.Add(new RadComboBoxItem(item.KSAText, item.KSAID.ToString()));
                //ControlUtility.SetDropdownListItemsBackground(KSAComboBox);

                HCMS.WebFramework.Site.Utilities.ControlUtility.BindRadComboBoxControlWithBackground(KSAComboBox, KSAList, null, "KSAText", "KSAID", "<<--Select KSA First-->>");  
            }
        }

        protected void imgsrchBttn_Click(object sender, ImageClickEventArgs e)
        {
           bool  blnvisible=spanright.Visible ;
           spanright.Visible = !blnvisible;

           //if (KSAImangeClickForReqValidation != null)
               //KSAImangeClickForReqValidation(sender, e);
           
        }

         
    }
}