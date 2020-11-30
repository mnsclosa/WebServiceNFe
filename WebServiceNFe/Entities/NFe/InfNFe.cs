using ServiceNFe.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "infNFe" )]

	public class InfNFe
	{
		string _id = string.Empty;

		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		/// <summary>
		/// Informar a Chave de Acesso precedida do literal ‘NFe’.
		/// </summary>
		[XmlAttribute]
		public string Id
		{
			get
			{
				int conta2 = 4;
				int pos = 0;
				ide.Digito_VerificadorNFe = 0;

				_id = ide.Codigo_Estado;
				_id += DateTime.Today.ToString( "yy",new CultureInfo( "pt-BR" ) );
				_id += DateTime.Today.ToString( "MM",new CultureInfo( "pt-BR" ) );
				_id += emit.CNPJ == null ? emit.CPF : emit.CNPJ;
				_id += ide.Modelo;
				_id += ide.Serie.PadLeft( 3,'0' );
				_id += ide.Numero_NotaFiscal.PadLeft( 9,'0' );
				_id += ide.Tipo_Emissao;
				_id += ide.Codigo_NotaFiscal;

				/* calculo o digito */
				for( int conta = 0;conta < 6;conta++ )
				{
					while( conta2 > 1 )
					{
						ide.Digito_VerificadorNFe += ( Convert.ToChar( _id[pos++] ) - 0x30 ) * conta2;
						conta2--;
					}
					conta2 = 9;
				}
				ide.Digito_VerificadorNFe %= 11;
				if( ide.Digito_VerificadorNFe < 2 )
					ide.Digito_VerificadorNFe = 0;
				else
					ide.Digito_VerificadorNFe = 11 - ide.Digito_VerificadorNFe;

				return "NFe" + _id + ide.Digito_VerificadorNFe;
			}
			set
			{
				if( _id != value )
					_id = value;
			}
		}

		[XmlElement( ElementName = "ide",Order = 1 )]
		public Ide ide
		{
			get;set;
		}

		[XmlElement( ElementName = "emit",Order = 2 )]
		public Emit emit
		{
			get; set;
		}

		[XmlElement( ElementName = "dest",Order = 3 )]
		public Dest dest
		{
			get; set;
		}

		[XmlElement( ElementName = "det",Order = 4 )]
		public List<Det> L_det
		{
			get;
		} = new List<Det>();

		[XmlElement( ElementName = "total",Order = 5 )]
		public Total total
		{
			get; set;
		}

		[XmlElement( ElementName = "transp",Order = 6 )]
		public Transp transp
		{
			get; set;
		}

		[XmlElement( ElementName = "cobr",Order = 7 )]
		public Cobr cobr
		{
			get; set;
		}

		[XmlElement( ElementName = "pag",Order = 8 )]
		public Pag pag
		{
			get; set;
		}

		[XmlElement( ElementName = "infAdic",Order = 9 )]
		public InfAdic infAdic
		{
			get; set;
		}

		public InfNFe()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="_versao">Versão da NFe</param>
		/// <param name="_ide">Informações de identificação da NF-e</param>
		/// <param name="_emit">Identificação do emitente da NF-e</param>
		/// <param name="_dest">Identificação do Destinatário da NF-e</param>
		/// <param name="_det">Detalhamento de Produtos e Serviços</param>
		/// <param name="_total">Grupo Totais da NF-e</param>
		/// <param name="_transp">Grupo Informações do Transporte</param>
		/// <param name="_cobr">Grupo Cobrança</param>
		/// <param name="_pag">Grupo de Formas de Pagamento</param>
		public InfNFe( string _versao,Ide _ide,Emit _emit,Dest _dest,Det _det,Total _total,Transp _transp,Cobr _cobr,Pag _pag,InfAdic _infAdic ) : this( _det )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			ide = _ide ?? throw new ArgumentNullException( nameof( _ide ) );
			emit = _emit ?? throw new ArgumentNullException( nameof( _emit ) );
			dest = _dest ?? throw new ArgumentNullException( nameof( _dest ) );
			total = _total ?? throw new ArgumentNullException( nameof( _total ) );
			transp = _transp ?? throw new ArgumentNullException( nameof( _transp ) );
			cobr = _cobr ?? throw new ArgumentNullException( nameof( _cobr ) );
			pag = _pag ?? throw new ArgumentNullException( nameof( _pag ) );
			infAdic = _infAdic ?? throw new ArgumentNullException( nameof( _infAdic ) );
		}

		/// <summary>
		/// Insere um item na List da classe Det
		/// </summary>
		/// <param name="_det"></param>
		public InfNFe( Det _det )
		{
			AddDet( _det );
		}

		/// <summary>
		/// Insere um item na List da classe Det
		/// </summary>
		/// <param name="_det"></param>
		public void AddDet( Det _det )
		{
			L_det.Add( _det );
		}
	}
}
