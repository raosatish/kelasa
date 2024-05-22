public interface IKelasaRepository{
    Task<Kelasa> GetKelasa(string id);
    Task<IEnumerable<Kelasa>> GetAllKelasa();
    Task<Kelasa> Create(Kelasa newKelasa);
    Task<bool> Delete(string deleteKelasaID);
}