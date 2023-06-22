/// <summary>
/// Аргументы для метода класса CreatorElementGallery.
/// </summary>
public class ArgsCreatorElementGallery
{
    public CreatorButton CreatorButton;
    public AdminLevel AdminLevel;
    public Game Client;

    public ArgsCreatorElementGallery(Game client,AdminLevel adminLevel,CreatorButton creatorButton) 
    {
        Client = client;
        AdminLevel = adminLevel;
        CreatorButton = creatorButton;
    }
}