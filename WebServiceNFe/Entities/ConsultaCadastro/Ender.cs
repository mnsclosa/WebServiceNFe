using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.ConsultaCadastro
{
	/// <summary>
	/// Endereço - grupo de	informações opcionais.
	/// </summary>
	[Serializable()]
	[XmlRoot( ElementName = "ender" )]
	public class Ender
	{
		/// <summary>
		/// Nome do Logradouro
		/// </summary>
		[XmlElement( ElementName = "xLgr",Order = 0 )]
		public string Logradouro
		{
			get; set;
		}
		/// <summary>
		/// Número
		/// </summary>
		[XmlElement( ElementName = "nro",Order = 1 )]
		public string Numero
		{
			get; set;
		}
		/// <summary>
		/// Complemento
		/// </summary>
		[XmlElement( ElementName = "xCpl",Order = 2 )]
		public string Complemento
		{
			get; set;
		}
		/// <summary>
		/// Nome do Bairro
		/// </summary>
		[XmlElement( ElementName = "xBairro",Order = 3 )]
		public string Bairro
		{
			get; set;
		}
		/// <summary>
		/// Código do Município do Contribuinte, conforme Tabela do IBGE. (3550308=Cidade de São Paulo)
		/// </summary>
		[XmlElement( ElementName = "cMun",Order = 4 )]
		public string CodigoMunicipio
		{
			get; set;
		}
		/// <summary>
		/// Nome do Municipio
		/// </summary>
		[XmlElement( ElementName = "xMun",Order = 5 )]
		public string Municipio
		{
			get; set;
		}
		/// <summary>
		/// Sigla da UF
		/// </summary>
		[XmlElement( ElementName = "UF",Order = 6 )]
		public string Estado
		{
			get; set;
		}


		/// <summary>
		/// Código do CEP
		/// </summary>
		[XmlElement( ElementName = "CEP",Order = 7 )]
		public string CEP
		{
			get; set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public Ender()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="logradouro">Rua, Avenida.. da Empresa</param>
		/// <param name="numero">Número da Empresa</param>
		/// <param name="complemento">Complemento do endereço. ex Bloco 2</param>
		/// <param name="bairro">Bairro da Empresa</param>
		/// <param name="codigoMunicipio">Utilizar a Tabela do IBGE (Anexo IX- Tabela de UF, Município e País).</param>
		/// <param name="municipio">Nome do Município</param>
		/// <param name="cEP">CEP da Empresa</param>
		public Ender( string logradouro,string numero,string complemento,string bairro,string codigoMunicipio,string municipio,string cEP )
		{
			Logradouro = logradouro ?? throw new ArgumentNullException( nameof( logradouro ) );
			Numero = numero ?? throw new ArgumentNullException( nameof( numero ) );
			Complemento = complemento;
			Bairro = bairro ?? throw new ArgumentNullException( nameof( bairro ) );
			CodigoMunicipio = codigoMunicipio ?? throw new ArgumentNullException( nameof( codigoMunicipio ) );
			Municipio = municipio ?? throw new ArgumentNullException( nameof( municipio ) );
			CEP = cEP ?? throw new ArgumentNullException( nameof( cEP ) );
		}
	}
}
