using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
    public enum IssueStatus
    {
        [Display(Name = "Создано")]
        Created,
        [Display(Name = "В работе")]
        Active,
        [Display(Name = "Отработано")]
        Fixed,
        [Display(Name = "Отложено")]
        Suspended
    }
}
