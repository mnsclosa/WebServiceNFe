using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	[Serializable()]
	[XmlRoot( ElementName = "infAdic" )]
	public class InfAdic
	{
		private string _informacoesadcionaisisco;
		private string _informacaocomplementar;

		/// <summary>
		/// Informações Adicionais de Interesse do Fisco
		/// </summary>
		[XmlElement( ElementName = "infAdFisco",Order = 1 )]
		public string Informacoes_AdcionaisFisco
		{
			get
			{
				return _informacoesadcionaisisco.RetiraAcento();
			}
			set
			{
				_informacoesadcionaisisco = value;
			}
		}

		/// <summary>
		/// Informações Complementares de interesse do Contribuinte
		/// </summary>
		[XmlElement( ElementName = "infCpl",Order = 2 )]
		public string Informacao_Complementar
		{
			get
			{
				return _informacaocomplementar.RetiraAcento();
			}
			set
			{
				_informacaocomplementar = value;
			}
		}

		/// <summary>
		/// Construtor para a Serialização
		/// </summary>
		public InfAdic()
		{
		}

		/// <summary>
		/// Grupo de Informações Adicionais
		/// </summary>
		/// <param name="informacoes_AdcionaisFisco">Informações Adicionais de Interesse do Fisco, máximo 2000 caracteres</param>
		/// <param name="informacao_Complementar">Informações Complementares de interesse do Contribuinte, máximo 5000 caracteres</param>
		public InfAdic( string informacoes_AdcionaisFisco,string informacao_Complementar )
		{
			Informacoes_AdcionaisFisco = informacoes_AdcionaisFisco;
			Informacao_Complementar = informacao_Complementar;
		}
	}
}
