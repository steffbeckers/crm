import { Component, OnInit, Input } from '@angular/core';
import { Router } from '@angular/router';

import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

@Component({
  templateUrl: './account.new.component.html',
  styleUrls: ['./account.new.component.scss'],
})
/**
 * Create form view.
 */
export class NewAccountComponent implements OnInit {
  /**
   * Input binding for object.
   */
  @Input() selectedAccount: Account;

  /**
   * Component constructor and DI injection point.
   * @param {Router} router
   
   * @param {AccountsService} service
   */
  constructor(
    private router: Router,

    private service: AccountsService
  ) {}

  /**
   * Called part of the component lifecycle. Best first
   * place to start adding your code.
   */
  ngOnInit() {
    this.selectedAccount = new Account();
  }

  /**
   * Responds to submitting the form.
   */
  onSubmit() {
    const router = this.router;
    this.service.create(this.selectedAccount).subscribe(function(result) {
      router.navigate(['/accounts']);
    });
  }
}
