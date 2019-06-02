// tslint:disable: no-console
// tslint:disable: typedef

import { Injectable } from '@angular/core';
import { environment } from 'environments/environment';

@Injectable({
  providedIn: 'root',
})
export default class Logger {
  debug = localStorage.getItem('debug') || !environment.production;

  log(...args) {
    if (this.debug) {
      console.log.apply(console, JSON.parse(JSON.stringify(args)));
    }
  }

  info(...args) {
    if (this.debug) {
      console.info.apply(console, args);
    }
  }

  error(...args) {
    if (this.debug) {
      console.error.apply(console, args);
    }
  }

  count(arg) {
    if (this.debug) {
      console.count(arg);
    }
  }

  group(arg) {
    if (this.debug) {
      console.count(arg);
    }
  }

  groupEnd() {
    if (this.debug) {
      console.groupEnd();
    }
  }

  profile(arg) {
    if (this.debug) {
      console.count(arg);
    }
  }

  profileEnd() {
    if (this.debug) {
      console.profileEnd();
    }
  }

  time(arg) {
    if (this.debug) {
      console.time(arg);
    }
  }

  timeEnd(arg) {
    if (this.debug) {
      console.timeEnd(arg);
    }
  }
}
