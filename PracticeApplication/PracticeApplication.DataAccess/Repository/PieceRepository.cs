using MongoDB.Driver;
using PracticeApplication.DataAccess.Exceptions;
using PracticeApplication.DataAccess.Repository.Interface;
using PracticeApplication.DataAccess.Settings;
using PracticeApplication.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PracticeApplication.DataAccess.Repository
{
    public class PieceRepository : IPieceRepository
    {
        private readonly IMongoCollection<Piece> _pieces;

        public PieceRepository(IPracticeDatabaseSettings settings)
        {
            IMongoClient client = new MongoClient(settings.ConnectionString);
            IMongoDatabase db = client.GetDatabase(settings.DatabaseName);

            _pieces = db.GetCollection<Piece>(settings.PieceCollectionName);
        }

        public Piece GetPieceByTitle(string title)
        {
            Piece piece = _pieces.Find(p => p.Title == title).FirstOrDefault();
            return piece ?? throw new PieceNotFoundException($"No pieces found with title {title}.");
        }

        public List<Piece> GetPiecesByComposer(string id)
        {
            return _pieces.Find(p => p.ComposerId == id).ToList();
        }

        public List<Piece> GetAll()
        {
            return _pieces.Find(p => true).ToList();
        }

        public Piece GetById(string id)
        {
            return _pieces.Find(p => p.Id == id).FirstOrDefault();
        }

        public void Insert(Piece data)
        {
            _pieces.InsertOne(data);
        }

        public void Update(string id, Piece data)
        {
            _pieces.ReplaceOne(p => p.Id == id, data);
        }

        public void Delete(string id)
        {
            _pieces.DeleteOne(p => p.Id == id);
        }
    }
}
