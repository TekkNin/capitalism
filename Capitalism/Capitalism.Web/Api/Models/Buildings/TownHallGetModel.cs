namespace Capitalism.Web.Api.Models.Buildings
{
    public class TownHallGetModel
    {
        public string TownName { get; set; }
        public int Population { get; set; }
        public long AccountBalance { get; set; }
        public int PollutionLevel { get; set; }
    }
}
