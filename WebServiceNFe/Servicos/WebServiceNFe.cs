using ServiceNFe.Enums;
using System;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace ServiceNFe.Servicos
{
	public abstract class WebServiceNFe
	{
		/// <summary>
		/// Para indicar qual ambiente o sistema irá trabalhar
		/// </summary>
		public TipodeAmbiente Tipodeambiente
		{
			get; set;
		}

		public void RelacionarCertObj( object pObjeto,X509Certificate2 X509Cert )
		{
			// Detectar o tipo do objeto
			Type tipoServico = pObjeto.GetType();

			//Relacionar o certificado ao objeto
			object oClientCertificates = tipoServico.InvokeMember( "ClientCertificates",System.Reflection.BindingFlags.GetProperty,null,pObjeto,new object[] { } );
			Type tipoClientCertificates = oClientCertificates.GetType();
			tipoClientCertificates.InvokeMember( "Add",System.Reflection.BindingFlags.InvokeMethod,null,oClientCertificates,new object[] { X509Cert } );
		}

		public abstract XmlNode ConsultaCadastro( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode StatusServico( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode InutilizaNumeracao( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode ConsultaProtocolo( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode CartadeCorrecaoCancelamento( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode AutorizaNFe( XmlNode xml,X509Certificate2 X509Cert );
		public abstract XmlNode AutorizaRetNFe( XmlNode xml,X509Certificate2 X509Cert );
	}
}
