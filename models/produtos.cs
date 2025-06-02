using Microsoft.EntityFrameworkCore.Storage.Json;

namespace WebApplication1.models
{
	public class produtos : Base
	{
		public string? Nome{ get; set; }
		public string? Descricao { get; set; }
		public int  Quantidade { get; set; }
		public decimal Valor { get; set; }


		// tipos de dados 
		string nome = "Etec"; // tipo de ref
		char letra = 'e';

		int valor = 10; // numeros inteiros
		long valor1 = 10L;
		byte valorB = 127;


		double valor2 = 10.0;
		float valor3 = 10.5F;
}
