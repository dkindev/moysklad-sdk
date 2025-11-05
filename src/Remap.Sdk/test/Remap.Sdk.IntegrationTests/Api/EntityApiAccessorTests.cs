using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Confiti.MoySklad.Remap.Client;
using Confiti.MoySklad.Remap.Entities;
using Confiti.MoySklad.Remap.Queries;
using FluentAssertions;
using NUnit.Framework;

namespace Confiti.MoySklad.Remap.IntegrationTests.Api
{
    public abstract class EntityApiAccessorTests<TApi, TEntity, TEntityBuilder, TEntitiesBuilder>
        where TApi : EntityApiAccessor<TEntity, TEntityBuilder, TEntitiesBuilder>
        where TEntity : MetaEntity, new()
        where TEntityBuilder : ApiParameterBuilder, new()
        where TEntitiesBuilder : ApiParameterBuilder, new()
    {
        #region Fields

        protected readonly TApi _subject;
        private readonly Func<TEntity, Task> _initSampleEntity;

        #endregion Fields

        #region Ctor

        public EntityApiAccessorTests(TApi api, Func<TEntity, Task> initSampleEntity = null)
        {
            _subject = api;
            _initSampleEntity = initSampleEntity;
        }

        #endregion Ctor

        #region Methods

        [Test]
        public async Task CreateAsync_should_return_status_code_200()
        {
            var sample = new TEntity
            {
                Name = $"Sample {typeof(TEntity).Name} {Guid.NewGuid()}"
            };

            if (_initSampleEntity != null)
                await _initSampleEntity(sample);

            TEntity createdEntity = null;

            var response = await _subject.CreateAsync(sample);

            Pipeline.Instance.AddSampleEntity(response.Payload, entity => _subject.DeleteAsync(entity));

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);

            createdEntity = response.Payload;
            createdEntity.Should().NotBeNull();
            createdEntity.Name.Should().Be(sample.Name);
        }

        [Test]
        public async Task CreateOrUpdateAsync_should_return_status_code_200()
        {
            var samplesCount = 3;
            var samples = new List<TEntity>();

            TEntity sample = null;

            for (var i = 0; i < samplesCount; i++)
            {
                sample = new TEntity
                {
                    Name = $"Sample {typeof(TEntity).Name} {Guid.NewGuid()} {i}"
                };

                samples.Add(sample);

                if (_initSampleEntity != null)
                    await _initSampleEntity(sample);
            }

            TEntity[] createdEntities = null;

            var response = await _subject.CreateOrUpdateAsync(samples);

            createdEntities = response.Payload;

            Pipeline.Instance.AddSampleEntity(createdEntities[0], _ => _subject.DeleteAsync(createdEntities));

            for (var i = 1; i < createdEntities.Length; i++)
                Pipeline.Instance.AddSampleEntity(createdEntities[i]);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            createdEntities.Should().NotBeNull();
            createdEntities
                .All(newEntity => samples.Any(sample => sample.Name.Equals(newEntity.Name)))
                .Should()
                .BeTrue();
        }

        [Test]
        public async Task CreateOrUpdateAsync_with_updated_entities_should_return_status_code_200()
        {
            var samples = await Pipeline.Instance.CreateSampleEntitiesAsync(_subject, _initSampleEntity);

            foreach (var sample in samples)
                sample.Name = $"{sample.Name} (Updated)";

            var response = await _subject.CreateOrUpdateAsync(samples);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull();
            response.Payload
                .All(updatedEntity => samples.Any(product => product.Name.Equals(updatedEntity.Name)))
                .Should()
                .BeTrue();
        }

        [Test]
        public async Task DeleteAsync_should_return_status_code_200()
        {
            var sample = await Pipeline.Instance.CreateSampleEntityAsync(_subject, _initSampleEntity, autoDelete: false);
            var response = await _subject.DeleteAsync(sample);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task DeleteAsync_with_entities_should_return_status_code_200()
        {
            var samples = await Pipeline.Instance.CreateSampleEntitiesAsync(_subject, _initSampleEntity, autoDelete: false);
            var response = await _subject.DeleteAsync(samples);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAllAsync_should_return_status_code_200()
        {
            var response = await _subject.GetAllAsync();

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
        }

        [Test]
        public async Task GetAsync_should_return_status_code_200()
        {
            var sample = await Pipeline.Instance.GetOrCreateSampleEntityAsync(_subject, _initSampleEntity);
            var response = await _subject.GetAsync(sample.Id.Value);

            response.Should().NotBeNull();
            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull();
            response.Payload.Id.Should().Be(sample.Id.Value);
        }

        [Test]
        public async Task UpdateAsync_should_return_status_code_200()
        {
            var sample = await Pipeline.Instance.CreateSampleEntityAsync(_subject, _initSampleEntity);
            sample.Name = $"{sample.Name} (Updated)";

            var response = await _subject.UpdateAsync(sample);

            response.StatusCode.Should().Be(200);
            response.Payload.Should().NotBeNull();
            response.Payload.Name.Should().Be(sample.Name);
        }

        #endregion Methods
    }
}