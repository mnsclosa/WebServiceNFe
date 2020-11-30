using ServiceNFe.Enums;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "transp" )]
	public class Transp
	{
		/// <summary>
		/// Modalidade do frete
		/// 
		/// 0=Por conta do emitente;
		/// 1=Por conta do destinatário/remetente;
		/// 2=Por conta de terceiros;
		/// 9=Sem frete. ( V2.0)
		/// </summary>
		[XmlElement( ElementName = "modFrete",Order = 1 )]
		public int Modalidade_Frete
		{
			get; set;
		}

		[XmlElement( ElementName = "transporta",Order = 2 )]
		public Transporta transporta
		{
			get;set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Transp()
		{
		}

		/// <summary>
		/// Grupo Informações do Transporte
		/// </summary>
		/// <param name="modalidade_Frete">Modalidade do frete.
		/// 0=Por conta do emitente;
		/// 1=Por conta do destinatário/remetente;
		/// 2=Por conta de terceiros;
		/// 9=Sem frete. ( V2.0)</param>
		/// <param name="_transporta">Grupo Transportador</param>
		public Transp( ModalidadeFrete modalidade_Frete,Transporta _transporta )
		{
			Modalidade_Frete = (int)modalidade_Frete;
			transporta = _transporta ?? throw new ArgumentNullException( nameof( _transporta ) );
		}
	}
}
