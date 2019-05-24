import { Component, OnInit, Input } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

import { Account } from 'src/app/vos/account/account';
import { AccountsService } from 'src/app/services/accounts/accounts.service';

@Component({
  templateUrl: './account.edit.component.html',
  styleUrls: ['./account.edit.component.scss'],
})
export class EditAccountComponent implements OnInit {
  /**
   * Input binding for object.
   */
  @Input() selectedAccount: Account;

  /**
   * Component constructor and DI injection point.
   * @param {ActivatedRoute} route
   * @param {Router} router
   
   * @param {AccountsService} service
   */
  constructor(
    private route: ActivatedRoute,
    private router: Router,

    private service: AccountsService
  ) {}

  /**
   * Called part of the component lifecycle. Best first
   * place to start adding your code.
   */
  ngOnInit() {
    this.selectedAccount = this.route.snapshot.data['account'];
  }

  /**
   * Responds to submitting the form.
   */
  onSubmit() {
    this.service.update(this.selectedAccount).subscribe((result) => {
      this.router.navigate(['/accounts']);
    });
  }
}
