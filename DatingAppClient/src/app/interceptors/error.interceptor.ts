import type { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { NavigationExtras, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { catchError, switchScan } from 'rxjs';

export const errorInterceptor: HttpInterceptorFn = (req, next) => {
  const toastrService = inject(ToastrService);
  const routerService = inject(Router);
  return next(req).pipe(
    catchError(error => {
      if (error) {
        switch (error.status) {
          case 400:
            if (error.error.errors) {
              const allErrors = [];
              for (const key in error.error.errors) {
                const currentError = error.error.errors[key];
                if (currentError) {
                  allErrors.push(currentError);
                }
              }
              const flatErrors = allErrors.flat();
              throw flatErrors;
            }
            toastrService.error(error.error, error.status);
            break;

          case 401:
            toastrService.error('Unauthorised', error.status);
            break;

          case 404:
            routerService.navigateByUrl('/not-found');
            break;

          case 500:
            const extras: NavigationExtras = { state: { error: error.error } };
            routerService.navigateByUrl('/server-error', extras);
            break;

          default:
            toastrService.error('Something unexpected went wrong');
            break;
        }
      }
      throw error;
    })
  );
};
