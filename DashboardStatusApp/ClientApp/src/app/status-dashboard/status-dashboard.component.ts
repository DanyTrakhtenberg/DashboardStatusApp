import { Component, OnInit } from "@angular/core";
import { ClientType } from "./../models/client-type";
import { Observable } from "rxjs";
import { Store, select } from "@ngrx/store";
import ClientStatusState from "../clientStatus.state";
import * as ClientStatusActions from "./../clientStatus.action";
import { ClientStatus } from "../models/client-status";
import { map } from "rxjs/operators";

@Component({
  selector: "app-status-dashboard",
  templateUrl: "./status-dashboard.component.html",
  styleUrls: ["./status-dashboard.component.css"],
})
export class StatusDashboardComponent implements OnInit {
  clientsStatusState$: Observable<ClientStatusState>;
  clientsStatus$: Observable<ClientStatus[]>;
  constructor(private store: Store<{ clientsStatus: ClientStatusState }>) {
    this.clientsStatusState$ = store.pipe(select("clientsStatus"));
  }
  ngOnInit() {
    this.store.dispatch(ClientStatusActions.GetClientStatusAction());
    this.clientsStatus$ = this.clientsStatusState$.pipe(
      map((x) => {
        return x.ClientsStatus;
      })
    );
  }
}
