﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JCSoft.WX.Framework.Models.ApiResponses;
using JCSoft.Core.Net.Http;

namespace JCSoft.WX.Framework.Models.ApiRequests
{
    public class MerchantGroupAddRequest : ApiRequest<MerchantGroupAddResponse>
    {
        [JsonProperty("group_detail")]
        public MerchantGroupDetail GroupDetail { get; set; }

        internal override HttpRequestActionType Method
        {
            get { return HttpRequestActionType.Content; }
        }

        protected override string UrlFormat
        {
            get { return "/merchant/group/add?access_token={0}"; }
        }

        internal override string GetUrl()
        {
            return String.Format(UrlFormat, AccessToken);
        }

        protected override bool NeedToken
        {
            get { return true; }
        }

        internal override string GetPostContent()
        {
            return JsonConvert.SerializeObject(this);
        }

        public override void Validate()
        {
            base.Validate();
            if (this.GroupDetail != null)
            {
                this.GroupDetail.GroupId = 0;
                this.GroupDetail.Product = null;
            }
        }
    }
}
