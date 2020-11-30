using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace ServiceNFe.Entities
{
	public static class AuxXML
	{
		/// <summary>
		/// Serializo qualquer classe preparada para tanto.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">Classe Genérica</param>
		/// <returns>"Retorno o documento no formato XmlDocument"</returns>
		public static XmlDocument ObjetoparaXml<T>( T obj )
		{
			using( MemoryStream stream = new MemoryStream() )
			{
				XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
				xmlSerializer.Serialize( XmlWriter.Create( stream ),obj );
				stream.Flush();
				stream.Seek( 0,SeekOrigin.Begin );
				XmlDocument doc = new XmlDocument
				{
					PreserveWhitespace = false,
				};
				doc.Load( stream );

				/* elimino somente o namespace que não pertence a NFe */
				XmlDocument novodoc = new XmlDocument
				{
					PreserveWhitespace = false
				};
				novodoc.LoadXml( Regex.Replace( doc.OuterXml,@"(xmlns:xd?[^=]*=[""][^""]*[""])","",RegexOptions.IgnoreCase | RegexOptions.Multiline ) );
				return novodoc;
			}
		}
		/// <summary>
		/// Serializo qualquer classe preparada para tanto e Salvo o arquivo.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">Classe Genérica</param>
		/// <param name="caminhoarquivo">Local onde sera salvo o arquivo xml</param>
		/// <returns>"Retorno o documento no formato XmlDocument"</returns>
		public static XmlDocument ObjetoparaXml<T>( T obj,string caminhoarquivo )
		{
			/* crio o diretório se não existir */
			if( Directory.Exists( Path.GetDirectoryName( caminhoarquivo ) ) == false )
				Directory.CreateDirectory( Path.GetDirectoryName( caminhoarquivo ) );

			XmlDocument novodoc = new XmlDocument
			{
				PreserveWhitespace = false
			};
			novodoc = ObjetoparaXml( obj );

			TextWriter writer = new StreamWriter( caminhoarquivo );

			writer.Write( novodoc.OuterXml );
			writer.Close();
			return novodoc;
		}
		/// <summary>
		/// Le uma variavel xml e retorna o conteúdo para um Objeto. (deserealização)
		/// </summary>
		/// <param name="obj">Classe Genérica</param>
		/// <param name="doc">XmlDocument</param>
		/// <param name="limpaNamespace">Limpa o namespace</param>
		/// <returns>Tipo de classe que retornará(Genérica)T</returns>
		public static T XmlparaObjeto<T>( T obj,XmlDocument doc,bool limpaNamespace )
		{
			if( limpaNamespace == true )
			{
				XmlDocument novodoc = new XmlDocument();
				novodoc.LoadXml( Regex.Replace( doc.OuterXml,@"(xmlns:?[^=]*=[""][^""]*[""])","",RegexOptions.IgnoreCase | RegexOptions.Multiline ) );
				doc = novodoc;
				doc.PreserveWhitespace = false;
			}

			StringReader stringReader = new StringReader( doc.OuterXml );

			XmlSerializer xmlSerializer = new XmlSerializer( typeof( T ) );
			return (T)xmlSerializer.Deserialize( stringReader );
		}
		/// <summary>
		/// Le uma variavel xml e retorna o conteúdo para um Objeto e salvo. (deserealização)
		/// </summary>SS
		/// <typeparam name="T"></typeparam>
		/// <param name="obj">Classe Genérica</param>
		/// <param name="doc">XmlDocument</param>
		/// <param name="limpaNamespace">Limpa o namespace</param>
		/// <param name="caminhoarquivo">Local onde será salvo o arquivo xml</param>
		/// <returns>Tipo de classe que retornará(Genérica)T</returns>
		public static T XmlparaObjeto<T>( T obj,XmlDocument doc,bool limpaNamespace,string caminhoarquivo )
		{
			/* crio o diretório se não existir */
			if( Directory.Exists( Path.GetDirectoryName( caminhoarquivo ) ) == false )
				Directory.CreateDirectory( Path.GetDirectoryName( caminhoarquivo ) );

			TextWriter writer = new StreamWriter( caminhoarquivo );

			writer.Write( doc.OuterXml );
			writer.Close();

			return XmlparaObjeto( obj,doc,limpaNamespace );
		}
	}
}
