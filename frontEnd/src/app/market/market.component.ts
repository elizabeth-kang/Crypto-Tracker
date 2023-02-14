import { Component, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { marketData, MarketService } from '../market.service';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.css'],
  animations: [
  trigger('detailExpand', [
    state('collapsed', style({height: '0px', minHeight: '0'})),
    state('expanded', style({height: '*'})),
    transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class MarketComponent implements OnInit {

  marketDatas: marketData[] = [];
  columnsToDisplay: string[] = ['base', 'currency', 'amount'];
  columnsToDisplayi: string[] = ['CryptoCurrency', 'Fiat Currency', 'amount'];

  expandedData!: marketData;

  obj: marketData[] = {} as marketData

  constructor(private marketDataService: MarketService) { 
  }
  priceFetcher(): void{
    this.marketDataService.GetMarketData()
      .subscribe((marketData: marketData[]) => 
      {
        this.marketDatas = marketData
      }
      );
  }
  timedCount() {
    setInterval(() => this.priceFetcher(), 30000);
  }
  ngOnInit(): void {
    this.timedCount();
    this.priceFetcher();
  }

}
