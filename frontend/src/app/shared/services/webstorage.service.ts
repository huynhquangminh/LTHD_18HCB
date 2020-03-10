import { Injectable } from '@angular/core';
import { LocalStorageService, SessionStorageService } from 'angular-web-storage';


@Injectable()
export class WebStorageSerivce {
    constructor(
        public local: LocalStorageService,
        public session: SessionStorageService

    ) { }

    getLocalStorage(key: string) {
        return this.local.get(key);
    }

    setLocalStorage(key: string, vaule: any) {
        this.local.set(key, vaule);
    }

    removeLocalStorage(key: string) {
        this.local.remove(key);
    }

    clearLocalStorage() {
        this.local.clear();
    }

    getSessionStorage(key: string) {
        return this.session.get(key);
    }

    setSessionStorage(key: string, vaule: any) {
        this.session.set(key, vaule);
    }

    removeSessionStorage(key: string) {
        this.session.remove(key);
    }

    clearSessionStorage() {
        this.session.clear();
    }
}
