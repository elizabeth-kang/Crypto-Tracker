import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { transaction, TransactionService } from '../transaction.service';
import { LocalStorageService, SessionStorageService, LocalStorage, SessionStorage } from 'angular-web-storage';

@Component({
  selector: 'app-transaction-component',
  templateUrl: './transaction-component.component.html',
  styleUrls: ['./transaction-component.component.css']
})
export class TransactionComponentComponent implements OnInit {
  constructor(private api:TransactionService, private local: LocalStorageService, private session: SessionStorageService) { }
  ngOnInit(): void {
    
  }

  newTrans:transaction = 
  {
    transactionId: 0,
    walletIdFk: 0,
    currencyIdFk: 0,
    transactionType: "",
    transactionValue: 0,
    transactionTime: new Date
  }

  currentUser:any = "";
  walletId:number = 1;
  type:string = "";
  amount:number = 0;

  selectedCrypto = "BTC";

  selectedCurrency(value:string): void{
    this.selectedCrypto = value;
  }

  cryptoConverttoId(value:string): number{
    console.log(value);
    switch(value)
    {
      
      case 'ETH': {return 2};
      case 'USDT': {return 3};
      case 'USDC': {return 4};
      case 'ETH2': {return 5};
      case 'DOGE': {return 6};
      case 'BUSD': {return 7};
      case 'ADA': {return 8};
      case 'SOL': {return 9};
      case 'DOT': {return 10};
      default:{break;}
    }
    return 1;
  }
  
  buyCrypto(buy:string)
  {
    this.newTrans.transactionType = "buy";
    this.newTrans.currencyIdFk = this.cryptoConverttoId(this.selectedCrypto);
    if(this.currentUser.UserId)
    {
      this.api.CreateTransaction(this.newTrans);
    }
  }

  sellCrypto(sell:string)
  {
    this.newTrans.transactionType = "sell";
    this.newTrans.currencyIdFk = this.cryptoConverttoId(this.selectedCrypto);
    if(this.currentUser.UserId)
    {
      this.api.CreateTransaction(this.newTrans);
    }
  }

  currencyData:any

  apicall() {
    
    // let fiatelem = document.getElementById('fiat');
    // let fiatInput = fiatelem.value;
    // let cryptoelem = document.getElementById('crypto');
    // let cryptotInput = cryptoelem.value;
    if(document)
    {
      fetch('https://api.coinbase.com/v2/prices/' + this.selectedCrypto + '-USD/spot')
    .then((response) => response.json()).then((resBody) => {
      console.log(resBody)
        this.currencyData = resBody;
        // <HTMLSelectElement>document.querySelector('#result-fiat').innerText = resBody.data.currency;
        //<HTMLSelectElement>document.querySelector('#result-crypt').innerText = resBody.data.base;
        //<HTMLSelectElement>document.querySelector('#result-amount').innerText = resBody.data.amount;
      });
    }
  
  

  }
}