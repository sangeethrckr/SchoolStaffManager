import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import {  Staff } from '../models/staff';
import * as myGlobals from '../utils/global';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectorsService {

  constructor(
    private http:HttpClient
  ) { }

  baseUrl = myGlobals.baseUrl;

  

  getStaff(staffType : number) : Observable<Staff[]>{

    switch(staffType){
      case 1:
        return this.http.get<Staff[]>(this.baseUrl + '?staffType=teaching')
        .pipe(
          catchError(this.handleError)
        );
      case 2:
        return this.http.get<Staff[]>(this.baseUrl + '?staffType=admin')
        .pipe(
          catchError(this.handleError)
        );
      case 3:
      return this.http.get<Staff[]>(this.baseUrl + '?staffType=support')
      .pipe(
        catchError(this.handleError)
      );
        
    }

  }

  createStaff(jsonBody : JSON) {
    return this.http.post(this.baseUrl ,jsonBody)
    .pipe(
      catchError(this.handleError)
    );
  }

  updateStaff(staffId: number, jsonBody : JSON){
    return this.http.put(this.baseUrl + '/' + staffId,jsonBody)
    .pipe(
      catchError(this.handleError)
    );
  }

  deleteStaff(staffId: number){
    return this.http.delete(this.baseUrl + '/' + staffId)
    .pipe(
      catchError(this.handleError)
    );
  }

  deleteMultipleStaff(lstStaffId : number[]){
    var appendToUrl = "?";
    lstStaffId.forEach(function(staffId){
      appendToUrl += "ids=" + staffId + "&";
    })
    //console.log(appendToUrl);
    return this.http.delete(this.baseUrl + '/' + appendToUrl)
    .pipe(
      catchError(this.handleError)
    );
  }

  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      
      console.error('An error occurred:', error.error.message);
    } else {
      
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    
    return throwError(
      'Something bad happened; please try again later.');
  }


}
