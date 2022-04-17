using System;
using System.Collections.Generic;

namespace Contrato.Models
{
    public class OrderRegistryReqVM
    {
        public string auth_token { get; set; }
        public string delivery_needed { get; set; } = "false";
        public string amount_cents { get; set; }
        public string currency { get; set; }
        public List<Item> items { get; set; }
    }

    public class OrderRegistryResVM
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public bool delivery_needed { get; set; }
        public Merchant merchant { get; set; }
        public object collector { get; set; }
        public int amount_cents { get; set; }
        public object shipping_data { get; set; }
        public string currency { get; set; }
        public bool is_payment_locked { get; set; }
        public bool is_return { get; set; }
        public bool is_cancel { get; set; }
        public bool is_returned { get; set; }
        public bool is_canceled { get; set; }
        public object merchant_order_id { get; set; }
        public object wallet_notification { get; set; }
        public int paid_amount_cents { get; set; }
        public bool notify_user_with_email { get; set; }
        public List<Item> items { get; set; }
        public string order_url { get; set; }
        public int commission_fees { get; set; }
        public int delivery_fees_cents { get; set; }
        public int delivery_vat_cents { get; set; }
        public string payment_method { get; set; }
        public object merchant_staff_tag { get; set; }
        public string api_source { get; set; }
        public string token { get; set; }
        public string url { get; set; }
    }

    public class Item
    {
        public string name { get; set; }
        public string amount_cents { get; set; }
        public string description { get; set; }
        public string quantity { get; set; }
    }

    public class Merchant
    {
        public int id { get; set; }
        public DateTime created_at { get; set; }
        public List<string> phones { get; set; }
        public List<string> company_emails { get; set; }
        public string company_name { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public object city { get; set; }
        public string postal_code { get; set; }
        public string street { get; set; }
    }
}
