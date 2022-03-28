using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException //Criando nossa própria excessão
    {
        public double Saldo { get; }//criando a propriedade somente leitura
        public double ValorSaque { get; }
        SaldoInsuficienteException() //Seguindo a convensão, construtor sem argumentos
        {

        }
        public SaldoInsuficienteException(double saldo, double valorSaque)
            : this("Tentativa de saque no valor de: R$" + valorSaque + "\nSeu saldo é insuficiente, valor: R$" + saldo)
            //O this significa que a partir de um construtor com 2 argumentos, estamos chamando o construtor SaldoInsufienteException com 1 argumento, o this passa a mensagem pra :base
        {
            Saldo = saldo; //propriedade atribunindo o argumento
            ValorSaque = valorSaque; //ValorSque é a propriedade e valorSaque é o argumento
        }
        public SaldoInsuficienteException(string mensagem): base(mensagem) //Seguindo a convenção, construtor com argumento, chamando a base que seta a propriedade message no Program
        {

        }
        public SaldoInsuficienteException(string mensagem, Exception excecaoInterna)
            : base(mensagem, excecaoInterna)
        {

        }//Boa prática: 1 construtor vazio, 1 construtor com uma menssagem, 1 construtor com a Inner Exception
    }
}
