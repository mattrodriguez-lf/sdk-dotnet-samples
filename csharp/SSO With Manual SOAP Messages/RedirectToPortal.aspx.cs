﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RedirectToPortal : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //If there's no portal security token in the web user's session send them back to the main page
        if (Request.UrlReferrer == null || ConciergeApiHelper.PortalLoginToken == null)
        {
            Response.Redirect("~/default.aspx");
            return;
        }

        //Define the form variables to POST to the portal Login.aspx
        litReturnUrl.Text = Request.UrlReferrer.ToString();
        litToken.Text = Convert.ToBase64String(ConciergeApiHelper.PortalLoginToken);
        //litNextUrl.Text = "profile/EditIndividualInfo.aspx"; //This OPTIONAL value tells the portal where to redirect the user after login.  This MUST be a relative URI
        litAction.Text = ConciergeApiHelper.PortalUrl + "/Login.aspx";

        //Clear out the portal security token from the web user's session
        ConciergeApiHelper.PortalLoginToken = null;

        //This page should never be cached
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
    }
}