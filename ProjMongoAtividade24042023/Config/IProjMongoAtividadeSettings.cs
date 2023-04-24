namespace ProjMongoAtividade24042023.Config
{
    public interface IProjMongoAtividadeSettings
    {
        public string ClientCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
