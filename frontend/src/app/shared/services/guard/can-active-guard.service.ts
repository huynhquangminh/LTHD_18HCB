import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../auth.service';
import { WebStorageSerivce } from '../webstorage.service';
import { WebKeyStorage } from '../../globlas/web-key-storage';

@Injectable({
  providedIn: 'root'
})
export class CanActiveGuardService implements CanActivate {

  constructor(
    private authService: AuthService,
    private router: Router,
    private webStorageSerivce: WebStorageSerivce
  ) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean {
    const userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info)
    if (userInfo && userInfo.isLogin) {
      return true;
    } else {
      this.router.navigate(['/login']);
    }
    return false;
  }
}
