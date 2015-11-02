using System;
namespace HCMS.Business.NarrativeFactor
{
    interface INarrativeFactor
    {
        bool Equals(object obj);
        string FactorDescription { get; set; }
        int FactorID { get; set; }
        string FactorTitle { get; set; }
        int GetHashCode();
        string ToString();
        string ToXML();
    }
}
