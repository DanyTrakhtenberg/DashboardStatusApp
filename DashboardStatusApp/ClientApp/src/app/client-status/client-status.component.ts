import { ClientType } from "./../models/client-type";
import { Observable } from "rxjs";
import { Component, OnInit, Input } from "@angular/core";
import { Store, select } from "@ngrx/store";
import ClientStatusState from "../clientStatus.state";
import * as ClientStatusActions from "./../clientStatus.action";
import { ClientStatus } from "../models/client-status";
import { map } from "rxjs/operators";

@Component({
  selector: "app-client-status",
  templateUrl: "./client-status.component.html",
  styleUrls: ["./client-status.component.css"],
})
export class ClientStatusComponent implements OnInit {
  @Input("client") client: ClientStatus;

  clientsStatusState$: Observable<ClientStatusState>;
  clientsStatus$: Observable<ClientStatus[]>;
  constructor() {}

  ngOnInit() {}
}
