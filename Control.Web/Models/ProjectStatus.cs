using System.ComponentModel.DataAnnotations;

namespace Control.Web.Models
{
	public enum ProjectStatus
	{
		[Display(Name = "Создано")]
		Created,
        [Display(Name = "В работе")]
		Active,
        [Display(Name = "Завершено")]
		Completed,
        [Display(Name = "Отложено")]
		Suspended
	}
}
