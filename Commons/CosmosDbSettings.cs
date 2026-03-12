namespace Commons;

public class CosmosDbSettings
{
    public string Account { get; set; } = "";
    public string Key { get; set; } = "";
    public string DatabaseName { get; set; } = "";
    public string ContainerMasterData { get; set; } = ""; // nama container untuk Pengguna
}