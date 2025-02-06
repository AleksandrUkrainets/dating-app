import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { Router, RouterLink, RouterLinkActive } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TitleCasePipe } from '@angular/common';

@Component({
  selector: 'app-nav-bar',
  imports: [FormsModule, BsDropdownModule, RouterLink, RouterLinkActive, TitleCasePipe],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
})
export class NavBarComponent {
  accountService = inject(AccountService);
  private router = inject(Router);
  private toastrService = inject(ToastrService);
  model: any = {};

  signin(): void {
    this.accountService.signin(this.model).subscribe({
      next: _ => {
        this.router.navigateByUrl('/members');
      },
      error: er => this.toastrService.error(er.error),
    });
  }

  signout(): void {
    this.accountService.signout();
    this.router.navigateByUrl('/');
  }
}
