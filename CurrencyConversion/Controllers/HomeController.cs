using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;

namespace CurrencyConversion.Controllers
{
    public class HomeController : ApiController
    {
              
        [Route("EUR/100/USD")]
        [HttpGet]
        public RawJsonActionResult ConversionEURUSD(string access_key, string amt, string from_curr, string to_curr)
        {
            dynamic jresponse = new JObject();

            try
            {
                int currency = 0;
                double finalamount = 0;
                bool isAmount;
                if (access_key == "135a1eb922ae3aa21eefa5be17f510ec")
                {
                    if (string.IsNullOrEmpty(amt))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Please enter amount\"}";
                        return new RawJsonActionResult(jresponse);
                    }
                    if (string.IsNullOrEmpty(from_curr))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Currency to Convert from is not specified\"}";
                        return new RawJsonActionResult(jresponse);
                    }
                    if (string.IsNullOrEmpty(to_curr))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Conversion to Currency is not specified\"}";
                        return new RawJsonActionResult(jresponse);
                    }

                    isAmount = int.TryParse(amt, out currency);
                    if (isAmount && from_curr.ToUpper() == "EUR" && to_curr.ToUpper() == "USD")
                    {
                        //dynamic rate = new JObject();
                        finalamount = (double)(currency * 1.18);
                        //rate.INR = finalamount;
                        jresponse.success = true;
                        jresponse.timestamp = GetTimestamp(DateTime.Now).ToString();
                        jresponse.Base = from_curr.ToUpper().ToString();
                        jresponse.date = System.DateTime.Now.ToString();
                        jresponse.rates = new JObject();
                        jresponse.rates.USD = finalamount.ToString();
                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Request\"}";
                        return new RawJsonActionResult(jresponse);
                    }

                }
                else
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Access Key is Invalid\"}";
                    return new RawJsonActionResult(jresponse);
                }
            }
            catch (Exception ex)
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }
           
            return new RawJsonActionResult(jresponse.ToString());
        }

        [Route("usd/100/inr")]
        [HttpGet]
        public RawJsonActionResult ConversionUSDINR( string access_key, string amt,string from_curr,string to_curr)
        {
            dynamic jresponse = new JObject();
            try
            {
                int currency = 0;
                int finalamount = 0;
                bool isAmount;
                if (access_key == "135a1eb922ae3aa21eefa5be17f510ec")
                {
                    if (string.IsNullOrEmpty(amt))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Please enter amount\"}";
                        return new RawJsonActionResult(jresponse);
                    }
                    if (string.IsNullOrEmpty(from_curr))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Currency to Convert from is not specified\"}";
                        return new RawJsonActionResult(jresponse);
                    }
                    if (string.IsNullOrEmpty(to_curr))
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Conversion to Currency is not specified\"}";
                        return new RawJsonActionResult(jresponse);
                    }

                    isAmount = int.TryParse(amt, out currency);
                    if (isAmount && from_curr.ToUpper() == "USD" && to_curr.ToUpper() == "INR")
                    {
                        //dynamic rate = new JObject();
                        finalamount = currency * 73;
                        //rate.INR = finalamount;
                        jresponse.success = true;
                        jresponse.timestamp = GetTimestamp(DateTime.Now).ToString();
                        jresponse.Base = from_curr.ToUpper().ToString();
                        jresponse.date = System.DateTime.Now.ToString();
                        jresponse.rates = new JObject();
                        jresponse.rates.INR = finalamount.ToString();
                    }
                    else
                    {
                        jresponse = "{\"status\":" + false + ",\"message\":\"Invalid Request\"}";
                        return new RawJsonActionResult(jresponse);
                    }

                }
                else
                {
                    jresponse = "{\"status\":" + false + ",\"message\":\"Access Key is Invalid\"}";
                    return new RawJsonActionResult(jresponse);
                }
            }
            catch(Exception ex)
            {
                jresponse = "{\"status\":" + false + ",\"message\":\"Some error Occured\"}";
                return new RawJsonActionResult(jresponse.ToString());
            }

            return new RawJsonActionResult(jresponse.ToString());
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("yyyyMMddHHmmss");
        }
        public class RawJsonActionResult : IHttpActionResult
        {
            private readonly string _jsonString;

            public RawJsonActionResult(string jsonString)
            {
                _jsonString = jsonString;
            }

            public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
            {
                var content = new StringContent(_jsonString);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = new HttpResponseMessage(HttpStatusCode.OK) { Content = content };
                return Task.FromResult(response);
            }
        }        
    }
}
