using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class LeitorDeArquivo : IDisposable //Usando a Interface IDisposable interna do .NET
    {
        public string Arquivo { get; }

        public LeitorDeArquivo(string arquivo)
        {
            Arquivo = arquivo;

            //throw new FileNotFoundException(); //exceção para quando o arquivo não for encontrado

            Console.WriteLine("Abrindo arquivo: " + arquivo);
        }

        public string LerProximaLinha()
        {
            Console.WriteLine("Lendo linha. . .");

            throw new IOException(); //Exceção de entrada ou saída
            return "Linha do arquivo";
        }
        public void Dispose() //Esse é o método que tem a responsabilidade de liberar os recursos
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
