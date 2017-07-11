using System;
using System.IO;
using System.Web;
using System.Web.Hosting;
using System.Xml.Linq;

namespace PadelManager.UiMvc
{
    public class Secrets
    {
        private const string SecretsFileName = "Keys.xml";
        private static readonly XDocument XmlDocument;
        

        static Secrets()
        {
            string appPath = HostingEnvironment.MapPath("~/");
            if (string.IsNullOrEmpty(appPath)) throw new InvalidOperationException("Can not get app virtual path");
            var secretsFilePath = Path.Combine(appPath, SecretsFileName);
            if(!File.Exists(secretsFilePath)) throw new FileNotFoundException("Could not find secrets file.");
            XmlDocument  = XDocument.Load(secretsFilePath);
        }


        public static string GoogleOAuthClientId
        {
            get
            {
                var xElement = XmlDocument.Element("Secrets");
                var element = xElement?.Element("GoogleOAuthClientId");
                if (element != null)
                    return element.Value;
                throw new ApplicationException("GoogleOAuthClientId not defined");
            }
        }

        public static string GoogleOAuthClientSecret
        {
            get
            {
                var xElement = XmlDocument.Element("Secrets");
                var element = xElement?.Element("GoogleOAuthClientSecret");
                if (element != null)
                    return element.Value;
                throw new ApplicationException("GoogleOAuthClientSecret not defined");
            }
        }
    }
}