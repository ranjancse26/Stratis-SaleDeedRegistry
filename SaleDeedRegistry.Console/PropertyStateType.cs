using System.ComponentModel;

namespace SaleDeedRegistry.Console
{
    partial class Program
    {
        public enum PropertyStateType : uint
        {
            [Description("InProgress")]
            InProgress = 0,
            [Description("UnderReview")]
            UnderReview = 1,
            [Description("ReviewComplete")]
            ReviewComplete = 2,
            [Description("PaidTransferFee")]
            PaidTransferFee = 3,
            [Description("Approved")]
            Approved = 4,
            [Description("Rejected")]
            Rejected = 5
        }
    }
}
