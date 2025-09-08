using System.Runtime.Serialization;

namespace Confiti.MoySklad.Remap.Entities
{
    /// <summary>
    /// Represents an entity type.
    /// </summary>
    public enum EntityType
    {
        /// <summary>
        /// AssortmentSettings entity type.
        /// </summary>
        [EnumMember(Value = "assortmentsettings")]
        AssortmentSettings,

        /// <summary>
        /// Employee entity type.
        /// </summary>
        [EnumMember(Value = "employee")]
        Employee,

        /// <summary>
        /// Contract entity type.
        /// </summary>
        [EnumMember(Value = "contract")]
        Contract,

        /// <summary>
        /// Counterparty entity type.
        /// </summary>
        [EnumMember(Value = "counterparty")]
        Counterparty,

        /// <summary>
        /// Organization entity type.
        /// </summary>
        [EnumMember(Value = "organization")]
        Organization,

        /// <summary>
        /// Group entity type.
        /// </summary>
        [EnumMember(Value = "group")]
        Group,

        /// <summary>
        /// Account entity type.
        /// </summary>
        [EnumMember(Value = "account")]
        Account,

        /// <summary>
        /// Demand entity type.
        /// </summary>
        [EnumMember(Value = "demand")]
        Demand,

        /// <summary>
        /// Store entity type.
        /// </summary>
        [EnumMember(Value = "store")]
        Store,

        /// <summary>
        /// Demand position entity type.
        /// </summary>
        [EnumMember(Value = "demandposition")]
        DemandPosition,

        /// <summary>
        /// Note entity type.
        /// </summary>
        [EnumMember(Value = "note")]
        Note,

        /// <summary>
        /// State entity type.
        /// </summary>
        [EnumMember(Value = "state")]
        State,

        /// <summary>
        /// Product entity type.
        /// </summary>
        [EnumMember(Value = "product")]
        Product,

        /// <summary>
        /// Service entity type.
        /// </summary>
        [EnumMember(Value = "service")]
        Service,

        /// <summary>
        /// Bundle entity type.
        /// </summary>
        [EnumMember(Value = "bundle")]
        Bundle,

        /// <summary>
        /// Bundle component entity type.
        /// </summary>
        [EnumMember(Value = "bundlecomponent")]
        BundleComponent,

        /// <summary>
        /// Currency entity type.
        /// </summary>
        [EnumMember(Value = "currency")]
        Currency,

        /// <summary>
        /// Uom entity type.
        /// </summary>
        [EnumMember(Value = "uom")]
        Uom,

        /// <summary>
        /// Product folder entity type.
        /// </summary>
        [EnumMember(Value = "productfolder")]
        ProductFolder,

        /// <summary>
        /// Supply position entity type.
        /// </summary>
        [EnumMember(Value = "supplyposition")]
        SupplyPosition,

        /// <summary>
        /// Country entity type.
        /// </summary>
        [EnumMember(Value = "country")]
        Country,

        /// <summary>
        /// Variant entity type.
        /// </summary>
        [EnumMember(Value = "variant")]
        Variant,

        /// <summary>
        /// Retail store entity type.
        /// </summary>
        [EnumMember(Value = "retailstore")]
        RetailStore,

        /// <summary>
        /// Retail shift entity type.
        /// </summary>
        [EnumMember(Value = "retailshift")]
        RetailShift,

        /// <summary>
        /// Retail demand entity type.
        /// </summary>
        [EnumMember(Value = "retaildemand")]
        RetailDemand,

        /// <summary>
        /// Retail drawer cash in entity type.
        /// </summary>
        [EnumMember(Value = "retaildrawercashin")]
        RetailDrawerCashIn,

        /// <summary>
        /// Retail drawer cash out entity type.
        /// </summary>
        [EnumMember(Value = "retaildrawercashout")]
        RetailDrawerCashOut,

        /// <summary>
        /// Retail sales return entity type.
        /// </summary>
        [EnumMember(Value = "retailsalesreturn")]
        RetailSalesReturn,

        /// <summary>
        /// Sales return entity type.
        /// </summary>
        [EnumMember(Value = "salesreturn")]
        SalesReturn,

        /// <summary>
        /// Sales return position entity type.
        /// </summary>
        [EnumMember(Value = "salesreturnposition")]
        SalesReturnPosition,

        /// <summary>
        /// Sales channelentity type.
        /// </summary>
        [EnumMember(Value = "saleschannel")]
        SalesChannel,

        /// <summary>
        /// Consignment entity type.
        /// </summary>
        [EnumMember(Value = "consignment")]
        Consignment,

        /// <summary>
        /// Move entity type.
        /// </summary>
        [EnumMember(Value = "move")]
        Move,

        /// <summary>
        /// Move position entity type.
        /// </summary>
        [EnumMember(Value = "moveposition")]
        MovePosition,

        /// <summary>
        /// Purchase return entity type.
        /// </summary>
        [EnumMember(Value = "purchasereturn")]
        PurchaseReturn,

        /// <summary>
        /// Purchase return position entity type.
        /// </summary>
        [EnumMember(Value = "purchasereturnposition")]
        PurchaseReturnPosition,

        /// <summary>
        /// Enter entity type.
        /// </summary>
        [EnumMember(Value = "enter")]
        Enter,

        /// <summary>
        /// Enter position entity type.
        /// </summary>
        [EnumMember(Value = "enterposition")]
        EnterPosition,

        /// <summary>
        /// Supply entity type.
        /// </summary>
        [EnumMember(Value = "supply")]
        Supply,

        /// <summary>
        /// Purchase order entity type.
        /// </summary>
        [EnumMember(Value = "purchaseorder")]
        PurchaseOrder,

        /// <summary>
        /// Purchase order position entity type.
        /// </summary>
        [EnumMember(Value = "purchaseorderposition")]
        PurchaseOrderPosition,

        /// <summary>
        /// Customer order entity type.
        /// </summary>
        [EnumMember(Value = "customerorder")]
        CustomerOrder,

        /// <summary>
        /// Customer order position entity type.
        /// </summary>
        [EnumMember(Value = "customerorderposition")]
        CustomerOrderPosition,

        /// <summary>
        /// Processing plan material entity type.
        /// </summary>
        [EnumMember(Value = "processingplanmaterial")]
        ProcessingPlanMaterial,

        /// <summary>
        /// Processing plan result entity type.
        /// </summary>
        [EnumMember(Value = "processingplanresult")]
        ProcessingPlanResult,

        /// <summary>
        /// Processing plan entity type.
        /// </summary>
        [EnumMember(Value = "processingplan")]
        ProcessingPlan,

        /// <summary>
        /// Processing order entity type.
        /// </summary>
        [EnumMember(Value = "processingorder")]
        ProcessingOrder,

        /// <summary>
        /// Processing order position entity type.
        /// </summary>
        [EnumMember(Value = "processingorderposition")]
        ProcessingOrderPosition,

        /// <summary>
        /// Processing entity type.
        /// </summary>
        [EnumMember(Value = "processing")]
        Processing,

        /// <summary>
        /// Processing position result entity type.
        /// </summary>
        [EnumMember(Value = "processingpositionresult")]
        ProcessingPositionResult,

        /// <summary>
        /// Processing position material entity type.
        /// </summary>
        [EnumMember(Value = "processingpositionmaterial")]
        ProcessingPositionMaterial,

        /// <summary>
        /// Expense item entity type.
        /// </summary>
        [EnumMember(Value = "expenseitem")]
        ExpenseItem,

        /// <summary>
        /// Cash in entity type.
        /// </summary>
        [EnumMember(Value = "cashin")]
        CashIn,

        /// <summary>
        /// Cash out entity type.
        /// </summary>
        [EnumMember(Value = "cashout")]
        CashOut,

        /// <summary>
        /// Payment in entity type.
        /// </summary>
        [EnumMember(Value = "paymentin")]
        PaymentIn,

        /// <summary>
        /// Payment out entity type.
        /// </summary>
        [EnumMember(Value = "paymentout")]
        PaymentOut,

        /// <summary>
        /// Project entity type.
        /// </summary>
        [EnumMember(Value = "project")]
        Project,

        /// <summary>
        /// Embedded template entity type.
        /// </summary>
        [EnumMember(Value = "embeddedtemplate")]
        EmbeddedTemplate,

        /// <summary>
        /// Custom template entity type.
        /// </summary>
        [EnumMember(Value = "customtemplate")]
        CustomTemplate,

        /// <summary>
        /// Attribute metadata entity type.
        /// </summary>
        [EnumMember(Value = "attributemetadata")]
        AttributeMetadata,

        /// <summary>
        /// Custom entity entity type.
        /// </summary>
        [EnumMember(Value = "customentity")]
        CustomEntity,

        /// <summary>
        /// Custom entity metadata entity type.
        /// </summary>
        [EnumMember(Value = "customentitymetadata")]
        CustomEntityMetadata,

        /// <summary>
        /// Personal discount entity type.
        /// </summary>
        [EnumMember(Value = "personaldiscount")]
        PersonalDiscount,

        /// <summary>
        /// Special price discount entity type.
        /// </summary>
        [EnumMember(Value = "specialpricediscount")]
        SpecialPriceDiscount,

        /// <summary>
        /// Discount entity type.
        /// </summary>
        [EnumMember(Value = "discount")]
        Discount,

        /// <summary>
        /// Round off discount entity type.
        /// </summary>
        [EnumMember(Value = "roundoffdiscount")]
        RoundOffDiscount,

        /// <summary>
        /// Bonus program entity type.
        /// </summary>
        [EnumMember(Value = "bonusprogram")]
        BonusProgram,

        /// <summary>
        /// Accumulation discount entity type.
        /// </summary>
        [EnumMember(Value = "accumulationdiscount")]
        AccumulationDiscount,

        /// <summary>
        /// Contact person entity type.
        /// </summary>
        [EnumMember(Value = "contactperson")]
        ContactPerson,

        /// <summary>
        /// Price type entity type.
        /// </summary>
        [EnumMember(Value = "pricetype")]
        PriceType,

        /// <summary>
        /// Invoice in entity type.
        /// </summary>
        [EnumMember(Value = "invoicein")]
        InvoiceIn,

        /// <summary>
        /// Invoice out entity type.
        /// </summary>
        [EnumMember(Value = "invoiceout")]
        InvoiceOut,

        /// <summary>
        /// Invoice position entity type.
        /// </summary>
        [EnumMember(Value = "invoiceposition")]
        InvoicePosition,

        /// <summary>
        /// Internal order entity type.
        /// </summary>
        [EnumMember(Value = "internalorder")]
        InternalOrder,

        /// <summary>
        /// Internal order position entity type.
        /// </summary>
        [EnumMember(Value = "internalorderposition")]
        InternalOrderPosition,

        /// <summary>
        /// Commission report in entity type.
        /// </summary>
        [EnumMember(Value = "commissionreportin")]
        CommissionReportIn,

        /// <summary>
        /// Commission report in position entity type.
        /// </summary>
        [EnumMember(Value = "commissionreportinposition")]
        CommissionReportInPosition,

        /// <summary>
        /// Commission report out entity type.
        /// </summary>
        [EnumMember(Value = "commissionreportout")]
        CommissionReportOut,

        /// <summary>
        /// Commission report out position entity type.
        /// </summary>
        [EnumMember(Value = "commissionreportoutposition")]
        CommissionReportOutPosition,

        /// <summary>
        /// Price list entity type.
        /// </summary>
        [EnumMember(Value = "pricelist")]
        PriceList,

        /// <summary>
        /// Price list row entity type.
        /// </summary>
        [EnumMember(Value = "pricelistrow")]
        PriceListRow,

        /// <summary>
        /// Facture in entity type.
        /// </summary>
        [EnumMember(Value = "facturein")]
        FactureIn,

        /// <summary>
        /// Facture out entity type.
        /// </summary>
        [EnumMember(Value = "factureout")]
        FactureOut,

        /// <summary>
        /// Task entity type.
        /// </summary>
        [EnumMember(Value = "task")]
        Task,

        /// <summary>
        /// Loss entity type.
        /// </summary>
        [EnumMember(Value = "loss")]
        Loss,

        /// <summary>
        /// Loss position entity type.
        /// </summary>
        [EnumMember(Value = "lossposition")]
        LossPosition,

        /// <summary>
        /// Inventory entity type.
        /// </summary>
        [EnumMember(Value = "inventory")]
        Inventory,

        /// <summary>
        /// Inventory position entity type.
        /// </summary>
        [EnumMember(Value = "inventoryposition")]
        InventoryPosition,

        /// <summary>
        /// Company settings entity type.
        /// </summary>
        [EnumMember(Value = "companysettings")]
        CompanySettings,

        /// <summary>
        /// Cashier entity type.
        /// </summary>
        [EnumMember(Value = "cashier")]
        Cashier,

        /// <summary>
        /// Tasknote entity type.
        /// </summary>
        [EnumMember(Value = "tasknote")]
        Tasknote,

        /// <summary>
        /// Image entity type.
        /// </summary>
        [EnumMember(Value = "image")]
        Image,

        /// <summary>
        /// Bonus transaction entity type.
        /// </summary>
        [EnumMember(Value = "bonustransaction")]
        BonusTransaction,

        /// <summary>
        /// Region entity type.
        /// </summary>
        [EnumMember(Value = "region")]
        Region,

        /// <summary>
        /// Assortment entity type.
        /// </summary>
        [EnumMember(Value = "assortment")]
        Assortment,

        /// <summary>
        /// Operation publication entity type.
        /// </summary>
        [EnumMember(Value = "operationpublication")]
        OperationPublication,

        /// <summary>
        /// Contract publication entity type.
        /// </summary>
        [EnumMember(Value = "contractpublication")]
        ContractPublication,

        /// <summary>
        /// Notification entity type.
        /// </summary>
        [EnumMember(Value = "notification")]
        Notification,

        /// <summary>
        /// Notification order new entity type.
        /// </summary>
        [EnumMember(Value = "NotificationOrderNew")]
        NotificationOrderNew,

        /// <summary>
        /// Notification order overdue entity type.
        /// </summary>
        [EnumMember(Value = "NotificationOrderOverdue")]
        NotificationOrderOverdue,

        /// <summary>
        /// Notification invoice out overdue entity type.
        /// </summary>
        [EnumMember(Value = "NotificationInvoiceOutOverdue")]
        NotificationInvoiceOutOverdue,

        /// <summary>
        /// Notification good count too low entity type.
        /// </summary>
        [EnumMember(Value = "NotificationGoodCountTooLow")]
        NotificationGoodCountTooLow,

        /// <summary>
        /// Notification task assigned entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskAssigned")]
        NotificationTaskAssigned,

        /// <summary>
        /// Notification task unassigned entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskUnassigned")]
        NotificationTaskUnassigned,

        /// <summary>
        /// Notification task overdue entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskOverdue")]
        NotificationTaskOverdue,

        /// <summary>
        /// Notification task completed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskCompleted")]
        NotificationTaskCompleted,

        /// <summary>
        /// Notification task reopened entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskReopened")]
        NotificationTaskReopened,

        /// <summary>
        /// Notification task new comment entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskNewComment")]
        NotificationTaskNewComment,

        /// <summary>
        /// Notification task changed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskChanged")]
        NotificationTaskChanged,

        /// <summary>
        /// Notification task deleted entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskDeleted")]
        NotificationTaskDeleted,

        /// <summary>
        /// Notification task comment deleted entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskCommentDeleted")]
        NotificationTaskCommentDeleted,

        /// <summary>
        /// Notification task comment changed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationTaskCommentChanged")]
        NotificationTaskCommentChanged,

        /// <summary>
        /// Notification import completed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationImportCompleted")]
        NotificationImportCompleted,

        /// <summary>
        /// Notification export completed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationExportCompleted")]
        NotificationExportCompleted,

        /// <summary>
        /// Notification subscribe expired entity type.
        /// </summary>
        [EnumMember(Value = "NotificationSubscribeExpired")]
        NotificationSubscribeExpired,

        /// <summary>
        /// Notification subscribe terms expired entity type.
        /// </summary>
        [EnumMember(Value = "NotificationSubscribeTermsExpired")]
        NotificationSubscribeTermsExpired,

        /// <summary>
        /// Notification retail shift opened entity type.
        /// </summary>
        [EnumMember(Value = "NotificationRetailShiftOpened")]
        NotificationRetailShiftOpened,

        /// <summary>
        /// Notification retail shift closed entity type.
        /// </summary>
        [EnumMember(Value = "NotificationRetailShiftClosed")]
        NotificationRetailShiftClosed,

        /// <summary>
        /// Webhook entity type.
        /// </summary>
        [EnumMember(Value = "webhook")]
        Webhook,

        /// <summary>
        /// Receipt template entity type.
        /// </summary>
        [EnumMember(Value = "receipttemplate")]
        ReceiptTemplate,

        /// <summary>
        /// Prepayment entity type.
        /// </summary>
        [EnumMember(Value = "prepayment")]
        Prepayment,

        /// <summary>
        /// Prepayment return entity type.
        /// </summary>
        [EnumMember(Value = "prepaymentreturn")]
        PrepaymentReturn,

        /// <summary>
        /// Prepayment position entity type.
        /// </summary>
        [EnumMember(Value = "prepaymentposition")]
        PrepaymentPosition,

        /// <summary>
        /// Prepayment return position entity type.
        /// </summary>
        [EnumMember(Value = "prepaymentreturnposition")]
        PrepaymentReturnPosition,

        /// <summary>
        /// Application entity type.
        /// </summary>
        [EnumMember(Value = "application")]
        Application,

        /// <summary>
        /// SalesByProduct entity type.
        /// </summary>
        [EnumMember(Value = "salesbyproduct")]
        SalesByProduct,

        /// <summary>
        /// SalesByVariant entity type.
        /// </summary>
        [EnumMember(Value = "salesbyvariant")]
        SalesByVariant,

        /// <summary>
        /// SalesByEmployee entity type.
        /// </summary>
        [EnumMember(Value = "salesbyemployee")]
        SalesByEmployee,

        /// <summary>
        /// SalesByCounterparty entity type.
        /// </summary>
        [EnumMember(Value = "salesbyCounterparty")]
        SalesByCounterparty,

        /// <summary>
        /// SalesBySalesChannel entity type.
        /// </summary>
        [EnumMember(Value = "salesbysaleschannel")]
        SalesBySalesChannel,
    }
}