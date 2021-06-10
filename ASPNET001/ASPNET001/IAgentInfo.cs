using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNET001
{
    public interface IAgentInfo
    {
        public int AgentId { get; }
        public Uri AgentAddress { get; }
    }

    public class AgentInfo : IAgentInfo
    {
        public int AgentId { get; }
        public Uri AgentAddress { get; }
    }
}
