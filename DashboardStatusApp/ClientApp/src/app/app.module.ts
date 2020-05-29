import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ClientStatusComponent } from './client-status/client-status.component';
import { ClientStatusReducer } from './clientStatus.reducer';
import { ClientStatusEffects } from './clientStatus.effects';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { StatusDashboardComponent } from './status-dashboard/status-dashboard.component';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatCardModule} from '@angular/material/card';
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientStatusComponent,
    StatusDashboardComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatCardModule,
    MatGridListModule,
    StoreModule.forRoot({ clientsStatus: ClientStatusReducer }),
    EffectsModule.forRoot([ClientStatusEffects]),
    RouterModule.forRoot([
      { path: '', component: StatusDashboardComponent, pathMatch: 'full' }

    ]),
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
