import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of , forkJoin} from 'rxjs';

export interface marketData {
  base: string,
  amount: number,
  currency: string,

}
export interface marketData extends Array<marketData>{}

@Injectable({
  providedIn: 'root'
})
export class MarketService {

  constructor(private http: HttpClient) { }


  marketData: Observable<marketData[]>[] = [];

  apiUrl = 'https://api.coinbase.com/v2/prices/'
  // reqArr: string[] = [
  //   this.apiUrl+'BTC-USD/spot',
  //   this.apiUrl+'ETH-USD/spot',
  //   this.apiUrl+'USDT-USD/spot',
  //   this.apiUrl+'USDC-USD/spot',
  //   this.apiUrl+'ETH2-USD/spot',
  //   this.apiUrl+'DOGE-USD/spot',
  //   this.apiUrl+'BUSD-USD/spot',
  //   this.apiUrl+'ADA-USD/spot',
  //   this.apiUrl+'SOL-USD/spot',
  //   this.apiUrl+'DOT-USD/spot'
  //   ]
  coinTypes : string[] = ['BTC', 'ETH', 'USDT', 'USDC', 'ETH2', 'DOGE', 'BUSD', 'ADA', 'SOL', 'DOT'];
  reqArr = this.coinTypes.map((coinType) => this.http.get(this.apiUrl + coinType + '-USD/spot'));
  GetMarketData(): Observable<marketData[]> {
    console.log(this.reqArr);
    return forkJoin(this.reqArr) as Observable<marketData[]>;
    // return this.marketData;

  }
}
