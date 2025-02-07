import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  standalone: true,
  selector: 'app-server-error',
  imports: [],
  templateUrl: './server-error.component.html',
  styleUrl: './server-error.component.css',
})
export class ServerErrorComponent {
  error: any;

  constructor(private router: Router) {
    const currentNavigation = router.getCurrentNavigation();
    const extras = currentNavigation?.extras;
    this.error = extras?.state?.['error'];
  }
}
