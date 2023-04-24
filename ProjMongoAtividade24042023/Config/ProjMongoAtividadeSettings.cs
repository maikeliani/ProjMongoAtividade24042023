namespace ProjMongoAtividade24042023.Config
{
    public class ProjMongoAtividadeSettings : IProjMongoAtividadeSettings
    {
        public string ClientCollectionName { get; set; }
        public string AddressCollectionName { get; set; }
        public string CityCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName  { get; set; }
        }
}
