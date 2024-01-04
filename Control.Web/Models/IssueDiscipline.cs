using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public enum IssueDiscipline
    {
        [Display(Name = "АР")]
        Architecture,
        [Display(Name = "КР")]
        Structure,
        [Display(Name = "ВиК")]
        WSS,
        [Display(Name = "ОВиК")]
        HVAC,
        [Display(Name = "ЭС")]
        Electrics,
        [Display(Name = "CC")]
        LowVoltage,
        [Display(Name = "КИПиА")]
        Instrumentation
    }
}
