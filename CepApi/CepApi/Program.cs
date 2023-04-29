using CepApi;
using Refit;

internal class Program
{
    static async Task Main(string[] args)
    {
        try
        {
            var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
            Console.WriteLine("Informe seu CEP:");

            string cepInformado = Console.ReadLine().ToString();
            Console.WriteLine("Consultando informações do CEP: " + cepInformado);

            var address = await cepClient.GetAddressAsync(cepInformado);

            Console.Write($"\nLogradouro:{address.Logradouro}\nBairro:{address.Bairro}" + $"\nEstado:{address.Uf}\nCódigo Ibge:{address.Ibge},\nComplemento:{address.Complemento}");
            
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro na consulta de cep:" +ex.Message);
        }
    }
}