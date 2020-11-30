using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "infProt" )]
	public class InfProt
	{
		/// <summary>
		/// Identificador da TAG a ser assinada, somente precisa ser informado se a UF assinar a resposta.
		/// Em caso de assinatura da resposta pela SEFAZ preencher o campo com o Número do Protocolo, precedido com o literal “ID”
		/// </summary>
		[XmlElement( ElementName = "Id",Order = 2 )]
		public string Id
		{
			get; set;
		}

		/// <summary>
		/// Identificação do Ambiente:1 – Produção;2 - Homologação
		/// </summary>
		[XmlElement( ElementName = "tpAmb",Order = 3 )]
		public int Tipo_deAmbiente
		{
			get; set;
		}

		/// <summary>
		/// Versão do Aplicativo que processou o Lote.
		/// A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla SVAN ou SVRS nos demais casos.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 4 )]
		public string Versao_Aplicativo
		{
			get; set;
		}

		/// <summary>
		/// Chave de Acesso da NF-e (vide item 5.4)
		/// </summary>
		[XmlElement( ElementName = "chNFe",Order = 5 )]
		public string Chave_NFe
		{
			get; set;
		}

		/// <summary>
		/// Preenchido com a data e hora do processamento (informado também no caso de rejeição).
		/// Formato: “AAAA-MM-DDThh:mm:ssTZD” (UTC - Universal Coordinated Time).
		/// </summary>
		[XmlElement( ElementName = "dhRecbto",Order = 6 )]
		public string DataHora_Recebimento
		{
			get; set;
		}

		/// <summary>
		/// Número do Protocolo da NF-e (vide item 5.8)
		/// </summary>
		[XmlElement( ElementName = "nProt",Order = 7 )]
		public string Numero_Protocolo
		{
			get; set;
		}

		/// <summary>
		/// Digest Value da NF-e processada Utilizado para conferir a integridade da NFe original.
		        /// </summary>
		[XmlElement( ElementName = "digVal",Order = 8 )]
		public string Valor_Digest
		{
			get; set;
		}

		/// <summary>
		/// Descrição literal do status da resposta para a NF-e.
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 9 )]
		public string Codigo_Status
		{
			get; set;
		}

		/// <summary>
		/// Descrição literal do status da resposta para a NF-e.
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 10 )]
		public string Descricao_Motivo
		{
			get; set;
		}

		/// <summary>
		/// Assinatura XML do grupo identificado pelo atributo “Id” A decisão de assinar a mensagem fica a critério da UF interessada.
		/// </summary>
		[XmlElement( ElementName = "Signature",Order = 11 )]
		public string Assinatura
		{
			get; set;
		}

		/// <summary>
		/// Construtor para a Serialização.
		/// </summary>
		public InfProt()
		{
		}
	}
}
