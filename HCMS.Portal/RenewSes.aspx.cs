﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal
{
    public partial class RenewSes : System.Web.UI.Page
    {
        static byte[] gif = {0x47,0x49,0x46,0x38,0x39,0x61,0x01,0x00,0x01,
                          0x00,0x91,0x00,0x00,0x00,0x00,0x00,0x00,0x00,
                          0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x21,0xf9,
                          0x04,0x09,0x00,0x00,0x00,0x00,0x2c,0x00,0x00,
                          0x00,0x00,0x01,0x00,0x01,0x00,0x00,0x08,0x04,
                          0x00,0x01,0x04,0x04,0x00,0x3b,0x00};

        override protected void OnInit(EventArgs e)
        {
            InitializeComponent();
            base.OnInit(e);
        }

        private void InitializeComponent()
        {
            Response.AddHeader("ContentType", "image/gif");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.BinaryWrite(gif);
            Response.End();
        }


    }
}
