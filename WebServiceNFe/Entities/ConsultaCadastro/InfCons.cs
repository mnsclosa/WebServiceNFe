using ServiceNFe.Entities.Exceptions;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaCadastro
{
	/// <summary>
	/// Classe que recebe o cadastro que foi solicitado
	/// </summary>
	[Serializable()]
	[XmlRoot( ElementName = "infCons" )]
	public class InfCons
	{

		private string _xmotivo;

		/// <summary>
		/// Serviço solicitado ‘CONS-CAD’
		/// </summary>
		[XmlElement( ElementName = "xServ",Order = 0 )]
		public string NomeServico
		{
			get; set;
		}
		/// <summary>
		/// Versão do Aplicativo que processou a consulta.
		/// A versão deve ser iniciada com a sigla da UF nos casos de WS próprio ou a sigla
		/// SVAN ou SVRS nos demais casos.
		/// </summary>
		[XmlElement( ElementName = "verAplic",Order = 1 )]
		public string VersaoAplicacao
		{
			get; set;
		}
		/// <summary>
		/// Código do status da	resposta
		/// </summary>
		[XmlElement( ElementName = "cStat",Order = 2 )]
		public string Status
		{
			get;set;
		}
		/// <summary>
		/// Descrição do Status da resposta
		/// XMotivo trás a mensagem do erro ocorrido.
		/// Em CStat leio o valor do erro.
		/// Os valores para Consulta Cadastro do Contribuinte 111 - consulta cadastro com uma ocorrência.
		///													  112 - consulta cadastro com mais de uma ocorrência,
		///	são corretos.
		///	
		/// </summary>
		[XmlElement( ElementName = "xMotivo",Order = 3 )]
		public string XMotivo
		{
			get
			{
				return _xmotivo;
			}
			set
			{
				if( _xmotivo != value )
				{
					_xmotivo = value;

					switch( Status )
					{
						case "111":
						case "112":
						{
						}
						break;
						default:
						{
							throw new NFeException( "cStat= " + Status + "\r\nXMotivo= " + XMotivo );
						}
					}
				}
			}
		}
		/// <summary>
		/// Sigla da UF consultada,	informar 'SU' para SUFRAMA
		/// </summary>
		[XmlElement( ElementName = "UF",Order = 4 )]
		public string Estado
		{
			get; set;
		}
		/// <summary>
		/// Inscrição estadual do contribuinte
		/// </summary>
		[XmlElement( ElementName = "IE",Order = 5 )]
		public string InscricaoEstadual
		{
			get; set;
		}
		/// <summary>
		/// CNPJ do contribuinte/Consultado
		/// </summary>
		[XmlElement( ElementName = "CNPJ",Order = 6 )]
		public string CNPJ
		{
			get; set;
		}
		/// <summary>
		/// CPF do contribuinte/Consultado
		/// </summary>
		[XmlElement( ElementName = "CPF",Order = 7 )]
		public string CPF
		{
			get; set;
		}
		/// <summary>
		/// Data e hora de processamento da consulta Formato = AAAA - MMDDTHH:MM:SS
		/// </summary>
		[XmlElement( ElementName = "dhCons",Order = 8 )]
		public string DataConsulta
		{
			get; set;
		}
		/// <summary>
		/// Código da UF que atendeu a solicitação. (38=São Paulo)
		/// </summary>
		[XmlElement( ElementName = "cUF",Order = 9 )]
		public string CodigoEstado
		{
			get; set;
		}
		public InfCons()
		{
		}
		public InfCons( string inscricaoEstadual,string cnpj,string cpf )
		{
			InscricaoEstadual = inscricaoEstadual;
			CNPJ = cnpj;
			CPF = cpf;
		}

		[XmlElement( ElementName = "infCad",Order = 10 )]
		public InfCad infCad
		{
			get;set;
		}
	}
}
