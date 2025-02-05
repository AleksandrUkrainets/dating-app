import { ChangeDetectionStrategy, Component, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../services/account.service';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav-bar',
  imports: [FormsModule, BsDropdownModule],
  templateUrl: './nav-bar.component.html',
  styleUrl: './nav-bar.component.css',
  changeDetection: ChangeDetectionStrategy.OnPush,
  standalone: true,
})
export class NavBarComponent {
  accountService = inject(AccountService);
  model: any = {};

  signin(): void {
    this.accountService.signin(this.model).subscribe({
      next: response => {
        console.log(response);
      },
      error: er => console.log(er),
    });
  }

  signout(): void {
    this.accountService.signout();
  }
}
