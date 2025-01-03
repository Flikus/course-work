class FabricGame
{
    public Game CreateGame (string nameGame, int rating) {
        switch(nameGame)
        {
        case "Standart": return new StandartGame("standart", rating);
        case "Onerisk" : return new OneriskGame("onerisk", rating);
        case "Training": return new TrainingGame("training");
        default        : Console.Write("\nПомилка: такого типу гри не існує\n\n"); return null;           
        }
    }
}