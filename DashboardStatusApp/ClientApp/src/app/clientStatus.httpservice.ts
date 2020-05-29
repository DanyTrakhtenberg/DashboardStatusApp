import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { ClientStatus } from "./models/client-status";
import { Observable } from "rxjs/internal/Observable";
import { interval, timer } from "rxjs";
import { switchMap } from "rxjs/operators";


@Injectable({
  providedIn: "root",
})
export class ClientStatusHttpService {
  private readonly MILI_SECONDS_TO_WAIT = 5000;
  private ApiURL: string = "/api/ClientStatus";
  constructor(private httpClient: HttpClient) {}
  getClientStatus(): Observable<ClientStatus[]> {
   return timer(0, this.MILI_SECONDS_TO_WAIT).pipe(switchMap(e => this.httpClient.get<ClientStatus[]>(this.ApiURL)));
  }
}
