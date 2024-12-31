using ProjectManagement.Core.Values;
 
namespace ProjectManagement.Core.Models;
 
public partial class Project
{
#pragma warning disable CS8618
    internal Project()
    {
        Number = string.Empty;
        Name = string.Empty;
        UpdatedOn = DateTime.UtcNow;
        Sites = [];
        PriorityClientGroups = [];
        SectorClientGroups = [];
        Milestones = [];
        SustainabilitySolutionsESGClassifications = [];
        ProjectLinks = [];
        ProjectActivities = [];
    }
#pragma warning disable  CS8618
 
    public Project(
        string number,
        string name,
        DateTime? startDate,
        DateTime? endDate,
        Stage? stage,
        ConfidentialityLevel? confidentialityLevel,
        Status? status)
        : this()
    {
        Number = number;
        Name = name;
        StartDate = startDate;
        CompletionDate = endDate;
        Stage = stage;
        ConfidentialityLevel = confidentialityLevel;
        Status = status;
    }
 
    public Project(
        string number,
        string name,
        DateTime? startDate,
        DateTime? endDate,
        Stage? stage,
        ConfidentialityLevel? confidentialityLevel,
        Status? status,
        Client client,
        Fee fee,
        User proposalManager,
        User proposalDirector,
        Currency billingCurrency
    ) : this(number, name, startDate, endDate, stage, confidentialityLevel, status)
    {
        Client = client;
        Fee = fee;
        ProposalManager = proposalManager;
        ProposalDirector = proposalDirector;
        BillingCurrency = billingCurrency;
    }
 
    public Project(string number, string name) : this()
    {
        Number = number;
        Name = name;
    }
 
    public int NumberId { get; private set; }
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Number { get; private set; }
 
    public Stage? Stage { get; private set; }
 
    public ConfidentialityLevel? ConfidentialityLevel { get; private set; }
    public Status? Status { get; private set; }
 
    public int? BillingClientId { get; private set; }
    public Client? BillingClient { get; private set; }
 
    public int? ContactId { get; private set; }
    public Contact? Contact { get; private set; }
 
    public int? ClientLocationId { get; private set; }
    public Location? ClientLocation { get; private set; }
 
    public int? ProfitCentreId { get; private set; }
    public ProfitCentre? ProfitCentre { get; private set; }
 
    public decimal? ContractValue { get; private set; }
    public decimal? WIPValue { get; private set; }
    public DateTime? MonthlyReviewDue { get; private set; }
 
    public int? FeeId { get; private set; }
    public Fee? Fee { get; private set; }
 
    public string? BillingCurrencyCode { get; private set; }
    public Currency? BillingCurrency { get; private set; }
 
    public string? ProjectCurrencyCode { get; private set; }
    public Currency? ProjectCurrency { get; private set; }
 
    public string? GoDecisionReason { get; private set; }
 
    public bool? SRAndEDEligible { get; private set; }
    public bool? IndigenousProject { get; private set; }
 
    public string? UpdatedBy { get; private set; }
    public DateTime UpdatedOn { get; private set; }
 
    public int FixedGeneralDisbursementPercentage { get; private set; }
 
    public bool ProjectDirectorRevReq { get; private set; }
 
    public ICollection<ProjectActivity> ProjectActivities { get; private set; }
 
    public void UpdateDetails(
        User updatedBy,
        bool travelRequired,
        User? proposalManager = null,
        User? proposalDirector = null,
        DateTime? startDate = null,
        DateTime? endDate = null,
        int? goingAheadProbability = null,
        int? winningProbability = null,
        int? locationId = null,
        EthicalRiskLevelLookup? ethicalRisk = null,
        AbcAndHumanRightsRiskLookup? abcAndHumanRightsRisk = null,
        Stage? stage = null,
        ConfidentialityLevel? confidentialityLevel = null,
        Status? status = null,
        decimal? contractValue = null,
        decimal? wipValue = null,
        DateTime? monthlyReviewDue = null,
        ProfitCentre? profitCentre = null
    )
    {
        TravelRequired = travelRequired;
 
        if (proposalManager is not null) ProposalManager = proposalManager;
        if (proposalDirector is not null) ProposalDirector = proposalDirector;
        if (startDate is not null) StartDate = startDate;
        if (endDate is not null) CompletionDate = endDate;
        if (goingAheadProbability is not null) GoingAheadProbability = goingAheadProbability;
        if (winningProbability is not null) WinningProbability = winningProbability;
        if (locationId is not null) LocationId = locationId;
        if (ethicalRisk is not null) EthicalRisk = ethicalRisk;
        if (abcAndHumanRightsRisk is not null) AbcAndHumanRightsRisk = abcAndHumanRightsRisk;
        if (stage is not null) Stage = stage;
        if (confidentialityLevel is not null) ConfidentialityLevel = confidentialityLevel;
        if (status is not null) Status = status;
        if (contractValue is not null) ContractValue = contractValue;
        if (wipValue is not null) WIPValue = wipValue;
        if (monthlyReviewDue is not null) MonthlyReviewDue = monthlyReviewDue;
        if (profitCentre is not null) ProfitCentre = profitCentre;
 
        SetUpdatedProperties(updatedBy);
    }
 
    public void UpdateFee(
        User updatedBy,
        Fee? fee = null,
        Currency? currency = null,
        DateTime? proposalDueDate = null,
        string? goDecisionReason = null
    )
    {
        if (fee is not null) Fee = fee;
        if (currency is not null) BillingCurrency = currency;
        if (proposalDueDate is not null) ProposalDueDate = proposalDueDate;
        if (goDecisionReason is not null) GoDecisionReason = goDecisionReason;
 
        SetUpdatedProperties(updatedBy);
    }
 
    public void UpdateRegionalSpecificDetails(
        User updatedBy,
        bool? sRAndEDEligible = null,
        bool? indigenousProject = null
    )
    {
        if (sRAndEDEligible is not null) SRAndEDEligible = sRAndEDEligible;
        if (indigenousProject is not null) IndigenousProject = indigenousProject;
 
        SetUpdatedProperties(updatedBy);
    }
 
    public void UpdateProjectInformation(
        User updatedBy,
        int profitCentreId,
        int billingClientId,
        string projectCurrencyCode,
        int slrOfficeClosestToProjectSiteLocationId,
        int fixedGeneralDisbursementPercentage)
    {
        ProfitCentreId = profitCentreId;
        BillingClientId = billingClientId;
        ProjectCurrencyCode = projectCurrencyCode;
        SlrOfficeClosestToProjectSiteLocationId = slrOfficeClosestToProjectSiteLocationId;
        FixedGeneralDisbursementPercentage = fixedGeneralDisbursementPercentage;
 
        SetUpdatedProperties(updatedBy);
    }
 
    public void UpdateProjectDetails(
        User updatedBy,
        string? name,
        int? clientId,
        int? sectorId,
        int? projectDirectorId,
        int? profitCentre,
        DateTime? estStart,
        DateTime? estCompletion,
        int? billingRateCard,
        int? fixedGeneralDisbursement,
        bool projectDirectorRevReq,
        DateTime? proposalDueDate
        )
    {
        if (ClientId != clientId)
        {
            ContractLocationId = null;
            SectorId = sectorId;
            SubSectorId = null;
        }
 
        Name = name;
        ClientId = clientId;
        ProjectDirectorId = projectDirectorId;
        ProfitCentreId = profitCentre;
        StartDate = estStart;
        CompletionDate = estCompletion;
        BillingRateCard = billingRateCard;
        ProjectDirectorRevReq = projectDirectorRevReq;
        ProposalDueDate = proposalDueDate;
        if (fixedGeneralDisbursement != null)
        {
            FixedGeneralDisbursementPercentage = fixedGeneralDisbursement.Value;
        }
 
        SetUpdatedProperties(updatedBy);
    }
 
    private void SetUpdatedProperties(User updatedBy)
    {
        UpdatedBy = updatedBy.Email;
        UpdatedOn = DateTime.UtcNow;
    }
}