using System;
using System.Xml.Serialization;
using static ServiceNFe.Entities.Constantes;
using ServiceNFe.Enums;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "prod" )]
	public class Prod
	{

		private decimal _quantidadecomercial;
		private decimal _valorunitario;
		private decimal _valortotalproduto;
		private decimal _quantidadetributavel;
		private decimal _valorunitariotributavel;
		private string _valortotalfrete;
		private string _valortotalseguro;
		private string _valordesconto;
		private string _outrasdespesas;

		/// <summary>
		/// Preencher com CFOP, caso se trate de itens não relacionados com mercadorias/produtos e que o contribuinte não possua 
		/// codificação própria.Formato: ”CFOP9999”
		/// </summary>
		[XmlElement( ElementName = "cProd",Order = 1 )]
		public string Codigo_Produto
		{
			get; set;
		}

		/// <summary>
		/// Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN14 (antigos códigos EAN, UPC e DUN-14), não informar o
		/// conteúdo da TAG em caso de o produto não possuir este código
		/// </summary>
		[XmlElement( ElementName = "cEAN",Order = 2 )]
		public string Codigo_EAN
		{
			get; set;
		}

		/// <summary>
		/// Descrição do produto ou serviço
		/// </summary>
		[XmlElement( ElementName = "xProd",Order = 3 )]
		public string Descricao_Produto
		{
			get; set;
		}

		/* Precisa acrescentar o NVE e o EXTIPI para quem for usar estes campos */


		/// <summary>
		/// Obrigatória informação do NCM completo (8 dígitos).	Nota: Em caso de item de serviço ou item que não tenham
		/// produto( ex.transferência de crédito,crédito do ativo imobilizado,etc.), informar o valor 00 (dois zeros). (NT2014/004)
		/// </summary>
		[XmlElement( ElementName = "NCM",Order = 4 )]
		public string Ncm
		{
			get; set;
		}

		/// <summary>
		/// Utilizar Tabela de CFOP
		/// </summary>
		[XmlElement( ElementName = "CFOP",Order = 5 )]
		public string Cfop
		{
			get; set;
		}

		/// <summary>
		/// Informar a unidade de comercialização do produto. ex. Caixa(CX), Peça(PC)
		/// </summary>
		[XmlElement( ElementName = "uCom",Order = 6 )]
		public string Unidade_Comercial
		{
			get; set;
		}

		/// <summary>
		/// Informar a quantidade de comercialização do produto (v2.0).
		/// </summary>
		[XmlElement( ElementName = "qCom",Order = 7 )]
		public decimal Quantidade_Comercial
		{
			get
			{
				return _quantidadecomercial.Round( DecimalQuantidade );
			}
			set
			{
				if( _quantidadecomercial != value )
					_quantidadecomercial = value;
			}
		}

		/// <summary>
		/// Informar o valor unitário de comercialização do produto, campo meramente informativo, o contribuinte pode utilizar a precisão
		/// desejada(0-10 decimais). Para efeitos de cálculo, o valor unitário será obtido pela divisão do valor do produto pela
		/// quantidade comercial. ( v2.0)
		/// </summary>
		[XmlElement( ElementName = "vUnCom",Order = 8 )]
		public decimal Valor_Unitario
		{
			get
			{
				return _valorunitario.Round( DecimalValorUnitario );
			}
			set
			{
				if( _valorunitario != value )
					_valorunitario = value;
			}
		}

		/// <summary>
		/// Valor Total Bruto dos Produtos ou Serviços
		/// </summary>
		[XmlElement( ElementName = "vProd",Order = 9 )]
		public decimal Valor_TotalProduto
		{
			get
			{
				_valortotalproduto = ( _valorunitario * _quantidadecomercial ).Round( DecimalValorTotal );
				return _valortotalproduto;
			}
			set
			{
				if( _valortotalproduto != value )
					_valortotalproduto = value;
			}
		}

		/// <summary>
		/// Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN14 (antigos códigos EAN, UPC e DUN-14) da unidade tributável
		/// do produto, não informar o conteúdo da TAG em caso de o produto não possuir este código.
		/// </summary>
		[XmlElement( ElementName = "cEANTrib",Order = 10 )]
		public string Codigo_EANTributavel
		{
			get; set;
		}

		/// <summary>
		/// Unidade Tributável
		/// </summary>
		[XmlElement( ElementName = "uTrib",Order = 11 )]
		public string Unidade_Tributavel
		{
			get; set;
		}

		/// <summary>
		/// Informar a quantidade de tributação do produto (v2.0).
		/// </summary>
		[XmlElement( ElementName = "qTrib",Order = 12 )]
		public decimal Quantidade_Tributavel
		{
			get
			{
				return _quantidadetributavel.Round( DecimalQuantidade );
			}
			set
			{
				if( _quantidadetributavel != value )
					_quantidadetributavel = value;
			}
		}

		/// <summary>
		/// Informar o valor unitário de tributação do produto, campo meramente informativo, o contribuinte pode utilizar a precisão desejada(0-10 decimais).
		/// Para efeitos de cálculo, o valor unitário será obtido pela divisão do valor do produto pela quantidade tributável( NT 2013/003).
		/// </summary>
		[XmlElement( ElementName = "vUnTrib",Order = 13 )]
		public decimal Valor_UnitarioTributavel
		{
			get
			{
				return _valorunitariotributavel.Round( DecimalValorUnitario );
			}
			set
			{
				if( _valorunitariotributavel != value )
					_valorunitariotributavel = value;
			}
		}

		/// <summary>
		/// Valor Total do Frete
		/// </summary>
		[XmlElement( ElementName = "vFrete",Order = 14 )]
		public string Valor_TotalFrete
		{
			get
			{
				return _valortotalfrete.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotalfrete != value )
					_valortotalfrete = value;
			}
		}

		/// <summary>
		/// Valor Total do Seguro
		/// </summary>
		[XmlElement( ElementName = "vSeg",Order = 15 )]
		public string Valor_TotalSeguro
		{
			get
			{
				return _valortotalseguro.Round( DecimalValorTotal );
			}
			set
			{
				if( _valortotalseguro != value )
					_valortotalseguro = value;
			}
		}

		/// <summary>
		/// Valor do Desconto
		/// </summary>
		[XmlElement( ElementName = "vDesc",Order = 16 )]
		public string Valor_Desconto
		{
			get
			{
				return _valordesconto.Round( DecimalValorTotal );
			}
			set
			{
				if( _valordesconto != value )
					_valordesconto = value;
			}
		}

		/// <summary>
		/// Outras despesas acessórias
		/// </summary>
		[XmlElement( ElementName = "vOutro",Order = 17 )]
		public string Outras_Despesas
		{
			get
			{
				return _outrasdespesas.Round( DecimalValorTotal );
			}
			set
			{
				if( _outrasdespesas != value )
					_outrasdespesas = value;
			}
		}

		/// <summary>
		/// Indica se valor do Item (vProd) entra no valor total da NF-e( vProd)
		/// 
		/// 0=Valor do item (vProd) não compõe o valor total da NF-e
		/// 1=Valor do item( vProd) compõe o valor total da NF-e( vProd)(v2.0)
		/// </summary>
		[XmlElement( ElementName = "indTot",Order = 18 )]
		public int Indica_ItemTotal
		{
			get; set;
		}

		/// <summary>
		/// Informação de interesse do emissor para controle do B2B.(v2.0)
		/// </summary>
		[XmlElement( ElementName = "xPed",Order = 19 )]
		public string Numero_PedidoCompra
		{
			get; set;
		}

		/// <summary>
		/// Informação de interesse do emissor para controle do B2B.(v2.0)
		/// </summary>
		[XmlElement( ElementName = "nItemPed",Order = 20 )]
		public string Item_PedidoCompra
		{
			get; set;
		}

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public Prod()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="codigo_Produto">Código do produto ou serviço. Preencher com CFOP, caso se trate de itens não relacionados 
		/// com mercadorias/produtos e que o contribuinte não possua codificação própria.Formato: ”CFOP9999”</param>
		/// <param name="codigo_EAN">GTIN (Global Trade Item Number) do produto, antigo código EAN ou código de
		/// barras. Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN14 (antigos códigos EAN, UPC e DUN-14), não informar o
		/// conteúdo da TAG em caso de o produto não possuir este código.</param>
		/// <param name="descricao_Produto">Descrição do produto ou serviço</param>
		/// <param name="ncm">Código NCM com 8 dígitos. Obrigatória informação do NCM completo (8 dígitos).
		/// Nota: Em caso de item de serviço ou item que não tenham produto( ex.transferência de crédito,crédito do ativo imobilizado,etc.),
		/// informar o valor 00 (dois zeros). (NT2014/004)</param>
		/// <param name="cfop">Código Fiscal de Operações e Prestações. Utilizar Tabela de CFOP.</param>
		/// <param name="unidade_Comercial">Unidade Comercia. Informar a unidade de comercialização do produto.</param>
		/// <param name="quantidade_Comercial">Quantidade Comercial. Informar a quantidade de comercialização do produto (v2.0).</param>
		/// <param name="valor_Unitario">Valor Unitário de Comercialização. Informar o valor unitário de comercialização do produto, campo
		/// meramente informativo, o contribuinte pode utilizar a precisão desejada(0-10 decimais). Para efeitos de cálculo, o valor
		/// unitário será obtido pela divisão do valor do produto pela quantidade comercial. ( v2.0)</param>
		/// <param name="codigo_EANTributavel">GTIN (Global Trade Item Number) da unidade tributável, antigo código EAN ou
		/// código de barras. Preencher com o código GTIN-8, GTIN-12, GTIN-13 ou GTIN14 (antigos códigos EAN, UPC e DUN-14) da unidade tributável
		/// do produto, não informar o conteúdo da TAG em caso de o produto não possuir este código.</param>
		/// <param name="unidade_Tributavel">Unidade Tributável.</param>
		/// <param name="quantidade_Tributavel">Quantidade Tributável. Informar a quantidade de tributação do produto (v2.0).</param>
		/// <param name="valor_UnitarioTributavel">Valor Unitário de tributação. Informar o valor unitário de tributação do produto, campo
		/// meramente informativo, o contribuinte pode utilizar a precisão desejada(0-10 decimais). Para efeitos de cálculo, o valor
		/// unitário será obtido pela divisão do valor do produto pela quantidade tributável( NT 2013/003).</param>
		/// <param name="valor_TotalFrete">Valor Total do Frete.</param>
		/// <param name="valor_TotalSeguro">Valor Total do Seguro.</param>
		/// <param name="valor_Desconto">Valor do Desconto.</param>
		/// <param name="outras_Despesas">Outras despesas acessórias.</param>
		/// <param name="indica_ItemTotal">Indica se valor do Item (vProd) entra no valor total da NF-e( vProd).
		/// 0=Valor do item (vProd) não compõe o valor total da NF-e
		/// 1=Valor do item( vProd) compõe o valor total da NF-e( vProd)(v2.0)</param>
		/// <param name="numero_PedidoCompra">Número do Pedido de Compra. Informação de interesse do emissor para controle do B2B.(v2.0)</param>
		/// <param name="item_PedidoCompra">Item do Pedido de Compra. Informação de interesse do emissor para controle do B2B.(v2.0)</param>
		public Prod( string codigo_Produto,string codigo_EAN,string descricao_Produto,string ncm,string cfop,string unidade_Comercial,
					 decimal quantidade_Comercial,decimal valor_Unitario,string codigo_EANTributavel,
					 string unidade_Tributavel,decimal quantidade_Tributavel,decimal valor_UnitarioTributavel,string valor_TotalFrete,
					 string valor_TotalSeguro,string valor_Desconto,string outras_Despesas,IndicaItemTotal indica_ItemTotal,
					 string numero_PedidoCompra,string item_PedidoCompra )
		{
			Codigo_Produto = codigo_Produto ?? throw new ArgumentNullException( nameof( codigo_Produto ) );
			Codigo_EAN = codigo_EAN;
			Descricao_Produto = descricao_Produto ?? throw new ArgumentNullException( nameof( descricao_Produto ) );
			Ncm = ncm ?? throw new ArgumentNullException( nameof( ncm ) );
			Cfop = cfop ?? throw new ArgumentNullException( nameof( cfop ) );
			Unidade_Comercial = unidade_Comercial ?? throw new ArgumentNullException( nameof( unidade_Comercial ) );
			Quantidade_Comercial = quantidade_Comercial;
			Valor_Unitario = valor_Unitario;
			Codigo_EANTributavel = codigo_EANTributavel;
			Unidade_Tributavel = unidade_Tributavel ?? throw new ArgumentNullException( nameof( unidade_Tributavel ) );
			Quantidade_Tributavel = quantidade_Tributavel;
			Valor_UnitarioTributavel = valor_UnitarioTributavel;
			Valor_TotalFrete = valor_TotalFrete;
			Valor_TotalSeguro = valor_TotalSeguro;
			Valor_Desconto = valor_Desconto;
			Outras_Despesas = outras_Despesas;
			Indica_ItemTotal = (int)indica_ItemTotal;
			Numero_PedidoCompra = numero_PedidoCompra;
			Item_PedidoCompra = item_PedidoCompra;
		}
	}
}

