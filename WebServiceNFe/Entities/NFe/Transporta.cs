using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "transporta" )]
	public class Transporta
	{
		private string _cnpj;
		private string _cpf;

		/// <summary>
		/// Informar o CNPJ ou o CPF da Transportadora, preenchendo os zeros não significativos.
		/// </summary>

		/// <summary>
		/// CNPJ da transportadora
		/// </summary>
		[XmlElement( ElementName = "CNPJ",Order = 1 )]
		public string CNPJ
		{
			get
			{
				return _cnpj != null ? _cnpj.PadLeft( 14,'0' ) : null;
			}
			set
			{
				if( _cnpj != value )
					_cnpj = value;
			}
		}
		/// <summary>
		/// CPF da transportadora
		/// </summary>
		[XmlElement( ElementName = "CPF",Order = 2 )]
		public string CPF
		{
			get
			{
				return _cpf != null ? _cpf.PadLeft( 11,'0' ) : null;
			}
			set
			{
				if( _cpf != value )
					_cpf = value;
			}
		}

		/// <summary>
		/// Razão Social ou nome
		/// </summary>
		[XmlElement( ElementName = "xNome",Order = 4 )]
		public string Nome
		{
			get; set;
		}

		/// <summary>
		/// Inscrição Estadual do Transportador.
		/// 
		/// Informar: - Inscrição Estadual do transportador contribuinte do ICMS, sem caracteres de formatação( ponto,barra,hífen,etc.);
		///			  - Literal “ISENTO” para transportador isento de inscrição no cadastro de contribuintes ICMS;
		///			  - Não informar a tag para não contribuinte do ICMS, A UF deve ser informada se informado uma IE. (v2.0)
		/// </summary>
		[XmlElement( ElementName = "IE",Order = 5 )]
		public string Inscricao_Estadual
		{
			get; set;
		} = null;

		/// <summary>
		/// Endereço Completo
		/// </summary>
		[XmlElement( ElementName = "xEnder",Order = 6 )]
		public string Endereco
		{
			get; set;
		}

		/// <summary>
		/// Nome do município
		/// </summary>
		[XmlElement( ElementName = "xMun",Order = 7 )]
		public string Municipio
		{
			get; set;
		}

		/// <summary>
		/// Sigla da UF
		/// 
		/// A UF deve ser informada se informado uma IE. (v2.0). Informar "EX" para Exterior
		/// </summary>
		[XmlElement( ElementName = "UF",Order = 8 )]
		public string Estado
		{
			get; set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Transporta()
		{
		}

		/// <summary>
		/// Grupo Transportador
		/// </summary>
		/// <param name="cNPJ">CNPJ do Transportador</param>
		/// <param name="cPF">CPF do Transportador</param>
		/// <param name="nome">Razão Social ou nome</param>
		/// <param name="inscricao_Estadual">Inscrição Estadual do Transportador.
		/// Informar: - Inscrição Estadual do transportador contribuinte do ICMS, sem caracteres de formatação( ponto,barra,hífen,etc.);
		///			  - Literal “ISENTO” para transportador isento de inscrição no cadastro de contribuintes ICMS;
		///			  - Não informar a tag para não contribuinte do ICMS,A UF deve ser informada se informado uma IE. (v2.0)</param>
		/// <param name="endereco">Endereço Completo</param>
		/// <param name="municipio">Nome do município</param>
		/// <param name="estado">Sigla da UF.
		/// A UF deve ser informada se informado uma IE. (v2.0). Informar "EX" para Exterior.</param>
		public Transporta( string cNPJ,string cPF,string nome,string inscricao_Estadual,string endereco,string municipio,string estado )
		{
			CNPJ = cNPJ;
			CPF = cPF;
			Nome = nome ?? throw new ArgumentNullException( nameof( nome ) );
			Inscricao_Estadual = inscricao_Estadual ?? throw new ArgumentNullException( nameof( inscricao_Estadual ) );
			Endereco = endereco;
			Municipio = municipio ?? throw new ArgumentNullException( nameof( municipio ) );
			Estado = estado ?? throw new ArgumentNullException( nameof( estado ) );
		}
	}
}