using System;


namespace ByteBank
{
    public class ContaCorrente
    {
        public static double TaxaOperacao { get; private set; } //Por ser uma caracteristica da classe, será static
        public static int TotalDeContasCriadas { get; private set; }
        public Cliente Titular { get; set; }
        public int Agencia { get; } //Quando eu uso somente o get, a variavel fica protegida como se usasse o readonly
       
        public int Conta { get; }

        private double _saldo = 100;
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }
                _saldo = value;
            }
        }

        public int ContadorSaquesNaoPermitidos { get; private set; }
        public int ContadorTransferenciasNaoPermitidas { get; private set; }

        public ContaCorrente(int numeroAgencia, int numeroConta)
        {
            if(numeroAgencia <= 0)
            {
                throw new ArgumentException("o número da agência deve ser maior que 0!" , nameof(numeroAgencia)); //nameof é um operador que retorna uma string com o nome do parametro
            }
            if(numeroConta <= 0)
            {
                throw new ArgumentException("O número da conta está inválido, deve ser maior que 0" , nameof(numeroConta)); //ParamName mostra o tipo do argumento usado
            }
            Agencia = numeroAgencia;
            Conta = numeroConta;

            TotalDeContasCriadas++;
            TaxaOperacao = 30 / TotalDeContasCriadas; //Regra de negócio, quanto mais contas criadas, menor será a taxa de operação
         }
        public void Sacar(double valor)
        {
            if(valor < 0)
            {
               
                throw new ArgumentException("Valor inválido!!!", nameof(valor));
            }
            if (_saldo < valor)
            {
                ContadorSaquesNaoPermitidos++;
                throw new SaldoInsuficienteException(Saldo, valor);
            }
            
        }
        public void Depositar(double valor)
        {
            _saldo += valor;
        }
        public void Transferir(double valor, ContaCorrente contaDestino)
        {
         
            if (valor < 0)
            {
                
                throw new ArgumentException("Valor inválido para transferência!!!", nameof(valor));
            }
            try
            {
                Sacar(valor); //chamando o método sacar
            }
            catch(SaldoInsuficienteException ex)
            {
                ContadorTransferenciasNaoPermitidas++;
                throw;
            }

            contaDestino.Depositar(valor);
            
        }
    }
}
