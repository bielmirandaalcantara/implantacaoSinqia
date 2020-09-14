﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CucCluParametro", Namespace="http://schemas.datacontract.org/2004/07/CucCpwCadastros.Estruturas")]
    public partial class CucCluParametro : object
    {
        
        private int DependenciaField;
        
        private int EmpresaField;
        
        private string IPField;
        
        private string LoginField;
        
        private string SiglaAplicacaoField;
        
        private string TokenField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Dependencia
        {
            get
            {
                return this.DependenciaField;
            }
            set
            {
                this.DependenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Empresa
        {
            get
            {
                return this.EmpresaField;
            }
            set
            {
                this.EmpresaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IP
        {
            get
            {
                return this.IPField;
            }
            set
            {
                this.IPField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login
        {
            get
            {
                return this.LoginField;
            }
            set
            {
                this.LoginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SiglaAplicacao
        {
            get
            {
                return this.SiglaAplicacaoField;
            }
            set
            {
                this.SiglaAplicacaoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Token
        {
            get
            {
                return this.TokenField;
            }
            set
            {
                this.TokenField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CucCluRetorno", Namespace="http://schemas.datacontract.org/2004/07/CucCpwCadastros.Estruturas")]
    public partial class CucCluRetorno : object
    {
        
        private string CodigoContaRelacionamentoField;
        
        private string CodigoFilialField;
        
        private string CodigoPessoaField;
        
        private Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluExcecao ExcecaoField;
        
        private string TipoPessoaField;
        
        private string XmlField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoContaRelacionamento
        {
            get
            {
                return this.CodigoContaRelacionamentoField;
            }
            set
            {
                this.CodigoContaRelacionamentoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoFilial
        {
            get
            {
                return this.CodigoFilialField;
            }
            set
            {
                this.CodigoFilialField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string CodigoPessoa
        {
            get
            {
                return this.CodigoPessoaField;
            }
            set
            {
                this.CodigoPessoaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluExcecao Excecao
        {
            get
            {
                return this.ExcecaoField;
            }
            set
            {
                this.ExcecaoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string TipoPessoa
        {
            get
            {
                return this.TipoPessoaField;
            }
            set
            {
                this.TipoPessoaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Xml
        {
            get
            {
                return this.XmlField;
            }
            set
            {
                this.XmlField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CucCluExcecao", Namespace="http://schemas.datacontract.org/2004/07/CucCpwCadastros.Estruturas")]
    public partial class CucCluExcecao : object
    {
        
        private Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CategoriaExcecao CategoriaField;
        
        private long CodigoField;
        
        private string DetalheField;
        
        private string MensagemField;
        
        private string NomeColunaField;
        
        private string NomeTabelaField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CategoriaExcecao Categoria
        {
            get
            {
                return this.CategoriaField;
            }
            set
            {
                this.CategoriaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public long Codigo
        {
            get
            {
                return this.CodigoField;
            }
            set
            {
                this.CodigoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Detalhe
        {
            get
            {
                return this.DetalheField;
            }
            set
            {
                this.DetalheField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Mensagem
        {
            get
            {
                return this.MensagemField;
            }
            set
            {
                this.MensagemField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomeColuna
        {
            get
            {
                return this.NomeColunaField;
            }
            set
            {
                this.NomeColunaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string NomeTabela
        {
            get
            {
                return this.NomeTabelaField;
            }
            set
            {
                this.NomeTabelaField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CategoriaExcecao", Namespace="http://schemas.datacontract.org/2004/07/CucCpwCadastros.Estruturas")]
    public enum CategoriaExcecao : int
    {
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Validacao = 0,
        
        [System.Runtime.Serialization.EnumMemberAttribute()]
        Erro = 1,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="CucCluParametroSimples", Namespace="http://schemas.datacontract.org/2004/07/CucCpwCadastros.Estruturas")]
    public partial class CucCluParametroSimples : object
    {
        
        private int DependenciaField;
        
        private int EmpresaField;
        
        private string IPField;
        
        private string LoginField;
        
        private string SenhaField;
        
        private string SiglaAplicacaoField;
        
        private string UsuarioField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Dependencia
        {
            get
            {
                return this.DependenciaField;
            }
            set
            {
                this.DependenciaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int Empresa
        {
            get
            {
                return this.EmpresaField;
            }
            set
            {
                this.EmpresaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string IP
        {
            get
            {
                return this.IPField;
            }
            set
            {
                this.IPField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Login
        {
            get
            {
                return this.LoginField;
            }
            set
            {
                this.LoginField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Senha
        {
            get
            {
                return this.SenhaField;
            }
            set
            {
                this.SenhaField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string SiglaAplicacao
        {
            get
            {
                return this.SiglaAplicacaoField;
            }
            set
            {
                this.SiglaAplicacaoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Usuario
        {
            get
            {
                return this.UsuarioField;
            }
            set
            {
                this.UsuarioField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.ICucCliCadastroPessoaS" +
        "implificada")]
    public interface ICucCliCadastroPessoaSimplificada
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Selecionar", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/SelecionarResponse")]
        Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Selecionar(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Selecionar", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/SelecionarResponse")]
        System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> SelecionarAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/VerificarExistencia", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/VerificarExistenciaResponse")]
        Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno VerificarExistencia(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCpfCnpj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/VerificarExistencia", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/VerificarExistenciaResponse")]
        System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> VerificarExistenciaAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCpfCnpj);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Atualizar", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarResponse")]
        Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Atualizar(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaXmlAtualizacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Atualizar", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarResponse")]
        System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> AtualizarAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaXmlAtualizacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarSemToken", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarSemTokenResponse")]
        Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno AtualizarSemToken(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametroSimples axobParametrosLogin, string axvaXmlAtualizacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarSemToken", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/AtualizarSemTokenResponse")]
        System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> AtualizarSemTokenAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametroSimples axobParametrosLogin, string axvaXmlAtualizacao);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Excluir", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/ExcluirResponse")]
        Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Excluir(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICucCliCadastroPessoaSimplificada/Excluir", ReplyAction="http://tempuri.org/ICucCliCadastroPessoaSimplificada/ExcluirResponse")]
        System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> ExcluirAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public interface ICucCliCadastroPessoaSimplificadaChannel : Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.ICucCliCadastroPessoaSimplificada, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1")]
    public partial class CucCliCadastroPessoaSimplificadaClient : System.ServiceModel.ClientBase<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.ICucCliCadastroPessoaSimplificada>, Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.ICucCliCadastroPessoaSimplificada
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CucCliCadastroPessoaSimplificadaClient() : 
                base(CucCliCadastroPessoaSimplificadaClient.GetDefaultBinding(), CucCliCadastroPessoaSimplificadaClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CucCliCadastroPessoaSimplificadaClient(EndpointConfiguration endpointConfiguration) : 
                base(CucCliCadastroPessoaSimplificadaClient.GetBindingForEndpoint(endpointConfiguration), CucCliCadastroPessoaSimplificadaClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CucCliCadastroPessoaSimplificadaClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CucCliCadastroPessoaSimplificadaClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CucCliCadastroPessoaSimplificadaClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CucCliCadastroPessoaSimplificadaClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CucCliCadastroPessoaSimplificadaClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Selecionar(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa)
        {
            return base.Channel.Selecionar(axobParametrosLogin, axvaCodigoPessoa);
        }
        
        public System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> SelecionarAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa)
        {
            return base.Channel.SelecionarAsync(axobParametrosLogin, axvaCodigoPessoa);
        }
        
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno VerificarExistencia(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCpfCnpj)
        {
            return base.Channel.VerificarExistencia(axobParametrosLogin, axvaCpfCnpj);
        }
        
        public System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> VerificarExistenciaAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCpfCnpj)
        {
            return base.Channel.VerificarExistenciaAsync(axobParametrosLogin, axvaCpfCnpj);
        }
        
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Atualizar(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaXmlAtualizacao)
        {
            return base.Channel.Atualizar(axobParametrosLogin, axvaXmlAtualizacao);
        }
        
        public System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> AtualizarAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaXmlAtualizacao)
        {
            return base.Channel.AtualizarAsync(axobParametrosLogin, axvaXmlAtualizacao);
        }
        
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno AtualizarSemToken(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametroSimples axobParametrosLogin, string axvaXmlAtualizacao)
        {
            return base.Channel.AtualizarSemToken(axobParametrosLogin, axvaXmlAtualizacao);
        }
        
        public System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> AtualizarSemTokenAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametroSimples axobParametrosLogin, string axvaXmlAtualizacao)
        {
            return base.Channel.AtualizarSemTokenAsync(axobParametrosLogin, axvaXmlAtualizacao);
        }
        
        public Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno Excluir(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa)
        {
            return base.Channel.Excluir(axobParametrosLogin, axvaCodigoPessoa);
        }
        
        public System.Threading.Tasks.Task<Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluRetorno> ExcluirAsync(Sinqia.CoreBank.Services.CUC.WCF.CadatroPessoaSimplificada.CucCluParametro axobParametrosLogin, string axvaCodigoPessoa)
        {
            return base.Channel.ExcluirAsync(axobParametrosLogin, axvaCodigoPessoa);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada))
            {
                return new System.ServiceModel.EndpointAddress("http://attbhzs021.att.com.br:83/PROD/Sites/FIN/CUCWCF/CucClwCadastroPessoaSimplif" +
                        "icada.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CucCliCadastroPessoaSimplificadaClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CucCliCadastroPessoaSimplificadaClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICucCliCadastroPessoaSimplificada);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ICucCliCadastroPessoaSimplificada,
        }
    }
}