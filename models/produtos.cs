namespace WebApplication1.models
{
	public class produtos : Base
	{
		public string? Nome{ get; set; }
		public string? Descricao { get; set; }
		public int  Quantidade { get; set; }
		public decimal Valor { get; set; }

	}
}
