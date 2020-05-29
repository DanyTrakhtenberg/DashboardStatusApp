import { ClientStatus } from "./models/client-status";

export default class ClientStatusState {
  ClientsStatus: Array<ClientStatus>;
  Error: Error;
}

export const initializeState = (): ClientStatusState => {
  return { ClientsStatus: Array<ClientStatus>(), Error: null };
};
