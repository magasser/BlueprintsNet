using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlueprintsNet.Core.Models.Blueprints;

public class BPFor : BPFlowControlBase
{
    internal BPFor()
    {
        OutBody = new OutNode("Body");
        OutCompleted = new OutNode("Completed");
    }

    public override string DisplayName => BPNames.For;

    public override OutNode Out => OutBody;

    public OutNode OutBody { get; }

    public OutNode OutCompleted { get; }
}
