using ServiceNFe.Enums;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "emit" )]

	public class Emit
	{
		private string _cnpj;
		private string _cpf;

		/// <summary>
		/// Informar o CNPJ ou o CPF do emitente
		/// </summary>

		/// <summary>
		/// CNPJ do  emitente
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
		/// CPF do  emitente
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
		/// Razão Social ou Nome do emitente
		/// </summary>
		[XmlElement( ElementName = "xNome",Order = 3 )]
		public string Razao_Social
		{
			get; set;
		}
		
		/// <summary>
		/// Nome fantasia
		/// </summary>
		[XmlElement( ElementName = "xFant",Order = 4 )]
		public string Nome_Fantasia
		{
			get; set;
		}

		[XmlElement( ElementName = "enderEmit",Order = 5 )]
		public EnderEmit enderEmit
		{
			get;set;
		}

		/// <summary>
		/// Inscrição estadual do Emitente
		/// </summary>
		[XmlElement( ElementName = "IE",Order = 6 )]
		public string Inscricao_Estadual
		{
			get; set;
		}

		/// <summary>
		/// Inscrição municipal do Prestador de Serviço
		/// </summary>
		[XmlElement( ElementName = "IM",Order = 7 )]
		public string Inscricao_Municipal
		{
			get; set;
		}

		/// <summary>
		/// CNAE Fiscal
		/// </summary>
		[XmlElement( ElementName = "CNAE",Order = 8 )]
		public string CNAE
		{
			get; set;
		}

		/// <summary>
		/// Código de Regime Tributário
		/// 1=Simples Nacional;
		/// 2=Simples Nacional, excesso sublimite de receita bruta;
		/// 3=Regime Normal. ( v2.0).
		/// </summary>
		[XmlElement( ElementName = "CRT",Order = 9 )]
		public int Regime_Tributario
		{
			get; set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Emit()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="cNPJ">CNPJ se Empresa ou</param>
		/// <param name="cPF">CPF para pessoa fisíoca cmo emissor</param>
		/// <param name="razao_Social"></param>
		/// <param name="nome_Fantasia"></param>
		/// <param name="enderEmit">Classe do Endereço do Emitente</param>
		/// <param name="inscricao_Estadual"></param>
		/// <param name="inscricao_Municipal"></param>
		/// <param name="cNAE"></param>
		/// <param name="regime_Tributario">1=Simples Nacional;2=Simples Nacional, excesso sublimite de receita bruta;3=Regime Normal. ( v2.0).</param>
		public Emit( string cNPJ,string cPF,string razao_Social,string nome_Fantasia,EnderEmit _enderEmit,string inscricao_Estadual,
					 string inscricao_Municipal,string cNAE,RegimeTributario regime_Tributario )
		{
			CNPJ = cNPJ ?? throw new ArgumentNullException( nameof( cNPJ ) );
			CPF = cPF;
			Razao_Social = razao_Social ?? throw new ArgumentNullException( nameof( razao_Social ) );
			Nome_Fantasia = nome_Fantasia ?? throw new ArgumentNullException( nameof( nome_Fantasia ) );
			enderEmit = _enderEmit ?? throw new ArgumentNullException( nameof( enderEmit ) );
			Inscricao_Estadual = inscricao_Estadual ?? throw new ArgumentNullException( nameof( inscricao_Estadual ) );
			Inscricao_Municipal = inscricao_Municipal ?? throw new ArgumentNullException( nameof( inscricao_Municipal ) );
			CNAE = cNAE ?? throw new ArgumentNullException( nameof( cNAE ) );
			Regime_Tributario = (int)regime_Tributario;
		}
	}
}
