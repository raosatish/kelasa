
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

public class KelasaRepository : IKelasaRepository
{
     private readonly IMongoCollection<Kelasa> _kelasaCollection;
    public KelasaRepository(IOptions<KelasaDatabaseSettings> kelasaDatabaseSettings, IMongoClient client)
    {
        var database = client.GetDatabase(kelasaDatabaseSettings.Value.DatabaseName);
        _kelasaCollection = database.GetCollection<Kelasa>(kelasaDatabaseSettings.Value.KelasaCollectionName);
    }
    public async Task<Kelasa> Create(Kelasa newKelasa)
    {
        newKelasa.Id = ObjectId.GenerateNewId().ToString();
        await _kelasaCollection.InsertOneAsync(newKelasa);
        return newKelasa;
    }

    public async Task<bool> Delete(string deleteKelasaID)
    {
         var result = await _kelasaCollection.DeleteOneAsync(d => d.Id == deleteKelasaID);
         if(result.DeletedCount > 0){
            return true;
         }
         return false;
    }

    public async Task<IEnumerable<Kelasa>> GetAllKelasa()
    {
        return await _kelasaCollection.Find(s => true).ToListAsync(); 
    }

    public async Task<Kelasa> GetKelasa(string id)
    {
         return await _kelasaCollection.Find(s => s.Id == id).FirstOrDefaultAsync();
    }
}
