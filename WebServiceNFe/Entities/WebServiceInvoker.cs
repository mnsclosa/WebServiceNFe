using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;
using System.Windows.Forms;
using System.Xml;

namespace ConectaWebServiceNFe.Entities
{
    class WebServiceInvoker
    {
        static string xmlconsultacadastro()
        {

            string xml = "<?xml version=\"1.0\" encoding=\"utf-8\"?>";
            xml += "<ConsCad xmlns=\"http://www.portalfiscal.inf.br/nfe\" versao=\"" + "2.00" + "\">";
            xml += "<infCons>";
            xml += "<xServ>CONS-CAD</xServ>";
            xml += "<UF>SP</UF>";
            xml += "<CNPJ>07349148000185</CNPJ>";
            xml += "</infCons>";
            xml += "</ConsCad>";
            return xml;
        }

        public static void chamarWebService()
        {
            WebServiceInvoker invoker = new WebServiceInvoker( new Uri( "https://nfe.fazenda.sp.gov.br/ws/cadconsultacadastro4.asmx" ) );

            string service = invoker.services[0].ToString();
            string method = invoker.EnumerateServiceMethods( service)[0];

            object[] args = new object[] { xmlconsultacadastro() };

            string result = invoker.InvokeMethod<string>( service,method,args );
        }
        Dictionary<string,Type> availableTypes;

        /// <summary>
        /// Text description of the available services within this web service.
        /// </summary>
        public List<string> AvailableServices
        {
            get
            {
                return this.services;
            }
        }

        /// <summary>
        /// Creates the service invoker using the specified web service.
        /// </summary>
        /// <param name="webServiceUri"></param>
        public WebServiceInvoker( Uri webServiceUri )
        {
            this.services = new List<string>(); // available services
            this.availableTypes = new Dictionary<string,Type>(); // available types

            // create an assembly from the web service description
            this.webServiceAssembly = BuildAssemblyFromWSDL( webServiceUri );

            // see what service types are available
            Type[] types = this.webServiceAssembly.GetExportedTypes();

            // and save them
            foreach( Type type in types )
            {
                services.Add( type.FullName );
                availableTypes.Add( type.FullName,type );
            }
        }

        /// <summary>
        /// Gets a list of all methods available for the specified service.
        /// </summary>
        /// <param name="serviceName"></param>
        /// <returns></returns>
        public List<string> EnumerateServiceMethods( string serviceName )
        {
            List<string> methods = new List<string>();

            if( !this.availableTypes.ContainsKey( serviceName ) )
                throw new Exception( "Service Not Available" );
            else
            {
                Type type = this.availableTypes[serviceName];

                // only find methods of this object type (the one we generated)
                // we don't want inherited members (this type inherited from SoapHttpClientProtocol)
                foreach( MethodInfo minfo in type.GetMethods( BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly ) )
                    methods.Add( minfo.Name );

                return methods;
            }
        }

        /// <summary>
        /// Invokes the specified method of the named service.
        /// </summary>
        /// <typeparam name="T">The expected return type.</typeparam>
        /// <param name="serviceName">The name of the service to use.</param>
        /// <param name="methodName">The name of the method to call.</param>
        /// <param name="args">The arguments to the method.</param>
        /// <returns>The return value from the web service method.</returns>
        public T InvokeMethod<T>( string serviceName,string methodName,params object[] args )
        {
            // create an instance of the specified service
            // and invoke the method
            object obj = this.webServiceAssembly.CreateInstance( serviceName );

            Type type = obj.GetType();

			return (T)type.InvokeMember( methodName,BindingFlags.InvokeMethod,null,obj,args );
		}

        /// <summary>
        /// Builds the web service description importer, which allows us to generate a proxy class based on the 
        /// content of the WSDL described by the XmlTextReader.
        /// </summary>
        /// <param name="xmlreader">The WSDL content, described by XML.</param>
        /// <returns>A ServiceDescriptionImporter that can be used to create a proxy class.</returns>
        private ServiceDescriptionImporter BuildServiceDescriptionImporter( XmlTextReader xmlreader )
        {
            // make sure xml describes a valid wsdl
            if( !ServiceDescription.CanRead( xmlreader ) )
                throw new Exception( "Invalid Web Service Description" );

            // parse wsdl
            ServiceDescription serviceDescription = ServiceDescription.Read( xmlreader );

            // build an importer, that assumes the SOAP protocol, client binding, and generates properties
            ServiceDescriptionImporter descriptionImporter = new ServiceDescriptionImporter();
            //descriptionImporter.ProtocolName = "Soap";
            descriptionImporter.AddServiceDescription( serviceDescription,null,null );
            descriptionImporter.Style = ServiceDescriptionImportStyle.Client;
            descriptionImporter.CodeGenerationOptions = System.Xml.Serialization.CodeGenerationOptions.GenerateProperties;

            return descriptionImporter;
        }

        /// <summary>
        /// Compiles an assembly from the proxy class provided by the ServiceDescriptionImporter.
        /// </summary>
        /// <param name="descriptionImporter"></param>
        /// <returns>An assembly that can be used to execute the web service methods.</returns>
        private Assembly CompileAssembly( ServiceDescriptionImporter descriptionImporter )
        {
            // a namespace and compile unit are needed by importer
            CodeNamespace codeNamespace = new CodeNamespace();
            CodeCompileUnit codeUnit = new CodeCompileUnit();

            codeUnit.Namespaces.Add( codeNamespace );

            ServiceDescriptionImportWarnings importWarnings = descriptionImporter.Import( codeNamespace,codeUnit );

            if( importWarnings == 0 ) // no warnings
            {
                // create a c# compiler
                CodeDomProvider compiler = CodeDomProvider.CreateProvider( "CSharp" );

                // include the assembly references needed to compile
                string[] references = new string[2] { "System.Web.Services.dll","System.Xml.dll" };

                CompilerParameters parameters = new CompilerParameters( references );

                // compile into assembly
                CompilerResults results = compiler.CompileAssemblyFromDom( parameters,codeUnit );

                foreach( CompilerError oops in results.Errors )
                {
                    // trap these errors and make them available to exception object
                    throw new Exception( "Compilation Error Creating Assembly" );
                }

                // all done....
                return results.CompiledAssembly;
            }
            else
            {
                // warnings issued from importers, something wrong with WSDL
                throw new Exception( "Invalid WSDL" );
            }
        }
        public static X509Certificate2 oCertificado
        {
            get; private set;
        }

        /// <summary>
        /// Builds an assembly from a web service description.
        /// The assembly can be used to execute the web service methods.
        /// </summary>
        /// <param name="webServiceUri">Location of WSDL.</param>
        /// <returns>A web service assembly.</returns>
        private Assembly BuildAssemblyFromWSDL( Uri webServiceUri )
        {
            if( String.IsNullOrEmpty( webServiceUri.ToString() ) )
                throw new Exception( "Web Service Not Found" );

            X509Certificate2 oX509Cert = new X509Certificate2();
            X509Store store = new X509Store( "MY",StoreLocation.CurrentUser );
            store.Open( OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly );
            X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
            X509Certificate2Collection collection1 = (X509Certificate2Collection)collection.Find( X509FindType.FindByTimeValid,DateTime.Now,true );
            X509Certificate2Collection collection2 = (X509Certificate2Collection)collection.Find( X509FindType.FindByKeyUsage,X509KeyUsageFlags.DigitalSignature,true );
            X509Certificate2Collection scollection = X509Certificate2UI.SelectFromCollection( collection2,"Certificado(s) Digital(is) disponível(is)","Selecione o certificado digital para uso no aplicativo",X509SelectionFlag.SingleSelection );

			//if( scollection.Count == 0 )
			//    MessageBox.Show( "Nenhum certificado digital foi selecionado ou o certificado selecionado está com problemas.","Advertência",MessageBoxButton.OK,MessageBoxImage.Warning );
			oCertificado = scollection[0];




			HttpWebRequest wr = (HttpWebRequest)HttpWebRequest.Create( webServiceUri.OriginalString + "?wsdl" );
            wr.ClientCertificates.Add( oCertificado );
            HttpWebResponse wres = (HttpWebResponse)wr.GetResponse();

            XmlTextReader xmlreader = new XmlTextReader( wres.GetResponseStream() );


            //XmlTextReader xmlreader = new XmlTextReader(webServiceUri.ToString() + "?wsdl");


            ServiceDescriptionImporter descriptionImporter = BuildServiceDescriptionImporter( xmlreader );

            return CompileAssembly( descriptionImporter );
        }

        private Assembly webServiceAssembly;
        private List<string> services;
    }
}
