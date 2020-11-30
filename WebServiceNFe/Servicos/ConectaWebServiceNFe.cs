using ServiceNFe.Entities;
using ServiceNFe.Entities.ConsultaCadastro;
using ServiceNFe.Entities.ConsultaSituacaoNFe;
using ServiceNFe.Entities.ConsultaStatusServico;
using ServiceNFe.Entities.Eventos;
using ServiceNFe.Entities.InutilizacaoNumeracao;
using ServiceNFe.Entities.NFe;
using ServiceNFe.Enums;
using ServiceNFe.Properties;
using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Threading;
using System.Xml;

namespace ServiceNFe.Servicos
{
	public class ConectaWebServiceNFe
	{
		public X509Certificate2 X509Cert
		{
			get; set;
		}

		private static WebServiceNFe _webService
		{
			get;set;
		}

		private TipodeAmbiente _tipoambiente;
		private string _estado;
		private string _codigoestado;

		public ConectaWebServiceNFe( WebServiceNFe webService,TipodeAmbiente tipodeAmbiente,string estado,string codigoestado )
		{
			/* para não deixar criar outra instancia forço um singleton aqui pelo fato da classe WebServiceNFe ser abstract */
			if( _webService == null )
				_webService = webService;
			else
			{
				/* forço o tipo de ambiente na classe chamadora */
				webService.Tipodeambiente = tipodeAmbiente;
			}


			_tipoambiente = tipodeAmbiente;
			_estado = estado ?? throw new ArgumentNullException( nameof( estado ) );
			_codigoestado = codigoestado ?? throw new ArgumentNullException( nameof( codigoestado ) );
		}

		public RetConsCad ConsultaCadastro( ConsCad consCad )
		{
			/* acrescento os valores que são fixos. */
			consCad.infCons.Estado = _estado;
			consCad.infCons.NomeServico = "CONS-CAD";

			XmlDocument doc = AuxXML.ObjetoparaXml( consCad );
			Le_certificado();
			XmlNode xmlNode = _webService.ConsultaCadastro( doc,X509Cert );
			doc.LoadXml( xmlNode.OuterXml );
			return AuxXML.XmlparaObjeto( new RetConsCad(),doc,false );
		}

		public RetConsStatServ ConsultaStatus( ConsStatServ consStatServ )
		{
			/* acrescento os valores que são fixos. */
			consStatServ.CodigoEstado = _codigoestado;
			consStatServ.TipodeAmbiente = (int)_tipoambiente;
			consStatServ.NomeServico = "STATUS";


			XmlDocument doc = AuxXML.ObjetoparaXml( consStatServ );
			Le_certificado();
			XmlNode xmlNode = _webService.StatusServico( doc,X509Cert );
			doc.LoadXml( xmlNode.OuterXml );
			return AuxXML.XmlparaObjeto( new RetConsStatServ(),doc,false );
		}

		/// <summary>
		/// Inutilizo um sequencia de números que não foram usados na NFe
		/// </summary>
		/// <param name="inutNFe">Objeto com os valor da NFe a se cancelar a numeração</param>
		/// <param name="arqxsd">XSD correspondente ao xml a ser enviado no formato: inutNFe_v9.99.xsd </param>
		/// <returns>Retorna, RetInutNFe, o objeto com a resposta do site da secretaria da fazenda do estado chamado.</returns>
		public RetInutNFe InutilizaNumeracao( InutNFe inutNFe,string arqxsd )
		{
			/* acrescento os valores que são fixos e monto o ID */
			inutNFe.infInut.CodigoEstado = _codigoestado;
			inutNFe.infInut.TipodeAmbiente = (int)_tipoambiente;
			inutNFe.infInut.NomeServico = "INUTILIZAR";
			inutNFe.infInut.Id = "ID" + inutNFe.infInut.CodigoEstado + inutNFe.infInut.Ano + inutNFe.infInut.CNPJ + inutNFe.infInut.Modelo +
								 inutNFe.infInut.Serie.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 3,'0' ) + inutNFe.infInut.NumeroInicial.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 9,'0' ) +
								 inutNFe.infInut.NumeroFinal.ToString( new CultureInfo( "pt-BR" ) ).PadLeft( 9,'0' );

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( inutNFe );

			/* leio o certificado */
			Le_certificado();

			/* assino o documento */
			doc.InnerXml = AssinaXML( "infInut",doc.OuterXml );

			/* valido o arquivo antes de enviar */
			ValidaXML( arqxsd,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.InutilizaNumeracao( doc,X509Cert );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetInutNFe(),doc,false );
		}

		/// <summary>
		/// Consulto um NFe com a sua respectiva chave.
		/// </summary>
		/// <param name="consSitNFe">Objeto com os valor da NFe a ser consultada</param>
		/// <param name="arqxsd">XSD correspondente ao xml a ser enviado no formato: consSitNFe_v9.99.xsd </param>
		/// <returns>Retorna, RetConsSitNFe, o objeto com a resposta do site da secretaria da fazenda do estado chamado.</returns>
		public RetConsSitNFe ConsultaProtocolo( ConsSitNFe consSitNFe,string arqxsd )
		{
			/* acrescento o ambiente e o serviço a se executar */
			consSitNFe.TipodeAmbiente = (int)_tipoambiente;
			consSitNFe.NomeServico = "CONSULTAR";

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( consSitNFe );

			/* leio o certificado */
			Le_certificado();

			/* valido o arquivo antes de enviar */
			ValidaXML( arqxsd,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.ConsultaProtocolo( doc,X509Cert );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetConsSitNFe(),doc,false );
		}

		/// <summary>
		/// <summary>
		/// Passa a Classe evento para assinar e fazer todo o resto do processo.
		/// </summary>
		/// <param name="evento">Objeto com os valor da NFe a ser cancelada</param>
		/// <param name="arqxsd">XSD correspondente ao xml a ser enviado no formato: envCCe_v9.99.xsd </param>
		/// <returns>Retorna, RetEnvEvento, o objeto com a resposta do site da secretaria da fazenda do estado chamado.</returns>
		public RetEnvEvento CartadeCorrecao( Evento evento,string arqxsd )
		{
			/* acrescento o ambiente e o codigo do estado */
			evento.infEvento.Tipo_de_Ambiente = (int)_tipoambiente;
			evento.infEvento.Corgao = _codigoestado;

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( evento );

			/* leio o certificado */
			Le_certificado();

			/* assino o arquivo a se enviar */
			doc.InnerXml = AssinaXML( "infEvento",doc.OuterXml );

			/* crio o EnvEvento para inserir a Tag assinada dentro */
			EnvEvento envEvento = new EnvEvento( evento.versao,"1".PadLeft( 15,'0' ) );

			/* crio o xml do EnvEvento que recebera a assinatura */
			XmlDocument doc1 = AuxXML.ObjetoparaXml( envEvento );
			XmlElement xmlElement = doc.DocumentElement;

			/* insiro a assinatura */
			doc1.DocumentElement.AppendChild( doc1.ImportNode( xmlElement,true ) );
			doc = doc1;

			/* valido o arquivo antes de enviar */
			ValidaXML( arqxsd,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.CartadeCorrecaoCancelamento( doc,X509Cert );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetEnvEvento(),doc,true );
		}

		/// <summary>
		/// <summary>
		/// Passa a Classe evento para assinar e fazer todo o resto do processo.
		/// </summary>
		/// <param name="evento">Objeto com os valor da NFe a ser cancelada</param>
		/// <param name="arqxsd">XSD correspondente ao xml a ser enviado no formato:envEventoCancNFe_v9.99.xsd </param>
		/// <returns>Retorna, RetEnvEvento, o objeto com a resposta do site da secretaria da fazenda do estado chamado.</returns>
		public RetEnvEvento CancelaNFe( Evento evento,string arqxsd )
		{
			/* acrescento o ambiente e o codigo do estado */
			evento.infEvento.Tipo_de_Ambiente = (int)_tipoambiente;
			evento.infEvento.Corgao = _codigoestado;

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( evento );

			/* leio o certificado */
			Le_certificado();

			/* assino o arquivo a se enviar */
			doc.InnerXml = AssinaXML( "infEvento",doc.OuterXml );

			/* crio o EnvEvento para inserir a Tag assinada dentro */
			EnvEvento envEvento = new EnvEvento( evento.versao,"1".PadLeft( 15,'0' ) );

			/* crio o xml do EnvEvento que recebera a assinatura */
			XmlDocument doc1 = AuxXML.ObjetoparaXml( envEvento );
			XmlElement xmlElement = doc.DocumentElement;

			/* insiro a assinatura */
			doc1.DocumentElement.AppendChild( doc1.ImportNode( xmlElement,true ) );
			doc = doc1;

			/* valido o arquivo antes de enviar */
			ValidaXML( arqxsd,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.CartadeCorrecaoCancelamento( doc,X509Cert );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetEnvEvento(),doc,true );
		}

		/// <summary>
		/// Envio a NFe para o Sefaz.
		/// </summary>
		/// <param name="nFe">Valores previamente cadastrados nesta classe.</param>
		/// <param name="arqxsd_infNFe">Nome do arquivo XSD de validação da NFe após ser assinado</param>
		/// <param name="arqxsd_enviNFe">Nome do arquivo XSD de validação do arquivo de envio da NFe</param>
		public RetEnviNFe AutorizaNFe( NFe nFe,string arqxsd_infNFe,string arqxsd_enviNFe,string idlote,IndicaSincronismo indicaSincronismo )
		{
			/* acrescento o ambiente e o codigo do estado e o estado */
			nFe.infNFe.ide.Codigo_Estado = _codigoestado;
			nFe.infNFe.ide.Tipo_de_Ambiente = (int)_tipoambiente;
			nFe.infNFe.emit.enderEmit.Estado = _estado;
			nFe.infNFe.dest.enderDest.Estado = _estado;

			/* acerto o nome da empresa na Homologação para o padrão do Sefaz */
			if( _tipoambiente == TipodeAmbiente.Homologacao )
				nFe.infNFe.dest.Nome = "NF-E EMITIDA EM AMBIENTE DE HOMOLOGACAO - SEM VALOR FISCAL";

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( nFe );

			/* leio o certificado */
			Le_certificado();

			/* assino o arquivo a se enviar */
			doc.InnerXml = AssinaXML( "infNFe",doc.OuterXml );

			/* valido o arquivo após assinar */
			ValidaXML( arqxsd_infNFe,doc.OuterXml );

			/* crio o enviNfe */
			EnviNFe enviNFe = new EnviNFe( nFe.infNFe.versao,idlote,indicaSincronismo );

			/* crio o xml do NFe que recebera a assinatura */
			XmlDocument doc1 = AuxXML.ObjetoparaXml( enviNFe );
			XmlElement xmlElement = doc.DocumentElement;

			/* insiro a assinatura */
			doc1.DocumentElement.AppendChild( doc1.ImportNode( xmlElement,true ) );
			doc = doc1;

			/* valido o arquivo antes de enviar */
			ValidaXML( arqxsd_enviNFe,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.AutorizaNFe( doc,X509Cert );

			/* seguro 2 segundos para dar tempo do Sefaz processar */
			Thread.Sleep( 2000 );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetEnviNFe(),doc,true );
		}

		/// <summary>
		/// Envio a NFe para o Sefaz.
		/// </summary>
		/// <param name="retEnviNFe">Valores recebidos no envio da NFe.</param>
		/// <param name="arqxsd">Nome do arquivo XSD de validação do recibo da NFe</param>
		public RetConsReciNFe AutorizaRetNFe( RetEnviNFe retEnviNFe,string arqxsd )
		{
			/* acrescento o ambiente e o codigo do estado e o estado */
			ConsReciNFe consReciNFe = new ConsReciNFe( retEnviNFe.versao,retEnviNFe.infRec.Numero_Recibo );
			consReciNFe.Tipo_deAmbiente = (int)_tipoambiente;

			/* converto, serializo, a classe em xml */
			XmlDocument doc = AuxXML.ObjetoparaXml( consReciNFe );

			/* valido o arquivo após assinar */
			ValidaXML( arqxsd,doc.OuterXml );

			/* chamo o webservice e leio o retorno */
			XmlNode xmlNode = _webService.AutorizaRetNFe( doc,X509Cert );

			/* leio o xml de retorno */
			doc.LoadXml( xmlNode.OuterXml );

			/* retorno o objeto */
			return AuxXML.XmlparaObjeto( new RetConsReciNFe(),doc,true );
		}

		/// <summary>
		/// Faz a Leitura do certificado, se já foi lido anteriormente não exibe a lista de certificados validos.
		/// </summary>
		/// <returns></returns>
		public bool Le_certificado()
		{
			/* Ajustar o certificado digital de String para o tipo X509Certificate2 */
			X509Store store = new X509Store( "MY",StoreLocation.CurrentUser );
			store.Open( OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly );

			/* já esta preparado para a nova versão de protocolo TLS13 */
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls13 | SecurityProtocolType.Tls12;

			X509Certificate2Collection collection = store.Certificates;
			EncriptaDecripta chave = new EncriptaDecripta( new byte[] { 122,232,66,117,12,67,33,23,121,22,56,117,12,67,3,23 } );

			if( string.IsNullOrEmpty( Settings.Default.Certificado ) == true )
			{
				X509Certificate2Collection collection2 = collection.Find( X509FindType.FindByTimeValid,DateTime.Now,true );
				X509Cert = X509Certificate2UI.SelectFromCollection( collection2,
																	"Certificado(s) Digital(is) disponível(is).\r\n",
																	"Selecione o certificado digital para uso no aplicativo.",
																	X509SelectionFlag.SingleSelection )[0];
				/* salvo o nome do certificado, criptografado, digital para não haver a necessidade de ficar procurando toda vez que for emitir uma nota */
				Settings.Default.Certificado = chave.Encriptar( X509Cert.Subject );
				Settings.Default.Save();
			}
			else
			{
				collection = collection.Find( X509FindType.FindBySubjectDistinguishedName,
											chave.Desencriptar( Settings.Default.Certificado ),
											true );
				X509Cert = collection[0];
			}

			return collection.Count > 0;
		}

		/// <summary>
		/// Acrescenta a tag no arquivo xml e assina.
		/// </summary>
		/// <param name="campoxml"></param>
		/// <param name="strXML"></param>
		/// <returns></returns>
		public string AssinaXML( string campoxml,string strXML )
		{
			XmlDocument doc = new XmlDocument();

			if( Le_certificado() == false )
				throw new ArgumentNullException( "Problemas no certificado digital" );
			else
			{
				/* Ignora espaço em branco */
				doc.PreserveWhitespace = false;
				doc.LoadXml( strXML );

				/* Verifica se a tag a ser assinada existe e é única */
				int qtdeRefUri = doc.GetElementsByTagName( campoxml ).Count;

				if( qtdeRefUri == 0 )
				{
					throw new ArgumentNullException( "A tag de assinatura " + campoxml.Trim() + " não existe" );
				}
				/* Exsiste mais de uma tag a ser assinada */
				else
				{
					if( qtdeRefUri > 1 )
					{
						throw ( new ArgumentNullException( "A tag de assinatura " + campoxml.Trim() + " não é unica" ) );
					}
					else
					{
						try
						{
							/* cria o objeto SigneXml */
							SignedXml signedXml = new SignedXml( doc );
							Reference referencia = new Reference();

							/* acrescenta a chave no documento SigneXml */
							signedXml.SigningKey = X509Cert.PrivateKey;
							signedXml.SignedInfo.SignatureMethod = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
							referencia.DigestMethod = "http://www.w3.org/2000/09/xmldsig#sha1";

							/* cria uma referencia para assinar 
								http://www.w3.org/2000/09/xmldsig#sha1.
							*/
							//referencia.DigestMethod = SignedXml.XmlDsigSHA256Url;

							/* pega o uri que deve ser assinada */
							XmlAttributeCollection _Uri = doc.GetElementsByTagName( campoxml ).Item( 0 ).Attributes;
							foreach( XmlAttribute _atributo in _Uri )
							{
								if( _atributo.Name == "Id" )
									referencia.Uri = "#" + _atributo.InnerText;
							}
							if( string.IsNullOrEmpty( referencia.Uri ) == true )
								referencia.Uri = "";
							/* acrescenta o envelope na transferencia */
							XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
							referencia.AddTransform( env );

							XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();

							referencia.AddTransform( c14 );

							/* acrescenta a rferencia no objeto SignedXml */
							signedXml.AddReference( referencia );

							/* Create a new KeyInfo object */
							KeyInfo keyInfo = new KeyInfo();

							/* carrega o certificado na KeyInfoX509Data e acrescenta  na KeyInfo */
							keyInfo.AddClause( new KeyInfoX509Data( X509Cert ) );

							/* acrescenta o objeto KeyInfo no objeto SigneXml */
							signedXml.KeyInfo = keyInfo;
							signedXml.ComputeSignature();

							/* Obtem a representação XML da assinatura e salva em um objeto XmlElement. */
							XmlElement xmlDigitalSignature = signedXml.GetXml();

							/* Gravar o elemento no documento XML */
							doc.DocumentElement.AppendChild( doc.ImportNode( xmlDigitalSignature,true ) );
						}
						catch( Exception e )
						{
							throw new Exception( "ConectaWebService\r\nErro ao assinar o documento.\r\n",e.InnerException );
						}
					}
				}
				return doc.OuterXml;
			}
		}

		/// <summary>
		/// Valida o arquivo xml com o seu respectivo XSD
		/// </summary>
		/// <param name="nomeXSD"></param>
		/// <param name="strXMLAssinado"></param>
		/// <returns></returns>
		public bool ValidaXML( string nomeXSD,string strXMLAssinado )
		{
			bool ret = true;
			//string arqXSD = Application.StartupPath + @"\XSD\" + nomeXSD;
			string arqXSD = @"D:\Teste\XSD\" + nomeXSD;
			XmlDocument doc = new XmlDocument();

			if( File.Exists( arqXSD ) )
			{
				doc.LoadXml( strXMLAssinado );

				/* Define as configurações de validação. */
				XmlReaderSettings settings = new XmlReaderSettings();
				settings.ValidationType = ValidationType.Schema;
				settings.Schemas.Add( "http://www.portalfiscal.inf.br/nfe",arqXSD );

				/* Cria um leitor da validação e agrupa o objeto XmlNodeReader. */
				XmlNodeReader xmlnodereader = new XmlNodeReader( doc );

				XmlReader reader = XmlReader.Create( xmlnodereader,settings );

				/* Analisa o arquivo XML. */
				try
				{
					while( reader.Read() )
					{
					}
				}
				catch( Exception e )
				{
					ret = false;
					throw new Exception( "ConectaWebService\r\nErro ao validar o documento.\r\n",e.InnerException );
				}
				finally
				{
					reader.Close();
				}
			}
			else
				throw new Exception( "O Arquivo " + arqXSD + " Inexistente." );
			return ret;
		}
	}
}
