namespace WebApiChallange.Data.Dtos
{
	public class ReadCategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<ReadVideoDto> Videos { get; set; }
	}
}
