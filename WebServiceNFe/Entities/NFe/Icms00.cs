using ServiceNFe.Enums;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "ICMS00" )]
	public class Icms00 : IcmsBase
	{

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Icms00()
		{
		}

		/// <summary>
		/// Grupo Tributação do ICMS = 00.
		/// Tributada integralmente.
		/// </summary>
		/// <param name="origem_Mercadoria">0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
		/// 1 - Estrangeira - Importação direta, exceto a indicada no código 6;
		/// 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
		/// 3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;
		/// 4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as
		///		legislações citadas nos Ajustes;
		/// 5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
		/// 6 - Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;
		/// 7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante lista CAMEX e gás natural.
		/// 8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;</param>
		/// <param name="modalidade_BaseCalculoICMS">0=Margem Valor Agregado (%);
		/// 1=Pauta( Valor);
		/// 2=Preço Tabelado Máx. (valor);
		/// 3=Valor da operação.</param>
		/// <param name="valor_BaseCalculoICMS">Valor da BC do ICMS</param>
		/// <param name="aliquota_ImpostoICMS">Alíquota do imposto</param>
		public Icms00( OrigemMercadoria origem_Mercadoria,ModalidadeBasedeCalculoICMS modalidade_BaseCalculoICMS,decimal valor_BaseCalculoICMS,
						decimal aliquota_ImpostoICMS ) :base( origem_Mercadoria,modalidade_BaseCalculoICMS,valor_BaseCalculoICMS,aliquota_ImpostoICMS )
		{
		}
	}
}
