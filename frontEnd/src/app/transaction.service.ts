import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { wallet } from './wallet.service';

export interface transaction {
  transactionId: number;
  walletIdFk: number;
  currencyIdFk: number;
  transactionType: string;
  transactionValue: number;
  transactionTime: Date;
}

@Injectable({
  providedIn: 'root'
})
export class TransactionService {

  apiUrl = 'https://gamestonks.azurewebsites.net/'

  constructor(private http: HttpClient) { }

  GetTransaction(): Observable<transaction[]> {
    return this.http.get<transaction[]>(this.apiUrl + "transaction");
  }

  GetTransactionbyId( id:number): Observable<transaction>
  {
    return this.http.get<transaction>(this.apiUrl + "transaction/" + id) as Observable<transaction>;
  }

  CreateTransaction( trans:transaction): Observable<transaction>
  {
    return this.http.post<transaction>(this.apiUrl + "submit/transaction" , trans);
  }
} 