import type { CanActivateFn } from '@angular/router';
import { AccountService } from '../services/account.service';
import { inject } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toastrService = inject(ToastrService);
  if (accountService.currentUser()) {
    return true;
  } else {
    toastrService.error('Access denied, sign in please!');
    return false;
  }
};
