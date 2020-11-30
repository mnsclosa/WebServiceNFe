using System;
using System.Xml.Serialization;
using ServiceNFe.Enums;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "enviNFe",Namespace = @"http://www.portalfiscal.inf.br/nfe" )]
	public class EnviNFe
	{
		private string _idlote;

		/// <summary>
		/// Versão do leiaute
		/// </summary>
		[XmlAttribute]
		public string versao
		{
			get; set;
		}

		/// <summary>
		/// Identificador de controle do envio do lote.
		/// Número sequencial autoincremental, de controle correspondente ao identificador único do lote enviado.
		/// A responsabilidade de gerar e controlar esse número é exclusiva do contribuinte.
		/// </summary>
		[XmlElement( ElementName = "idLote",Order = 1 )]
		public string Id_Lote
		{
			get
			{
				return _idlote.PadLeft( 15,'0' );
			}
			set
			{
				_idlote = value;
			}
		}

		/// <summary>
		/// Indica se a resposta de processamento da NFe pelo Sefaz será sincrona ou não.
		/// 
		/// 0=Não.
		/// 1=Empresa solicita processamento síncrono do Lote de NF-e( sem a geração de Recibo para consulta futura );
		/// Nota: O processamento síncrono do Lote corresponde a entrega da resposta do processamento das NF-e do Lote, sem a geração
		/// de um Recibo de Lote para consulta futura.A resposta de forma síncrona pela SEFAZ Autorizadora só ocorrerá se:
		/// - a empresa solicitar e constar unicamente uma NFe no Lote;
		/// - a SEFAZ Autorizadora implementar o processamento síncrono para a resposta do Lote de NF-e.
		/// </summary>
		[XmlElement( ElementName = "indSinc",Order = 2 )]
		public int Indica_Sincronismo
		{
			get; set;
		} = 1;

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public EnviNFe()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="versao">Versão do laiout da NFe, não pode ser nulo.</param>
		/// <param name="idlote">Número de identificação do Lote a ser transmitido, não pode ser nulo.</param>
		public EnviNFe( string _versao,string idlote,IndicaSincronismo indicasincronismo )
		{
			versao = _versao ?? throw new ArgumentNullException( nameof( _versao ) );
			Id_Lote = idlote ?? throw new ArgumentNullException( nameof( idlote ) );
			Indica_Sincronismo = (int)indicasincronismo;
		}
	}
}
