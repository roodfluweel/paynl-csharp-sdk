using System.Collections.Specialized;

namespace PAYNLSDK.API.Alliance.AddBankAccount
{
    /// <summary>
    /// Request to add a bank account to an alliance merchant.
    /// </summary>
    public class Request : RequestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Request"/> class.
        /// </summary>
        /// <param name="merchantId">The merchant ID.</param>
        /// <param name="returnUrl">The return URL.</param>
        public Request(string merchantId, string returnUrl)
        {
            MerchantId = merchantId;
            ReturnUrl = returnUrl;
        }

        /// <inheritdoc />
        protected override int Version => 8;

        /// <inheritdoc />
        protected override string Controller => "Alliance";

        /// <inheritdoc />
        protected override string Method => "addBankaccount";

        /// <inheritdoc />
        public override NameValueCollection GetParameters()
        {
            var retVal = new NameValueCollection
            {
                { "merchantId", MerchantId },
                { "returnUrl", ReturnUrl }
            };

            if (BankId.HasValue)
            {
                retVal.Add("bankId", BankId.Value.ToString());
            }

            if (PaymentOptionId.HasValue)
            {
                retVal.Add("paymentOptionId", PaymentOptionId.Value.ToString());
            }

            return retVal;
        }

        /// <summary>
        /// The merchant ID.
        /// </summary>
        public string MerchantId { get; set; }

        /// <summary>
        /// The URL where the merchant is sent to after payment.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        /// Optional bank ID.
        /// </summary>
        public int? BankId { get; set; }

        /// <summary>
        /// Optional payment option ID.
        /// </summary>
        public int? PaymentOptionId { get; set; }

        /// <inheritdoc />
        protected override void PrepareAndSetResponse()
        {
            // do nothing
        }
    }
}
