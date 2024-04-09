namespace PeaksAndAdventures.Core.Models.QueryModels.Hut
{
    public class HutQueryServiceModel
    {
        public int TotalHuts { get; set; }

        public IEnumerable<HutServiceModel> Huts { get; set; } = new List<HutServiceModel>();
    }
}
