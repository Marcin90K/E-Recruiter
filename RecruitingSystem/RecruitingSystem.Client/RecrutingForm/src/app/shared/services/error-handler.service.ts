import { Injectable } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ErrorHandlerService {

  constructor() { }

  handleHTTPError(operation: string, httpError: HttpErrorResponse) {
    console.log('The operation: ' + operation +
    ' has returned an error message: ' + httpError.message +
    ' with status: ' + httpError.status);
  }
}
