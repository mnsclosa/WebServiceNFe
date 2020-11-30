using ServiceNFe.Entities.ConsultaCadastro;
using System;
using System.Xml.Serialization;

namespace ServiceNFe.Entities.NFe
{
	/// <summary>
	/// O estado é carregado por intermédio da classe ConectaWebServiceNFe, o código e nome do País estão com valor padrão na própria propriedade.
	/// </summary>
	[Serializable()]
	[XmlRoot( ElementName = "enderEmit" )]
	public class EnderEmit : Ender
	{
		/// <summary>
		/// Código do País
		/// 1058=Brasil
		/// </summary>
		[XmlElement( ElementName = "cPais",Order = 8 )]/* lembrar que esta Order é continuação da classe Ender */
		public string Codigo_Pais
		{
			get; set;
		} = "1058";

		/// <summary>
		/// Nome do País
		/// Brasil ou BRASIL
		/// </summary>
		[XmlElement( ElementName = "xPais",Order = 9 )]
		public string Pais
		{
			get; set;
		} = "Brasil";

		/// <summary>
		/// Preencher com o Código DDD + número do telefone. Nas operações com exterior é permitido informar
		/// o código do país + código da localidade + número do telefone( v2.0)
		/// </summary>
		[XmlElement( ElementName = "fone",Order = 10 )]
		public string Telefone
		{
			get; set;
		}

		/// <summary>
		/// Construtor padrão para a serialização.
		/// </summary>
		public EnderEmit()
		{
		}

		/// <summary>
		/// Construtor da classe
		/// </summary>
		/// <param name="logradouro">Rua, Avenida.. da Empresa (Herdado)</param>
		/// <param name="numero">Número da Empresa(Herdado)</param>
		/// <param name="complemento">Complemento do endereço. ex Bloco 2(Herdado)</param>
		/// <param name="bairro">Bairro da Empresa(Herdado)</param>
		/// <param name="codigoMunicipio">Utilizar a Tabela do IBGE (Anexo IX- Tabela de UF, Município e País).(Herdado)</param>
		/// <param name="municipio">Nome do Município(Herdado)</param>
		/// <param name="cEP">CEP da Empresa (Herdado)</param>
		/// <param name="telefone">Telefone da Empresa com DDD e sem a mascara</param>
		public EnderEmit( string logradouro,string numero,string complemento,string bairro,
						string codigoMunicipio,string municipio,string cEP,string telefone ) : base( logradouro,numero,complemento,bairro,codigoMunicipio,municipio,cEP )
		{
			Telefone = telefone ?? throw new ArgumentNullException( nameof( telefone ) );
		}
	}
}
