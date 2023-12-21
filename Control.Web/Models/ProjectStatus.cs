using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
	public enum ProjectStatus
	{
		[Display(Name = "Создан")]
		Created,
        [Display(Name = "В работе")]
		Active,
        [Display(Name = "Завершен")]
		Completed,
        [Display(Name = "Отложен")]
		Suspended
	}
}
