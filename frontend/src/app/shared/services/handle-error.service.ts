import { empty, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { HttpStatusCode } from '../globlas/enums';
import { DialogServiceService } from './dialog-service.service';

@Injectable({
  providedIn: 'root'
})
export class HandleErrorService {

  constructor(private dialogServiceService: DialogServiceService) {
    this.handleError = this.handleError.bind(this);
    this.handleError = this.extractData.bind(this);
  }

  public extractData(res: any) {
    if (res.status !== HttpStatusCode.OK) {
      return this.checkServerError(res);
    }
    // Parse response data to json
    try {
      const body = res.body;
      return body || {};

    } catch (error) {
      this.dialogServiceService.showDialogError('message error');
      return empty();
    }

  }

  public checkServerError(res: HttpErrorResponse | any) {
    const statusCode = res.status;

    if (!statusCode) {
      return empty();
    }

    switch (statusCode) {
      // Bad gate way status
      case HttpStatusCode.BadGateway:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        // this.showDialogError(`${ERRORS.SERVER_ERROR}<br>CODE: ${statusCode}`);
        break;
      // Internal server error
      case HttpStatusCode.InternalServerError:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        break;
      // Not found
      case HttpStatusCode.NotFound:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        break;
      // Service unavailable
      case HttpStatusCode.ServiceUnavailable:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        break;
      // Client error
      case HttpStatusCode.Forbidden:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        break;
      // Bad request
      case HttpStatusCode.BadRequest:
        this.dialogServiceService.showDialogError(`message error code: ${statusCode}`);
        break;
      default:
        // Unexpected error
        this.dialogServiceService.showDialogError(`message error`);
        break;
    }
    return empty();
  }


  public handleError(error) {
    this.dialogServiceService.showDialogError(`message error`);
    return throwError(error);
  }
}
