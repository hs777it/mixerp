﻿using System.ComponentModel;
using System.Web.Script.Services;
using System.Web.Services;
using MixERP.Net.ApplicationState.Cache;
using Newtonsoft.Json;

namespace MixERP.Net.Core.Modules.Sales.Services
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    [ScriptService]
    public class Order : WebService
    {
        [WebMethod]
        public string GetSupplyPlannerView(long orderId)
        {
            var model = Data.Transactions.Order.GetSupplyPlannerView(AppUsers.GetCurrentUserDB(), orderId);
            var result = JsonConvert.SerializeObject(model);

            return result;
        }

        [WebMethod]
        public string ListStock(int storeId, int[] itemIds)
        {
            if (itemIds.Length == 0)
                return string.Empty;

            var model = Data.Transactions.Order.ListClosingStock(AppUsers.GetCurrentUserDB(), storeId, itemIds);
            var result = JsonConvert.SerializeObject(model);

            return result;
        }
    }
}