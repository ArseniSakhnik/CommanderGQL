using System.Collections.Generic;

namespace CommanderGQL.Models
{
    public class Flag
    {
        public int Id { get; set; }
        public string Text { get; set; }
        
        public ICollection<CommandHasFlag> CommandHasFlags { get; set; }
    }
}