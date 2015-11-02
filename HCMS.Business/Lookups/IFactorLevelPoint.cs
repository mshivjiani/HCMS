using System;
namespace HCMS.Business.Lookups
{
   public interface IFactorLevelPoint
    {
        int FactorID { get; set; }
        int FactorLevelID { get; set; }
        int LevelID { get; set; }
        int Point { get; set; }
        
    }
}
