using System.ComponentModel.DataAnnotations;

namespace OHD.ModelsViews
{
	public class ModifiyPasswordView
	{
		public ModifiyPasswordView()
		{

		}
		public int Id { get; set; }
		[Required]
		public string? oldPassword { get; set; }
		[DataType(DataType.Password)]

		public string? NewPassword { get; set; }
		[DataType(DataType.Password)]
		[Compare("NewPassword")]
		public string? ConfrimPassword { get; set; }


	}
}
