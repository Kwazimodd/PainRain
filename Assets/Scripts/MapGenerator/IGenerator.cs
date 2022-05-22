public interface IGenerator
{
    public UnityEngine.Tilemaps.Tilemap TopTilemap { get; set; }
    public UnityEngine.Tilemaps.Tilemap BotTilemap { get; set; }
    public IBiom GetBiom();
    public void GenerateGrass();
    public void GenerateStuff();
}

