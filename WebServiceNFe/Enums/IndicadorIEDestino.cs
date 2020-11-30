using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceNFe.Enums
{
	/// <summary>
	/// 1=Contribuinte ICMS (informar a IE do destinatário);
	/// 2=Contribuinte isento de Inscrição no cadastro de Contribuintes do ICMS;
	/// 9=Não Contribuinte, que pode ou não possuir Inscrição Estadual no Cadastro de Contribuintes do ICMS.
	/// Nota 1: No caso de NFC-e informar indIEDest=9 e não informar a tag IE do destinatário;
	/// Nota 2: No caso de operação com o Exterior informar indIEDest=9 e não informar a tag IE do destinatário;
	/// Nota 3: No caso de Contribuinte Isento de Inscrição( indIEDest= 2 ), não informar a tag IE do destinatário.
	/// </summary>
	public enum IndicadorIEDestino : int
	{
		None,
		Contribuinte_ICMS,
		Contribuinte_Isento,
		Nao_Contribuinte
	}
}
