import { Component, OnInit } from '@angular/core';
import {animate, state, style, transition, trigger} from '@angular/animations';
import { wallet, WalletService } from '../wallet.service';

@Component({
  selector: 'app-wallets',
  templateUrl: './wallets.component.html',
  styleUrls: ['./wallets.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class WalletsComponent implements OnInit {

  wallets: wallet[] = [];

  columnsToDisplay: string[] = ['walletId', 'userIdFk', 'currencyIdFk', 'amountCurrency'];

  expandedWallet!: wallet;

  constructor(private walletService: WalletService) { 
    this.walletService.GetWallets()
      .subscribe(wallet => this.wallets = wallet);
  }

  ngOnInit(): void {
  }

}
