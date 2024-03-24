namespace LavaMenu.WebEndpoint.Models
{
    public class ShowCateguryModel
    {

        public string CateguryId { get; set; }
        public string CateguryName { get; set; }

        public bool IsAvailable { get; set; } = true;

        public string SrcCategury { get; set; }
    }
}
