import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { AngularWebStorageModule } from 'angular-web-storage';
import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MatTableModule } from '@angular/material/table';

import { TransactionComponentComponent } from './transaction-component/transaction-component.component';
import { WalletsComponent } from './wallets/wallets.component';

import { DashBoardComponent } from './dash-board/dash-board.component';
import { NavBardComponent } from './nav-bard/nav-bard.component';
import { ProfileComponent } from './profile/profile.component';
import { TransactionTableComponent } from './transaction-table/transaction-table.component';
import { MarketComponent } from './market/market.component';
import { LoginComponent } from './login/login.component';
import { LeaderboardComponent } from './leaderboard/leaderboard.component';
import { Scroll } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    TransactionComponentComponent,
    WalletsComponent,
    DashBoardComponent,
    NavBardComponent,
    ProfileComponent,
    TransactionTableComponent,
    MarketComponent,
    LoginComponent,
    LeaderboardComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    AngularWebStorageModule,
    BrowserAnimationsModule,
    MatTableModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }