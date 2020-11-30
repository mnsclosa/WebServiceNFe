using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaCadastro
{
	/// <summary>
	/// Dados da situação cadastral
	/// Esta estrutura existe somente para as consultas	realizadas com sucesso
	/// cStat=111, com possibilidade de múltiplas 
	/// ocorrências( Ex.: consulta por IE de contribuinte com Inscrição Única - retorno de todos os estabelecimentos do contribuinte )
	/// </summary>
	[Serializable()]
	[XmlRoot( ElementName = "infCad" )]
	public class InfCad
	{
		/// <summary>
		/// Inscrição estadual do contribuinte
		/// </summary>
		[XmlElement( ElementName = "IE",Order = 1 )]
		public string InscricaoEstadual
		{
			get; set;
		}
		/// <summary>
		/// CNPJ do contribuinte
		/// </summary>
		[XmlElement( ElementName = "CNPJ",Order = 2 )]
		public string CNPJ
		{
			get; set;
		}
		/// <summary>
		/// CPF em caso de pessoa física com IE
		/// </summary>
		[XmlElement( ElementName = "CPF",Order = 3 )]
		public string CPF
		{
			get; set;
		}
		/// <summary>
		/// O campo deve ser preenchido com a sigla da UF de localização do contribuinte.
		/// Em algumas situações, a UF de localização pode ser diferente da UF consultada.
		/// Ex.IE de contribuinte inscrito como Substituto Tributário
		/// </summary>
		[XmlElement( ElementName = "UF",Order = 4 )]
		public string Estado
		{
			get; set;
		}
		/// <summary>
		/// Situação do contribuinte: 0 - não habilitado; 1 - habilitado.
		/// </summary>
		[XmlElement( ElementName = "cSit",Order = 5 )]
		public string Situacao
		{
			get; set;
		}
		/// <summary>
		/// Indicador de contribuinte credenciado a emitir NF-e.
		/// 0 - Não credenciado para emissão da NF-e;
		/// 1 - Credenciado;
		/// 2 - Credenciado com obrigatoriedade para todas operações;
		/// 3 - Credenciado com obrigatoriedade parcial;
		/// 4 – a SEFAZ não fornece a informação. Este indicador significa apenas que o contribuinte écredenciado para emitir NFe na SEFAZ consultada
		/// </summary>
		[XmlElement( ElementName = "indCredNFe",Order = 6 )]
		public string IndicadorCreditoNFe
		{
			get; set;
		}
		/// <summary>
		/// Indicador de contribuinte credenciado a emitir CT-e.
		/// 0 - Não credenciado para emissão da CT-e;
		/// 1 - Credenciado;
		/// 2 - Credenciado com obrigatoriedade para todas operações;
		/// 3 - Credenciado com obrigatoriedade parcial;
		/// 4 – a SEFAZ não fornece a informação. Este indicador significa apenas que o contribuinte é credenciado para emitir CTe na SEFAZ consultada
		/// </summary>
		[XmlElement( ElementName = "indCredCTe",Order = 7 )]
		public string IndicadorCreditoCTe
		{
			get; set;
		}
		/// <summary>
		/// Razão Social ou nome do Contribuinte
		/// </summary>
		[XmlElement( ElementName = "xNome",Order = 8 )]
		public string RazaoSocial
		{
			get; set;
		}
		/// <summary>
		/// Nome Fantasia
		/// </summary>
		[XmlElement( ElementName = "xFant",Order = 9 )]
		public string NomeFantasia
		{
			get; set;
		}
		/// <summary>
		/// Regime de Apuração do ICMS do Contribuinte
		/// </summary>
		[XmlElement( ElementName = "xRegApur",Order = 10 )]
		public string RegimeApuracao
		{
			get; set;
		}
		/// <summary>
		/// CNAE principal do contribuinte
		/// </summary>
		[XmlElement( ElementName = "CNAE",Order = 11 )]
		public string CNAE
		{
			get; set;
		}
		/// <summary>
		/// Data de Início da Atividade do Contribuinte
		/// </summary>
		[XmlElement( ElementName = "dIniAtiv",Order = 12 )]
		public string DataInicioAtividade
		{
			get; set;
		}
		/// <summary>
		/// Data da última modificação da situação cadastral do contribuinte.
		/// </summary>
		[XmlElement( ElementName = "dUltSit",Order = 13 )]
		public string DataUltimaModificacao
		{
			get; set;
		}
		/// <summary>
		/// Data de ocorrência da baixa do contribuinte
		/// </summary>
		[XmlElement( ElementName = "dBaixa",Order = 14 )]
		public string DataBaixa
		{
			get; set;
		}
		/// <summary>
		/// IE única, este campo será informado quando o contribuinte possuir IE única
		/// </summary>
		[XmlElement( ElementName = "IEUnica",Order = 15 )]
		public string InscricaoEstadualUnica
		{
			get; set;
		}
		/// <summary>
		/// IE atual (em caso de IE	antiga consultada)
		/// </summary>
		[XmlElement( ElementName = "IEAtual",Order = 16 )]
		public string InscricaoEstadualAtual
		{
			get; set;
		}
		public InfCad()
		{
		}
		[XmlElement( ElementName = "ender",Order = 17 )]
		public Ender ender
		{
			get;set;
		}
	}
}
