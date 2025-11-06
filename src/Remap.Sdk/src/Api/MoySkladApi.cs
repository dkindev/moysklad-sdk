using System;
using System.Collections.Concurrent;
using System.Net;
using System.Net.Http;
using Confiti.MoySklad.Remap.Client;

namespace Confiti.MoySklad.Remap.Api
{
    /// <summary>
    /// Represents the API to interact with the MoySklad endpoints.
    /// </summary>
    public class MoySkladApi : IDisposable
    {
        #region Fields

        private readonly ConcurrentDictionary<RuntimeTypeHandle, ApiAccessor> _apiAccessors;
        private HttpClient _client;
        private MoySkladCredentials _credentials;
        private bool _isDisposed;
        private bool _useCustomHttpClient = false;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the <see cref="HttpClient"/>.
        /// </summary>
        public HttpClient Client
        {
            get
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(nameof(MoySkladApi));

                return _client;
            }
            set
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(nameof(MoySkladApi));

                if (!_useCustomHttpClient)
                {
                    DisposeDefaultHttpClient();
                    _useCustomHttpClient = true;
                }

                _client = value;

                foreach (var api in _apiAccessors.Values)
                {
                    api.Client = value;

                    if (api is IHasImageApi hasImageApi)
                        hasImageApi.Images.Client = value;

                    if (api is IHasMetadataApi<ApiAccessor> hasMetaDataApi)
                        hasMetaDataApi.Metadata.Client = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="MoySkladCredentials"/>.
        /// </summary>
        public MoySkladCredentials Credentials
        {
            get
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(nameof(MoySkladApi));

                return _credentials;
            }
            set
            {
                if (_isDisposed)
                    throw new ObjectDisposedException(nameof(MoySkladApi));

                _credentials = value;

                foreach (var api in _apiAccessors.Values)
                {
                    api.Credentials = value;

                    if (api is IHasImageApi hasImageApi)
                        hasImageApi.Images.Credentials = value;

                    if (api is IHasMetadataApi<ApiAccessor> hasMetaDataApi)
                        hasMetaDataApi.Metadata.Credentials = value;
                }
            }
        }

        /// <summary>
        /// Gets the API to interact with MoySklad '/entity' endpoint.
        /// </summary>
        public EntityEndpoint Entity { get; }

        /// <summary>
        /// Gets the API to interact with MoySklad '/report' endpoint.
        /// </summary>
        public ReportEndpoint Report { get; }

        /// <summary>
        /// Gets the API to interact with MoySklad '/report' endpoint.
        /// </summary>
        public SecurityEndpoint Security { get; }

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="MoySkladApi" /> class
        /// with MoySklad credentials (optional) and the HTTP client (use defaults if not specified).
        /// </summary>
        /// <param name="credentials">The MoySklad credentials.</param>
        /// <param name="httpClient">The HTTP client (if specified, then the HTTP client should be disposed manually).</param>
        public MoySkladApi(MoySkladCredentials credentials = null, HttpClient httpClient = null)
        {
            _credentials = credentials;
            _apiAccessors = new ConcurrentDictionary<RuntimeTypeHandle, ApiAccessor>();
            _useCustomHttpClient = httpClient != null;
            _client = httpClient ??
                new HttpClient(
                    new HttpClientHandler()
                    {
                        AutomaticDecompression = DecompressionMethods.GZip
                    },
                    true
                );

            Entity = new EntityEndpoint(GetApi);
            Report = new ReportEndpoint(GetApi);
            Security = new SecurityEndpoint(GetApi);
        }

        #endregion Ctor

        #region Methods

        /// <inheritdoc/>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting
        /// unmanaged resources.
        /// </summary>
        /// <param name="disposing">A value indicating whether to the managed resources must be disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_isDisposed)
            {
                _isDisposed = true;

                if (disposing && !_useCustomHttpClient)
                    DisposeDefaultHttpClient();
            }
        }

        /// <summary>
        /// Gets the instance of the specific <see cref="ApiAccessor"/> class.
        /// </summary>
        /// <param name="apiAccessorType">The type of the specific <see cref="ApiAccessor"/>.</param>
        /// <returns>The instance of the specific <see cref="ApiAccessor"/> class.</returns>
        /// <exception cref="ObjectDisposedException">Throws if object was disposed.</exception>
        protected virtual ApiAccessor GetApi(Type apiAccessorType)
        {
            if (_isDisposed)
                throw new ObjectDisposedException(nameof(MoySkladApi));

            return _apiAccessors.GetOrAdd(
                apiAccessorType.TypeHandle,
                typeHandle => (ApiAccessor)Activator.CreateInstance(Type.GetTypeFromHandle(typeHandle), _client, _credentials)
            );
        }

        #endregion Methods

        #region Utilities

        private void DisposeDefaultHttpClient()
        {
            _client?.Dispose();
            _client = null;
        }

        #endregion Utilities
    }

    #region Endpoints

    /// <summary>
    /// Represents an abstraction to interact with MoySklad endpoint.
    /// </summary>
    public abstract class Endpoint
    {
        #region Fields

        private readonly Func<Type, ApiAccessor> _apiAccessorFactory;

        #endregion Fields

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="Endpoint" /> class with <see cref="ApiAccessor"/> factory.
        /// </summary>
        /// <param name="apiAccessorFactory">The factory to create the instance of the specific <see cref="ApiAccessor"/> class.</param>
        internal Endpoint(Func<Type, ApiAccessor> apiAccessorFactory)
        {
            _apiAccessorFactory = apiAccessorFactory;
        }

        #endregion Ctor

        #region Methods

        /// <summary>
        /// Gets the instance of <typeparamref name="TApi"/> class.
        /// </summary>
        /// <typeparam name="TApi">The type of the <see cref="ApiAccessor"/>.</typeparam>
        /// <returns>The instance of <typeparamref name="TApi"/> class.</returns>
        protected virtual TApi GetApi<TApi>() where TApi : ApiAccessor
        {
            return (TApi)_apiAccessorFactory(typeof(TApi));
        }

        #endregion Methods
    }

    /// <summary>
    /// Represents an API to interact with MoySklad '/entity' endpoint.
    /// </summary>
    public class EntityEndpoint : Endpoint
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="AssortmentApi"/>.
        /// </summary>
        public AssortmentApi Assortment => GetApi<AssortmentApi>();

        /// <summary>
        /// Gets the <see cref="BundleApi"/>.
        /// </summary>
        public BundleApi Bundle => GetApi<BundleApi>();

        /// <summary>
        /// Gets the <see cref="CounterpartyApi"/>.
        /// </summary>
        public CounterpartyApi Counterparty => GetApi<CounterpartyApi>();

        /// <summary>
        /// Gets the <see cref="CustomerOrderApi"/>.
        /// </summary>
        public CustomerOrderApi CustomerOrder => GetApi<CustomerOrderApi>();

        /// <summary>
        /// Gets the <see cref="DemandApi"/>.
        /// </summary>
        public DemandApi Demand => GetApi<DemandApi>();

        /// <summary>
        /// Gets the <see cref="EnterApi"/>.
        /// </summary>
        public EnterApi Enter => GetApi<EnterApi>();

        /// <summary>
        /// Gets the <see cref="ExpenseItemApi"/>.
        /// </summary>
        public ExpenseItemApi ExpenseItem => GetApi<ExpenseItemApi>();

        /// <summary>
        /// Gets the <see cref="InvoiceOutApi"/>.
        /// </summary>
        public InvoiceOutApi InvoiceOut => GetApi<InvoiceOutApi>();

        /// <summary>
        /// Gets the <see cref="LossApi"/>.
        /// </summary>
        public LossApi Loss => GetApi<LossApi>();

        /// <summary>
        /// Gets the <see cref="MoveApi"/>.
        /// </summary>
        public MoveApi Move => GetApi<MoveApi>();

        /// <summary>
        /// Gets the <see cref="OrganizationApi"/>.
        /// </summary>
        public OrganizationApi Organization => GetApi<OrganizationApi>();

        /// <summary>
        /// Gets the <see cref="PaymentInApi"/>.
        /// </summary>
        public PaymentInApi PaymentIn => GetApi<PaymentInApi>();

        /// <summary>
        /// Gets the <see cref="PaymentOutApi"/>.
        /// </summary>
        public PaymentOutApi PaymentOut => GetApi<PaymentOutApi>();

        /// <summary>
        /// Gets the <see cref="PriceTypeApi"/>.
        /// </summary>
        public PriceTypeApi PriceType => GetApi<PriceTypeApi>();

        /// <summary>
        /// Gets the <see cref="ProductApi"/>.
        /// </summary>
        public ProductApi Product => GetApi<ProductApi>();

        /// <summary>
        /// Gets the <see cref="ProductFolderApi"/>.
        /// </summary>
        public ProductFolderApi ProductFolder => GetApi<ProductFolderApi>();

        /// <summary>
        /// Gets the <see cref="ProjectApi"/>.
        /// </summary>
        public ProjectApi Project => GetApi<ProjectApi>();

        /// <summary>
        /// Gets the <see cref="PurchaseReturnApi"/>.
        /// </summary>
        public PurchaseReturnApi PurchaseReturn => GetApi<PurchaseReturnApi>();

        /// <summary>
        /// Gets the <see cref="RetailDemandApi"/>.
        /// </summary>
        public RetailDemandApi RetailDemand => GetApi<RetailDemandApi>();

        /// <summary>
        /// Gets the <see cref="RetailSalesReturnApi"/>.
        /// </summary>
        public RetailSalesReturnApi RetailSalesReturn => GetApi<RetailSalesReturnApi>();

        /// <summary>
        /// Gets the <see cref="RetailShiftApi"/>.
        /// </summary>
        public RetailShiftApi RetailShift => GetApi<RetailShiftApi>();

        /// <summary>
        /// Gets the <see cref="SalesChannelApi"/>.
        /// </summary>
        public SalesChannelApi SalesChannel => GetApi<SalesChannelApi>();

        /// <summary>
        /// Gets the <see cref="SalesReturnApi"/>.
        /// </summary>
        public SalesReturnApi SalesReturn => GetApi<SalesReturnApi>();

        /// <summary>
        /// Gets the <see cref="ServiceApi"/>.
        /// </summary>
        public ServiceApi Service => GetApi<ServiceApi>();

        /// <summary>
        /// Gets the <see cref="StoreApi"/>.
        /// </summary>
        public StoreApi Store => GetApi<StoreApi>();

        /// <summary>
        /// Gets the <see cref="SupplyApi"/>.
        /// </summary>
        public SupplyApi Supply => GetApi<SupplyApi>();

        /// <summary>
        /// Gets the <see cref="TaskApi"/>.
        /// </summary>
        public TaskApi Task => GetApi<TaskApi>();

        /// <summary>
        /// Gets the <see cref="VariantApi"/>.
        /// </summary>
        public VariantApi Variant => GetApi<VariantApi>();

        /// <summary>
        /// Gets the <see cref="WebHookApi"/>.
        /// </summary>
        public WebHookApi WebHook => GetApi<WebHookApi>();

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="EntityEndpoint" /> class with <see cref="ApiAccessor"/> factory.
        /// </summary>
        /// <param name="apiAccessorFactory">The factory to create the instance of the specific <see cref="ApiAccessor"/> class.</param>
        internal EntityEndpoint(Func<Type, ApiAccessor> apiAccessorFactory)
            : base(apiAccessorFactory)
        {
        }

        #endregion Ctor
    }

    /// <summary>
    /// Represents an API to interact with MoySklad '/report' endpoint.
    /// </summary>
    public class ReportEndpoint : Endpoint
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="ProfitReportApi"/>.
        /// </summary>
        public ProfitReportApi Profit => GetApi<ProfitReportApi>();

        /// <summary>
        /// Gets the <see cref="StockReportApi"/>.
        /// </summary>
        public StockReportApi Stock => GetApi<StockReportApi>();

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="ReportEndpoint" /> class with <see cref="ApiAccessor"/> factory.
        /// </summary>
        /// <param name="apiAccessorFactory">The factory to create the instance of the specific <see cref="ApiAccessor"/> class.</param>
        internal ReportEndpoint(Func<Type, ApiAccessor> apiAccessorFactory)
            : base(apiAccessorFactory)
        {
        }

        #endregion Ctor
    }

    /// <summary>
    /// Represents an API to interact with MoySklad '/security' endpoint.
    /// </summary>
    public class SecurityEndpoint : Endpoint
    {
        #region Properties

        /// <summary>
        /// Gets the <see cref="TokenApi"/>.
        /// </summary>
        public TokenApi Token => GetApi<TokenApi>();

        #endregion Properties

        #region Ctor

        /// <summary>
        /// Creates a new instance of the <see cref="SecurityEndpoint" /> class with <see cref="ApiAccessor"/> factory.
        /// </summary>
        /// <param name="apiAccessorFactory">The factory to create the instance of the specific <see cref="ApiAccessor"/> class.</param>
        internal SecurityEndpoint(Func<Type, ApiAccessor> apiAccessorFactory)
            : base(apiAccessorFactory)
        {
        }

        #endregion Ctor
    }

    #endregion Endpoints
}