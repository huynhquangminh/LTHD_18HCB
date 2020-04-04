import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CommonService {
  public objTaikhoan = new BehaviorSubject<any>({});

  listChangeTaiKhoanDetail (newData: any) {
    // this.objTaikhoan = newData;
    this.objTaikhoan.next(newData);
  }
}
