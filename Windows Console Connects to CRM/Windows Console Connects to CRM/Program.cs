using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel; // For using the WCF
using System.ServiceModel.Description;
// Contains enumerations of possible picklists and integer values for some attributes. 
// The naming convention of the classes is [open arrow brace]entityname[close arrow brace][open arrow brace]attributename[close arrow brace] to make it easier to locate the specific attribute.
using Microsoft.Crm.Sdk;
// Defines the data contracts for attribute types, interfaces for authoring plug-ins, 
// and other general purpose xRM types and methods.
//using Microsoft.Xrm.Sdk;
// Defines classes for use by client-code, including a data context, 
// proxy classes to ease the connection to Microsoft Dynamics CRM, and the LINQ provider.
using Microsoft.Xrm.Sdk.Client;
// Defines request/response classes for Create, Retrieve, Update, Delete, Associate , Disassociate, and the metadata classes.
//using Microsoft.Xrm.Sdk.Messages;
// Defines query classes required to connect to Microsoft Dynamics CRM.
//using Microsoft.Xrm.Sdk.Query;
//using Microsoft.Crm.Services.Utility;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Diagnostics;
using System.ComponentModel;
using System.IO;


namespace ConsoleFindWrongOwnership
{
    class Program
    {

        private static OrganizationServiceProxy _serviceProxy;
        private static ClientCredentials _clientCreds;
        static void Main(string[] args)
        {
            // Setup credential
            string serverURL = "http://d1vbcrm01:5555/BMADEV/XRMServices/2011/Organization.svc";
            _clientCreds = new ClientCredentials();
            _clientCreds.Windows.ClientCredential.UserName = "";
            _clientCreds.Windows.ClientCredential.Password = "";
            _clientCreds.Windows.ClientCredential.Domain = "";


            _serviceProxy = new OrganizationServiceProxy(new Uri(serverURL), null, _clientCreds, null);
            OrganizationServiceContext orgContext

= new OrganizationServiceContext(_serviceProxy);

            var query = from a in orgContext.CreateQuery("account")
                       // where ((string)a["owneridname"]).Contains("WGS%")
                        select new { test = a["statecode"] };
            var count = query.ToList().Count;


            Console.WriteLine("Accounts No.:" + count);
            Console.ReadLine();


        }
    }
}
