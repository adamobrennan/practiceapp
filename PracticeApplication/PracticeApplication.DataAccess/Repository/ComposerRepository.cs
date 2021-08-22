using MongoDB.Driver;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.DataAccess.Settings;
using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Repository
{
    public class ComposerRepository : IComposerRepository
    {
        private readonly IMongoCollection<Composer> _composers;

        public ComposerRepository(IPracticeDatabaseSettings settings)
        {
            IMongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase db = client.GetDatabase(settings.DatabaseName);

            _composers = db.GetCollection<Composer>(settings.ComposerCollectionName);
        }
        public List<Composer> GetAll()
        {
            return _composers.Find(c => true).ToList();
        }

        public Composer GetById(string id)
        {
            return _composers.Find(c => c.Id == id).FirstOrDefault();
        }

        public List<Composer> GetComposerByLastName(string name)
        {
            return _composers.Find(c => c.LastName == name).ToList();
        }

        public string Insert(Composer data)
        {
            _composers.InsertOne(data);
            return data.Id;
        }

        public void Update(string id, Composer data)
        {
            _composers.ReplaceOne(c => c.Id == id, data);
        }

        public void Delete(string id)
        {
            _composers.DeleteOne(c => c.Id == id);
        }
    }
}
