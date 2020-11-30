using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.Eventos
{
	[Serializable()]
	public class DetEvento
	{
		private string _xcorrecao;
		private string _xjust;

		/// <summary>
		/// Versão do evento
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		/// <summary>
		/// “Carta de Correção” ou “Carta de Correcao” ou Cancelamento
		/// </summary>
		[XmlElement( ElementName = "descEvento",Order = 20 )]
		public string DescEvento
		{
			get; set;
		}

		/// <summary>
		/// Informar o número do Protocolo de Autorização da NF-e a ser Cancelada. ( vide item 5.8 do manual da NFe ).
		/// </summary>
		[XmlElement( ElementName = "nProt",Order = 25 )]
		public string Nprot
		{
			get; set;
		}
		/// <summary>
		/// Correção a ser considerada, texto livre. A correção mais recente substitui as anteriores.
		/// </summary>
		[XmlElement( ElementName = "xCorrecao",Order = 30 )]
		public string Xcorrecao
		{
			get
			{
				return _xcorrecao.RetiraAcento();
			}
			set
			{
				if( _xcorrecao != value )
				{
					_xcorrecao = value;
				}
			}
		}
		/// <summary>
		/// Informar a justificativa do cancelamento
		/// </summary>
		[XmlElement( ElementName = "xJust",Order = 35 )]
		public string Xjust
		{
			get
			{
				return _xjust.RetiraAcento();
			}
			set
			{
				if( _xjust != value )
				{
					_xjust = value;
				}
			}
		}
		/// <summary>
		/// Condições de uso da Carta de Correção,
		/// informar a literal :
		/// “A Carta de Correção é disciplinada pelo § 1º-A
		/// do art. 7º do Convênio S/N, de 15 de dezembro
		/// de 1970 e pode ser utilizada para regularização
		/// de erro ocorrido na emissão de documento
		/// fiscal, desde que o erro não esteja relacionado
		/// com: I - as variáveis que determinam o valor do
		/// imposto tais como: base de cálculo, alíquota,
		/// diferença de preço, quantidade, valor da
		/// operação ou da prestação; II - a correção de
		/// dados cadastrais que implique mudança do
		/// remetente ou do destinatário; III - a data de
		/// emissão ou de saída.” (texto com acentuação)
		/// ou
		/// “A Carta de Correcao e disciplinada pelo
		/// paragrafo 1o-A do art. 7o do Convenio S/N, de
		/// 15 de dezembro de 1970 e pode ser utilizada
		/// para regularizacao de erro ocorrido na emissao
		/// de documento fiscal, desde que o erro nao
		/// esteja relacionado com: I - as variaveis que
		/// determinam o valor do imposto tais como: base
		/// de calculo, aliquota, diferenca de preco,
		/// quantidade, valor da operacao ou da prestacao;
		/// II - a correcao de dados cadastrais que implique
		/// mudanca do remetente ou do destinatario; III - a
		/// data de emissao ou de saida.” (texto sem
		/// acentuação)
		/// HP21 Signature G HP04 XML 1-1 Assinatura Digital
		/// </summary>
		[XmlElement( ElementName = "xCondUso",Order = 40 )]
		public string XcondUso
		{
			get; set;
		}
		/// <summary>
		/// Inicializador para a Carta de Correção
		/// </summary>
		/// <param name="_versao"></param>
		/// <param name="descEvento"></param>
		/// <param name="xcorrecao"></param>
		public DetEvento( string _versao,string descEvento,string xcorrecao ):this()
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			DescEvento = descEvento ?? throw new ArgumentNullException( nameof( descEvento ) );
			Xcorrecao = xcorrecao ?? throw new ArgumentNullException( nameof( xcorrecao ) );
			XcondUso = "A Carta de Correcao e disciplinada pelo paragrafo 1o-A do art. 7o do Convenio S/N, de 15 de dezembro de 1970 e pode ser utilizada para regularizacao de erro ocorrido na emissao de documento fiscal, desde que o erro nao esteja relacionado com: I - as variaveis que determinam o valor do imposto tais como: base de calculo, aliquota, diferenca de preco, quantidade, valor da operacao ou da prestacao; II - a correcao de dados cadastrais que implique mudanca do remetente ou do destinatario; III - a data de emissao ou de saida.";
			Xjust = null;
		}

		/// <summary>
		/// Inicializador para o Cancelamento de NFe
		/// </summary>
		/// <param name="_versao"></param>
		/// <param name="descEvento"></param>
		/// <param name="nprot"></param>
		/// <param name="xjust"></param>
		public DetEvento( string _versao,string descEvento,string nprot,string xjust )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			DescEvento = descEvento ?? throw new ArgumentNullException( nameof( descEvento ) );
			Nprot = nprot ?? throw new ArgumentNullException( nameof( nprot ) );
			Xjust = xjust ?? throw new ArgumentNullException( nameof( xjust ) );
			Xcorrecao = null;
		}

		public DetEvento()
		{
		}
	}
}
