using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "infRec" )]
	public class InfRec
	{

		/// <summary>
		/// Número do Recibo gerado pelo Portal da Secretaria de Fazenda Estadual( vide item 5.5).
		/// </summary>
		[XmlElement( ElementName = "nRec",Order = 1 )]
		public string Numero_Recibo
		{
			get; set;
		}

		/// <summary>
		/// Tempo médio de resposta do serviço (em segundos) dos últimos 5 minutos( vide item 5.7).
		/// Nota: Caso o tempo médio de resposta fique abaixo de 1 (um) segundo, o tempo será informado como 1 segundo.
		/// Arredondar as frações de segundos para cima.
		/// </summary>
		[XmlElement( ElementName = "tMed",Order = 2 )]
		public int Tempo_Medio
		{
			get; set;
		}

		/// <summary>
		/// Construtor para a Serialização.
		/// </summary>
		public InfRec()
		{
		}
	}
}
