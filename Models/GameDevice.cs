namespace GamerCorner.Models
{
    public class GameDevice
    {
        public int GameId { get; set; }
        public Game Game { get; set; } = default!;

        public int DeciceId { get; set; }
        public Device Device { get; set; } = default!;

    }
}
