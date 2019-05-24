import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

@Component({
  templateUrl: './account.details.component.html',
  styleUrls: ['./account.details.component.scss'],
})
/**
 * Show details view.
 */
export class AccountComponent implements OnInit {
  /**
   * View bound variable.
   */
  selectedAccount: Account;

  /**
   * Component constructor and DI injection point.
   * @param {ActivatedRoute} route
   * @param {Router} router
   * @param {AccountsService} service
   */
  constructor(private route: ActivatedRoute, private router: Router, private service: AccountsService) {}

  /**
   * Called part of the component lifecycle. Best first
   * place to start adding your code.
   */
  ngOnInit() {
    this.selectedAccount = this.route.snapshot.data['account'];
  }

  /**
   * Responds to the destroy request.
   */
  onDestroy() {
    const router = this.router;
    this.service.destroy(this.selectedAccount.id).subscribe(function(result) {
      router.navigate(['/accounts']);
    });
  }
}
