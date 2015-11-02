using System;
namespace HCMS.Business.SeriesFactorLevelLanguage
{
    public interface ISeriesFactorLevelLanguage
    {
        bool Equals(object obj);
        enumFactorFormatType FactorFormatTypeID { get;  }
        int FactorID { get; set; }
        int FactorLevelID { get; set; }
        string FactorLevelLanguage { get; set; }     
        int GetHashCode();
        int LevelID { get; set; }
        int Point { get; set; }
        int SeriesID { get; set; }
        string ToString();
        string ToXML();
    }
}
