using ServiceNFe.Enums;
using System;
using System.Globalization;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "ide" )]
	public class Ide
	{
		private string _codigonotafiscal;
		private string _datahoraemissao;
		private string _datahorasaidaentrada;

		/// <summary>
		/// Código da UF do emitente do Documento Fiscal. Utilizar a Tabela do IBGE de código de unidades da federação( Anexo IX - Tabela de UF,Município e País).
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 1 )]
		public string Codigo_Estado
		{
			get; set;
		}

		/// <summary>
		/// Código numérico que compõe a Chave de Acesso. Número aleatório gerado pelo emitente para cada NF-e para evitar acessos indevidos da NF-e. (v2.0)
		/// </summary>
		[XmlElement( ElementName = "cNF",Order = 2 )]
		public string Codigo_NotaFiscal
		{
			get
			{
				return new Random( Convert.ToInt16( Numero_NotaFiscal,new CultureInfo( "pt-BR" ) ) ).Next().ToString( new CultureInfo( "pt-BR" ) ).PadRight( 8,'0' ).Substring( 0,8 );
			}
			set
			{
				if( _codigonotafiscal != value )
					_codigonotafiscal = value;
			}
		}
		/// <summary>
		/// Informar a natureza da operação de que decorrer a saída ou a entrada, tais como: venda, compra, transferência, devolução, 
		/// importação, consignação, remessa( para fins de demonstração, de industrialização ou outra ), conforme previsto na alínea 'i',
		///  inciso I, art. 19 do CONVÊNIO S/Nº, de 15 de dezembro de 1970.
		/// </summary>
		[XmlElement( ElementName = "natOp",Order = 3 )]
		public string Natureza_Operacao
		{
			get; set;
		}

		/// <summary>
		/// 55=NF-e emitida em substituição ao modelo 1 ou 1A;
		/// 65=NFC-e, utilizada nas operações de venda no varejo( acritério da UF aceitar este modelo de documento)
		/// </summary>
		[XmlElement( ElementName = "mod",Order = 5 )]
		public string Modelo
		{
			get; set;
		}

		/// <summary>
		/// Série do Documento Fiscal, preencher com zeros na hipótese de a NF-e não possuir série. (v2.0)
		/// Série 890-899: uso exclusivo para emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco ( procEmi= 2 ). (v2.0)
		/// Serie 900-999: uso exclusivo de NF-e emitidas no SCAN. ( v2.0)
		/// </summary>
		[XmlElement( ElementName = "serie",Order = 6 )]
		public string Serie
		{
			get; set;
		}

		/// <summary>
		/// Número do Documento Fiscal.
		/// </summary>
		[XmlElement( ElementName = "nNF",Order = 7 )]
		public string Numero_NotaFiscal
		{
			get; set;
		}

		/// <summary>
		/// Data e hora no formato UTC (Universal Coordinated Time): AAAA-MM-DDThh:mm:ssTZD
		/// </summary>
		[XmlElement( ElementName = "dhEmi",Order = 8 )]
		public string DataHora_Emissao
		{
			get
			{
				return DateTime.Now.ToString( new CultureInfo( "pt-BR" ) ).DataUtc();
			}
			set
			{
				if( _datahoraemissao != value )
					_datahoraemissao = value;
			}
		}

		/// <summary>
		/// Data e hora no formato UTC (Universal Coordinated Time): AAAA-MM-DDThh:mm:ssTZD
		/// Não informar este campo para a NFC-e.
		/// </summary>
		[XmlElement( ElementName = "dhSaiEnt",Order = 9 )]
		public string DataHora_Saida_Entrada
		{
			get
			{
				return DateTime.Now.ToString( new CultureInfo( "pt-BR" ) ).DataUtc();
			}
			set
			{
				if( _datahorasaidaentrada != value )
					_datahorasaidaentrada = value;
			}
		}

		/// <summary>
		/// 0=Entrada;
		/// 1=Saída
		/// </summary>
		[XmlElement( ElementName = "tpNF",Order = 10 )]
		public int Tipo_Operacao
		{
			get; set;
		} = 1;

		/// <summary>
		/// 1=Operação interna;
		/// 2=Operação interestadual;
		/// 3=Operação com exterior
		/// </summary>
		[XmlElement( ElementName = "idDest",Order = 11 )]
		public int Identificador_Destino
		{
			get; set;
		}

		/// <summary>
		/// 1=Operação interna;
		/// 2=Operação interestadual;
		/// 3=Operação com exterior
		/// </summary>
		[XmlElement( ElementName = "cMunFG",Order = 12 )]
		public string Municipio_ICMS
		{
			get; set;
		}

		/// <summary>
		/// 0=Sem geração de DANFE;
		/// 1=DANFE normal, Retrato;
		/// 2=DANFE normal, Paisagem;
		/// 3=DANFE Simplificado;
		/// 4=DANFE NFC-e;
		/// 5=DANFE NFC-e em mensagem eletrônica( o envio de mensagem eletrônica pode ser feita de forma simultânea com a 
		/// impressão do DANFE; usar o tpImp=5 quando esta for a única forma de disponibilização do DANFE).
		/// </summary>
		[XmlElement( ElementName = "tpImp",Order = 13 )]
		public int Tipo_Danfe
		{
			get; set;
		}

		/// <summary>
		/// 1=Emissão normal (não em contingência);
		/// 2=Contingência FS-IA, com impressão do DANFE em formulário de segurança;
		/// 3=Contingência SCAN( Sistema de Contingência do Ambiente Nacional );
		/// 4=Contingência DPEC( Declaração Prévia da Emissão em Contingência );
		/// 5=Contingência FS-DA, com impressão do DANFE em formulário de segurança;
		/// 6=Contingência SVC-AN( SEFAZ Virtual de Contingência do AN);
		/// 7=Contingência SVC-RS( SEFAZ Virtual de Contingência do RS);
		/// 9=Contingência off-line da NFC-e (as demais opções de contingência são válidas também para a NFC-e).
		/// Para a NFC-e somente estão disponíveis e são válidas as opções de contingência 5 e 9.
		/// </summary>
		[XmlElement( ElementName = "tpEmis",Order = 14 )]
		public int Tipo_Emissao
		{
			get; set;
		}

		/// <summary>
		/// Informar o DV da Chave de Acesso da NF-e, o DV será calculado com a aplicação do algoritmo módulo 11 (base 2,9)
		/// da Chave de Acesso. ( vide item 5 do Manual de Orientação)
		/// </summary>
		[XmlElement( ElementName = "cDV",Order = 15 )]
		public int Digito_VerificadorNFe
		{
			get; set;
		} = 0;

		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// Forço 2 como padrão para evitar problemas
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 16 )]
		public int Tipo_de_Ambiente
		{
			get; set;
		} = 2;

		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// Forço 2 como padrão para evitar problemas
		/// </summary>
		[XmlElement( ElementName = "finNFe",Order = 17 )]
		public int Finalidade_Emissao
		{
			get; set;
		} = 1;

		/// <summary>
		/// 0=Normal;
		/// 1=Consumidor final;
		/// </summary>
		[XmlElement( ElementName = "indFinal",Order = 18 )]
		public int Operacao_Consumidor
		{
			get; set;
		}

		/// <summary>
		/// 0=Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste);
		/// 1=Operação presencial;
		/// 2=Operação não presencial, pela Internet;
		/// 3=Operação não presencial, Teleatendimento;
		/// 4=NFC-e em operação com entrega a domicílio;
		/// 9=Operação não presencial, outros.
		/// </summary>
		[XmlElement( ElementName = "indPres",Order = 19 )]
		public int Presenca_Comprador
		{
			get; set;
		}

		/// <summary>
		/// 0=Emissão de NF-e com aplicativo do contribuinte;
		/// 1=Emissão de NF-e avulsa pelo Fisco;
		/// 2=Emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
		/// 3=Emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco
		/// </summary>
		[XmlElement( ElementName = "procEmi",Order = 20 )]
		public int Processo_Emissao
		{
			get; set;
		}

		/// <summary>
		/// Informar a versão do aplicativo emissor de NF-e.
		/// </summary>
		[XmlElement( ElementName = "verProc",Order = 21 )]
		public string Versao_Aplicativo
		{
			get; set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Ide()
		{
		}

		/// <summary>
		/// Construtor para a emissão da NFe.
		/// </summary>
		/// <param name="natureza_Operacao">Valor correspondente ao CFOP</param>
		/// <param name="forma_de_Pagamento">0=Pagamento à vista;1=Pagamento a prazo;2=Outros.</param>
		/// <param name="modelo">55=NF-e emitida em substituição ao modelo 1 ou 1A;65=NFC-e, utilizada nas operações de venda no varejo( acritério da UF aceitar este modelo de documento).</param>
		/// <param name="serie">Série do Documento Fiscal, preencher com zeros na hipótese de a NF-e não possuir série. (v2.0)
		/// Série 890-899: uso exclusivo para emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco ( procEmi= 2 ). (v2.0)
		/// Serie 900-999: uso exclusivo de NF-e emitidas no SCAN. ( v2.0)</param>
		/// <param name="numero_NotaFiscal">Número da Nota Fiscal</param>
		/// <param name="tipo_Operacao">0=Entrada;1=Saída</param>
		/// <param name="identificador_Destino">1=Operação interna;2=Operação interestadual;3=Operação com exterior</param>
		/// <param name="municipio_ICMS">Informar o município de ocorrência do fato gerador do ICMS.
		/// Utilizar a Tabela do IBGE( Anexo IX - Tabela de UF,Município e País)</param>
		/// <param name="tipo_Danfe">0=Sem geração de DANFE;1=DANFE normal, Retrato;2=DANFE normal, Paisagem;3=DANFE Simplificado;4=DANFE NFC-e;
		/// 5=DANFE NFC-e em mensagem eletrônica( o envio de mensagem eletrônica pode ser feita de forma simultânea com a 
		/// impressão do DANFE; usar o tpImp=5 quando esta for a única forma de disponibilização do DANFE).</param>
		/// <param name="tipo_Emissao">1=Emissão normal (não em contingência);2=Contingência FS-IA, com impressão do DANFE em formulário de segurança;
		/// 3=Contingência SCAN( Sistema de Contingência do Ambiente Nacional );
		/// 4=Contingência DPEC( Declaração Prévia da Emissão em Contingência );
		/// 5=Contingência FS-DA, com impressão do DANFE em formulário de segurança;
		/// 6=Contingência SVC-AN( SEFAZ Virtual de Contingência do AN);
		/// 7=Contingência SVC-RS( SEFAZ Virtual de Contingência do RS);
		/// 9=Contingência off-line da NFC-e (as demais opções de contingência são válidas também para a NFC-e).
		/// Para a NFC-e somente estão disponíveis e são válidas as opções de contingência 5 e 9.</param>
		/// <param name="finalidade_Emissao">1=NF-e normal;2=NF-e complementar;3=NF-e de ajuste;4=Devolução de mercadoria</param>
		/// <param name="operacao_Consumidor">0=Normal;1=Consumidor final;</param>
		/// <param name="presenca_Comprador">0=Não se aplica (por exemplo, Nota Fiscal complementar ou de ajuste);
		/// 1=Operação presencial;
		/// 2=Operação não presencial, pela Internet;
		/// 3=Operação não presencial, Teleatendimento;
		/// 4=NFC-e em operação com entrega a domicílio;
		/// 9=Operação não presencial, outros.</param>
		/// <param name="processo_Emissao">0=Emissão de NF-e com aplicativo do contribuinte;
		/// 1=Emissão de NF-e avulsa pelo Fisco;
		/// 2=Emissão de NF-e avulsa, pelo contribuinte com seu certificado digital, através do site do Fisco;
		/// 3=Emissão NF-e pelo contribuinte com aplicativo fornecido pelo Fisco.</param>
		/// <param name="versao_Aplicativo">Se for aplicativo próprio colocar o número da versão</param>
		public Ide( string natureza_Operacao,string modelo,string serie,string numero_NotaFiscal,
					TipoOperacao tipo_Operacao,IdentificadorDestino identificador_Destino,string municipio_ICMS,TipoDanfe tipo_Danfe,
					TipoEmissao tipo_Emissao,FinalidadeEmissaoNFe finalidade_Emissao,
					OperacaoConsumidor operacao_Consumidor,PresencaComprador presenca_Comprador,ProcessoEmissao processo_Emissao,string versao_Aplicativo )
		{
			Natureza_Operacao = natureza_Operacao ?? throw new ArgumentNullException( nameof( natureza_Operacao ) );
			Modelo = modelo ?? throw new ArgumentNullException( nameof( modelo ) );
			Serie = serie ?? throw new ArgumentNullException( nameof( serie ) );
			Numero_NotaFiscal = numero_NotaFiscal ?? throw new ArgumentNullException( nameof( numero_NotaFiscal ) );
			Tipo_Operacao = (int)tipo_Operacao;
			Identificador_Destino = (int)identificador_Destino;
			Municipio_ICMS = municipio_ICMS ?? throw new ArgumentNullException( nameof( municipio_ICMS ) );
			Tipo_Danfe = (int)tipo_Danfe;
			Tipo_Emissao = (int)tipo_Emissao;
			Finalidade_Emissao = (int)finalidade_Emissao;
			Operacao_Consumidor = (int)operacao_Consumidor;
			Presenca_Comprador = (int)presenca_Comprador;
			Processo_Emissao = (int)processo_Emissao;
			Versao_Aplicativo = versao_Aplicativo ?? throw new ArgumentNullException( nameof( versao_Aplicativo ) );
		}
	}
}
