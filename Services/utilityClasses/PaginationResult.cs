namespace OHD.Services.utilityClasses
{
	//Refrecnce in youtube vedio https://www.youtube.com/watch?v=oZXpDPp1qig&list=PL18HZjtdIA4CbwXGBa83yC9GUxQiAUS8-&index=8  

	public class PaginationResult<T> where T : class
	{
		public PaginationResult() { }
		public List<T> Data { get; set; }
		public int TotalItems { get; set; }
		public int PageIndex { get; set; }
		public int PageSize { get; set; }
	}
}
