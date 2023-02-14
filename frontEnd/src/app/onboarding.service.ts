import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { WalletService, wallet } from './wallet.service';

@Injectable({
  providedIn: 'root'
})
export class OnboardingService {

  constructor(private http: HttpClient, private walletService: WalletService) { }

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  userId: number = 1; //need to get user

  WalletCreateOnboarding(): boolean {
    let wallets: {
      userIdFk: number,
      currencyIdFk: number,
      amountCurrency: number }[] = [
        { "userIdFk": this.userId, "currencyIdFk": 1, "amountCurrency": 0 }, //
        { "userIdFk": this.userId, "currencyIdFk": 2, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 3, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 4, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 5, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 6, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 7, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 8, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 9, "amountCurrency": 0 },
        { "userIdFk": this.userId, "currencyIdFk": 10, "amountCurrency": 0 },
    ];
    
    for (let i: number = 0; i < 10; i++) {
      this.http.post<wallet>(this.apiUrl + "create/wallet/", wallets[i])
    }

    return true;
  }
}
