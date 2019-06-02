import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest, HttpEvent, HttpResponse } from '@angular/common/http';

// RxJS
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

import Logger from 'app/helpers/logger';

@Injectable({ providedIn: 'root' })
export class LogInterceptor implements HttpInterceptor {
  constructor(private logger: Logger) {}

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const started = Date.now();

    return next.handle(req).pipe(
      tap((event) => {
        if (event instanceof HttpResponse) {
          const elapsed = Date.now() - started;
          this.logger.log(`${req.method.toUpperCase()} ${req.urlWithParams} ${event.status} ${elapsed}ms`);
          if (event.body) {
            this.logger.log(event.body);
          }
        }
      })
    );
  }
}
