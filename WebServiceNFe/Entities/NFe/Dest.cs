using ServiceNFe.Enums;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "dest" )]
	public class Dest
	{
		private string _cnpj;
		private string _cpf;

		/// <summary>
		/// Informar o CNPJ ou o CPF do destinatário, preenchendo os zeros não significativos.No caso de operação com o exterior,
		/// ou para comprador estrangeiro informar a tag "idEstrangeiro", com o número do passaporte ou outro documento legal para
		/// identificar pessoa estrangeira( campo aceita valor nulo ).
		/// </summary>

		/// <summary>
		/// CNPJ do destinatario
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
		/// CPF do  destinatario
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

		[XmlElement( ElementName = "idEstrangeiro",Order = 3 )]
		public string Identificador_Estrangeiro
		{
			get; set;
		} = null;

		/// <summary>
		/// Tag obrigatória para a NF-e (modelo 55) e opcional para a NFCe
		/// Razão Social ou nome do destinatário
		/// </summary>
		[XmlElement( ElementName = "xNome",Order = 4 )]
		public string Nome
		{
			get; set;
		}

		[XmlElement( ElementName = "enderDest",Order = 5 )]
		public EnderDest enderDest
		{
			get;set;
		}

		/// <summary>
		/// 1=Contribuinte ICMS (informar a IE do destinatário);
		/// 2=Contribuinte isento de Inscrição no cadastro de Contribuintes do ICMS;
		/// 9=Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS.
		/// Nota 1: No caso de NFC-e informar indIEDest=9 e não informar a tag IE do destinatário;
		/// Nota 2: No caso de operação com o Exterior informar indIEDest=9 e não informar a tag IE do destinatário;
		/// Nota 3: No caso de Contribuinte Isento de Inscrição( indIEDest= 2 ), não informar a tag IE do destinatário.
		/// </summary>
		[XmlElement( ElementName = "indIEDest",Order = 6 )]
		public int Indicador_IE_Destino
		{
			get; set;
		}

		/// <summary>
		/// Campo opcional. Informar somente os algarismos, sem os caracteres de formatação( ponto,barra,hífen,etc.).
		/// </summary>
		[XmlElement( ElementName = "IE",Order = 7 )]
		public string Inscricao_Estadual
		{
			get; set;
		} = null;

		/// <summary>
		/// Obrigatório, nas operações que se beneficiam de incentivos fiscais existentes nas áreas sob controle da SUFRAMA.
		/// A omissão desta informação impede o processamento da operação pelo Sistema de Mercadoria Nacional da SUFRAMA e
		/// a liberação da Declaração de Ingresso,prejudicando a comprovação do ingresso / internamento da mercadoria nestas áreas. (v2.0)
		/// </summary>
		[XmlElement( ElementName = "ISUF",Order = 8 )]
		public string Inscricao_Suframa
		{
			get; set;
		} = null;

		/// <summary>
		/// Campo opcional, pode ser informado na NF-e conjugada, com itens de produtos sujeitos ao ICMS e itens de serviços sujeitos ao ISSQN.
		/// </summary>
		[XmlElement( ElementName = "IM",Order = 9 )]
		public string Inscricao_Municipal
		{
			get; set;
		} = null;

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public Dest()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="cNPJ">CNPJ se Empresa ou</param>
		/// <param name="cPF">CPF para pessoa fisíoca cmo emissor</param>
		/// <param name="identificador_Estrangeiro"></param>
		/// <param name="nome">Razão Social do Cliente, quando for tipo de emissão Homologação este campo será preenchido com o seguinte dizer:
		/// NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL</param>
		/// <param name="_enderDest"></param>
		/// <param name="indicador_IE_Destino">1=Contribuinte ICMS (informar a IE do destinatário);
		/// 2=Contribuinte isento de Inscrição no cadastro de Contribuintes do ICMS;
		/// 9=Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS.
		/// Nota 1: No caso de NFC-e informar indIEDest=9 e não informar a tag IE do destinatário;
		/// Nota 2: No caso de operação com o Exterior informar indIEDest=9 e não informar a tag IE do destinatário;
		/// Nota 3: No caso de Contribuinte Isento de Inscrição ( indIEDest= 2 ), não informar a tag IE do destinatário.</param>
		/// <param name="inscricao_Estadual">Deverá ser observado indicador_IE_destino, se for 1 este campo deverá ser preenchido</param>
		/// <param name="inscricao_Suframa">Código Suframa para vendas relacionadas a zona franca de Manaus.</param>
		/// <param name="inscricao_Municipal"></param>
		public Dest( string cNPJ,string cPF,string identificador_Estrangeiro,string nome,EnderDest _enderDest,IndicadorIEDestino indicador_IE_Destino,string inscricao_Estadual,string inscricao_Suframa,string inscricao_Municipal )
		{
			CNPJ = cNPJ;
			CPF = cPF;
			Identificador_Estrangeiro = identificador_Estrangeiro;
			Nome = nome ?? throw new ArgumentNullException( nameof( nome ) );
			enderDest = _enderDest ?? throw new ArgumentNullException( nameof( enderDest ) );
			Indicador_IE_Destino = (int)indicador_IE_Destino;
			Inscricao_Estadual = inscricao_Estadual;
			Inscricao_Suframa = inscricao_Suframa;
			Inscricao_Municipal = inscricao_Municipal;
		}
	}
}
