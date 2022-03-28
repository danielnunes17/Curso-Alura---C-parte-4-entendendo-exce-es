using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Program
    {
        static void Main(string[] args) //O controle da aplicação está no método Main, uma linha vai chamando a próxima em forma de pilha, a maquina virtual faz os testes de cima para baixo
        {
            CarregarContas();
            
        }
        private static void CarregarContas()
        {
            using (LeitorDeArquivo leitor = new LeitorDeArquivo("teste.txt")) //O using funcina como um try e finally que verifica se a referencia leitor é nula
            {
                leitor.LerProximaLinha();
            }

            //======================================================================


        //    LeitorDeArquivo leitor = null;
        //    try
        //    {
        //        leitor = new LeitorDeArquivo("contas.txt");

        //        leitor.LerProximaLinha();
        //        leitor.LerProximaLinha();
        //        leitor.LerProximaLinha();
        //    }
        //    catch (IOException)
        //    {
        //        Console.WriteLine("Exceção do tipo IOException capturada e tratada");
        //    }
        //    finally //sempre será executada de qq maneira com exceção ou não ele será executado
        //    {
        //        if(leitor != null)
        //        {
        //            leitor.Fechar();
        //        }
                
        //    }
        }
        private static void TestarInnerException()
        {
            try
            {
                ContaCorrente conta1 = new ContaCorrente(123, 123456789);

                ContaCorrente conta2 = new ContaCorrente(987, 654123);

                //conta1.Transferir(10000, conta2);
                conta1.Sacar(10000);
            }
            catch (OperacaoFinanceiraException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Operação INNER EXCEPTION (informação interna):");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
            catch (ArgumentException ex)
            {
                if (ex.ParamName == "conta")
                {

                }
                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma excessão do tipo ArgumentException"); //Usando um argumento especifico e não genérico como usamos na classe ContaCorrente
                Console.WriteLine(ex.Message);
            }

            try //O Try e o Cacth são um controle de fluxo
            {
                Metodo();
            }
            catch (DivideByZeroException) //podemos ter quantos catch for necessários após o try
            {
                Console.WriteLine("Não é possivel divisão por zero");
            }
            catch (Exception e) //Usando o Exception a classe que contem todos os tipos possiveis de excessões dentro do .NET ele deve sempre ser definido por último na ordem de catchs
            {
                Console.WriteLine(e.StackTrace);
                Console.WriteLine(e.Message);
                Console.WriteLine("Aconteceu um erro");

            }
            //Teste com a cadeia de chamada:
            //Metodo -> TestaDivisao -> Dividir
        }
        private static void Metodo()
            {
                TestaDivisao(0);
            ContaCorrente conta = new ContaCorrente(882, 8825566);

            Console.WriteLine(ContaCorrente.TaxaOperacao);
            }
            private static void TestaDivisao(int divisor)
            {
                int resultado = Dividir(10, divisor);

                Console.WriteLine("Resultado da divisão de 10 por" + divisor + "é" + resultado);
            }             
            private static int Dividir(int numero, int divisor)
            {
                try
                {
                    return numero / divisor;
                }
                catch(DivideByZeroException)
                {
                    Console.WriteLine("Excessão com o número = " + numero + " e divisor = " + divisor);
                    throw; //aqui estamos lançando a excessão que o bloco do catch pegou e agora não tem mais return, o throw é controle de fluxo, ele encerra o processamento do método e vai para o próximo método na pilha
                    
                }
            }
    }
}
 

