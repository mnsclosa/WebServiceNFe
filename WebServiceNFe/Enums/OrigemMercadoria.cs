using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNFe.Enums
{
	/// <summary>
	/// 0 - Nacional, exceto as indicadas nos códigos 3, 4, 5 e 8;
	/// 1 - Estrangeira - Importação direta, exceto a indicada no código 6;
	/// 2 - Estrangeira - Adquirida no mercado interno, exceto a indicada no código 7;
	/// 3 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 40% e inferior ou igual a 70%;
	/// 4 - Nacional, cuja produção tenha sido feita em conformidade com os processos produtivos básicos de que tratam as
	///		legislações citadas nos Ajustes;
	/// 5 - Nacional, mercadoria ou bem com Conteúdo de Importação inferior ou igual a 40%;
	/// 6 - Estrangeira - Importação direta, sem similar nacional, constante em lista da CAMEX e gás natural;
	/// 7 - Estrangeira - Adquirida no mercado interno, sem similar nacional, constante lista CAMEX e gás natural.
	/// 8 - Nacional, mercadoria ou bem com Conteúdo de Importação superior a 70%;
	/// </summary>
	public enum OrigemMercadoria : int
	{
		Nacional,
		Estrangeira,
		Estrangeira_Mercado_Interno,
		Nacional_Com_Conteudo_Importado40Menor70,
		Nacional_Com_Producao_em_Conformidade,
		Nacional_Com_Conteudo_Importado_Menor40,
		Estrangeira_Importacao_Direta,
		Estrangeira_Adquirida_Mercado_Interno_sem_Nacional,
		Nacional_Com_Conteudo_Maior70
	}
}
