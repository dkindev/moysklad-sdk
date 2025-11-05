using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Api;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests
{
    public sealed class Pipeline : IAsyncDisposable
    {
        public static Pipeline Instance { get; private set; }

        #region Fields

        private List<ISampleEntity<MetaEntity>> _sampleEntities = new();

        #endregion Fields

        #region Properties

        public MoySkladApi Api { get; private set; }

        #endregion Properties

        #region Ctor

        private Pipeline()
        {
            var account = TestAccount.Create();

            Api = new MoySkladApi(
                new MoySkladCredentials()
                {
                    Username = account.Username,
                    Password = account.Password
                },
                new HttpClient(new HttpClientHandler()
                {
                    AutomaticDecompression = DecompressionMethods.GZip
                }, true)
            );
        }

        #endregion Ctor

        #region Methods

        public void AddSampleEntity<T>(T entity, Func<T, Task> clearAction = null)
            where T : MetaEntity
        {
            _sampleEntities.Add(new SampleEntity<T>(entity, clearAction));
        }

        public async Task<IEnumerable<TEntity>> CreateSampleEntitiesAsync<TEntity, TEntityBuilder, TEntitiesBuilder>(
            EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> api, Func<TEntity, Task> init = null, int count = 3, bool autoDelete = true)
            where TEntity : MetaEntity, new()
            where TEntityBuilder : ApiParameterBuilder, new()
            where TEntitiesBuilder : ApiParameterBuilder, new()
        {
            var samples = new List<TEntity>();

            TEntity sample = null;

            for (var i = 0; i < count; i++)
            {
                sample = new TEntity
                {
                    Name = $"Sample {typeof(TEntity).Name} {Guid.NewGuid()} {i}"
                };

                samples.Add(sample);

                if (init != null)
                    await init(sample);
            }

            var response = await api.CreateOrUpdateAsync(samples);
            var createdEntities = response.Payload;

            if (autoDelete)
            {
                AddSampleEntity(createdEntities[0], _ => api.DeleteAsync(createdEntities));

                for (var i = 1; i < createdEntities.Length; i++)
                    AddSampleEntity(createdEntities[i]);
            }

            return createdEntities;
        }

        public async Task<TEntity> CreateSampleEntityAsync<TEntity, TEntityBuilder, TEntitiesBuilder>(
            EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> api, Func<TEntity, Task> init = null, bool autoDelete = true)
            where TEntity : MetaEntity, new()
            where TEntityBuilder : ApiParameterBuilder, new()
            where TEntitiesBuilder : ApiParameterBuilder, new()
        {
            var sample = new TEntity
            {
                Name = $"Sample {typeof(TEntity).Name} {Guid.NewGuid()}",
            };

            if (init != null)
                await init(sample);

            var response = await api.CreateAsync(sample);
            var createdEntity = response.Payload;

            if (autoDelete)
                AddSampleEntity(createdEntity, entity => api.DeleteAsync(entity));

            return createdEntity;
        }

        public async Task<TEntity> GetOrCreateSampleEntityAsync<TEntity, TEntityBuilder, TEntitiesBuilder>(
            EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder> api, Func<TEntity, Task> init = null, bool autoDelete = true)
            where TEntity : MetaEntity, new()
            where TEntityBuilder : ApiParameterBuilder, new()
            where TEntitiesBuilder : ApiParameterBuilder, new()
        {
            var sample = _sampleEntities
                .OfType<ISampleEntity<TEntity>>()
                .FirstOrDefault();

            if (sample == null)
                return await CreateSampleEntityAsync(api, init, autoDelete);

            return sample.Entity;
        }

        public async ValueTask DisposeAsync()
        {
            var exceptions = new List<Exception>();

            _sampleEntities.Reverse();

            foreach (var sampleEntity in _sampleEntities)
            {
                try
                {
                    await sampleEntity.DisposeAsync();
                }
                catch (Exception ex)
                {
                    exceptions.Add(ex);
                }
            }

            Api.Dispose();
            Api = null;

            if (exceptions.Count > 0)
                throw new AggregateException(exceptions);
        }

        public async Task<Organization> GetDefaultOrganizationAsync()
        {
            var sample = _sampleEntities
                .OfType<ISampleEntity<Organization>>()
                .FirstOrDefault();

            if (sample == null)
            {
                var response = await Api.Entity.Organization.GetAllAsync(query => query.Limit(1));
                var entity = response.Payload.Rows.FirstOrDefault();

                AddSampleEntity(entity);

                return entity;
            }

            return sample.Entity;
        }

        #endregion Methods

        #region Helper classes

        private interface ISampleEntity<out T> : IAsyncDisposable where T : MetaEntity
        {
            public T Entity { get; }
        }

        [SetUpFixture]
        public class SetUp
        {
            #region Methods

            [OneTimeTearDown]
            public async Task RunAfterAnyTestsAsync()
            {
                if (Instance != null)
                    await Instance.DisposeAsync();
            }

            [OneTimeSetUp]
            public void RunBeforeAnyTests()
            {
                Instance = new Pipeline();
            }

            #endregion Methods
        }

        private class SampleEntity<T> : ISampleEntity<T> where T : MetaEntity
        {
            #region Fields

            private readonly Func<T, Task> _clearAction;

            #endregion Fields

            #region Properties

            public T Entity { get; }

            #endregion Properties

            #region Ctor

            public SampleEntity(T entity, Func<T, Task> clearAction = null)
            {
                Entity = entity;
                _clearAction = clearAction;
            }

            #endregion Ctor

            #region Methods

            public async ValueTask DisposeAsync()
            {
                if (_clearAction != null)
                    await _clearAction(Entity);
            }

            #endregion Methods
        }

        #endregion Helper classes
    }
}