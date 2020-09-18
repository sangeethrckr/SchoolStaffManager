import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

import {  Staff, StaffForm } from './staff';

@Injectable({
  providedIn: 'root'
})
export class ApiConnectorsService {

  constructor(
    private http:HttpClient
  ) { }

  baseUrl = "http://schoolstaff.dev.com/api/staff";

  

  getStaff(staffType : number) : Observable<Staff[]>{

    switch(staffType){
      case 1:
        return this.http.get<Staff[]>(this.baseUrl + '?staffType=teaching');
      case 2:
        return this.http.get<Staff[]>(this.baseUrl + '?staffType=admin');
      case 3:
      return this.http.get<Staff[]>(this.baseUrl + '?staffType=support');
        
    }

  }

  createStaff(jsonBody : StaffForm) : Observable<Staff>{
    return this.http.post< Staff >(this.baseUrl ,jsonBody);
  }

  updateStaff(staffId: number, jsonBody : JSON) : Observable<Staff>{
    return this.http.put< Staff >(this.baseUrl + '/' + staffId,jsonBody);
  }


}
