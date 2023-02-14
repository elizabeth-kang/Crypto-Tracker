import { Component, OnInit } from '@angular/core';
import { transaction, TransactionService } from '../transaction.service';

@Component({
  selector: 'app-transaction-table',
  templateUrl: './transaction-table.component.html',
  styleUrls: ['./transaction-table.component.css']
})
export class TransactionTableComponent implements OnInit {

  transactions: transaction[] = [];

  columnsToDisplay: string[] = ['transactionId', 'walletIdFk', 'currencyIdFk', 'transactionType', 'transactionValue', 'transactionTime'];

  constructor(private transactionService: TransactionService) { 
    this.transactionService.GetTransaction()
      .subscribe(transaction => this.transactions = transaction);
  }

  ngOnInit(): void {
  }

}
