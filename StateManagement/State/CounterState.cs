using Fluxor;

namespace StateManagement.State;

[FeatureState]
public record CounterState
{
    public int Count { get; init; }
}
