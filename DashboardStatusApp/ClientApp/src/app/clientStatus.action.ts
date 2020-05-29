
import { createAction, props } from "@ngrx/store";
import { ClientStatus } from "./models/client-status";

export const GetClientStatusAction = createAction('[ClientStatus] - Get Clients Status ');

export const SuccessGetClientStatusAction = createAction('[ClientStatus] - Success Get Clients Status',  props<{ payload: ClientStatus[] }>());
export const ErrorGetClientAction = createAction('[GetClient] - Error', props<Error>());
