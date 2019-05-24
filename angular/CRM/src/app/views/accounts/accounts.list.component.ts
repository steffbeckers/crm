import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { Account } from 'src/app/vos/account/account';

@Component({
  templateUrl: './accounts.list.component.html',
  styleUrls: ['./accounts.list.component.scss'],
})
/**
 * List view.
 */
export class AccountsListComponent implements OnInit {
  /**
   * View bound variable.
   */
  list: Account[];

  /**
   * Component constructor and DI injection point.
   * @param {ActivatedRoute} route
   */
  constructor(private route: ActivatedRoute) {}

  /**
   * Called part of the component lifecycle. Best first
   * place to start adding your code.
   */
  ngOnInit() {
    this.list = this.route.snapshot.data['accounts'];
  }
}
