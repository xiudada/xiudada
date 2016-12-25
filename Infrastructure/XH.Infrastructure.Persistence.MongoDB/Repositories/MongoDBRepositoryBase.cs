using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using XH.Infrastructure.Domain.Models;
using XH.Infrastructure.Domain.Repositories;
using XH.Infrastructure.Exceptions;

namespace XH.Infrastructure.Persistence.MongoDb.Repositories
{
    public class MongoDbRepositoryBase<TEntity> : MongoDbRepositoryBase<TEntity, string>, IRepository<TEntity> where TEntity : class, IEntity<string>
    {
        public MongoDbRepositoryBase(IMongoDatabaseProvider databaseProvider) : base(databaseProvider)
        {
        }
    }

    public abstract class MongoDbRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey> where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual IMongoDatabase Database
        {
            get { return _databaseProvider.Database; }
        }

        public virtual IMongoCollection<TEntity> Collection
        {
            get
            {
                return _databaseProvider.Database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        private readonly IMongoDatabaseProvider _databaseProvider;

        public MongoDbRepositoryBase(IMongoDatabaseProvider databaseProvider)
        {
            _databaseProvider = databaseProvider;
        }

        public override IQueryable<TEntity> GetAll()
        {
            return Collection.AsQueryable();
        }

        public override TEntity Get(TPrimaryKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq(it => it.Id, id);

            // What will happen if id is not exist,does db return the first document ?
            var entity = Collection.Find(filter).FirstOrDefault();
            if (entity == null)
            {
                throw new EntityNotFoundException("There is no such an entity with given primary key. Entity type: " + typeof(TEntity).FullName + ", primary key: " + id);
            }

            return entity;
        }

        public override TEntity FirstOrDefault(TPrimaryKey id)
        {
            var filter = Builders<TEntity>.Filter.Eq(it => it.Id, id);

            // What will happen if id is not exist,does db return the first document ?
            return Collection.Find(filter).FirstOrDefault();
        }

        public override TEntity Insert(TEntity entity)
        {
            Collection.InsertOne(entity);
            return entity;
        }
        public override TEntity Update(TEntity entity)
        {
            Collection.ReplaceOne(Builders<TEntity>.Filter.Eq(it => it.Id, entity.Id), entity);
            return entity;
        }

        public override void Delete(TEntity entity)
        {
            Delete(entity.Id);
        }

        public override void Delete(TPrimaryKey id)
        {
            Collection.DeleteOne(Builders<TEntity>.Filter.Eq(it => it.Id, id));
        }
    }
}
