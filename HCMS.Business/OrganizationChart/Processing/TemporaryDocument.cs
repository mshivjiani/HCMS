using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.OrganizationChart.Processing
{
    /// <summary>
    /// General class for handling uploads
    /// We use the database as a temp directory instead of the file system
    /// </summary>
    public class TemporaryDocument : ITemporaryDocument
    {
        #region Object Declarations

        public Guid DocumentID { get; set; }
        public int UserID { get; set; }
        public byte[] DocumentData { get; set; }
        public DateTime? UploadDate { get; set; }
        public long SizeInBytes { get; set; }
        public string AttributeData { get; set; }

        #endregion

        #region Constructor

        public TemporaryDocument()
        {
            this.DocumentID = Guid.Empty;
            this.UserID = -1;
            this.DocumentData = null;
            this.UploadDate = null;
            this.SizeInBytes = 0;
            this.AttributeData = string.Empty;
        }

        #endregion
    }
}
