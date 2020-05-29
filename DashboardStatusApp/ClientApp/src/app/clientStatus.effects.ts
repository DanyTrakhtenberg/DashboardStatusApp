import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { Action } from '@ngrx/store';

import { catchError, map, mergeMap } from 'rxjs/operators';
import { ClientStatusHttpService } from './clientStatus.httpservice';
import * as ClientStatusActions from "./clientStatus.action"
import { Observable, of } from 'rxjs';
import { ClientStatus } from './models/client-status';

@Injectable()
export class ClientStatusEffects {
  constructor(private httpService: ClientStatusHttpService, private action$: Actions) {}

  GetClientStatus$: Observable<Action> = createEffect(() =>
    this.action$.pipe(
      ofType(ClientStatusActions.GetClientStatusAction),
      mergeMap(action =>
        this.httpService.getClientStatus().pipe(
          map((data: ClientStatus[]) => {
            return ClientStatusActions.SuccessGetClientStatusAction({ payload: data });
          }),
          catchError((error: Error) => {
            return of(ClientStatusActions.ErrorGetClientAction(error));
          })
        )
      )
    )
  );

}
