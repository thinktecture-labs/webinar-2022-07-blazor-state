using Fluxor;

namespace StateManagement.State;

public record IncrementAction(int Value = 1);

public partial class CounterStateReducers
{
    [ReducerMethod]
    public static CounterState Reduce(CounterState state, IncrementAction action)
        => state with { Count = state.Count + action.Value, };
}
