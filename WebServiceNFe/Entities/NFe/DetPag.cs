using ServiceNFe.Enums;
using System;
using System.Globalization;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "detPag" )]
	public class DetPag
	{
		private string _formadepagamento;
		private decimal _valorpagamento;

		/// <summary>
		/// 0=Pagamento à vista;
		/// 1=Pagamento a prazo;
		/// 2=Outros.
		/// </summary>
		[XmlElement( ElementName = "indPag",Order = 1 )]
		public int Indica_FormadePagamento
		{
			get; set;
		}

		/// <summary>
		/// Forma de Pagamento
		/// 
		/// 01=Dinheiro
		/// 02=Cheque
		/// 03=Cartão de Crédito
		/// 04=Cartão de Débito
		/// 05=Crédito Loja
		/// 10=Vale Alimentação
		/// 11=Vale Refeição
		/// 12=Vale Presente
		/// 13=Vale Combustível
		/// 15=Boleto Bancário
		/// 90= Sem pagamento
		/// 99=Outros
		/// </summary>
		[XmlElement( ElementName = "tPag",Order = 2 )]
		public string Forma_dePagamento
		{
			get
			{
				return _formadepagamento.PadLeft( 2,'0' ).ToString();
			}
			set
			{
				if( _formadepagamento != value )
					_formadepagamento = value;
			}
		}

		/// <summary>
		/// Valor Original da Fatura
		/// </summary>
		[XmlElement( ElementName = "vPag",Order = 3 )]
		public decimal Valor_Pagamento
		{
			get
			{
				return _valorpagamento.Round( DecimalValorTotal );
			}
			set
			{
				if( _valorpagamento != value )
					_valorpagamento = value;
			}
		}

		/// <summary>
		/// Contrutor para a Serialização
		/// </summary>
		public DetPag()
		{
		}

		/// <summary>
		/// Grupo Detalhamento da Forma de Pagamento
		/// </summary>
		/// <param name="indica_FormadePagamento"></param>
		/// <param name="forma_dePagamento"></param>
		/// <param name="valor_Pagamento"></param>
		public DetPag( IndicaFormadePagamento indica_FormadePagamento,FormadePagamento forma_dePagamento,decimal valor_Pagamento )
		{
			Indica_FormadePagamento = (int)indica_FormadePagamento;
			/* faço esta conversão para escrever com dois caracteres no XML, como solicitado no manual da NFe. */
			Forma_dePagamento = Convert.ToString( (int)forma_dePagamento,CultureInfo.CurrentCulture );
			Valor_Pagamento = valor_Pagamento;
		}
	}
}
