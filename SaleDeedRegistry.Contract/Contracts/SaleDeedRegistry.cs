using Stratis.SmartContracts;

/// <summary>
/// The SaleDeedRegistry that deals with the Property Asset Information Managment
/// The Property Buyer and Owner can transfer the asset ownership upon the agreed date and amount. 
/// </summary>
[Deploy]
public class SaleDeedRegistryContract : SmartContract
{
    /// <summary>
    /// Set the appropriate property state
    /// </summary>
    public enum PropertyStateType : uint
    {
        NotStarted = 0,
        InProgress = 1,
        UnderReview = 2,
        ReviewComplete = 3,
        PaidTransferFee = 4,
        Approved = 5,
        Rejected = 6
    }

    public SaleDeedRegistryContract(ISmartContractState smartContractState, Address payeeAddress)
    : base(smartContractState)
    {
        this.PayeeAddress = payeeAddress;
    }

    #region "Getter and Setters"

    public Address PayeeAddress
    {
        get
        {
            return PersistentState.GetAddress("PayeeAddress");
        }
        set
        {            
            PersistentState.SetAddress("PayeeAddress", value);
        }
    }

    public string GetAssetId(Address ownerAddress)
    {
        return this.PersistentState.GetString($"AssetId[{ownerAddress}]");
    }

    public void SetAssetId(Address ownerAddress, string assetId)
    {
        this.PersistentState.SetString($"AssetId[{ownerAddress}]", assetId);
    }

    public bool GetEncumbranceCleared(string assetId)
    {
        return this.PersistentState.GetBool($"EncumbranceCleared[{assetId}]");
    }

    private void SetEncumbranceCleared(string assetId, bool isCleared)
    {
        this.PersistentState.SetBool($"EncumbranceCleared[{assetId}]", isCleared);
    }
    

    public Address GetPropertyOwner(string assetId)
    {
        return this.PersistentState.GetAddress($"PropertyOwner[{assetId}]");
    }

    private void SetPropertyOwner(Address address, string assetId)
    {
        this.PersistentState.SetAddress($"PropertyOwner[{assetId}]", address);
    }

    public uint GetPropertyState(string assetId)
    {
        return this.PersistentState.GetUInt32($"PropertyState[{assetId}]");
    }

    private void SetPropertyState(string assetId, uint state)
    {
        this.PersistentState.SetUInt32($"PropertyState[{assetId}]", state);
    }

    #endregion

    /// <summary>
    /// Start the application process
    /// </summary
    /// <param name="propertyOwnerAddress"></param>
    /// <param name="buyerAddress"></param>
    /// <param name="assetId"></param>
    public void InitApplication(Address propertyOwnerAddress,
        Address buyerAddress, string assetId)
    {
        SetAssetId(propertyOwnerAddress, assetId);
        SetPropertyOwner(propertyOwnerAddress, assetId);
        SetPropertyState(assetId, (uint)PropertyStateType.InProgress);
        DoStateLogging(PropertyStateType.InProgress, "In-Progress");
    }

    private void DoStateLogging(PropertyStateType propertyStateType,
        string description)
    {
        Log(new StateLogInfo
        {
            State = (uint)propertyStateType,
            Description = description
        });
    }

    /// <summary>
    /// Start the review process
    /// </summary>
    /// <param name="buyerAddress"></param>
    public void StartReviewProcess(Address propertyOwnerAddress,
        Address buyerAddress, string assetId)
    {
        uint propState = GetPropertyState(assetId);
        Assert(propState == (int)PropertyStateType.InProgress);
        SetPropertyState(assetId, (uint)PropertyStateType.UnderReview);
        DoStateLogging(PropertyStateType.UnderReview, "Under Review");
    }

    /// <summary>
    /// Complete the review process
    /// </summary>
    /// <param name="buyerAddress"></param>
    public void CompleteReviewProcess(Address propertyOwnerAddress,
        Address buyerAddress, string assetId)
    {
        uint propState = GetPropertyState(assetId);
        Address owner = GetPropertyOwner(assetId);

        Assert(owner == propertyOwnerAddress);
        Assert(assetId != "");
        Assert(propState == (int)PropertyStateType.UnderReview);

        SetEncumbranceCleared(assetId, true);
        SetPropertyState(assetId, (uint)PropertyStateType.ReviewComplete);
        DoStateLogging(PropertyStateType.ReviewComplete, "Review Complete");
    }    

    /// <summary>
    /// Reject the application
    /// </summary>
    /// <param name="buyerAddress"></param>
    public void RejectApplication(string assetId)
    {
        SetPropertyState(assetId, (uint)PropertyStateType.Rejected);
        DoStateLogging(PropertyStateType.Rejected, "Rejected");
    }

    /// <summary>
    /// Re-apply the application process
    /// </summary>
    public void ReApply(string assetId)
    {
        SetPropertyState(assetId, (uint)PropertyStateType.InProgress);
        DoStateLogging(PropertyStateType.InProgress, "InProgress");
    }

    /// <summary>
    /// Pay the Application Transfer Fee
    /// </summary>
    /// <param name="buyerAddress">Buyer Address</param>
    /// <param name="payeeAddress">Payee Address</param>
    /// <param name="assetId">AssetId</param>
    /// <param name="fee">Fee</param>
    public void PayApplicationTransferFee(Address buyerAddress,
        Address payeeAddress, string assetId, ulong fee)
    {
        Assert(fee > 0, "Fee cannot be less than or equal to 0");
        Assert(this.PayeeAddress == payeeAddress, "Payee address mismatch");

        uint propState = GetPropertyState(assetId);

        // Set the state to ReviewComplete
        Assert(propState == (int)PropertyStateType.ReviewComplete,
            "The State is not in ReviewComplete mode");

        // Transfer the application fee
        Transfer(payeeAddress, fee);

        // Set the state to PaidTransferFee
        SetPropertyState(assetId, (uint)PropertyStateType.PaidTransferFee);
        DoStateLogging(PropertyStateType.PaidTransferFee, "Paid Transfer Fee");
    }

    /// <summary>
    /// Transfer Asset Ownership of a specific Property/Asset
    /// </summary>
    public void TransferOwnership(Address propertyOwner,
        Address propertyBuyer, string assetId)
    {
        uint propState = GetPropertyState(assetId);

        Assert(propertyOwner != propertyBuyer, "The owner and the buyer cannot be same");
        Assert(propState == (int)PropertyStateType.PaidTransferFee, "State not equal to PaidTransferFee");
        Assert(assetId != "", "AssetId is not set or empty");

        // Make sure to double check the Encumbrance is cleared
        bool isEncumbranceCleared = GetEncumbranceCleared(assetId);
        Assert(isEncumbranceCleared, "Encumbrance not cleared");

        // Set the Property Owner and the Asset Id
        SetPropertyOwner(propertyBuyer, assetId);

        // Log purchace information
        Log(new PurchaseLogInfo
        {
            AssetId = assetId,
            From = propertyOwner,
            To = propertyBuyer
        });

        // Set the property state as Approved
        SetPropertyState(assetId, (uint)PropertyStateType.Approved);
        DoStateLogging(PropertyStateType.Approved, "Approved");
    }

    /// <summary>
    /// State Logging Related
    /// </summary>
    public struct StateLogInfo
    {
        public uint State;
        public string Description;
    }

    /// <summary>
    /// Purchace Log Information
    /// </summary>
    public struct PurchaseLogInfo
    {
        public Address From;
        public Address To;
        public string AssetId;
    }
}


