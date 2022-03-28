using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class OperacaoFinanceiraException : Exception //Classe de excessão com os contrutores para ser usado na classe conta corrente
    {
        public OperacaoFinanceiraException()
        {

        }
        public OperacaoFinanceiraException(string mensagem)
            :base(mensagem)
        {

        }
        public OperacaoFinanceiraException(string mensagem, Exception excessaoInterna)
            :base(mensagem, excessaoInterna)
        {

        }
    }
}
