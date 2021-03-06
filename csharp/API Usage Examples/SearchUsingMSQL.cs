﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using MemberSuite.SDK.Concierge;
using MemberSuite.SDK.Searching;
using MemberSuite.SDK.Searching.Operations;
using MemberSuite.SDK.Types;

namespace API_Usage_Examples
{
    public class SearchUsingMSQL : ConciergeSampleBase
    {
        public override void Run()
        {
            /* This sample is designed to demonstrate running a search in MemberSuite
             * using MSQL. We'll do a search for all people who have first OR last names that
             * begin with the letter A */

            // First, we need to prepare the proxy with the proper security settings.
            // This allows the proxy to generate the appropriate security header. For more information
            // on how to get these settings, see http://api.docs.membersuite.com in the Getting Started section
            if (!ConciergeAPIProxyGenerator.IsSecretAccessKeySet)
            {
                ConciergeAPIProxyGenerator.SetAccessKeyId(ConfigurationManager.AppSettings["AccessKeyID"]);
                ConciergeAPIProxyGenerator.SetSecretAccessKey(ConfigurationManager.AppSettings["SecretAccessKey"]);
                ConciergeAPIProxyGenerator.AssociationId = ConfigurationManager.AppSettings["AssociationID"];
            }

            // ok, let's generate our API proxy
            using (var api = ConciergeAPIProxyGenerator.GenerateProxy())
            {
                string msql = "select LocalID, LastName, FirstName from Individual where LastName like 'A*' or FirstName like 'A*' order by LastName";

                var result = api.ExecuteMSQL(msql, 0, null);

                if (!result.Success)
                {
                    Console.WriteLine("Search failed: {0}", result.FirstErrorMessage);
                    return;
                }

                Console.WriteLine("Search successful: {0} results returned.",
                    result.ResultValue.SearchResult.TotalRowCount);


                foreach (DataRow row in result.ResultValue.SearchResult.Table.Rows)
                    Console.WriteLine("#{0} - {1}, {2}",
                        row["LocalID"], row["LastName"], row["FirstName"]);
            }
        }
    }
}
