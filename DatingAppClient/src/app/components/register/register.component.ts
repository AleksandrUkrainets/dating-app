import { Component, inject, Input, output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { User } from '../../models/user';
import { AccountService } from '../../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  standalone: true,
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  accountService = inject(AccountService);
  model: any = {};
  cancelRegister = output<boolean>();
  private toastrService = inject(ToastrService);

  register(): void {
    this.accountService.signup(this.model).subscribe({
      next: response => {
        console.log(response);
        this.cancel();
      },
      error: error => this.toastrService.error(error.error),
    });
  }

  cancel(): void {
    this.cancelRegister.emit(false);
  }
}
