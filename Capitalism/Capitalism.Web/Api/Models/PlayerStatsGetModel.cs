namespace Capitalism.Web.Api.Models
{
    public class PlayerStatsGetModel
    {
        public string Id { get; set; }
        public int Health { get; set; }
        public int Energy { get; set; }
        public int Happiness { get; set; }
        public int Swagger { get; set; }
        public long MoneyOnHand { get; set; }
    }
}
