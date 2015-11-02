using System;
namespace HCMS.Business.OrganizationChart.Processing
{
    public interface ITemporaryDocument
    {
        Guid DocumentID { get; set; }
        int UserID { get; set; }
        byte[] DocumentData { get; set; }
    }
}
