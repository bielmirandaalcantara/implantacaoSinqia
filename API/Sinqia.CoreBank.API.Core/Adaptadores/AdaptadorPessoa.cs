using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sinqia.CoreBank.API.Core.Models;
using Sinqia.CoreBank.API.Core.Constantes;

namespace Sinqia.CoreBank.API.Core.Adaptadores
{
    public class AdaptadorPessoa
    {
        public MsgRetorno AdaptarMsgRetorno(MsgPessoa msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPessoa.header != null)
            {
                identificador = msgPessoa.header.identificadorEnvio;
                dataEnvio = msgPessoa.header.dataHoraEnvio.HasValue ? msgPessoa.header.dataHoraEnvio.Value : DateTime.Now;
            }
            
            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            retorno.header = header;
            return retorno;
        }

        public MsgRetorno AdaptarMsgRetorno(MsgPessoaCompleto msgPessoa, IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            if (msgPessoa.header != null)
            {
                identificador = msgPessoa.header.identificadorEnvio;
                dataEnvio = msgPessoa.header.dataHoraEnvio.HasValue ? msgPessoa.header.dataHoraEnvio.Value : DateTime.Now;
            }

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            retorno.header = header;
            return retorno;
        }

        public MsgRetorno AdaptarMsgRetorno(IList<string> erros)
        {
            MsgRetorno retorno = new MsgRetorno();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };

            retorno.header = header;
            return retorno;
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(IList<string> erros)
        {
            return AdaptarMsgRetornoGet(null, erros);
        }

        public MsgRetornoGet AdaptarMsgRetornoGet(object msg, IList<string> erros) 
        {
            MsgRetornoGet retorno = new MsgRetornoGet();
            string identificador = string.Empty;
            DateTime dataEnvio = DateTime.MinValue;
            string status = erros.Any() ? ConstantesIntegracao.StatusIntegracao.Erro : ConstantesIntegracao.StatusIntegracao.OK;

            var header = new MsgHeaderRetorno()
            {
                identificador = identificador,
                dataHoraEnvio = dataEnvio,
                dataHoraRetorno = DateTime.Now,
                status = status
            };
            retorno.header = header;

            if (!erros.Any() && msg != null)
                retorno.body = msg;

            return retorno;
        }

        public MsgRegistropessoaCompleto AdaptarMsgRegistropessoaCompleto()
        {
            return new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste"                
            };
        }

        public IList<MsgRegistropessoaCompleto> AdaptarMsgRegistropessoaCompletoLista()
        {
            List<MsgRegistropessoaCompleto> listaRegristros = new List<MsgRegistropessoaCompleto>();
            listaRegristros.Add(new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste"
            });

            listaRegristros.Add(new MsgRegistropessoaCompleto()
            {
                nomePessoa = "Teste 1"
                ,dataAtualizacao = DateTime.Now
                ,dataInicio = DateTime.Now
                ,nomeMae = "Mãe do Teste 1"
            });

            return listaRegristros;
        }
    }
}