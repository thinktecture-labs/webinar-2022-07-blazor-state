using Fluxor;

namespace StateManagement.State;

public record DecrementAction(int Value = 1);

public partial class CounterStateReducers
{
    [ReducerMethod]
    public static CounterState Reduce(CounterState state, DecrementAction action)
        => state with { Count = state.Count - action.Value, };
}
