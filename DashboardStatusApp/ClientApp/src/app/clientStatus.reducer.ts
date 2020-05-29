import { Action, createReducer, on } from "@ngrx/store";
import * as ClientStatusActions from "./clientStatus.action";
import ClientStatusState, { initializeState } from "./clientStatus.state";

const initialState = initializeState();

const reducer = createReducer(
  initialState,
  on(ClientStatusActions.GetClientStatusAction, (state) => state),

  on(
    ClientStatusActions.SuccessGetClientStatusAction,
    (state: ClientStatusState, { payload }) => {
      return { ...state, ClientsStatus: payload, Error: null };
    }
  ),
  on(ClientStatusActions.ErrorGetClientAction, (state: ClientStatusState, error: Error) => {
    console.error(error);
    return { ...state, Error: error };
  })
);

export function ClientStatusReducer(
  state: ClientStatusState | undefined,
  action: Action
): ClientStatusState {
  return reducer(state, action);
}
