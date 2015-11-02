using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HCMS.Business.OrganizationChart.Processing
{
    [Serializable]
    public class ChartGenerationParameters
    {
        #region Object Declarations

        public int ID { get; set; }
        public OrganizationChartTypeViews ChartType { get; set; }
        public Guid DocumentID { get; set; }

        #endregion

        #region Constructor

        public ChartGenerationParameters()
        {
            this.ID = -1;
            this.ChartType = OrganizationChartTypeViews.None;
            this.DocumentID = Guid.Empty;
        }

        public ChartGenerationParameters(int loadID, OrganizationChartTypeViews loadChartType)
        {
            this.ID = loadID;
            this.ChartType = loadChartType;
            this.DocumentID = Guid.Empty;
        }

        #endregion
    }
}
