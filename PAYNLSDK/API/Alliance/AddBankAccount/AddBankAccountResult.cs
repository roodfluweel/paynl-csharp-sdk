using Newtonsoft.Json;

namespace PAYNLSDK.API.Alliance.AddBankAccount
{
    /// <summary>
    /// Response for the Alliance/addBankaccount call.
    /// </summary>
    public class AddBankAccountResult : ResponseBase
    {
        /// <summary>
        /// Payment URL where the merchant should be redirected to.
        /// </summary>
        [JsonProperty("issuerUrl")]
        public string IssuerUrl { get; set; }
    }
}
