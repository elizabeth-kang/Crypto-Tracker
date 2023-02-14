import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

  export interface wallet {
    walletId: number;
    userIdFk: number;
    currencyIdFk: number;
    amountCurrency: number;
  }

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  constructor(private http: HttpClient) { }

  GetWallets(): Observable<wallet[]> {
    return this.http.get<wallet[]>(this.apiUrl + "wallet");
  }

  GetWalletById(id: number): Observable<wallet> {
    return this.http.get<wallet>(this.apiUrl + "wallet/" + id);
  }

  WalletCreate(wallet: wallet): Observable<wallet> {
    return this.http.post<wallet>(this.apiUrl + "create/wallet", wallet)
  }

  UpdateWalletBalance(walletId: number, balance: number): void {
    let getWallet!: wallet;

    this.GetWalletById(walletId).subscribe(wallet => getWallet = wallet);

    getWallet.amountCurrency = getWallet.amountCurrency - balance;
    
    this.http.post<wallet>(this.apiUrl + "create/wallet/", getWallet);
  }

}
