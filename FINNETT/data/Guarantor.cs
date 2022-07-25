namespace FINNETT.data
{
    /// <summary>
    /// Defines the <see cref="Guarantor" />
    /// </summary>
    public class Guarantor
    {
        /// <summary>
        /// Defines the ClientID
        /// </summary>
        private readonly string ClientID;

        /// <summary>
        /// Defines the ClientName
        /// </summary>
        private readonly string ClientName;

        /// <summary>
        /// Defines the AccountNo
        /// </summary>
        private readonly string AccountNo;

        /// <summary>
        /// Defines the AccountName
        /// </summary>
        private readonly string AccountName;

        /// <summary>
        /// Defines the CurrentBalance
        /// </summary>
        private readonly string CurrentBalance;

        /// <summary>
        /// Defines the AvailableBalance
        /// </summary>
        private readonly string AvailableBalance;

        /// <summary>
        /// Defines the AmountGuaranteed
        /// </summary>
        private readonly string AmountGuaranteed;

        /// <summary>
        /// Defines the LoanPercentage
        /// </summary>
        private readonly string LoanPercentage;

        /// <summary>
        /// Defines the DateGuaranteed
        /// </summary>
        private readonly string DateGuaranteed;

        /// <summary>
        /// Initializes a new instance of the <see cref="Guarantor"/> class.
        /// </summary>
        /// <param name="clientid">The clientid<see cref="string"/></param>
        /// <param name="clientname">The clientname<see cref="string"/></param>
        /// <param name="accountno">The accountno<see cref="string"/></param>
        /// <param name="accountname">The accountname<see cref="string"/></param>
        /// <param name="currentbalance">The currentbalance<see cref="string"/></param>
        /// <param name="availablebalance">The availablebalance<see cref="string"/></param>
        /// <param name="amountguaranteed">The amountguaranteed<see cref="string"/></param>
        /// <param name="loanpercentage">The loanpercentage<see cref="string"/></param>
        /// <param name="dateguaranteed">The dateguaranteed<see cref="string"/></param>
        public Guarantor(string clientid, string clientname, string accountno, string accountname,
            string currentbalance, string availablebalance,
            string amountguaranteed, string loanpercentage, string dateguaranteed)
        {
            ClientID = clientid;
            ClientName = clientname;
            AccountNo = accountno;
            AccountName = accountname;
            CurrentBalance = currentbalance;
            AvailableBalance = availablebalance;
            AmountGuaranteed = amountguaranteed;
            LoanPercentage = loanpercentage;
            DateGuaranteed = dateguaranteed;
        }
    }
}