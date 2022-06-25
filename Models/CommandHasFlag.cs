namespace CommanderGQL.Models
{
    public class CommandHasFlag
    {
        public int CommandId { get; set; }
        public Command Command { get; set; }
        
        public int FlagId { get; set; }
        public Flag Flag { get; set; }
    }
}